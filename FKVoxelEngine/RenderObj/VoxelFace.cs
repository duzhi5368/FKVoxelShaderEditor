//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    体素 面
//-------------------------------------------------
namespace FKVoxelEngine
{
    public struct VoxelFace
    {
        public readonly byte Index;

        public bool IsEmpty => Index == 0;

        public VoxelFace(BlockData data)
        {
            Index = data.Index;
        }

        public static VoxelFace Empty => new VoxelFace(default(BlockData));

        public bool Equals(VoxelFace other)
        {
            return Index == other.Index;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VoxelFace && Equals((VoxelFace)obj);
        }

        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }

        public static bool operator ==(VoxelFace left, VoxelFace right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VoxelFace left, VoxelFace right)
        {
            return !left.Equals(right);
        }
    }
}
