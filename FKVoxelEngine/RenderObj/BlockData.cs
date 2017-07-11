//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    Block 小块数据
//-------------------------------------------------
namespace FKVoxelEngine
{
    public struct BlockData
    {
        public byte Index;

        public BlockData(byte index)
        {
            Index = index;
        }

        public bool IsEmpty()
        {
            return Index == 0;
        }

        public static BlockData Empty => default(BlockData);
    }
}
