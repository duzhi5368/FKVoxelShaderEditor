//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    Shader编辑窗口
//-------------------------------------------------
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;
using ScintillaNET;
using System.Drawing;
using System.Text;
using FKVoxelEngine;
using System.IO;
using System.ComponentModel;
using TwoMGFX;
using System.Diagnostics;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public partial class ShaderToyForm : Form
    {
        #region ======== WIN32 API ========

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion ======== WIN32 API ========

        #region ======== 成员变量 ========

        private Scintilla       m_EditorScintillaCtrl;
        private MruStripMenu    m_MruMenu;
        private string          m_strCurrentEffectFile;
        private string          m_2MGFXExeName;
        private string          m_2MGFXPath;

        #endregion ======== 成员变量 ========

        public ShaderToyForm()
        {
            InitializeComponent();
        }

        #region ======== 基本框架 ========

        // 截获处理热键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F3)
            {
                this.Hide();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        // 隐藏窗口
        private void CloseShaderCompileWndButton_Click(object sender, System.EventArgs e)
        {
            m_MruMenu.SaveToRegistry();
            this.Hide();
        }
        // 拖拽窗口标题
        private void ShaderToyFormTitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //this.Location = new System.Drawing.Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // 窗口关闭前执行
        protected override void OnClosing(CancelEventArgs e)
        {
            m_MruMenu.SaveToRegistry();
            base.OnClosing(e);
        }

        #endregion ======== 基本框架 ========

        #region ======== 控件消息 ========

        /// <summary>
        /// Form加载初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShaderToyForm_Load(object sender, EventArgs e)
        {
            InitEditorScintillaCtrl();

            // 检查2MGFX
            {
                m_2MGFXExeName = "2MGFX.exe";
                // 默认和exe同路径
                m_2MGFXPath = string.Empty;
                // 或者使用一个相对路径
                if (Directory.Exists(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "2MGFX")))
                    m_2MGFXPath = "2MGFX";
                if (!File.Exists(System.IO.Path.Combine(m_2MGFXPath, m_2MGFXExeName)))
                {
                    MessageBox.Show("2MGFX.exe 文件不存在...", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // MRU记录最近编辑的文件
            m_MruMenu = new MruStripMenuInline(fileToolStripMenuItem, recentFilesToolStripMenuItem,
                new MruStripMenu.ClickedHandler(OnMruFile), Consts.MyAppRegKey + "\\MRU", 16);
            m_MruMenu.LoadFromRegistry();

            // 加载一个默认纹理
            TextureSlotsUserControl.SetTextureSlot(0, "Content\\Texture\\DefaultTexture.jpg");
            // 加载默认特效
            using (var stream = File.OpenText("Content\\ShaderSrc\\DefaultSimpleColorShader.fx"))
            {
                var shader = stream.ReadToEnd();
                m_EditorScintillaCtrl.Text = shader;
                m_EditorScintillaCtrl.SetSavePoint();

                DoBuild(shader);
            }
            // 加载帮助
            webBrowserHelp.Navigate(Path.Combine(Environment.CurrentDirectory, "Content\\Config\\HLSLHelp.html"));
        }
        /// <summary>
        /// 按下 编译Shader 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildShaderF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoBuild(m_EditorScintillaCtrl.Text);
        }
        /// <summary>
        /// 新建脚本 按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            if (m_EditorScintillaCtrl.Modified == true)
            {
                var ret = MessageBox.Show("当前文件已修改，是否先进行保存?", this.Text, MessageBoxButtons.YesNoCancel);
                if (ret == System.Windows.Forms.DialogResult.Cancel)
                    return;

                if (ret == System.Windows.Forms.DialogResult.Yes)
                {
                    saveToolStripMenuItemSave_Click(sender, e);
                }
            }

            SetCurrentEffectFileName(null);

            // 重置为默认脚本
            using (var stream = File.OpenText("Content\\ShaderSrc\\DefaultSimpleColorShader.fx"))
            {
                var shader = stream.ReadToEnd();
                m_EditorScintillaCtrl.Text = shader;
                m_EditorScintillaCtrl.SetSavePoint();

                DoBuild(shader);
            }
        }
        /// <summary>
        /// 保存脚本 按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_strCurrentEffectFile) == true)
            {
                saveAsToolStripMenuItemSaveAs_Click(sender, e);
                return;
            }

            try
            {
                using (var stream = File.CreateText(m_strCurrentEffectFile))
                {
                    stream.Write(m_EditorScintillaCtrl.Text);
                    m_EditorScintillaCtrl.SetSavePoint();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("错误: 无法向系統写入文件: " + ex.Message);
            }
        }
        /// <summary>
        /// 加载脚本 按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItemLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadFXOpenFileDialog1 = new OpenFileDialog();

            LoadFXOpenFileDialog1.Filter = "effect files (*.fx)|*.fx|All files (*.*)|*.*";
            LoadFXOpenFileDialog1.RestoreDirectory = true;

            if (LoadFXOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadEffectFile(LoadFXOpenFileDialog1.FileName);
            }
        }
        /// <summary>
        /// 另存为 按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "effect files (*.fx)|*.fx|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = File.CreateText(saveFileDialog1.FileName))
                    {
                        stream.Write(m_EditorScintillaCtrl.Text);
                        m_EditorScintillaCtrl.SetSavePoint();

                        SetCurrentEffectFileName(saveFileDialog1.FileName);

                        m_MruMenu.AddFile(saveFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误: 无法向系統写入文件: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// 退出 按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            m_MruMenu.SaveToRegistry();
            this.Hide();
        }

        #endregion ======== 控件消息 ========

        #region ======== 核心函数 ========
       
        /// <summary>
        /// 初始化编辑器文本处理器
        /// </summary>
        private void InitEditorScintillaCtrl()
        {
            m_EditorScintillaCtrl = new Scintilla();
            m_EditorScintillaCtrl.Parent = EditorPanel;
            m_EditorScintillaCtrl.Dock = DockStyle.Fill;
            m_EditorScintillaCtrl.Margins[0].Width = 16;
            m_EditorScintillaCtrl.TabWidth = 2;

            m_EditorScintillaCtrl.StyleResetDefault();
            m_EditorScintillaCtrl.Styles[Style.Default].Font = "Consolas";
            m_EditorScintillaCtrl.Styles[Style.Default].Size = 10;
            m_EditorScintillaCtrl.Styles[Style.Default].BackColor = Color.FromArgb(219, 227, 227);
            m_EditorScintillaCtrl.StyleClearAll();

            m_EditorScintillaCtrl.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            m_EditorScintillaCtrl.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            m_EditorScintillaCtrl.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            m_EditorScintillaCtrl.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            m_EditorScintillaCtrl.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            m_EditorScintillaCtrl.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            m_EditorScintillaCtrl.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            m_EditorScintillaCtrl.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            m_EditorScintillaCtrl.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            m_EditorScintillaCtrl.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            m_EditorScintillaCtrl.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            m_EditorScintillaCtrl.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            m_EditorScintillaCtrl.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

            m_EditorScintillaCtrl.Lexer = Lexer.Cpp;

            // 添加 HLSL 关键字
            StringBuilder sb = new StringBuilder();
            var map = new EnumMap<ENUM_ShaderTokenType>();
            map.Load("Content\\Config\\HLSLKeywords.map");
            foreach (var kw in map)
            {
                var str = kw.Key + " ";

                if (str[0] == ':')
                    str = str.Substring(1);

                sb.Append(str);
            }
            m_EditorScintillaCtrl.SetKeywords(0, sb.ToString());
        }
        /// <summary>
        /// Mru加载文件回调
        /// </summary>
        /// <param name="number"></param>
        /// <param name="filename"></param>
        private void OnMruFile(int number, String filename)
        {
            if (LoadEffectFile(filename) == false)
            {
                m_MruMenu.RemoveFile(filename);
            }
            else
            {
                m_MruMenu.SetFirstFile(number);
            }
        }
        /// <summary>
        /// 加载指定 .fx 格式特效文件
        /// </summary>
        /// <param name="_strFileName"></param>
        /// <returns></returns>
        private bool LoadEffectFile(string _strFileName)
        {
            try
            {
                using (var stream = File.OpenText(_strFileName))
                {
                    var shader = stream.ReadToEnd();
                    m_EditorScintillaCtrl.Text = shader;
                    m_EditorScintillaCtrl.SetSavePoint();

                    // 记录
                    SetCurrentEffectFileName(_strFileName);
                    // 执行编译
                    DoBuild(shader);
                    // 记录
                    m_MruMenu.AddFile(_strFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误: 无法从系统中正确加载文件: " + ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// 记录当前使用的 .fx 特效文件
        /// </summary>
        /// <param name="_strFxName"></param>
        private void SetCurrentEffectFileName(string _strFxName)
        {
            m_strCurrentEffectFile = _strFxName;
            ShaderToyFormTitleLabel.Text = string.Format("Shader特效编辑器 - {0}", m_strCurrentEffectFile);
        }
        /// <summary>
        /// 更新参数列表UI
        /// </summary>
        /// <param name="strShaderSource"></param>
        private void CreateUIParameters(string strShaderSource)
        {
            Program.s_GameInstance.ShaderParameters.Clear();

            UIBaseParam.ENUM_UIBaseParamType paramType = UIBaseParam.ENUM_UIBaseParamType.eUnknow;
            int idxStart = 0;
            int idxSource = 0;

            // 第一轮查找Float
            while (idxSource != -1)
            {
                paramType = UIBaseParam.ENUM_UIBaseParamType.eUnknow;

                //Get FloatParam
                idxStart = strShaderSource.IndexOf("FloatParam", idxSource);
                if (idxStart != -1)
                {
                    paramType = UIBaseParam.ENUM_UIBaseParamType.eFloat;
                }

                if (paramType == UIBaseParam.ENUM_UIBaseParamType.eUnknow)
                {
                    break;
                }

                // 找到行尾
                int idxEnd = strShaderSource.IndexOf("\n", idxStart);
                if (idxEnd == -1)
                    break;

                idxSource = idxEnd;

                // 获取本行
                var line = strShaderSource.Substring(idxStart, idxEnd - idxStart);

                //Inputs Part
                idxStart = line.IndexOf("(");
                if (idxStart == -1)
                    break;

                idxEnd = line.IndexOf(")");
                if (idxEnd == -1)
                    break;

                var inputs = line.Substring(idxStart + 1, idxEnd - idxStart - 1);
                inputs = inputs.Replace(" ", "");

                //Egal Part
                idxStart = line.IndexOf("=");
                if (idxStart == -1)
                    break;

                //Value Part
                var value = line.Substring(idxStart + 1);
                value = value.Replace(" ", "");

                //Add Param
                if (paramType == UIBaseParam.ENUM_UIBaseParamType.eFloat)
                {
                    UIFloatParam p = UIFloatParam.FromString(inputs, value);
                    if (p != null)
                    {
                        Program.s_GameInstance.ShaderParameters.Add(p);
                    }
                }
            };

            // 第二轮，找Texture2D
            paramType = UIBaseParam.ENUM_UIBaseParamType.eUnknow;
            idxStart = 0;
            idxSource = 0;

            while (idxSource != -1)
            {
                paramType = UIBaseParam.ENUM_UIBaseParamType.eUnknow;

                idxStart = strShaderSource.IndexOf("Texture2DParam", idxSource);
                if (idxStart != -1)
                {
                    paramType = UIBaseParam.ENUM_UIBaseParamType.Texture2D;
                }

                if (paramType == UIBaseParam.ENUM_UIBaseParamType.eUnknow)
                {
                    break;
                }

                // 找到行尾
                int idxEnd = strShaderSource.IndexOf("\n", idxStart);
                if (idxEnd == -1)
                    break;

                //Update for next line
                idxSource = idxEnd;

                // 获取本行
                var line = strShaderSource.Substring(idxStart, idxEnd - idxStart);

                //Inputs Part
                idxStart = line.IndexOf("(");
                if (idxStart == -1)
                    break;

                idxEnd = line.IndexOf(")");
                if (idxEnd == -1)
                    break;

                var inputs = line.Substring(idxStart + 1, idxEnd - idxStart - 1);
                inputs = inputs.Replace(" ", "");

                //Egal Part
                idxStart = line.IndexOf("=");
                if (idxStart == -1)
                    break;

                //Value Part
                var value = line.Substring(idxStart + 1);
                value = value.Replace(" ", "");

                //Add Param
                if (paramType == UIBaseParam.ENUM_UIBaseParamType.Texture2D)
                {
                    UITexture2DParam p = UITexture2DParam.FromString(inputs, value);
                    if (p != null)
                    {
                        Program.s_GameInstance.ShaderParameters.Add(p);
                    }
                }
            };

            // 更新UI显示
            ShaderParametersUserControl.DisplayParameters(Program.s_GameInstance.ShaderParameters);
        }
        /// <summary>
        /// 编译Shader
        /// </summary>
        /// <param name="strShader"></param>
        private bool DoBuild(string strShaderSource)
        {
            // 更新参数列表的UI显示
            CreateUIParameters(strShaderSource);

            // 清空输出框
            OutputClear();

            // 清除历史数据
            string strTempFXFileName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Content\\tmp.fx";
            string strMGFXOFileName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Content\\tmp.dx11.mgfxo";
            File.Delete(strTempFXFileName);
            File.Delete(strMGFXOFileName);

            // 保存临时文件
            try
            {
                using (var stream = File.CreateText(strTempFXFileName))
                {
                    stream.Write(m_EditorScintillaCtrl.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误: 无法向系統写入文件: " + ex.Message);
                return false;
            }

            // 外部转义MGFX
            if (strTempFXFileName.Contains(".fx"))
            {
                Process process = new Process();
                process.StartInfo.Arguments = GetCommandArgs(strTempFXFileName);
                process.StartInfo.WorkingDirectory = m_2MGFXPath;
                process.StartInfo.FileName = m_2MGFXExeName;
                process.Start();

                // 等待进程结束，希望10秒内处理完毕
                process.WaitForExit(10000);
                process.Close();
            }
            else
            {
                MessageBox.Show("该文件不是有效的 .fx 特效文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(strMGFXOFileName))
            {
                MessageBox.Show("Shader 编译失败，可能 shader 编写有错误，请检查", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 创建特效对象
            try
            {
                byte[] bytecode = File.ReadAllBytes(strMGFXOFileName);
                Program.s_GameInstance.SetEffectBytesCode(bytecode);
            }
            catch
            {
                MessageBox.Show("加载 .mgfxo 文件失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            OutputAppend("Shader 编译完成!");
            /*
            // 内部转义MGFX
            var options = new Options();
            ShaderInfo shaderInfo;
            try
            {
                options.Debug = true;
                options.Profile = ShaderProfile.DirectX_11; // todo
                options.SourceFile = string.Empty;
                options.OutputFile = string.Empty;

                var strAppPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                shaderInfo = ShaderInfo.FromString(strShaderSource, strAppPath, options, this);
            }
            catch (Exception ex)
            {
                OutputAppend(ex.Message);
                OutputAppend("解析FX文件失败 !");
                return false;
            }

            OutputAppend("FX 文件解析完毕!");

            // 创建特效对象
            EffectObject effect;
            var shaderErrorsAndWarnings = string.Empty;
            try
            {
                effect = EffectObject.CompileEffect(shaderInfo, out shaderErrorsAndWarnings);

                if (!string.IsNullOrEmpty(shaderErrorsAndWarnings))
                    OutputAppend(shaderErrorsAndWarnings);
            }
            catch (ShaderCompilerException)
            {
                OutputAppend(shaderErrorsAndWarnings);
                OutputAppend("编译Shader失败 !");
                return false;
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(shaderErrorsAndWarnings))
                    OutputAppend(shaderErrorsAndWarnings);
                if (!string.IsNullOrEmpty(ex.Message))
                    OutputAppend(ex.Message);
                OutputAppend("编译Shader异常 !");
                return false;
            }

            OutputAppend("Shader 编译完成!");

            // 创建特效对象
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(stream);
                effect.Write(bw, options);

                byte[] bytecode = stream.ToArray();
                Program.s_GameInstance.SetEffectBytesCode(bytecode);
            }
            */
            return true;
        }
        /// <summary>
        /// 调用exe的参数
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string GetCommandArgs(string filePath)
        {
            string profile = string.Empty;
            string extra = " /Profile:";
            profile = "dx11";
            extra += "DirectX_11";
            //profile = "ogl";
            //extra += "OpenGL";
            string mgsExt = string.Format("{0}.mgfxo", profile);
            string newFilePath = filePath.Replace("fx", mgsExt);

            return filePath + " " + newFilePath + extra;
        }

        #endregion ======== 核心函数 ========

        #region ======== 辅助函数 ========

        public void WriteWarning(string file, int line, int column, string message)
        {
            OutputAppend(string.Format("警告: ({0},{1}): {2}", line, column, message));
        }
        public void WriteError(string file, int line, int column, string message)
        {
            OutputAppend(string.Format("错误: ({0},{1}): {2}", line, column, message));
        }
        void OutputClear()
        {
            LogOutputWnd.Clear();
        }
        void OutputAppend(string text)
        {
            if (text == null)
                return;

            var lines = text.Split('\n');

            foreach (var line in lines)
            {
                var fullline = string.Format("{0} {1}{2}", DateTime.Now.ToLongTimeString(), line, Environment.NewLine);

                if (InvokeRequired)
                    LogOutputWnd.Invoke(new Action<string>(LogOutputWnd.AppendText), new object[] { fullline });
                else
                    LogOutputWnd.AppendText(fullline);
            }

        }

        #endregion ======== 辅助函数 ========
    }
}
