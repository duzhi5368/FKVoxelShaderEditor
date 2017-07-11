//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    纹理显示面板
//-------------------------------------------------
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public class TextureSlotsUserControl : UserControl
    {
        public const int MAX_SLOT_COUNT = 4;    // 纹理层级认为最大是四层

        private Image[] m_ImageSlots = new Image[MAX_SLOT_COUNT];
        private System.ComponentModel.IContainer m_Components = null;

        public TextureSlotsUserControl()
        {
            InitializeComponent();
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

        public void SetTextureSlot(int _nSlotIdx, string _strFileName)
        {
            var streamT = File.OpenRead(_strFileName);
            Texture2D tex01 = Texture2D.FromStream(Program.s_GameInstance.GraphicsDevice, streamT);
            streamT.Close();

            SetTextureSlot(_nSlotIdx, tex01);
        }

        public void SetTextureSlot(int _nSlotIdx, Texture2D _tex)
        {
            if (_nSlotIdx < 0 || _nSlotIdx >= MAX_SLOT_COUNT)
                return;

            MemoryStream mem = new MemoryStream();
            _tex.SaveAsPng(mem, 256, 256);
            m_ImageSlots[_nSlotIdx] = Image.FromStream(mem);
            Program.s_GameInstance.SetTextureSlot(_nSlotIdx, _tex);

            Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TextureSlotsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DoubleBuffered = true;
            this.Name = "TextureSlotsUserControl";
            this.Size = new System.Drawing.Size(299, 429);
            this.ResumeLayout(false);
        }

        #endregion ======== 核心函数 ========

        #region ======== 事件重载 ========

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AutoScrollMinSize = new Size(0, Width * MAX_SLOT_COUNT);
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            // 获取SlotIndex
            MouseEventArgs evt = e as MouseEventArgs;
            int nSlotIdx = (evt.Y - AutoScrollPosition.Y) / ClientSize.Width;
            if (nSlotIdx < 0 || nSlotIdx >= MAX_SLOT_COUNT)
                return;

            // 弹出面板
            OpenFileDialog LoadTextureOpenFileDialog = new OpenFileDialog();
            LoadTextureOpenFileDialog.Filter = "bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            LoadTextureOpenFileDialog.RestoreDirectory = true;

            if (LoadTextureOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SetTextureSlot(nSlotIdx, LoadTextureOpenFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误: 无法从系統加载纹理图片: " + ex.Message);
                }
            }

        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int w = ClientSize.Width;
            int h = ClientSize.Height;

            e.Graphics.FillRectangle(Brushes.Black, 0, 0, w, h);

            // 计算偏移
            e.Graphics.TranslateTransform(0, AutoScrollPosition.Y);

            // 绘制纹理包围盒
            Rectangle rc = new Rectangle(0, 0, w, w);
            SolidBrush brSlotBk = new SolidBrush(Color.Gray);

            rc.Inflate(-4, -4);// 包围盒宽度

            for (int i = 0; i < MAX_SLOT_COUNT; i++)
            {
                // 插槽背景
                e.Graphics.FillRectangle(brSlotBk, rc);

                // 绘制纹理
                var img = m_ImageSlots[i];

                if (img != null)
                    e.Graphics.DrawImage(img, rc);

                // 绘制插槽名
                if (img != null)
                    e.Graphics.DrawString(string.Format("纹理层 {0} {1}x{2}", i, img.Width, img.Height), SystemFonts.DefaultFont, Brushes.White, rc);
                else
                    e.Graphics.DrawString(string.Format("纹理层 {0} ", i), SystemFonts.DefaultFont, Brushes.White, rc);

                rc.Offset(0, w);
            }
        }

        #endregion ======== 事件重载 ========
    }
}
