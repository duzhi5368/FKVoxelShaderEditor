//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    包围盒增强类
//-------------------------------------------------
using Microsoft.Xna.Framework;
using System;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public static class BoundingBoxExtensions
    {
        /// <summary>
        /// 获取包围盒中心点
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static Vector3 GetCenter(this BoundingBox box)
        {
            var width = box.Max.X - box.Min.X;
            var height = box.Max.Y - box.Min.Y;
            var depth = box.Max.Z - box.Min.Z;
            return new Vector3(
                box.Min.X + width / 2.0f,
                box.Min.Y + height / 2.0f,
                box.Min.Z + depth / 2.0f
                );
        }

        /// <summary>
        /// 获取包围盒宽度
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static float GetWidth(this BoundingBox box)
        {
            return Math.Abs(box.Max.X - box.Min.X);
        }

        /// <summary>
        /// 获取包围盒高度
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static float GetHeight(this BoundingBox box)
        {
            return Math.Abs(box.Max.Y - box.Min.Y);
        }

        /// <summary>
        /// 获取包围盒深度
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static float GetDepth(this BoundingBox box)
        {
            return Math.Abs(box.Max.Z - box.Min.Z);
        }

        /// <summary>
        /// 获取包围盒尺寸
        /// </summary>
        /// <param name="box"></param>
        /// <param name="dim"></param>
        public static void GetDimensions(this BoundingBox box, ref Vector3 dim)
        {
            dim.X = box.GetWidth();
            dim.Y = box.GetHeight();
            dim.Z = box.GetDepth();
        }

        /// <summary>
        /// 获取包围盒尺寸
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public static Vector3 GetDimensions(this BoundingBox box)
        {
            var vec = new Vector3();
            box.GetDimensions(ref vec);
            return vec;
        }
    }
}
