//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170707
// Desc:    Form窗口管理类
//-------------------------------------------------
using FKVoxelEngine;
using System.Collections.Generic;
using System.Windows.Forms;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public partial class MainForm : Form
    {
        #region ======== 成员变量 ========

        ShaderCompileForm m_ShaderCompileForm = new ShaderCompileForm();
        ShaderToyForm m_ShaderToyForm = new ShaderToyForm();

        #endregion ======== 成员变量 ========

        #region ======== 构造函数 ========
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion ======== 构造函数 ========

        #region ======== 控件事件 ========

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            // 默认隐藏
            this.ConsolePanel.Hide();
            this.ModelPanel.Hide();

            // 加载资源列表
            this.ModelListView.BeginUpdate();
            ModelListView.Columns.Add("Name", 300, HorizontalAlignment.Left);
            { // 基本图元
                List<string> GeoPrimitiveNameList = Utils.GetDefaultGeoPrimitiveNameList();
                for (int i = 0; i < GeoPrimitiveNameList.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = GeoPrimitiveNameList[i];
                    this.ModelListView.Items.Add(lvi);
                }
            }
            {
                List<string> VoxModelFileNameList = Utils.GetModelFileNameList();
                for (int i = 0; i < VoxModelFileNameList.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = VoxModelFileNameList[i];
                    this.ModelListView.Items.Add(lvi);
                }
            }
            this.ModelListView.EndUpdate();  //结束数据处理，UI界面一次性绘制

            // 添加渲染类型选项单
            for (int i = 0; i < RenderState.RenderStateCount; ++i)
            {
                var RenderStateString = RenderState.RenderTypeName[i];
                this.RenderModeComboBox.Items.Add(RenderStateString);
            }
            this.RenderModeComboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// 全屏化 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullScreenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Program.s_GameInstance.ToggleFullScreen();
        }
        /// <summary>
        /// 命令窗口 显示按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsoleWndToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.ConsoleWndToolStripMenuItem.Checked)
            {
                this.ConsolePanel.Hide();
                this.ConsoleWndToolStripMenuItem.Checked = false;
            }
            else
            {
                this.ConsolePanel.Show();
                this.ConsoleWndToolStripMenuItem.Checked = true;
            }
        }
        /// <summary>
        /// 模型窗口 显示按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelWndToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (this.ModelWndToolStripMenuItem.Checked)
            {
                this.ModelPanel.Hide();
                this.ModelWndToolStripMenuItem.Checked = false;
            }
            else
            {
                this.ModelPanel.Show();
                this.ModelWndToolStripMenuItem.Checked = true;
            }
        }
        /// <summary>
        /// Shader编辑窗口 显示按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShaderEditorWndToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if(this.m_ShaderToyForm.Visible)
            {
                m_ShaderToyForm.Hide();
            }
            else
            {
                m_ShaderToyForm.Show(this);
            }
        }
        /// <summary>
        /// Shader编译窗口 显示按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShaderCompileWndToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (m_ShaderCompileForm.Visible)
            {
                m_ShaderCompileForm.Hide();
            }
            else
            {
                m_ShaderCompileForm.Show(this);
            }
        }
        /// <summary>
        /// 准备关闭Form事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit the editor?",
                       "FreeKnight Voxel Editor",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 更换模型事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelListView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FKGameState gs = Program.s_GameInstance.GetGameState();
            if (gs == null)
                return;
            ListView.SelectedListViewItemCollection selectItems =
                    this.ModelListView.SelectedItems;
            foreach (ListViewItem item in selectItems)
            {
                gs.ChangeModel(item.Text);
            }
        }
        /// <summary>
        /// 线条显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WireframeCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            FKGameState gs = Program.s_GameInstance.GetGameState();
            if (gs == null)
                return;
            gs.ToggleWireframe();
        }
        /// <summary>
        /// 摄像机旋转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoRateCameraCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            FKGameState gs = Program.s_GameInstance.GetGameState();
            if (gs == null)
                return;
            gs.ToggleCameraRotation();
        }
        /// <summary>
        /// 渲染方式 发生更变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenderModeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            FKGameState gs = Program.s_GameInstance.GetGameState();
            if (gs == null)
                return;
            gs.ChangeRenderState((RenderState.ENUM_RenderType)RenderModeComboBox.SelectedIndex);
        }

        #endregion ======== 控件事件 ========

        #region ======== 事件重载 ========

        /// <summary>
        /// Form的按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!base.ProcessCmdKey(ref msg, keyData))  // 父类没人用，再交给Game处理
            {
                // 将Form消息注入Game中处理
                Program.s_GameInstance.HookFormKeyEvent(keyData);
            }
            return false;
        }

        #endregion ======== 事件重载 ========

        #region ======== 逻辑事件 ========

        /// <summary>
        /// 一秒一次的定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneSecondTimer_Tick(object sender, System.EventArgs e)
        {
            // 更新模型信息窗口
            UpdateModelInfosPanel();
        }
        /// <summary>
        /// 更新模型信息窗口
        /// </summary>
        private void UpdateModelInfosPanel()
        {
            FKGameState gs = Program.s_GameInstance.GetGameState();
            if (gs == null)
                return;
            string strCurModelName = gs.GetCurrentModelName();
            this.CurModelNameLabel.Text = string.IsNullOrEmpty(strCurModelName) ?  "无" : strCurModelName + ".vox";
            this.PrimitivesNumLabel.Text = Program.s_GameInstance.GetCurrentModelPrimitiveCount().ToString();
            this.BlocksNumLabel.Text = Program.s_GameInstance.GetCurrentModelBlockCount().ToString();
            this.ModelSizeLabel.Text = Program.s_GameInstance.GetCurrentModelSizeDesc();
        }

        #endregion ======== 逻辑事件 ========

        #region ======== 便捷接口 ========


        #endregion ======== 便捷接口 ========
    }
}
