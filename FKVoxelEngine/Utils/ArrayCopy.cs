//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    数组拷贝
//-------------------------------------------------
using System;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public static class ArrayCopy
    {
        public static T[] Copy<T>(this T[] array)
        {
            var Copy = new T[array.Length];
            Array.Copy(array, Copy, array.Length);
            return Copy;
        }
    }
}
