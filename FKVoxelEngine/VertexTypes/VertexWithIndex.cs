//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    带索引的顶点
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
//-------------------------------------------------
namespace FKVoxelEngine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class VertexWithIndex : IVertexType
    {
        #region ======== 变量声明 ========

            public byte X = 0;
            public byte Y = 0;
            public byte Z = 0;          // TODO: 坐标要不要调整为Vector3算了
            public byte Index = 0;

        #endregion ======== 变量声明 ========
    
        #region ======== 构造函数 ========

            public VertexWithIndex(byte x, byte y, byte z, byte index)
            {
                X = x;
                Y = y;
                Z = z;
                Index = index;
            }
            public VertexWithIndex(byte[] bytes)
            {
                X = bytes[0];
                Y = bytes[1];
                Z = bytes[2];
                Index = bytes[3];
            }
            public VertexWithIndex(uint packedValue) : this(
                    (byte)(packedValue & 0xFF),
                    (byte)((packedValue >> 8) & 0xFF),
                    (byte)((packedValue >> 16) & 0xFF),
                    (byte)((packedValue >> 24) & 0xFF))
            {
            }

        #endregion ======== 构造函数 ========
    
        #region ======== 静态函数 ========

            public static readonly VertexDeclaration VertexDeclaration;     // 顶点格式声明，静态唯一

            public static bool operator ==(VertexWithIndex a, VertexWithIndex b)
            {
                return a.Equals(b);
            }

            public static bool operator !=(VertexWithIndex a, VertexWithIndex b)
            {
                return !(a == b);
            }

            static VertexWithIndex()
            {
                var elements = new[]
                {
                    new VertexElement(0, VertexElementFormat.Byte4, VertexElementUsage.Position, 1)
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
                return $"Position: ({X}, {Y}, {Z}), Index: {Index}";
            }
            /// <summary>
            /// 比较一个对象是否相同
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is VertexWithIndex && Equals((VertexWithIndex)obj);
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
            private bool Equals(VertexWithIndex other)
            {
                return X == other.X && Y == other.Y && Z == other.Z && Index == other.Index;
            }

        #endregion ======== 核心函数 ========
    }
}
