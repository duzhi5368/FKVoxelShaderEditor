//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    摄像机状态
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class CameraState
    {
        public enum ENUM_CameraType
        {
            eCT_Static = 0,
            eCT_AutoRotating = 1,
            eCT_Front = 2,
            eCT_Back = 3,
        }
        public ENUM_CameraType CameraType { get; set; }

        public CameraState()
        {

        }
    }
}
