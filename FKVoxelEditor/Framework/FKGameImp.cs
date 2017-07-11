//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    游戏App类
//-------------------------------------------------
using FKVoxelEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public partial class FKGame : Game
    {
        #region ======== 常量 ========

        const int BACKGROUND_IMG_LINE_NUM = 60;

        #endregion ======== 常量 ========

        #region ======== 成员变量 ========

        private Form                        m_CustomRenderForm = null;      // 渲染区域面板
        private bool                        m_bIsEditorMode = false;        // 是否是编辑器模式，若非，则Form无效
        private bool                        m_bIsFirstTimeDraw = true;      // 是否是第一次执行Draw，为了隐藏MonoGame窗口
        private SpriteFont                  m_DeafultFont = null;           // 默认英文字体文件
        private Texture2D                   m_DeafaultBGImg = null;         // 默认背景纹理
        private FKGameState                 m_GameState = null;             // 游戏状态管理
        private DirectionalShadowMap        m_ShadowMap = null;             // ShadowMap
        private GraphicsDeviceStateStack    m_DeviceStatesList;             // 设备渲染状态表
        private List<Microsoft.Xna.Framework.Input.Keys> m_HookFormKeysList = new List<Microsoft.Xna.Framework.Input.Keys>();    // 按键事件列表

        private GraphicsMetrics             m_DrawMatrics;                  // 模型渲染数据
        private TimeSpan                    m_OneMinuteUpdate = TimeSpan.Zero;
        private int                         m_nDrawTimes = 0;
        private string                      m_strLastFPSValue = "";

        private Effect                      m_CurEffect = null;             // 当前使用的特效(若该值为null, Chunk将会使用默认shader，GeoPrimitive将不显示)
        private Texture2D[]                 m_TexSlots = new Texture2D[TextureSlotsUserControl.MAX_SLOT_COUNT]; // 当前使用的纹理
        public List<UIBaseParam>            ShaderParameters                 // shader参数表
        {
            get; set;
        }

        #endregion ======== 成员变量 ========

        #region ======== 流程函数 ========

        /// <summary>
        /// 自己的构造函数
        /// </summary>
        private void MyFKGameConstructor(Form customRenderForm, bool bIsEditorMode)
        {
            m_bIsEditorMode = bIsEditorMode;
            m_CustomRenderForm = customRenderForm;
            ShaderParameters = new List<UIBaseParam>();

            if (bIsEditorMode)
            {
                m_Graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>
                        (OnEditorPreparingDeviceSettings);
            }

            // 设置默认渲染状态
            SetDefaultRenderState();
        }
        /// <summary>
        /// 自己的初始化函数
        /// </summary>
        private void MyFKGameInit()
        {
            if (m_bIsEditorMode)
            {
                this.Window.AllowAltF4 = false;
                this.IsMouseVisible = true;
                this.Window.AllowUserResizing = false;
                m_CustomRenderForm.Show();
            }
            else
            {
                this.Window.AllowAltF4 = true;
                this.IsMouseVisible = false;
                this.Window.AllowUserResizing = true;
            }
            // 自定义窗口标题
            SetWindowTitle();
            // 创建帧按键处理对象
            Components.Add(new FKInputHandle(this, m_bIsEditorMode));
        }
        /// <summary>
        /// 自己的加载资源函数（仅调用一次）
        /// </summary>
        private void MyFKGameLoadContent()
        {
            // 创建渲染设备状态列表
            m_DeviceStatesList = new GraphicsDeviceStateStack(GraphicsDevice);
            // 加载自定义字体
            m_DeafultFont = Content.Load<SpriteFont>("Font\\DefaultFont");
            // 创建背景图片
            m_DeafaultBGImg = new Texture2D(m_Graphics.GraphicsDevice, 1, BACKGROUND_IMG_LINE_NUM);
            var gradientColor = new Color[BACKGROUND_IMG_LINE_NUM];
            for (var i = 0; i < BACKGROUND_IMG_LINE_NUM; i++)
            {
                var val = Remap((float)i / BACKGROUND_IMG_LINE_NUM, 0f, 1f, 0.3f, 0.75f);
                gradientColor[i] = new Color(val, val, val, 1f);
            }
            m_DeafaultBGImg.SetData(gradientColor);
            // 加载模型
            var ModelNamesList = Utils.GetModelFileNameList();
            var ModelChunksList = new List<Chunk>();
            foreach (var model in ModelNamesList)
            {
                var chunk = Content.Load<Chunk>("VoxModel\\" + model);
                ModelChunksList.Add(chunk);
                chunk.Position = -chunk.Center();
            }
            // 创建ShadowMap
            m_ShadowMap = new DirectionalShadowMap(GraphicsDevice);
            // 创建GameState
            m_GameState = new FKGameState(ModelNamesList, ModelChunksList);
        }
        /// <summary>
        /// 自己的资源卸载函数（仅调用一次）
        /// </summary>
        private void MyFKGameUnloadContent()
        {
            m_DeafaultBGImg.Dispose();
        }
        /// <summary>
        /// 自己的帧逻辑更新函数
        /// </summary>
        private void MyFKGameUpdate(GameTime gameTime)
        {
            // 每帧将按键事件注入给自定义KeyboardState中
            FKKeyboardState.SetKeys(m_HookFormKeysList);
            m_HookFormKeysList.Clear();
            // 检查本帧的按键操作情况
            HandleInputInThisFrame();
            // 游戏状态更新
            m_GameState.Update(gameTime);
        }
        /// <summary>
        /// 自己的帧绘制更新函数
        /// </summary>
        private void MyFKGameDraw(GameTime gameTime)
        {
            if(m_bIsFirstTimeDraw && m_bIsEditorMode)
            {
                HideMonoWindow();
                m_bIsFirstTimeDraw = false;
            }

            if(m_GameState.GetRenderState().RenderType == RenderState.ENUM_RenderType.eRS_ShadowMap)
            {
                UpdateShadowMap();
            }

            RenderDefaultBackground();

            m_DrawMatrics = GraphicsDevice.Metrics;                 // 临时缓存渲染模型之前的渲染数据
            switch (m_GameState.GetRenderState().RenderType)
            {
                case RenderState.ENUM_RenderType.eRS_SimpleRender:
                    RenderModel(false, false);
                    break;
                case RenderState.ENUM_RenderType.eRS_ShadowMap:
                    RenderModel(true, true);
                    break;
                case RenderState.ENUM_RenderType.eRS_Depth:
                    RenderModel(true, false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            m_DrawMatrics = GraphicsDevice.Metrics - m_DrawMatrics;// 相减获得模型本身的渲染数据

            RenderUI(gameTime);
        }

        #endregion ======== 流程函数 ========

        #region ======== 便捷接口 ========

        /// <summary>
        /// 全屏切换
        /// </summary>
        public void ToggleFullScreen()
        {
            if (m_Graphics.IsFullScreen)
            {
                Window.AllowAltF4 = false;
                m_Graphics.ToggleFullScreen();
            }
            else
            {
                Window.AllowAltF4 = true;
                m_Graphics.ToggleFullScreen();
            }
        }
        /// <summary>
        /// 从Form发送来的按键消息
        /// </summary>
        /// <param name="m"></param>
        public void HookFormKeyEvent(Keys formKeys)
        {
            Microsoft.Xna.Framework.Input.Keys xkey = FKKeyboardUtil.ToXna(formKeys);
            m_HookFormKeysList.Add(xkey);
        }
        /// <summary>
        /// 获取当前Chunk对象
        /// </summary>
        /// <returns></returns>
        public Chunk GetCurrentChunk()
        {
            return m_GameState.GetCurrentChunk();
        }
        /// <summary>
        /// 获取当前需要渲染图元对象
        /// </summary>
        /// <returns></returns>
        public GeometricPrimitive GetCurrentGeoPrimitive()
        {
            return m_GameState.GetCurrentGeoPrimitive();
        }
        /// <summary>
        /// 获取当前默认的特效对象
        /// </summary>
        /// <returns></returns>
        public VoxelEffect GetEffect()
        {
            if (GetCurrentChunk() == null)
                return null;
            return GetCurrentChunk().Renderer.GetEffect();
        }
        /// <summary>
        /// 获取游戏状态对象
        /// </summary>
        /// <returns></returns>
        public FKGameState GetGameState()
        {
            return m_GameState;
        }
        /// <summary>
        /// 获取当前模型的顶点数
        /// </summary>
        /// <returns></returns>
        public long GetCurrentModelPrimitiveCount()
        {
            return m_DrawMatrics.PrimitiveCount;
        }
        /// <summary>
        /// 当前块个数
        /// </summary>
        /// <returns></returns>
        public int GetCurrentModelBlockCount()
        {
            if (GetCurrentChunk() != null)
                return GetCurrentChunk().BlockCount;
            return 0;
        }
        /// <summary>
        /// 获取当前模型块的大小描述
        /// </summary>
        /// <returns></returns>
        public string GetCurrentModelSizeDesc()
        {
            if (GetCurrentChunk() == null)
                return "0x0x0";
            return $"{GetCurrentChunk().SizeX}x{GetCurrentChunk().SizeY}x{GetCurrentChunk().SizeZ}";
        }
        /// <summary>
        /// 设置当前第N层纹理对象
        /// </summary>
        /// <param name="_nSlotIdx"></param>
        /// <param name="_tex"></param>
        public void SetTextureSlot(int nSlotIdx, Texture2D tex)
        {
            if (nSlotIdx < 0 || nSlotIdx >= TextureSlotsUserControl.MAX_SLOT_COUNT)
                return;

            m_TexSlots[nSlotIdx] = tex;
        }
        /// <summary>
        /// 设置当前特效对象
        /// </summary>
        /// <param name="byShaderCode"></param>
        public void SetEffectBytesCode(byte[] byShaderCode)
        {
            m_CurEffect = new Effect(GraphicsDevice, byShaderCode);
        }

        #endregion ======== 便捷接口 ========

        #region ======== 核心函数 ========

        /// <summary>
        /// 重置编辑器模式渲染设备参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditorPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            // 重置渲染句柄
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = m_CustomRenderForm.Handle;
            // 重置后台缓冲大小
            e.GraphicsDeviceInformation.PresentationParameters.BackBufferHeight = m_CustomRenderForm.ClientSize.Height;
            e.GraphicsDeviceInformation.PresentationParameters.BackBufferWidth = m_CustomRenderForm.ClientSize.Width;
        }
        /// <summary>
        /// 设置默认渲染状态
        /// </summary>
        private void SetDefaultRenderState()
        {
            // 开启高级渲染模式
            m_Graphics.GraphicsProfile = GraphicsProfile.HiDef;
            // 关闭垂直同步
            m_Graphics.SynchronizeWithVerticalRetrace = false;
        }
        /// <summary>
        /// 设置窗口标题
        /// </summary>
        private void SetWindowTitle(string strTitle = null)
        {
            string strWndTitle = strTitle;

            // 自计算
            if (string.IsNullOrEmpty(strWndTitle))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var descriptionAttribute = assembly
                     .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                     .OfType<AssemblyDescriptionAttribute>()
                     .FirstOrDefault();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = "unknown version";
                if (fvi != null)
                    version = "v" + fvi.FileVersion;
                string description = "FKVoxelEditor";
                if (descriptionAttribute != null)
                    description = descriptionAttribute.Description;
                string editorMode = m_bIsEditorMode ? " [EditorMode] " : " [GameMode] ";
                strWndTitle = description + editorMode + version;
            }

            if (m_bIsEditorMode)
            {
                m_CustomRenderForm.Text = strWndTitle;
            }
            else
            {
                Window.Title = strWndTitle;
            }
        }
        /// <summary>
        /// 隐藏MonoGame自带窗口
        /// </summary>
        private void HideMonoWindow()
        {
            // 隐藏Mono窗口
            Control MonoDefaultWindow = Control.FromHandle((this.Window.Handle));
            if (MonoDefaultWindow != null)
            {
                MonoDefaultWindow.Visible = false;
            }
        }
        /// <summary>
        /// 本帧内的按键消息处理
        /// </summary>
        private void HandleInputInThisFrame()
        {
            if (FKInputHandle.IsPressed(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                if (m_bIsEditorMode)
                {
                    if (MessageBox.Show("Are you sure to exit the editor?",
                           "FreeKnight Voxel Editor",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Program.OnAppExit(null, null);
                    }
                }
                else
                {
                    Program.OnAppExit(null, null);
                }
            }
        }
        /// <summary>
        ///  计算背景色值
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min1"></param>
        /// <param name="max1"></param>
        /// <param name="min2"></param>
        /// <param name="max2"></param>
        /// <returns></returns>
        private float Remap(float val, float min1, float max1, float min2, float max2)
        {
            return (val - min1) / (max1 - min1) * (max2 - min2) + min2;
        }
        /// <summary>
        /// 更新ShadowMap
        /// </summary>
        private void UpdateShadowMap()
        {
            m_DeviceStatesList.Push();

            m_ShadowMap.Prepare();
            if(GetCurrentChunk() != null)
                GetCurrentChunk().Draw(m_CurEffect);
            if (GetCurrentGeoPrimitive() != null)
                GetCurrentGeoPrimitive().Draw(m_CurEffect);

            m_DeviceStatesList.Pop();
            GraphicsDevice.SetRenderTarget(null);
        }

        #endregion ======== 核心函数 ========

        #region ======== 渲染函数 ========

        /// <summary>
        /// 渲染背景板
        /// </summary>
        private void RenderDefaultBackground()
        {
            m_DeviceStatesList.Push();

            m_SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            m_SpriteBatch.Draw(m_DeafaultBGImg, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            m_SpriteBatch.End();

            m_DeviceStatesList.Pop();
        }
        /// <summary>
        /// 渲染模型
        /// </summary>
        /// <param name="bHasShadow"></param>
        /// <param name="bUseShadowMap"></param>
        private void RenderModel(bool bHasShadow, bool bUseShadowMap)
        {
            m_DeviceStatesList.Push();

            if (bHasShadow)
            {   
                // 计算ShadowMap
                GraphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;
                GetEffect().ShadowMap = m_ShadowMap.GetRenderTarget();
            }

            // 计算Effect参数
            if (m_CurEffect != null)
            {
                // 设置部分矩阵
                var p1 = m_CurEffect.Parameters["xWorld"];
                if (p1 != null)
                    p1.SetValue(m_GameState.GetWorldMatrix());

                var p2 = m_CurEffect.Parameters["xView"];
                if (p2 != null)
                    p2.SetValue(m_GameState.GetViewMatrix());

                var p3 = m_CurEffect.Parameters["xProjection"];
                if (p3 != null)
                    p3.SetValue(m_GameState.GetProjectionMatrix());

                // 设置纹理
                for (int i = 0; i < m_TexSlots.Length; i++)
                {
                    if (m_TexSlots[i] != null)
                    {
                        var p4 = m_CurEffect.Parameters[string.Format("xTexSlot{0}", i)];
                        if (p4 != null)
                        {
                            p4.SetValue(m_TexSlots[i]);
                        }
                    }
                }

                // 设置用户参数
                foreach (var p in ShaderParameters)
                {
                    var px = m_CurEffect.Parameters[p.Name];

                    //UIFloatParam
                    if (px != null && px.ParameterType == EffectParameterType.Single && p is UIFloatParam)
                    {
                        var floatParam = p as UIFloatParam;
                        px.SetValue(floatParam.Value);
                    }
                    //UITexture2DParam
                    else if (px != null && px.ParameterType == EffectParameterType.Texture2D && p is UITexture2DParam)
                    {
                        var texParam = p as UITexture2DParam;
                        Texture2D tex = null;
                        int idx = 0;
                        if (int.TryParse(texParam.Value, out idx))
                        {
                            if (idx >= 0 && idx < m_TexSlots.Length && m_TexSlots[idx] != null)
                            {
                                tex = m_TexSlots[idx];
                            }
                        }
                        px.SetValue(tex);
                    }
                }

                // 设置Pass
                m_CurEffect.CurrentTechnique.Passes[0].Apply();
            }

            // 默认特效参数更新
            if (GetEffect() != null)
            {
                GetEffect().View = m_GameState.GetViewMatrix();
                GetEffect().Projection = m_GameState.GetProjectionMatrix();
            }

            if (GetCurrentChunk() != null)
                GetCurrentChunk().Draw(null);
            if (GetCurrentGeoPrimitive() != null)
                GetCurrentGeoPrimitive().Draw(m_CurEffect);

            m_DeviceStatesList.Pop();

            // 绘制ShadowMap
            if (bUseShadowMap)
            {
                m_DeviceStatesList.Push();

                m_SpriteBatch.Begin();
                m_SpriteBatch.Draw(m_ShadowMap.GetRenderTarget(), Vector2.Zero);
                m_SpriteBatch.End();

                m_DeviceStatesList.Pop();
            }

        }
        /// <summary>
        /// 渲染UI文字
        /// </summary>
        /// <param name="gameTime"></param>
        private void RenderUI(GameTime gameTime)
        {
            m_DeviceStatesList.Push();

            m_SpriteBatch.Begin();

            /*
            var h = GraphicsDevice.PresentationParameters.BackBufferHeight;
            var w = GraphicsDevice.PresentationParameters.BackBufferWidth;
            */
            m_nDrawTimes++;
            if (m_OneMinuteUpdate == TimeSpan.Zero)
            {
                int framerate = (int)(1 / gameTime.ElapsedGameTime.TotalSeconds);
                var fpsStr = $"FPS: {framerate}";
                m_strLastFPSValue = fpsStr;
                RenderString(fpsStr, new Vector2(5, 28));

                m_OneMinuteUpdate += gameTime.ElapsedGameTime;
            }
            else
            {
                if (m_OneMinuteUpdate.TotalSeconds >= 1.0f)
                {
                    var fpsStr = $"FPS: {m_nDrawTimes}";
                    m_strLastFPSValue = fpsStr;
                    RenderString(fpsStr, new Vector2(5, 28));

                    m_nDrawTimes = 0;
                    m_OneMinuteUpdate -= new TimeSpan(0, 0, 1);
                }
                else
                {
                    RenderString(m_strLastFPSValue, new Vector2(5, 28));
                    m_OneMinuteUpdate += gameTime.ElapsedGameTime;
                }
            }

            m_SpriteBatch.End();

            m_DeviceStatesList.Pop();
        }
        /// <summary>
        /// 渲染一个文字对象
        /// </summary>
        /// <param name="str"></param>
        /// <param name="position"></param>
        private void RenderString(string str, Vector2 position)
        {
            m_SpriteBatch.DrawString(m_DeafultFont, str, position, Color.Black);
            m_SpriteBatch.DrawString(m_DeafultFont, str, position - Vector2.One, Color.White);
        }

        #endregion ======== 渲染函数 ========
    }
}
