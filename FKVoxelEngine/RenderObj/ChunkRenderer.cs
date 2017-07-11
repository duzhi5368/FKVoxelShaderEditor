//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    块 对象渲染管理
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public abstract class ChunkRenderer : IDisposable
    {
        #region ======== 成员变量 ========

        protected GraphicsDevice    m_GraphicsDevice = null;
        protected Chunk             m_Chunk = null;

        protected bool              m_bIsInitialized = false;       // 是否已经初始化过
        protected bool              m_bIsDisposed = false;          // 是否已经释放过
        protected int               m_nBlockCount = 0;              // 所包含的Block个数
        protected VoxelEffect       m_DefaultEffect = null;                // Voxel体素效果
        protected int               m_nFreeBlocks = 0;              // 在不进行rebuild render缓冲的前提下可以增加的block个数

        #endregion ======== 成员变量 ========

        #region ======== 便捷函数 ========

        /// <summary>
        /// render缓冲是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsBufferFull()
        {
            return m_nFreeBlocks <= 0;
        }
        /// <summary>
        /// 不进行rebuild情况下的Block个数
        /// </summary>
        /// <returns></returns>
        public int FreeBlocks()
        {
            return m_nFreeBlocks;
        }
        /// <summary>
        /// 体素效果
        /// </summary>
        /// <returns></returns>
        public VoxelEffect GetEffect()
        {
            return m_DefaultEffect;
        }
        /// <summary>
        /// 是否已初始化过
        /// </summary>
        /// <returns></returns>
        public bool IsInitialized()
        {
            return m_bIsInitialized;
        }

        #endregion ======== 便捷函数 ========

        #region ======== 构造函数 ========

        protected ChunkRenderer(GraphicsDevice graphicsDevice, Vector4[] palette)
        {
            if (graphicsDevice == null)
                throw new ArgumentNullException(nameof(graphicsDevice));
            if (graphicsDevice.GraphicsProfile != GraphicsProfile.HiDef)
                throw new ArgumentException("GraphicsDevice should have the HiDef profile!");
            if (palette == null)
                throw new ArgumentNullException(nameof(palette));

            m_GraphicsDevice = graphicsDevice;
            m_DefaultEffect = new VoxelEffect(graphicsDevice);
            m_DefaultEffect.Palette = palette;
        }
        ~ChunkRenderer()
        {
            Dispose(false);
            m_bIsDisposed = true;
        }

        #endregion ======== 构造函数 ========

        #region ======== 核心函数 ========

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="blocks"></param>
        /// <param name="active"></param>
        /// <param name="maxBlocks"></param>
        public void Init(Chunk chunk, VertexWithIndex[] blocks, int active, int? maxBlocks = null)
        {
            if (chunk == null)
                throw new ArgumentNullException(nameof(chunk));
            if (m_Chunk != null && !ReferenceEquals(chunk, m_Chunk))
                throw new ArgumentException("Renderer was already intialized for a different chunk.");

            if (m_bIsInitialized)
            {
                Dispose();
            }

            InitInternal(chunk, blocks, active, maxBlocks ?? chunk.BlockCount);
            m_nBlockCount += chunk.BlockCount;
            m_bIsInitialized = true;
        }
        /// <summary>
        /// 添加一个Block
        /// </summary>
        /// <param name="block"></param>
        /// <param name="rebuildIfNeeded"></param>
        /// <returns></returns>
        public int AddBlock(VertexWithIndex block, bool bRebuildIfNeeded = false)
        {
            if (m_nFreeBlocks == 0)
            {
                if (bRebuildIfNeeded)
                {
                    RebuildInternal(m_nBlockCount + 1);
                }
                else
                    throw new InvalidOperationException("The buffer cannot hold any more blocks, rebuild the buffer");
            }
            var index = m_nBlockCount;
            SetBlock(block, index);
            m_nBlockCount++;

            return index;
        }
        /// <summary>
        /// 预渲染
        /// </summary>
        protected virtual void PreDraw()
        {
        }
        /// <summary>
        /// 渲染函数
        /// </summary>
        public void Draw(Effect CurEffect)
        {
            PreDraw();

            if (CurEffect == null)
            {
                foreach (var pass in m_DefaultEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    DrawInternal();
                }
            }
            else
            {
                foreach (var pass in CurEffect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    DrawInternal();
                }
            }
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            m_bIsDisposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion ======== 核心函数 ========

        #region ======== 等待继承 ========

        protected abstract void InitInternal(Chunk chunk, VertexWithIndex[] blocks, int active, int maxBlocks);
        protected abstract void RebuildInternal(int maxBlocks);
        protected abstract void DrawInternal();
        public abstract void SetBlock(VertexWithIndex block, int index);
        public abstract void RemoveBlock(int index);
        protected abstract void Dispose(bool disposing);

        #endregion ======== 等待继承 ========
    }
}
