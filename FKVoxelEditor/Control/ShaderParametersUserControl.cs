//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    Shader参数面板
//-------------------------------------------------
using System.Collections.Generic;
using System.Windows.Forms;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public class ParamControl
    {
        public UIBaseParam m_Params;
        public Control m_Control;
    }
    public class ShaderParametersUserControl : UserControl
    {
        List<ParamControl> m_ShaderParametersDesc;
        private System.ComponentModel.IContainer m_Components = null;

        public ShaderParametersUserControl()
        {
            InitializeComponent();
            m_ShaderParametersDesc = new List<ParamControl>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (m_Components != null))
            {
                m_Components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region ======== 核心函数 ========

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ShaderParametersUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Name = "ShaderParametersUserControl";
            this.Size = new System.Drawing.Size(249, 253);
            this.ResumeLayout(false);
        }

        public void DisplayParameters(List<UIBaseParam> _parameters)
        {
            SuspendLayout();

            this.Controls.Clear();

            ResumeLayout();

            int itemElsp = 4;
            int itemY = itemElsp;
            int itemH = 16;
            foreach (var p in _parameters)
            {
                if (p is UIFloatParam)
                {
                    var fp = p as UIFloatParam;

                    var slider = new SlideCtrl();
                    slider.Location = new System.Drawing.Point(0, itemY);
                    slider.Height = itemH;
                    slider.SetRange(fp.MinRange, fp.MaxRange, 0.01f);
                    slider.SetPos(fp.Value);
                    slider.Parent = this;
                    slider.Text = p.Name;
                    slider.ValueChanging += Control_ValueChanging;
                    slider.Tag = p;
                    slider.CreateControl();
                }
                else if (p is UITexture2DParam)
                {
                    var tp = p as UITexture2DParam;

                    var label = new Label();
                    label.Location = new System.Drawing.Point(0, itemY);
                    label.Height = itemH;
                    label.Parent = this;
                    label.Text = tp.Name;
                    label.Tag = p;
                    label.CreateControl();

                    var textbox = new TextBox();
                    textbox.Location = new System.Drawing.Point(label.Width + 1, itemY);
                    textbox.Height = itemH;
                    textbox.Parent = this;
                    textbox.Text = tp.Value;
                    textbox.TextChanged += Textbox_TextChanged;
                    textbox.Tag = p;
                    textbox.CreateControl();
                }

                itemY += (itemH + itemElsp);
            }
        }

        private void Textbox_TextChanged(object sender, System.EventArgs e)
        {
            TextBox tb = sender as TextBox;
            UITexture2DParam p = tb.Tag as UITexture2DParam;
            p.Value = tb.Text;
        }

        private void Control_ValueChanging(object sender, System.EventArgs e)
        {
            SlideCtrl s = sender as SlideCtrl;
            UIFloatParam p = s.Tag as UIFloatParam;
            p.Value = s.GetPos();
        }

        #endregion ======== 核心函数 ========
    }
}
