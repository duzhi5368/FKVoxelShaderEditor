//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    MagicaVox格式加载器
//-------------------------------------------------
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
//-------------------------------------------------
namespace MagicaVoxLoader
{
    [ContentTypeWriter]
    public class ChunkCollectionWriter : ContentTypeWriter<ChunkContentList>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "FKVoxelEngine.ChunkListReader, FKVoxelEngine";
        }

        protected override void Write(ContentWriter output, ChunkContentList value)
        {
            var chunkWriter = new ChunkWriter();

            output.Write(value.Chunks.Count);

            foreach (var chunk in value.Chunks)
                output.WriteObject(chunk, chunkWriter);
        }
    }
}
