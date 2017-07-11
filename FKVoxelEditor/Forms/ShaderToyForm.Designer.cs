namespace FKVoxelEditor
{
    partial class ShaderToyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShaderToyForm));
            this.ShaderToyMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildShaderF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShaderToyFormTitlePanel = new System.Windows.Forms.Panel();
            this.ShaderToyFormTitleLabel = new System.Windows.Forms.Label();
            this.CloseShaderCompileWndButton = new System.Windows.Forms.Button();
            this.ShaderToyMainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ShaderToyTextEditorPanel = new System.Windows.Forms.Panel();
            this.EditorSplitContainer = new System.Windows.Forms.SplitContainer();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.LogPanel = new System.Windows.Forms.Panel();
            this.LogOutputWnd = new System.Windows.Forms.TextBox();
            this.ShaderTopControlTabControl = new System.Windows.Forms.TabControl();
            this.tabPageParameters = new System.Windows.Forms.TabPage();
            this.tabPageTexSlots = new System.Windows.Forms.TabPage();
            this.tabPageHelp = new System.Windows.Forms.TabPage();
            this.webBrowserHelp = new System.Windows.Forms.WebBrowser();
            this.TextureSlotsUserControl = new FKVoxelEditor.TextureSlotsUserControl();
            this.ShaderParametersUserControl = new FKVoxelEditor.ShaderParametersUserControl();
            this.ShaderToyMainMenuStrip.SuspendLayout();
            this.ShaderToyFormTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShaderToyMainSplitContainer)).BeginInit();
            this.ShaderToyMainSplitContainer.Panel1.SuspendLayout();
            this.ShaderToyMainSplitContainer.Panel2.SuspendLayout();
            this.ShaderToyMainSplitContainer.SuspendLayout();
            this.ShaderToyTextEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditorSplitContainer)).BeginInit();
            this.EditorSplitContainer.Panel1.SuspendLayout();
            this.EditorSplitContainer.Panel2.SuspendLayout();
            this.EditorSplitContainer.SuspendLayout();
            this.LogPanel.SuspendLayout();
            this.ShaderTopControlTabControl.SuspendLayout();
            this.tabPageParameters.SuspendLayout();
            this.tabPageTexSlots.SuspendLayout();
            this.tabPageHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShaderToyMainMenuStrip
            // 
            this.ShaderToyMainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ShaderToyMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.buildToolStripMenuItem});
            this.ShaderToyMainMenuStrip.Location = new System.Drawing.Point(0, 20);
            this.ShaderToyMainMenuStrip.Name = "ShaderToyMainMenuStrip";
            this.ShaderToyMainMenuStrip.Size = new System.Drawing.Size(140, 25);
            this.ShaderToyMainMenuStrip.TabIndex = 1;
            this.ShaderToyMainMenuStrip.Text = "MainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItemNew,
            this.loadToolStripMenuItemLoad,
            this.saveToolStripMenuItemSave,
            this.saveAsToolStripMenuItemSaveAs,
            this.toolStripSeparator1,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItemExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // newToolStripMenuItemNew
            // 
            this.newToolStripMenuItemNew.Name = "newToolStripMenuItemNew";
            this.newToolStripMenuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItemNew.Size = new System.Drawing.Size(147, 22);
            this.newToolStripMenuItemNew.Text = "新建";
            this.newToolStripMenuItemNew.Click += new System.EventHandler(this.newToolStripMenuItemNew_Click);
            // 
            // loadToolStripMenuItemLoad
            // 
            this.loadToolStripMenuItemLoad.Name = "loadToolStripMenuItemLoad";
            this.loadToolStripMenuItemLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItemLoad.Size = new System.Drawing.Size(147, 22);
            this.loadToolStripMenuItemLoad.Text = "加载";
            this.loadToolStripMenuItemLoad.Click += new System.EventHandler(this.loadToolStripMenuItemLoad_Click);
            // 
            // saveToolStripMenuItemSave
            // 
            this.saveToolStripMenuItemSave.Name = "saveToolStripMenuItemSave";
            this.saveToolStripMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItemSave.Size = new System.Drawing.Size(147, 22);
            this.saveToolStripMenuItemSave.Text = "保存";
            this.saveToolStripMenuItemSave.Click += new System.EventHandler(this.saveToolStripMenuItemSave_Click);
            // 
            // saveAsToolStripMenuItemSaveAs
            // 
            this.saveAsToolStripMenuItemSaveAs.Name = "saveAsToolStripMenuItemSaveAs";
            this.saveAsToolStripMenuItemSaveAs.Size = new System.Drawing.Size(147, 22);
            this.saveAsToolStripMenuItemSaveAs.Text = "另存为...";
            this.saveAsToolStripMenuItemSaveAs.Click += new System.EventHandler(this.saveAsToolStripMenuItemSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.recentFilesToolStripMenuItem.Text = "记录文件";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(144, 6);
            // 
            // exitToolStripMenuItemExit
            // 
            this.exitToolStripMenuItemExit.Name = "exitToolStripMenuItemExit";
            this.exitToolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItemExit.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItemExit.Text = "退出";
            this.exitToolStripMenuItemExit.Click += new System.EventHandler(this.exitToolStripMenuItemExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.editToolStripMenuItem.Text = "编辑";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.findToolStripMenuItem.Text = "查找";
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.replaceToolStripMenuItem.Text = "替换";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildShaderF5ToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.buildToolStripMenuItem.Text = "编译";
            // 
            // buildShaderF5ToolStripMenuItem
            // 
            this.buildShaderF5ToolStripMenuItem.Name = "buildShaderF5ToolStripMenuItem";
            this.buildShaderF5ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.buildShaderF5ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.buildShaderF5ToolStripMenuItem.Text = "编译Shader";
            this.buildShaderF5ToolStripMenuItem.Click += new System.EventHandler(this.buildShaderF5ToolStripMenuItem_Click);
            // 
            // ShaderToyFormTitlePanel
            // 
            this.ShaderToyFormTitlePanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ShaderToyFormTitlePanel.Controls.Add(this.ShaderToyFormTitleLabel);
            this.ShaderToyFormTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.ShaderToyFormTitlePanel.Name = "ShaderToyFormTitlePanel";
            this.ShaderToyFormTitlePanel.Size = new System.Drawing.Size(775, 20);
            this.ShaderToyFormTitlePanel.TabIndex = 3;
            this.ShaderToyFormTitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShaderToyFormTitlePanel_MouseMove);
            // 
            // ShaderToyFormTitleLabel
            // 
            this.ShaderToyFormTitleLabel.AutoSize = true;
            this.ShaderToyFormTitleLabel.Location = new System.Drawing.Point(7, 5);
            this.ShaderToyFormTitleLabel.Name = "ShaderToyFormTitleLabel";
            this.ShaderToyFormTitleLabel.Size = new System.Drawing.Size(101, 12);
            this.ShaderToyFormTitleLabel.TabIndex = 0;
            this.ShaderToyFormTitleLabel.Text = "Shader特效编辑器";
            // 
            // CloseShaderCompileWndButton
            // 
            this.CloseShaderCompileWndButton.BackColor = System.Drawing.Color.OrangeRed;
            this.CloseShaderCompileWndButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseShaderCompileWndButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseShaderCompileWndButton.Location = new System.Drawing.Point(774, 0);
            this.CloseShaderCompileWndButton.Name = "CloseShaderCompileWndButton";
            this.CloseShaderCompileWndButton.Size = new System.Drawing.Size(45, 20);
            this.CloseShaderCompileWndButton.TabIndex = 5;
            this.CloseShaderCompileWndButton.Text = "X";
            this.CloseShaderCompileWndButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CloseShaderCompileWndButton.UseVisualStyleBackColor = false;
            this.CloseShaderCompileWndButton.Click += new System.EventHandler(this.CloseShaderCompileWndButton_Click);
            // 
            // ShaderToyMainSplitContainer
            // 
            this.ShaderToyMainSplitContainer.Location = new System.Drawing.Point(0, 50);
            this.ShaderToyMainSplitContainer.Name = "ShaderToyMainSplitContainer";
            // 
            // ShaderToyMainSplitContainer.Panel1
            // 
            this.ShaderToyMainSplitContainer.Panel1.Controls.Add(this.ShaderToyTextEditorPanel);
            // 
            // ShaderToyMainSplitContainer.Panel2
            // 
            this.ShaderToyMainSplitContainer.Panel2.Controls.Add(this.ShaderTopControlTabControl);
            this.ShaderToyMainSplitContainer.Size = new System.Drawing.Size(820, 483);
            this.ShaderToyMainSplitContainer.SplitterDistance = 597;
            this.ShaderToyMainSplitContainer.TabIndex = 2;
            // 
            // ShaderToyTextEditorPanel
            // 
            this.ShaderToyTextEditorPanel.Controls.Add(this.EditorSplitContainer);
            this.ShaderToyTextEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaderToyTextEditorPanel.Location = new System.Drawing.Point(0, 0);
            this.ShaderToyTextEditorPanel.Name = "ShaderToyTextEditorPanel";
            this.ShaderToyTextEditorPanel.Size = new System.Drawing.Size(597, 483);
            this.ShaderToyTextEditorPanel.TabIndex = 0;
            // 
            // EditorSplitContainer
            // 
            this.EditorSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.EditorSplitContainer.Name = "EditorSplitContainer";
            this.EditorSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // EditorSplitContainer.Panel1
            // 
            this.EditorSplitContainer.Panel1.Controls.Add(this.EditorPanel);
            // 
            // EditorSplitContainer.Panel2
            // 
            this.EditorSplitContainer.Panel2.Controls.Add(this.LogPanel);
            this.EditorSplitContainer.Size = new System.Drawing.Size(597, 483);
            this.EditorSplitContainer.SplitterDistance = 349;
            this.EditorSplitContainer.TabIndex = 0;
            // 
            // EditorPanel
            // 
            this.EditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorPanel.Location = new System.Drawing.Point(0, 0);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(597, 349);
            this.EditorPanel.TabIndex = 0;
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.LogOutputWnd);
            this.LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel.Location = new System.Drawing.Point(0, 0);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(597, 130);
            this.LogPanel.TabIndex = 0;
            // 
            // LogOutputWnd
            // 
            this.LogOutputWnd.AcceptsReturn = true;
            this.LogOutputWnd.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LogOutputWnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogOutputWnd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutputWnd.ForeColor = System.Drawing.Color.Wheat;
            this.LogOutputWnd.Location = new System.Drawing.Point(0, 0);
            this.LogOutputWnd.Multiline = true;
            this.LogOutputWnd.Name = "LogOutputWnd";
            this.LogOutputWnd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogOutputWnd.Size = new System.Drawing.Size(597, 130);
            this.LogOutputWnd.TabIndex = 1;
            // 
            // ShaderTopControlTabControl
            // 
            this.ShaderTopControlTabControl.Controls.Add(this.tabPageParameters);
            this.ShaderTopControlTabControl.Controls.Add(this.tabPageTexSlots);
            this.ShaderTopControlTabControl.Controls.Add(this.tabPageHelp);
            this.ShaderTopControlTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaderTopControlTabControl.Location = new System.Drawing.Point(0, 0);
            this.ShaderTopControlTabControl.Name = "ShaderTopControlTabControl";
            this.ShaderTopControlTabControl.SelectedIndex = 0;
            this.ShaderTopControlTabControl.Size = new System.Drawing.Size(219, 483);
            this.ShaderTopControlTabControl.TabIndex = 1;
            // 
            // tabPageParameters
            // 
            this.tabPageParameters.Controls.Add(this.ShaderParametersUserControl);
            this.tabPageParameters.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameters.Name = "tabPageParameters";
            this.tabPageParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParameters.Size = new System.Drawing.Size(211, 457);
            this.tabPageParameters.TabIndex = 2;
            this.tabPageParameters.Text = "参数列表";
            this.tabPageParameters.UseVisualStyleBackColor = true;
            // 
            // tabPageTexSlots
            // 
            this.tabPageTexSlots.Controls.Add(this.TextureSlotsUserControl);
            this.tabPageTexSlots.Location = new System.Drawing.Point(4, 22);
            this.tabPageTexSlots.Name = "tabPageTexSlots";
            this.tabPageTexSlots.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTexSlots.Size = new System.Drawing.Size(211, 457);
            this.tabPageTexSlots.TabIndex = 0;
            this.tabPageTexSlots.Text = "纹理列表";
            this.tabPageTexSlots.UseVisualStyleBackColor = true;
            // 
            // tabPageHelp
            // 
            this.tabPageHelp.Controls.Add(this.webBrowserHelp);
            this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
            this.tabPageHelp.Name = "tabPageHelp";
            this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHelp.Size = new System.Drawing.Size(211, 457);
            this.tabPageHelp.TabIndex = 1;
            this.tabPageHelp.Text = "HLSL帮助";
            this.tabPageHelp.UseVisualStyleBackColor = true;
            // 
            // webBrowserHelp
            // 
            this.webBrowserHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserHelp.Location = new System.Drawing.Point(3, 3);
            this.webBrowserHelp.MinimumSize = new System.Drawing.Size(20, 18);
            this.webBrowserHelp.Name = "webBrowserHelp";
            this.webBrowserHelp.Size = new System.Drawing.Size(205, 451);
            this.webBrowserHelp.TabIndex = 0;
            // 
            // TextureSlotsUserControl
            // 
            this.TextureSlotsUserControl.AutoScroll = true;
            this.TextureSlotsUserControl.AutoScrollMinSize = new System.Drawing.Size(0, 820);
            this.TextureSlotsUserControl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TextureSlotsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextureSlotsUserControl.Location = new System.Drawing.Point(3, 3);
            this.TextureSlotsUserControl.Name = "TextureSlotsUserControl";
            this.TextureSlotsUserControl.Size = new System.Drawing.Size(205, 451);
            this.TextureSlotsUserControl.TabIndex = 0;
            // 
            // ShaderParametersUserControl
            // 
            this.ShaderParametersUserControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ShaderParametersUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShaderParametersUserControl.Location = new System.Drawing.Point(3, 3);
            this.ShaderParametersUserControl.Name = "ShaderParametersUserControl";
            this.ShaderParametersUserControl.Size = new System.Drawing.Size(205, 451);
            this.ShaderParametersUserControl.TabIndex = 0;
            // 
            // ShaderToyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(820, 534);
            this.Controls.Add(this.CloseShaderCompileWndButton);
            this.Controls.Add(this.ShaderToyFormTitlePanel);
            this.Controls.Add(this.ShaderToyMainSplitContainer);
            this.Controls.Add(this.ShaderToyMainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShaderToyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shader特效编辑器";
            this.Load += new System.EventHandler(this.ShaderToyForm_Load);
            this.ShaderToyMainMenuStrip.ResumeLayout(false);
            this.ShaderToyMainMenuStrip.PerformLayout();
            this.ShaderToyFormTitlePanel.ResumeLayout(false);
            this.ShaderToyFormTitlePanel.PerformLayout();
            this.ShaderToyMainSplitContainer.Panel1.ResumeLayout(false);
            this.ShaderToyMainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShaderToyMainSplitContainer)).EndInit();
            this.ShaderToyMainSplitContainer.ResumeLayout(false);
            this.ShaderToyTextEditorPanel.ResumeLayout(false);
            this.EditorSplitContainer.Panel1.ResumeLayout(false);
            this.EditorSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditorSplitContainer)).EndInit();
            this.EditorSplitContainer.ResumeLayout(false);
            this.LogPanel.ResumeLayout(false);
            this.LogPanel.PerformLayout();
            this.ShaderTopControlTabControl.ResumeLayout(false);
            this.tabPageParameters.ResumeLayout(false);
            this.tabPageTexSlots.ResumeLayout(false);
            this.tabPageHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ShaderToyMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItemLoad;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItemSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildShaderF5ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer ShaderToyMainSplitContainer;
        private System.Windows.Forms.Panel ShaderToyTextEditorPanel;
        private System.Windows.Forms.TabControl ShaderTopControlTabControl;
        private System.Windows.Forms.TabPage tabPageParameters;
        private System.Windows.Forms.TabPage tabPageTexSlots;
        private System.Windows.Forms.TabPage tabPageHelp;
        private System.Windows.Forms.WebBrowser webBrowserHelp;
        private System.Windows.Forms.Panel ShaderToyFormTitlePanel;
        private System.Windows.Forms.Label ShaderToyFormTitleLabel;
        private System.Windows.Forms.Button CloseShaderCompileWndButton;
        private System.Windows.Forms.SplitContainer EditorSplitContainer;
        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.Panel LogPanel;
        private System.Windows.Forms.TextBox LogOutputWnd;
        private TextureSlotsUserControl TextureSlotsUserControl;
        private ShaderParametersUserControl ShaderParametersUserControl;
    }
}