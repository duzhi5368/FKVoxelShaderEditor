//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170707
// Desc:    渲染设备的一种渲染状态
//-------------------------------------------------
using Microsoft.Xna.Framework.Graphics;
using System;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class GraphicsDeviceState
    {
        public BlendState BlendState { get; }
        public DepthStencilState DepthStencilState { get; }
        public RasterizerState RasterizerState { get; }
        public int SamplerStateCount => SamplerStates.Length;
        public SamplerState[] SamplerStates { get; }


        /// <summary>
        /// 构造函数 , 保存一个渲染设备当前的渲染状态
        /// </summary>
        /// <param name="graphicsDevice"></param>
        /// <param name="samplerStateCount"></param>
        public GraphicsDeviceState(GraphicsDevice graphicsDevice, int samplerStateCount = 1)
        {
            if (graphicsDevice == null)
                throw new ArgumentNullException(nameof(graphicsDevice));

            BlendState = graphicsDevice.BlendState;
            DepthStencilState = graphicsDevice.DepthStencilState;
            RasterizerState = graphicsDevice.RasterizerState;

            SamplerStates = new SamplerState[samplerStateCount];
            for (var i = 0; i < samplerStateCount; i++)
            {
                SamplerStates[i] = graphicsDevice.SamplerStates[i];
            }
        }
        /// <summary>
        /// 恢复一个渲染设备的渲染状态
        /// </summary>
        /// <param name="graphicsDevice"></param>
        internal void Restore(GraphicsDevice graphicsDevice)
        {
            if (graphicsDevice == null)
                throw new ArgumentNullException(nameof(graphicsDevice));

            graphicsDevice.BlendState = BlendState;
            graphicsDevice.DepthStencilState = DepthStencilState;
            graphicsDevice.RasterizerState = RasterizerState;

            for (var i = 0; i < SamplerStateCount; i++)
            {
                graphicsDevice.SamplerStates[i] = SamplerStates[i];
            }
        }
    }
}
