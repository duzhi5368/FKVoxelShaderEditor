//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    MagicaVox格式加载器
//-------------------------------------------------
using Microsoft.Xna.Framework;
//-------------------------------------------------
namespace MagicaVoxLoader
{
    public class VoxContent
    {
        public int VoxelCount;
        public int SizeX;
        public int SizeY;
        public int SizeZ;
        public MagicaVoxel[] Voxels;
        public Color[] Palette;
    }
}
