namespace FKVoxelEditor
{
    partial class ShaderCompileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShaderCompileForm));
            this.AcceptFXPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DescLabel = new System.Windows.Forms.Label();
            this.ShaderCompileTypeListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShaderCompileFormTitlePanel = new System.Windows.Forms.Panel();
            this.ShaderWndTitleLabel = new System.Windows.Forms.Label();
            this.CloseShaderCompileWndButton = new System.Windows.Forms.Button();
            this.AcceptFXPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ShaderCompileFormTitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptFXPanel
            // 
            this.AcceptFXPanel.AllowDrop = true;
            this.AcceptFXPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AcceptFXPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AcceptFXPanel.Controls.Add(this.pictureBox1);
            this.AcceptFXPanel.Controls.Add(this.DescLabel);
            this.AcceptFXPanel.Location = new System.Drawing.Point(12, 28);
            this.AcceptFXPanel.Name = "AcceptFXPanel";
            this.AcceptFXPanel.Size = new System.Drawing.Size(250, 148);
            this.AcceptFXPanel.TabIndex = 0;
            this.AcceptFXPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.AcceptFXPanel_DragDrop);
            this.AcceptFXPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.AcceptFXPanel_DragEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(97, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // DescLabel
            // 
            this.DescLabel.AutoSize = true;
            this.DescLabel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DescLabel.Location = new System.Drawing.Point(20, 103);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(211, 20);
            this.DescLabel.TabIndex = 0;
            this.DescLabel.Text = "拖拽 .fx 文件到此处";
            // 
            // ShaderCompileTypeListBox
            // 
            this.ShaderCompileTypeListBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ShaderCompileTypeListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShaderCompileTypeListBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShaderCompileTypeListBox.FormattingEnabled = true;
            this.ShaderCompileTypeListBox.ItemHeight = 16;
            this.ShaderCompileTypeListBox.Items.AddRange(new object[] {
            "DirectX",
            "OpenGL",
            "PlayStation 4"});
            this.ShaderCompileTypeListBox.Location = new System.Drawing.Point(268, 78);
            this.ShaderCompileTypeListBox.Name = "ShaderCompileTypeListBox";
            this.ShaderCompileTypeListBox.Size = new System.Drawing.Size(124, 98);
            this.ShaderCompileTypeListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(286, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "平台类型";
            // 
            // ShaderCompileFormTitlePanel
            // 
            this.ShaderCompileFormTitlePanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ShaderCompileFormTitlePanel.Controls.Add(this.ShaderWndTitleLabel);
            this.ShaderCompileFormTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.ShaderCompileFormTitlePanel.Name = "ShaderCompileFormTitlePanel";
            this.ShaderCompileFormTitlePanel.Size = new System.Drawing.Size(364, 22);
            this.ShaderCompileFormTitlePanel.TabIndex = 3;
            this.ShaderCompileFormTitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ShaderCompileFormTitlePanel_MouseMove);
            // 
            // ShaderWndTitleLabel
            // 
            this.ShaderWndTitleLabel.AutoSize = true;
            this.ShaderWndTitleLabel.Location = new System.Drawing.Point(9, 5);
            this.ShaderWndTitleLabel.Name = "ShaderWndTitleLabel";
            this.ShaderWndTitleLabel.Size = new System.Drawing.Size(89, 12);
            this.ShaderWndTitleLabel.TabIndex = 0;
            this.ShaderWndTitleLabel.Text = "Shader编译面板";
            // 
            // CloseShaderCompileWndButton
            // 
            this.CloseShaderCompileWndButton.BackColor = System.Drawing.Color.OrangeRed;
            this.CloseShaderCompileWndButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseShaderCompileWndButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseShaderCompileWndButton.Location = new System.Drawing.Point(360, 0);
            this.CloseShaderCompileWndButton.Name = "CloseShaderCompileWndButton";
            this.CloseShaderCompileWndButton.Size = new System.Drawing.Size(45, 22);
            this.CloseShaderCompileWndButton.TabIndex = 4;
            this.CloseShaderCompileWndButton.Text = "X";
            this.CloseShaderCompileWndButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CloseShaderCompileWndButton.UseVisualStyleBackColor = false;
            this.CloseShaderCompileWndButton.Click += new System.EventHandler(this.CloseShaderCompileWndButton_Click);
            // 
            // ShaderCompileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(404, 188);
            this.Controls.Add(this.CloseShaderCompileWndButton);
            this.Controls.Add(this.ShaderCompileFormTitlePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShaderCompileTypeListBox);
            this.Controls.Add(this.AcceptFXPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShaderCompileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shader编译面板";
            this.Load += new System.EventHandler(this.ShaderCompileForm_Load);
            this.AcceptFXPanel.ResumeLayout(false);
            this.AcceptFXPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ShaderCompileFormTitlePanel.ResumeLayout(false);
            this.ShaderCompileFormTitlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel AcceptFXPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.ListBox ShaderCompileTypeListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ShaderCompileFormTitlePanel;
        private System.Windows.Forms.Label ShaderWndTitleLabel;
        private System.Windows.Forms.Button CloseShaderCompileWndButton;
    }
}