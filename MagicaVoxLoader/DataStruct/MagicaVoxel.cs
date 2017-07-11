//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    MagicaVox格式加载器
//-------------------------------------------------

//-------------------------------------------------
namespace MagicaVoxLoader
{
    public class MagicaVoxel
    {
        public byte X;
        public byte Y;
        public byte Z;
        public byte ColorIndex;
        public bool IsEmpty => ColorIndex == 0;
    }
}
