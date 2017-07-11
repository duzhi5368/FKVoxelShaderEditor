//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    带索引和法线信息的顶点（受光照）
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
//-------------------------------------------------
namespace FKVoxelEngine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
    public struct VertexWithIndexNormal : IVertexType
    {
        #region ======== 变量声明 ========

        public byte X;
        public byte Y;
        public byte Z;
        public byte Index;
        public byte Normal; // TODO: 这里法线仅为一位Byte，不是一个Vector3

        #endregion ======== 变量声明 ========

        #region ======== 构造函数 ========
        public VertexWithIndexNormal(byte x, byte y, byte z, byte index, byte normal)
        {
            X = x;
            Y = y;
            Z = z;
            Index = index;
            Normal = normal;
        }
        public VertexWithIndexNormal(byte[] bytes, byte normal)
        {
            X = bytes[0];
            Y = bytes[1];
            Z = bytes[2];
            Index = bytes[3];
            Normal = normal;
        }

        #endregion ======== 构造函数 ========

        #region ======== 静态函数 ========

        public static readonly VertexDeclaration VertexDeclaration;     // 顶点格式声明，静态唯一

        public static bool operator ==(VertexWithIndexNormal a, VertexWithIndexNormal b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(VertexWithIndexNormal a, VertexWithIndexNormal b)
        {
            return !(a == b);
        }

        static VertexWithIndexNormal()
        {
            var elements = new[]
            {
                new VertexElement(0, VertexElementFormat.Byte4, VertexElementUsage.Position, 0),
                new VertexElement(4, VertexElementFormat.Byte4, VertexElementUsage.Normal, 0),
            };
            VertexDeclaration = new VertexDeclaration(elements);
        }

        #endregion ======== 静态函数 ========

        #region ======== 便捷接口 ========

        /// <summary>
        /// 获取点位置
        /// </summary>
        public Vector3 Position
        {
            get { return new Vector3(X, Y, Z); }
            set
            {
                X = (byte)value.X;
                Y = (byte)value.Y;
                Z = (byte)value.Z;
            }
        }
        /// <summary>
        /// 是否是空点/无效点
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (Index == 0);
        }

        #endregion ======== 便捷接口 ========

        #region ======== 继承实现 ========

        /// <summary>
        /// 获取顶点声明
        /// </summary>
        VertexDeclaration IVertexType.VertexDeclaration
        {
            get
            {
                return VertexDeclaration;
            }
        }
        /// <summary>
        /// 格式化Debug字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Position: ({X}, {Y}, {Z}), Index: {Index}, Normal: {Normal}";
        }
        /// <summary>
        /// 比较一个对象是否相同
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VertexWithIndexNormal && Equals((VertexWithIndexNormal)obj);
        }
        /// <summary>
        /// 获取本顶点单元Hash值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked // 无需检查数据溢出
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ Index.GetHashCode();
                hashCode = (hashCode * 397) ^ Normal.GetHashCode();
                return hashCode;
            }
        }

        #endregion ======== 继承实现 ========

        #region ======== 核心函数 ========

        /// <summary>
        /// 比较两个点
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        private bool Equals(VertexWithIndexNormal other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && Index == other.Index && Normal == other.Normal;
        }

        #endregion ======== 核心函数 ========
    }
}
