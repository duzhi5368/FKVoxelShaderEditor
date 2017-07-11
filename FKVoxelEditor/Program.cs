using System;
using System.Drawing;
using System.Windows.Forms;

namespace FKVoxelEditor
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static FKGame        s_GameInstance;

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                bool bIsEditorMode = true;

                MainForm mainForm = new MainForm();
                mainForm.Disposed += new EventHandler(OnAppExit);
                mainForm.ClientSize = new Size(800, 600);

                s_GameInstance = new FKGame(mainForm, bIsEditorMode);
                s_GameInstance.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
            }
        }

        public static void OnAppExit(object sender, EventArgs e)
        {
            s_GameInstance.Dispose();
            s_GameInstance.Exit();
        }
    }
#endif
}
