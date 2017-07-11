//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    游戏状态管理
//-------------------------------------------------
using Microsoft.Xna.Framework.Graphics;
using FKVoxelEngine;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public class FKGameState
    {
        #region ======== 成员变量 ========

        private RasterizerState             m_RasterizerState;
        private RenderState                 m_RenderState;
        private CameraState                 m_CameraState;

        private List<string>                m_ModelNameList;
        private List<Chunk>                 m_ModelChunkList;
        private List<string>                m_DefaultGeoPrimitiveNameList;
        private List<GeometricPrimitive>    m_DefaultGeoPrimitiveList;
        private float                       m_fCameraAngle;
        private int                         m_nCurrentChunkIndex;
        private int                         m_nCurrentGeoPrimitiveIndex;

        private Matrix                      m_WorldMatrix;

        private OrbitCamera                 m_Camera;

        MouseState                          m_prevMouseState;
        private bool                        m_bIsDraggingCamera;
        private int                         m_nStartDragX;
        private int                         m_nStartDragY;
        private bool                        m_bIsZoomingCamera;

        #endregion ======== 成员变量 ========

        #region ======== 构造函数 ========

        public FKGameState(List<string> modelNames, List<Chunk> modelChunks)
        {
            m_RenderState = new RenderState();
            m_RenderState.RenderType = RenderState.ENUM_RenderType.eRS_SimpleRender;
            m_CameraState = new CameraState();
            m_CameraState.CameraType = CameraState.ENUM_CameraType.eCT_Static;
            m_RasterizerState = new RasterizerState {
                CullMode = CullMode.CullCounterClockwiseFace,
                FillMode = FillMode.WireFrame
            };
            m_ModelNameList = modelNames;
            m_ModelChunkList = modelChunks;

            // 创建基本图元
            m_DefaultGeoPrimitiveNameList = Utils.GetDefaultGeoPrimitiveNameList();

            m_DefaultGeoPrimitiveList = new List<GeometricPrimitive>();
            m_DefaultGeoPrimitiveList.Add(new CubePrimitive(GraphicsDevice()));
            m_DefaultGeoPrimitiveList.Add(new SpherePrimitive(GraphicsDevice()));
            m_DefaultGeoPrimitiveList.Add(new TorusPrimitive(GraphicsDevice()));
            m_DefaultGeoPrimitiveList.Add(new TeapotPrimitive(GraphicsDevice()));

            // 设置默认对象
            m_nCurrentGeoPrimitiveIndex = 0;
            m_nCurrentChunkIndex = int.MaxValue;
            m_WorldMatrix = Matrix.Identity;

            // 重计算
            m_Camera = new OrbitCamera(Program.s_GameInstance);
            m_Camera.Update();
        }

        #endregion ======== 构造函数 ========

        #region ======== 便捷接口 ========

        private GraphicsDevice GraphicsDevice()
        {
            return Program.s_GameInstance.GraphicsDevice;
        }
        public Chunk GetCurrentChunk()
        {
            return ( m_ModelChunkList.Count == 0 || m_nCurrentChunkIndex >= m_ModelChunkList.Count )
                ? null : m_ModelChunkList[m_nCurrentChunkIndex];
        }
        public GeometricPrimitive GetCurrentGeoPrimitive()
        {
            return (m_DefaultGeoPrimitiveList.Count == 0 || m_nCurrentGeoPrimitiveIndex >= m_DefaultGeoPrimitiveList.Count)
                ? null : m_DefaultGeoPrimitiveList[m_nCurrentGeoPrimitiveIndex];
        }
        public string GetCurrentModelName()
        {
            if (m_nCurrentChunkIndex != int.MaxValue)
            {
                if (m_ModelNameList.Count <= 0)
                    return string.Empty;
                return m_ModelNameList[m_nCurrentChunkIndex];
            }
            if (m_nCurrentGeoPrimitiveIndex != int.MaxValue)
            {
                if (m_DefaultGeoPrimitiveNameList.Count <= 0)
                    return string.Empty;
                return m_DefaultGeoPrimitiveNameList[m_nCurrentGeoPrimitiveIndex];
            }
            return string.Empty;
        }
        public Matrix GetViewMatrix()
        {
            return m_Camera.View;
        }
        public Matrix GetProjectionMatrix()
        {
            return m_Camera.Projection;
        }
        public Matrix GetWorldMatrix()
        {
            return m_WorldMatrix;
        }
        public RenderState GetRenderState()
        {
            return m_RenderState;
        }

        #endregion ======== 便捷接口 ========

        #region ======== 对外接口 ========

        /// <summary>
        /// 逻辑帧更新
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            HandleInput();
            UpdateCameraState(gameTime);
        }
        /// <summary>
        /// 更改渲染方式
        /// </summary>
        public void ToggleWireframe()
        {
            if (GraphicsDevice().RasterizerState.FillMode == FillMode.Solid)
            {
                GraphicsDevice().RasterizerState = m_RasterizerState;
            }
            else
            {
                GraphicsDevice().RasterizerState = RasterizerState.CullNone;
            }
        }
        /// <summary>
        /// 更改摄像机旋转模式
        /// </summary>
        public void ToggleCameraRotation()
        {
            if (m_CameraState.CameraType == CameraState.ENUM_CameraType.eCT_AutoRotating)
            {
                m_CameraState.CameraType = CameraState.ENUM_CameraType.eCT_Static;
            }
            else
            {
                m_CameraState.CameraType = CameraState.ENUM_CameraType.eCT_AutoRotating;
            }
        }
        /// <summary>
        /// 更新模型对象
        /// </summary>
        /// <param name="strModelName"></param>
        public void ChangeModel(string strModelName)
        {
            int nIndex = 0;
            bool bIsMode = false;
            bool bIsGeoPrimitive = false;
            for (int i = 0; i < m_ModelNameList.Count; ++i)
            {
                if (string.Compare(strModelName, m_ModelNameList[i], true) == 0)
                {
                    bIsMode = true;
                    nIndex = i;
                    break;
                }
            }
            if (!bIsMode)
            {
                for (int i = 0; i < m_DefaultGeoPrimitiveNameList.Count; ++i)
                {
                    if (string.Compare(strModelName, m_DefaultGeoPrimitiveNameList[i], true) == 0)
                    {
                        bIsGeoPrimitive = true;
                        nIndex = i;
                        break;
                    }
                }
            }
            if (bIsMode && m_ModelChunkList.Count > nIndex)
            {
                ChangeModel(nIndex);
            }
            if (bIsGeoPrimitive && m_DefaultGeoPrimitiveList.Count > nIndex)
            {
                ChangeGeoPrimitive(nIndex);
            }
        }
        /// <summary>
        /// 更新渲染模式
        /// </summary>
        /// <param name="newType"></param>
        public void ChangeRenderState(RenderState.ENUM_RenderType newType)
        {
            m_RenderState.RenderType = newType;
        }

        #endregion ======== 对外接口 ========

        #region ======== 核心函数 ========

        /// <summary>
        /// 按键消息处理
        /// </summary>
        private void HandleInput()
        {
            var ms = Mouse.GetState();
            var ks = FKKeyboardState.GetState();

            // 若鼠标不在Windows管理区内，则不处理
            if (!Program.s_GameInstance.Window.ClientBounds.Contains(ms.Position))
            {
                System.Diagnostics.Debug.WriteLine("ClientBounds:  " + Program.s_GameInstance.Window.ClientBounds.ToString());
                System.Diagnostics.Debug.WriteLine("MousePosition:  " + ms.Position.ToString());
                return;
            }

            // 左键按下
            if (ms.LeftButton == ButtonState.Pressed && m_prevMouseState.LeftButton == ButtonState.Released)
            {
                System.Diagnostics.Debug.WriteLine("LefeButtonDown");
                m_nStartDragX = ms.X;
                m_nStartDragY = ms.Y;

                if (ks.IsKeyDown(Keys.LeftControl))
                {
                    m_bIsZoomingCamera = true;  //  按下Ctrl则缩放
                }
                else
                {
                    m_bIsDraggingCamera = true; // 仅仅是拖拽
                }
            }

            // 左键释放
            if (ms.LeftButton == ButtonState.Released && m_prevMouseState.LeftButton == ButtonState.Pressed)
            {
                System.Diagnostics.Debug.WriteLine("LefeButtonUp");
                m_bIsDraggingCamera = false;
                m_bIsZoomingCamera = false;
            }

            // 处理拖拽
            if (m_bIsDraggingCamera)
            {
                float fTurnSpeed = 8f;

                float offsetX = ((ms.X - m_nStartDragX) * fTurnSpeed * 0.001f); // pitch degree
                float offsetY = ((ms.Y - m_nStartDragY) * fTurnSpeed * 0.001f); // yaw degree

                var angleRadian = m_Camera.AngleRadian;
                angleRadian.X -= offsetY;
                angleRadian.Y -= offsetX;

                angleRadian.Y = MathHelper.Clamp(angleRadian.Y, 0, MathHelper.Pi * 2);
                angleRadian.X = MathHelper.Clamp(angleRadian.X, -(MathHelper.PiOver2 - 0.1f), (MathHelper.PiOver2 - 0.1f));

                m_Camera.AngleRadian = angleRadian;

                m_nStartDragX = ms.X;
                m_nStartDragY = ms.Y;
            }
            // 处理缩放
            if (m_bIsZoomingCamera == true)
            {
                float speed = 8f;
                float offsetY = ((ms.Y - m_nStartDragY) * speed * 0.001f);

                m_Camera.TargetDistance += offsetY;
                m_Camera.TargetDistance = MathHelper.Clamp(m_Camera.TargetDistance, 1.0f, 10);

                m_nStartDragY = ms.Y;
            }
            // 鼠标滚轮
            var wheelDelta = m_prevMouseState.ScrollWheelValue - ms.ScrollWheelValue;
            if (wheelDelta != 0)
            {
                m_Camera.TargetDistance += (wheelDelta / 100.0f);
                m_Camera.TargetDistance = MathHelper.Clamp(m_Camera.TargetDistance, 1.0f, 10);
            }

            // 记录上一次鼠标数据信息
            m_prevMouseState = ms;
        }
        /// <summary>
        /// 更新摄像机状态
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdateCameraState(GameTime gameTime)
        {
            if (m_CameraState.CameraType == CameraState.ENUM_CameraType.eCT_AutoRotating)
            {
                m_fCameraAngle += 0.6f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if(m_CameraState.CameraType == CameraState.ENUM_CameraType.eCT_Static)
            {
                m_fCameraAngle = 0.0f;
            }

            if (m_CameraState.CameraType == CameraState.ENUM_CameraType.eCT_AutoRotating 
                || m_CameraState.CameraType == CameraState.ENUM_CameraType.eCT_Static)
            {
                Chunk currentChunk = GetCurrentChunk();
                var dist = currentChunk == null ? 3 : currentChunk.SizeZ + 80;
                m_Camera.TargetDistance = dist;

                // 更新摄像机
                m_Camera.Update();

                // 更新模型的世界矩阵              
                m_WorldMatrix = Matrix.CreateRotationX(m_fCameraAngle) * Matrix.CreateRotationY(m_fCameraAngle) * Matrix.CreateRotationZ(m_fCameraAngle);
            }
        }
        /// <summary>
        /// 更新模型对象
        /// </summary>
        /// <param name="index"></param>
        private void ChangeModel(int index)
        {
            var length = m_ModelNameList.Count;
            m_nCurrentChunkIndex = (index % length + length) % length;
            m_nCurrentGeoPrimitiveIndex = int.MaxValue;

            m_Camera.Update();
        }
        /// <summary>
        /// 更新图元对象
        /// </summary>
        /// <param name="nIndex"></param>
        private void ChangeGeoPrimitive(int nIndex)
        {
            var length = m_DefaultGeoPrimitiveNameList.Count;
            m_nCurrentGeoPrimitiveIndex = (nIndex % length + length) % length;
            m_nCurrentChunkIndex = int.MaxValue;

            m_Camera.Update();
        }

        #endregion ======== 便捷接口 ========
    }
}
