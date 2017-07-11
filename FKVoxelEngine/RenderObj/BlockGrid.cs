//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    块 容积体
//-------------------------------------------------
using System;
using Microsoft.Xna.Framework;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class BlockGrid : BlockContainer
    {
        #region ======== 成员变量 ========

        //private Vector3             m_Position;
        private BoundingBox         m_BoundingBox;
        private BlockData[][][]     m_Grid;

        #endregion ======== 成员变量 ========

        public BlockGrid(Chunk chunk) : base(chunk)
        {
            // m_BoundingBox = new BoundingBox(m_Position, m_Position + new Vector3(chunk.SizeX, chunk.SizeY, chunk.SizeZ));
            m_BoundingBox = new BoundingBox(Vector3.Zero, new Vector3(chunk.SizeX, chunk.SizeY, chunk.SizeZ));
            InitGrids();
        }
        private void InitGrids()
        {
            int nSizeX = SizeX();
            int nSizeY = SizeY();
            int nSizeZ = SizeZ();
            m_Grid = new BlockData[nSizeX][][];
            for (var x = 0; x < nSizeX; x++)
            {
                m_Grid[x] = new BlockData[nSizeY][];

                for (var y = 0; y < nSizeY; y++)
                {
                    m_Grid[x][y] = new BlockData[nSizeZ];
                }
            }
        }


        #region ======== 继承实现 ========

        protected override BoundingBox BoundingBox
        {
            get
            {
                return m_BoundingBox;
            }
        }

        public override void Add(byte x, byte y, byte z, BlockData block)
        {
            m_Grid[x][y][z] = new BlockData(block.Index);
        }

        public override void Clear()
        {
            int nSizeX = SizeX();
            int nSizeY = SizeY();
            int nSizeZ = SizeZ();
            for (var x = 0; x < nSizeX; x++)
            {
                for (var y = 0; y < nSizeY; y++)
                {
                    Array.Clear(m_Grid[x][y], 0, nSizeZ);
                }
            }
        }

        public override BlockData Get(byte x, byte y, byte z)
        {
            return m_Grid[x][y][z];
        }

        public override bool Intersect(Ray ray, out BlockIntersection intersection)
        {
            if (!m_BoundingBox.Intersects(ray).HasValue)
            {
                intersection = default(BlockIntersection);
                return false;
            }
            intersection = default(BlockIntersection);
            return true;
        }

        public override void Remove(byte x, byte y, byte z)
        {
            m_Grid[x][y][z] = BlockData.Empty;
        }

        #endregion ======== 继承实现 ========
    }
}
