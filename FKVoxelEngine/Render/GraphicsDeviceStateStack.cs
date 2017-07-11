//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170707
// Desc:    渲染设备的渲染状态表
//-------------------------------------------------
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class GraphicsDeviceStateStack
    {
        private readonly GraphicsDevice             m_GraphicsDevice;
        private readonly Stack<GraphicsDeviceState> m_StatesList;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public GraphicsDeviceStateStack(GraphicsDevice graphicsDevice)
        {
            m_GraphicsDevice = graphicsDevice;
            m_StatesList = new Stack<GraphicsDeviceState>();
        }
        /// <summary>
        /// 记录当前设备当前渲染状态
        /// </summary>
        public void Push()
        {
            lock (m_StatesList)
            {
                m_StatesList.Push(new GraphicsDeviceState(m_GraphicsDevice));
            }
        }
        /// <summary>
        /// 移除一个已记录的渲染状态，并且将设备进行状态更改
        /// </summary>
        public void Pop()
        {
            lock (m_StatesList)
            {
                if (m_StatesList.Count <= 0)
                    return;

                var state = m_StatesList.Pop();
                state.Restore(m_GraphicsDevice);
            }
        }
        /// <summary>
        /// 移除一个最后记录的渲染状态
        /// </summary>
        /// <returns></returns>
        public GraphicsDeviceState Peek()
        {
            lock (m_StatesList)
            {
                return m_StatesList.Peek();
            }
        }
    }
}
