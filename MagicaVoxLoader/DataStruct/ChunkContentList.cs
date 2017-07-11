//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    MagicaVox格式加载器
//-------------------------------------------------
using System.Collections.Generic;
//-------------------------------------------------
namespace MagicaVoxLoader
{
    public class ChunkContentList
    {
        public readonly List<ChunkContent> Chunks = new List<ChunkContent>();

        public void Add(ChunkContent chunk)
        {
            Chunks.Add(chunk);
        }

        public ChunkContent this[int i]
        {
            get { return Chunks[i]; }
        }
    }
}
