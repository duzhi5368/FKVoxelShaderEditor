//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    自转义 vox 格式加载器
//-------------------------------------------------
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class ChunkListReader : ContentTypeReader<ChunkList>
    {
        protected override ChunkList Read(ContentReader reader, ChunkList existingInstance)
        {
            var count = reader.ReadInt32();

            var chunks = new List<Chunk>(count);

            for (var i = 0; i < count; i++)
            {
                var chunk = reader.ReadObject<Chunk>();
                chunks.Add(chunk);
            }

            return new ChunkList(chunks);
        }
    }
}
