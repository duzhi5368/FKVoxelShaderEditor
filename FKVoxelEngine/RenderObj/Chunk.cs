//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    块 对象
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class Chunk
    {
        #region ======== 常量 ========

        public const int MAX_SIZE = 255;
        public const int DEFAULT_SIZE = 16;

        #endregion ======== 常量 ========

        #region ======== 成员变量 ========

        public readonly byte SizeX;
        public readonly byte SizeY;
        public readonly byte SizeZ;

        public readonly int TotalSize;
        public int BlockCount { get; private set; }
        public ChunkRenderer Renderer { get; }  // 渲染信息
        public BlockContainer Blocks { get; }   // 数据信息
        private Vector3 m_Position;             // 当前坐标位置

        #endregion ======== 成员变量 ========

        #region ======== 构造函数 ========

        public Chunk(ChunkRenderer renderer, Vector3 position,
            byte sizeX = DEFAULT_SIZE, byte sizeY = DEFAULT_SIZE, byte sizeZ = DEFAULT_SIZE)
        {
            Renderer = renderer;
            Position = position;
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
            TotalSize = sizeX * sizeY * sizeZ;

            Blocks = new BlockGrid(this);
        }

        #endregion ======== 构造函数 ========

        #region ======== 便捷接口 ========

        /// <summary>
        /// 设置和获取当前块的坐标
        /// </summary>
        public Vector3 Position
        {
            get { return m_Position; }
            set
            {
                m_Position = value;
                Renderer.GetEffect().ChunkPosition = value;
            }
        }
        /// <summary>
        /// 获取当前块 中心坐标
        /// </summary>
        /// <returns></returns>
        public Vector3 Center()
        {
            return m_Position + new Vector3(SizeX / 2, SizeY / 2, SizeZ / 2);
        }

        #endregion ======== 便捷接口 ========

        #region ======== 核心函数 ========

        public void SetBlockData(int index, VertexWithIndex data)
        {
            if (!Renderer.IsInitialized())
                throw new InvalidOperationException("Renderer must be initialized with <see cref='BuildChunk' /> first.");

            Renderer.SetBlock(data, index);
        }

        public void AddBlock(VertexWithIndex data, bool bRebuildIfNeeded = false)
        {
            if (BlockCount >= TotalSize)
                throw new InvalidOperationException("Chunk is full.");

            Renderer.AddBlock(data, bRebuildIfNeeded);
        }

        public void BuildChunk(VertexWithIndex[] data, int? activeCount = null, bool rebuild = false)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length > TotalSize)
                throw new ArgumentException("Too much data for this chunk.", nameof(data));
            if (Renderer.IsInitialized() && !rebuild)
                throw new InvalidOperationException("Chunk is already built, to override set the rebuild flag.");
            if (activeCount < 0 || activeCount > data.Length)
                throw new ArgumentOutOfRangeException(nameof(activeCount));

            Blocks.AddRange(data);
            BlockCount = data.Length;

            Renderer.Init(this, data, activeCount ?? data.Length);
        }

        public void Draw(Effect CurEffect)
        {
            Renderer.Draw(CurEffect);
        }

        #endregion ======== 核心函数 ========
    }
}
