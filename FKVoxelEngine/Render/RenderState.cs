//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    渲染状态枚举
//-------------------------------------------------
using System;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class RenderState
    {
        public static readonly int RenderStateCount = Enum.GetValues(typeof(ENUM_RenderType)).Length;
        public enum ENUM_RenderType
        {
            eRS_SimpleRender = 0,
            eRS_ShadowMap = 1,
            eRS_Depth = 2,
        }

        public static string[] RenderTypeName =
        {
            "Simple",
            "ShaowMap",
            "Depth"
        };

        public ENUM_RenderType RenderType { get; set; }
        public RenderState()
        {

        }
    }
}
