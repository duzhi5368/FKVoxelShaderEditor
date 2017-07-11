//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    块 容积体
//-------------------------------------------------
using Microsoft.Xna.Framework;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public abstract class BlockContainer
    {
        #region ======== 成员变量 ========

        protected readonly Chunk m_Chunk;
        protected abstract BoundingBox BoundingBox { get; }

        #endregion ======== 成员变量 ========

        #region ======== 构造函数 ========
        protected BlockContainer(Chunk chunk)
        {
            m_Chunk = chunk;
        }

        #endregion ======== 构造函数 ========

        #region ======== 便捷接口 ========

        public int GetBlockCount()
        {
            return m_Chunk.BlockCount;
        }
        public int SizeX()
        {
            return m_Chunk.SizeX;
        }
        public int SizeY()
        {
            return m_Chunk.SizeY;
        }
        public int SizeZ()
        {
            return m_Chunk.SizeZ;
        }

        public BlockData this[byte x, byte y, byte z] => Get(x,y,z);

        #endregion ======== 便捷接口 ========

        #region ======== 核心函数 ========

        /// <summary>
        /// 添加一个Block
        /// </summary>
        /// <param name="block"></param>
        public virtual void Add(VertexWithIndex block)
        {
            Add(block.X, block.Y, block.Z, new BlockData(block.Index));
        }
        /// <summary>
        /// 添加一堆Block
        /// </summary>
        /// <param name="blocks"></param>
        public virtual void AddRange(VertexWithIndex[] blocks)
        {
            foreach (var b in blocks)
                Add(b.X, b.Y, b.Z, new BlockData(b.Index));
        }
        /// <summary>
        /// 移除一个Block
        /// </summary>
        /// <param name="block"></param>
        public void Remove(VertexWithIndex block)
        {
            Remove(block.X, block.Y, block.Z);
        }

        #endregion ======== 核心函数 ========

        #region ======== 等待继承 ========

        public abstract BlockData Get(byte x, byte y, byte z);
        public abstract void Add(byte x, byte y, byte z, BlockData block);
        public abstract void Remove(byte x, byte y, byte z);
        public abstract void Clear();
        public abstract bool Intersect(Ray ray, out BlockIntersection intersection);

        #endregion ======== 等待继承 ========
    }
}
