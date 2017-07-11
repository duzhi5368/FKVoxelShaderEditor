//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    Block 交集检测
//-------------------------------------------------
using Microsoft.Xna.Framework;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class BlockIntersection
    {
        public readonly BlockData BlockData;        // 将被检测的Block
        public readonly Vector3 Entry;              // 检测射线起点
        public readonly Vector3 Exit;               // 检测射线终点

        public bool Empty => BlockData.Index == 0;

        public BlockIntersection(BlockData blockData, Vector3 entry, Vector3 exit)
        {
            BlockData = blockData;
            Entry = entry;
            Exit = exit;
        }
    }
}
