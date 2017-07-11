//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    特效部分协助函数
//-------------------------------------------------
using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Reflection;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public static class EffectHelper
    {
        public static readonly int ShaderProfileType = 0;
        static EffectHelper()
        {
            ShaderProfileType = GetShaderProfileType();
        }
        // 获取当前Shader类型 ， 返回0表示OpenGL,返回1表示DirectX
        private static int GetShaderProfileType()
        {
            var mgAssembly = Assembly.GetAssembly(typeof(Game));
            var shaderType = mgAssembly.GetType("Microsoft.Xna.Framework.Graphics.Shader");
            var profileProperty = shaderType.GetProperty("Profile");
            return (int)profileProperty.GetValue(null);
        }

        public static bool IsUsingDX()
        {
            return (ShaderProfileType == 1);
        }
        public static bool IsUsingOpenGL()
        {
            return (ShaderProfileType == 0);
        }

        public static byte[] LoadShaderBytes(string strShaderName)
        {
            var ShaderExtension = (IsUsingDX() ? ".dx11" : ".ogl") + ".mgfxo";
            var fullname = "FKVoxelEngine.Assets.Shaders." + strShaderName + ShaderExtension;
            var stream = typeof(EffectHelper).Assembly.GetManifestResourceStream(fullname);
            if (stream == null)
                throw new ArgumentException($"Cannot find effect with name {strShaderName}", nameof(strShaderName));

            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
