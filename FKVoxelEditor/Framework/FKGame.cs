//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    游戏App类
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public partial class FKGame : Game
    {
        GraphicsDeviceManager   m_Graphics = null;
        SpriteBatch             m_SpriteBatch = null;

        public FKGame(Form customRenderForm, bool bIsEditorMode)
        {
            m_Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            MyFKGameConstructor(customRenderForm, bIsEditorMode);
        }
        /// <summary>
        /// 初始化函数
        /// </summary>
        protected override void Initialize()
        {
            MyFKGameInit();

            base.Initialize();
        }
        /// <summary>
        /// 加载资源 （仅调用一次）
        /// </summary>
        protected override void LoadContent()
        {
            m_SpriteBatch = new SpriteBatch(GraphicsDevice);

            MyFKGameLoadContent();
        }
        /// <summary>
        /// 卸载资源 （仅调用一次）
        /// </summary>
        protected override void UnloadContent()
        {
            MyFKGameUnloadContent();
        }
        /// <summary>
        /// 逻辑更新函数
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            //System.Diagnostics.Debug.WriteLine(System.DateTime.Now.TimeOfDay.ToString());
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            MyFKGameUpdate(gameTime);

            base.Update(gameTime);
        }
        /// <summary>
        /// 每帧绘制函数
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            //System.Diagnostics.Debug.WriteLine(System.DateTime.Now.TimeOfDay.ToString());
            GraphicsDevice.Clear(Color.CornflowerBlue);

            MyFKGameDraw(gameTime);

            base.Draw(gameTime);
        }
    }
}
