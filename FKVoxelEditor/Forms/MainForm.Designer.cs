namespace FKVoxelEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.RenderControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WndControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsoleWndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModelWndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShaderEditorWndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShaderCompileWndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsolePanel = new System.Windows.Forms.Panel();
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.DebugLogRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ModelPanel = new System.Windows.Forms.Panel();
            this.ModelRenderSettingGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoRateCameraCheckBox = new System.Windows.Forms.CheckBox();
            this.WireframeCheckBox = new System.Windows.Forms.CheckBox();
            this.RenderModeComboBox = new System.Windows.Forms.ComboBox();
            this.RenderModelLabel = new System.Windows.Forms.Label();
            this.ModelInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.ModelSizeLabel = new System.Windows.Forms.Label();
            this.BlocksNumLabel = new System.Windows.Forms.Label();
            this.PrimitivesNumLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CurModelNameLabel = new System.Windows.Forms.Label();
            this.ModelListView = new System.Windows.Forms.ListView();
            this.OneSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenuStrip.SuspendLayout();
            this.ConsolePanel.SuspendLayout();
            this.ModelPanel.SuspendLayout();
            this.ModelRenderSettingGroupBox.SuspendLayout();
            this.ModelInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenderControlToolStripMenuItem,
            this.WndControlToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(804, 25);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // RenderControlToolStripMenuItem
            // 
            this.RenderControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FullScreenToolStripMenuItem});
            this.RenderControlToolStripMenuItem.Name = "RenderControlToolStripMenuItem";
            this.RenderControlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RenderControlToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.RenderControlToolStripMenuItem.Text = "渲染设置";
            // 
            // FullScreenToolStripMenuItem
            // 
            this.FullScreenToolStripMenuItem.Name = "FullScreenToolStripMenuItem";
            this.FullScreenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.FullScreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.FullScreenToolStripMenuItem.Text = "游戏全屏";
            this.FullScreenToolStripMenuItem.Click += new System.EventHandler(this.FullScreenToolStripMenuItem_Click);
            // 
            // WndControlToolStripMenuItem
            // 
            this.WndControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConsoleWndToolStripMenuItem,
            this.ModelWndToolStripMenuItem,
            this.ShaderEditorWndToolStripMenuItem,
            this.ShaderCompileWndToolStripMenuItem});
            this.WndControlToolStripMenuItem.Name = "WndControlToolStripMenuItem";
            this.WndControlToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.WndControlToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.WndControlToolStripMenuItem.Text = "窗口管理";
            // 
            // ConsoleWndToolStripMenuItem
            // 
            this.ConsoleWndToolStripMenuItem.Name = "ConsoleWndToolStripMenuItem";
            this.ConsoleWndToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.ConsoleWndToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ConsoleWndToolStripMenuItem.Text = "命令窗口";
            this.ConsoleWndToolStripMenuItem.Click += new System.EventHandler(this.ConsoleWndToolStripMenuItem_Click);
            // 
            // ModelWndToolStripMenuItem
            // 
            this.ModelWndToolStripMenuItem.Name = "ModelWndToolStripMenuItem";
            this.ModelWndToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ModelWndToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ModelWndToolStripMenuItem.Text = "模型查看";
            this.ModelWndToolStripMenuItem.Click += new System.EventHandler(this.ModelWndToolStripMenuItem_Click);
            // 
            // ShaderEditorWndToolStripMenuItem
            // 
            this.ShaderEditorWndToolStripMenuItem.Name = "ShaderEditorWndToolStripMenuItem";
            this.ShaderEditorWndToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.ShaderEditorWndToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ShaderEditorWndToolStripMenuItem.Text = "特效编辑";
            this.ShaderEditorWndToolStripMenuItem.Click += new System.EventHandler(this.ShaderEditorWndToolStripMenuItem_Click);
            // 
            // ShaderCompileWndToolStripMenuItem
            // 
            this.ShaderCompileWndToolStripMenuItem.Name = "ShaderCompileWndToolStripMenuItem";
            this.ShaderCompileWndToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ShaderCompileWndToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ShaderCompileWndToolStripMenuItem.Text = "特效编译";
            this.ShaderCompileWndToolStripMenuItem.Click += new System.EventHandler(this.ShaderCompileWndToolStripMenuItem_Click);
            // 
            // ConsolePanel
            // 
            this.ConsolePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsolePanel.Controls.Add(this.CommandTextBox);
            this.ConsolePanel.Controls.Add(this.DebugLogRichTextBox);
            this.ConsolePanel.Location = new System.Drawing.Point(0, 502);
            this.ConsolePanel.Name = "ConsolePanel";
            this.ConsolePanel.Size = new System.Drawing.Size(804, 100);
            this.ConsolePanel.TabIndex = 2;
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CommandTextBox.Location = new System.Drawing.Point(0, 76);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(804, 21);
            this.CommandTextBox.TabIndex = 1;
            this.CommandTextBox.Text = "请在此处输入命令";
            // 
            // DebugLogRichTextBox
            // 
            this.DebugLogRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DebugLogRichTextBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.DebugLogRichTextBox.ForeColor = System.Drawing.Color.Wheat;
            this.DebugLogRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.DebugLogRichTextBox.Name = "DebugLogRichTextBox";
            this.DebugLogRichTextBox.ReadOnly = true;
            this.DebugLogRichTextBox.Size = new System.Drawing.Size(804, 76);
            this.DebugLogRichTextBox.TabIndex = 0;
            this.DebugLogRichTextBox.Text = "";
            // 
            // ModelPanel
            // 
            this.ModelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ModelPanel.Controls.Add(this.ModelRenderSettingGroupBox);
            this.ModelPanel.Controls.Add(this.ModelInfoGroupBox);
            this.ModelPanel.Controls.Add(this.ModelListView);
            this.ModelPanel.Location = new System.Drawing.Point(668, 28);
            this.ModelPanel.Name = "ModelPanel";
            this.ModelPanel.Size = new System.Drawing.Size(136, 468);
            this.ModelPanel.TabIndex = 3;
            // 
            // ModelRenderSettingGroupBox
            // 
            this.ModelRenderSettingGroupBox.Controls.Add(this.AutoRateCameraCheckBox);
            this.ModelRenderSettingGroupBox.Controls.Add(this.WireframeCheckBox);
            this.ModelRenderSettingGroupBox.Controls.Add(this.RenderModeComboBox);
            this.ModelRenderSettingGroupBox.Controls.Add(this.RenderModelLabel);
            this.ModelRenderSettingGroupBox.Location = new System.Drawing.Point(5, 223);
            this.ModelRenderSettingGroupBox.Name = "ModelRenderSettingGroupBox";
            this.ModelRenderSettingGroupBox.Size = new System.Drawing.Size(128, 117);
            this.ModelRenderSettingGroupBox.TabIndex = 7;
            this.ModelRenderSettingGroupBox.TabStop = false;
            this.ModelRenderSettingGroupBox.Text = "当前模型信息";
            // 
            // AutoRateCameraCheckBox
            // 
            this.AutoRateCameraCheckBox.AutoSize = true;
            this.AutoRateCameraCheckBox.Location = new System.Drawing.Point(11, 25);
            this.AutoRateCameraCheckBox.Name = "AutoRateCameraCheckBox";
            this.AutoRateCameraCheckBox.Size = new System.Drawing.Size(96, 16);
            this.AutoRateCameraCheckBox.TabIndex = 1;
            this.AutoRateCameraCheckBox.Text = "自旋转摄像机";
            this.AutoRateCameraCheckBox.UseVisualStyleBackColor = true;
            this.AutoRateCameraCheckBox.CheckedChanged += new System.EventHandler(this.AutoRateCameraCheckBox_CheckedChanged);
            // 
            // WireframeCheckBox
            // 
            this.WireframeCheckBox.AutoSize = true;
            this.WireframeCheckBox.Location = new System.Drawing.Point(11, 47);
            this.WireframeCheckBox.Name = "WireframeCheckBox";
            this.WireframeCheckBox.Size = new System.Drawing.Size(72, 16);
            this.WireframeCheckBox.TabIndex = 2;
            this.WireframeCheckBox.Text = "线条显示";
            this.WireframeCheckBox.UseVisualStyleBackColor = true;
            this.WireframeCheckBox.CheckedChanged += new System.EventHandler(this.WireframeCheckBox_CheckedChanged);
            // 
            // RenderModeComboBox
            // 
            this.RenderModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RenderModeComboBox.FormattingEnabled = true;
            this.RenderModeComboBox.Location = new System.Drawing.Point(11, 88);
            this.RenderModeComboBox.Name = "RenderModeComboBox";
            this.RenderModeComboBox.Size = new System.Drawing.Size(96, 20);
            this.RenderModeComboBox.TabIndex = 3;
            this.RenderModeComboBox.SelectedIndexChanged += new System.EventHandler(this.RenderModeComboBox_SelectedIndexChanged);
            // 
            // RenderModelLabel
            // 
            this.RenderModelLabel.AutoSize = true;
            this.RenderModelLabel.Location = new System.Drawing.Point(11, 73);
            this.RenderModelLabel.Name = "RenderModelLabel";
            this.RenderModelLabel.Size = new System.Drawing.Size(53, 12);
            this.RenderModelLabel.TabIndex = 4;
            this.RenderModelLabel.Text = "渲染方式";
            // 
            // ModelInfoGroupBox
            // 
            this.ModelInfoGroupBox.Controls.Add(this.ModelSizeLabel);
            this.ModelInfoGroupBox.Controls.Add(this.BlocksNumLabel);
            this.ModelInfoGroupBox.Controls.Add(this.PrimitivesNumLabel);
            this.ModelInfoGroupBox.Controls.Add(this.label4);
            this.ModelInfoGroupBox.Controls.Add(this.label3);
            this.ModelInfoGroupBox.Controls.Add(this.label2);
            this.ModelInfoGroupBox.Controls.Add(this.CurModelNameLabel);
            this.ModelInfoGroupBox.Location = new System.Drawing.Point(5, 346);
            this.ModelInfoGroupBox.Name = "ModelInfoGroupBox";
            this.ModelInfoGroupBox.Size = new System.Drawing.Size(128, 119);
            this.ModelInfoGroupBox.TabIndex = 5;
            this.ModelInfoGroupBox.TabStop = false;
            this.ModelInfoGroupBox.Text = "当前模型信息";
            // 
            // ModelSizeLabel
            // 
            this.ModelSizeLabel.AutoSize = true;
            this.ModelSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ModelSizeLabel.Location = new System.Drawing.Point(64, 92);
            this.ModelSizeLabel.Name = "ModelSizeLabel";
            this.ModelSizeLabel.Size = new System.Drawing.Size(11, 12);
            this.ModelSizeLabel.TabIndex = 6;
            this.ModelSizeLabel.Text = "0";
            // 
            // BlocksNumLabel
            // 
            this.BlocksNumLabel.AutoSize = true;
            this.BlocksNumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BlocksNumLabel.Location = new System.Drawing.Point(64, 70);
            this.BlocksNumLabel.Name = "BlocksNumLabel";
            this.BlocksNumLabel.Size = new System.Drawing.Size(11, 12);
            this.BlocksNumLabel.TabIndex = 5;
            this.BlocksNumLabel.Text = "0";
            // 
            // PrimitivesNumLabel
            // 
            this.PrimitivesNumLabel.AutoSize = true;
            this.PrimitivesNumLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PrimitivesNumLabel.Location = new System.Drawing.Point(64, 48);
            this.PrimitivesNumLabel.Name = "PrimitivesNumLabel";
            this.PrimitivesNumLabel.Size = new System.Drawing.Size(11, 12);
            this.PrimitivesNumLabel.TabIndex = 4;
            this.PrimitivesNumLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(5, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "大小:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(5, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Block数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "顶点数:";
            // 
            // CurModelNameLabel
            // 
            this.CurModelNameLabel.AutoSize = true;
            this.CurModelNameLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurModelNameLabel.ForeColor = System.Drawing.Color.Blue;
            this.CurModelNameLabel.Location = new System.Drawing.Point(10, 24);
            this.CurModelNameLabel.Name = "CurModelNameLabel";
            this.CurModelNameLabel.Size = new System.Drawing.Size(22, 14);
            this.CurModelNameLabel.TabIndex = 0;
            this.CurModelNameLabel.Text = "无";
            // 
            // ModelListView
            // 
            this.ModelListView.FullRowSelect = true;
            this.ModelListView.GridLines = true;
            this.ModelListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ModelListView.Location = new System.Drawing.Point(3, 3);
            this.ModelListView.MultiSelect = false;
            this.ModelListView.Name = "ModelListView";
            this.ModelListView.Size = new System.Drawing.Size(130, 214);
            this.ModelListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ModelListView.TabIndex = 0;
            this.ModelListView.UseCompatibleStateImageBehavior = false;
            this.ModelListView.View = System.Windows.Forms.View.Details;
            this.ModelListView.SelectedIndexChanged += new System.EventHandler(this.ModelListView_SelectedIndexChanged);
            // 
            // OneSecondTimer
            // 
            this.OneSecondTimer.Enabled = true;
            this.OneSecondTimer.Interval = 1000;
            this.OneSecondTimer.Tick += new System.EventHandler(this.OneSecondTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 602);
            this.Controls.Add(this.ModelPanel);
            this.Controls.Add(this.ConsolePanel);
            this.Controls.Add(this.MainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FK体素编辑器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ConsolePanel.ResumeLayout(false);
            this.ConsolePanel.PerformLayout();
            this.ModelPanel.ResumeLayout(false);
            this.ModelRenderSettingGroupBox.ResumeLayout(false);
            this.ModelRenderSettingGroupBox.PerformLayout();
            this.ModelInfoGroupBox.ResumeLayout(false);
            this.ModelInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private new System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RenderControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullScreenToolStripMenuItem;
        private System.Windows.Forms.Panel ConsolePanel;
        private System.Windows.Forms.ToolStripMenuItem WndControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsoleWndToolStripMenuItem;
        private System.Windows.Forms.TextBox CommandTextBox;
        private System.Windows.Forms.RichTextBox DebugLogRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem ModelWndToolStripMenuItem;
        private System.Windows.Forms.Panel ModelPanel;
        private System.Windows.Forms.ListView ModelListView;
        private System.Windows.Forms.CheckBox WireframeCheckBox;
        private System.Windows.Forms.CheckBox AutoRateCameraCheckBox;
        private System.Windows.Forms.Label RenderModelLabel;
        private System.Windows.Forms.ComboBox RenderModeComboBox;
        private System.Windows.Forms.GroupBox ModelInfoGroupBox;
        private System.Windows.Forms.Timer OneSecondTimer;
        private System.Windows.Forms.Label CurModelNameLabel;
        private System.Windows.Forms.GroupBox ModelRenderSettingGroupBox;
        private System.Windows.Forms.Label ModelSizeLabel;
        private System.Windows.Forms.Label BlocksNumLabel;
        private System.Windows.Forms.Label PrimitivesNumLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem ShaderEditorWndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShaderCompileWndToolStripMenuItem;
    }
}