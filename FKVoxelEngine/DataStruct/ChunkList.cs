//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    块 列表
//-------------------------------------------------
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class ChunkList
    {
        public readonly List<Chunk> m_ChunksList;

        public ChunkList()
        {
            m_ChunksList = new List<Chunk>();
        }
        public ChunkList(List<Chunk> chunks)
        {
            m_ChunksList = chunks;
        }

        public void Draw(Effect curEffect)
        {
            foreach (var chunk in m_ChunksList)
            {
                chunk.Draw(curEffect);
            }
        }
        public Chunk this[int i] => m_ChunksList[i];
    }
}
