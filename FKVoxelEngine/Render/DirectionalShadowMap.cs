//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    块 容积体
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class DirectionalShadowMap
    {
        private readonly RenderTarget2D m_RenderTarget;
        private readonly GraphicsDevice m_GraphicsDevice;
        private readonly BlendState     m_BlendState;

        public DirectionalShadowMap(GraphicsDevice graphicsDevice)
            : this(graphicsDevice,
                  graphicsDevice.PresentationParameters.BackBufferWidth,
                  graphicsDevice.PresentationParameters.BackBufferHeight)
        {

        }

        public DirectionalShadowMap(GraphicsDevice graphicsDevice, int width, int height)
        {
            m_RenderTarget = new RenderTarget2D(graphicsDevice, width, height, false, SurfaceFormat.Single, DepthFormat.Depth24);
            m_GraphicsDevice = graphicsDevice;
            m_BlendState = BlendState.Opaque;
        }

        public void Prepare()
        {
            m_GraphicsDevice.SetRenderTarget(m_RenderTarget);
            m_GraphicsDevice.Clear(Color.White);
            m_GraphicsDevice.BlendState = m_BlendState;
            m_GraphicsDevice.DepthStencilState = DepthStencilState.Default;
        }

        public RenderTarget2D GetRenderTarget()
        {
            return m_RenderTarget;
        }
    }
}
