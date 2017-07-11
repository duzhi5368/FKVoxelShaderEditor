//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    Shader编译窗口
//-------------------------------------------------
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public partial class ShaderCompileForm : Form
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

        private string m_2MGFXExeName;
        private string m_2MGFXPath;

        #endregion ======== 成员变量 ========

        public ShaderCompileForm()
        {
            InitializeComponent();
        }
        // 初始化
        private void ShaderCompileForm_Load(object sender, System.EventArgs e)
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

            // 设置编译默认选项
            this.ShaderCompileTypeListBox.SelectedIndex = 0;
        }

        #region ======== 基本框架 ========

        // 隐藏窗口
        private void CloseShaderCompileWndButton_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }
        // 截获处理热键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F4)
            {
                this.Hide();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        // 拖拽窗口标题
        private void ShaderCompileFormTitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //this.Location = new System.Drawing.Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion ======== 基本框架 ========

        #region ======== 核心函数 ========

        // 拖拽文件到编译窗口
        private void AcceptFXPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data is DataObject && ((DataObject)e.Data).ContainsFileDropList())
            {
                foreach (string filePath in ((DataObject)e.Data).GetFileDropList())
                {
                    if (filePath.Contains(".fx"))
                    {
                        Process process = new Process();
                        process.StartInfo.Arguments = GetCommandArgs(filePath);
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
                        return;
                    }
                }
            }
        }
        // 调用exe的参数
        private string GetCommandArgs(string filePath)
        {
            string profile = string.Empty;
            string extra = " /Profile:";

            switch (ShaderCompileTypeListBox.SelectedIndex)
            {
                case 0:
                    profile = "dx11";
                    extra += "DirectX_11";
                    break;
                case 1:
                    profile = "ogl";
                    extra += "OpenGL";
                    break;
                case 2:
                    profile = "ps4";
                    extra += "PlayStation4";
                    break;
            }


            string mgsExt = string.Format("{0}.mgfxo", profile);
            string newFilePath = filePath.Replace("fx", mgsExt);

            return filePath + " " + newFilePath + extra;
        }
        // 拖拽文件进入
        private void AcceptFXPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        #endregion ======== 核心函数 ========
    }
}
