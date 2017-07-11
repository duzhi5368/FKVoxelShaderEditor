//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    带法线和颜色信息的顶点
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
//-------------------------------------------------
namespace FKVoxelEngine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class VertexWithNormalColor : IVertexType
    {
        #region ======== 变量声明 ========

        public Vector3 Position = Vector3.Zero;
        public Vector3 Normal = Vector3.Zero;
        public Color Color;

        #endregion ======== 变量声明 ========

        #region ======== 构造函数 ========
        public VertexWithNormalColor(Vector3 position, Vector3 normal, Color color)
        {
            Position = position;
            Normal = normal;
            Color = color;
        }

        #endregion ======== 构造函数 ========

        #region ======== 静态函数 ========

        public static readonly VertexDeclaration VertexDeclaration;
        public static bool operator ==(VertexWithNormalColor left, VertexWithNormalColor right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VertexWithNormalColor left, VertexWithNormalColor right)
        {
            return !(left == right);
        }

        static VertexWithNormalColor()
        {
            var elements = new[]
            {
                new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
                new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
                new VertexElement(24, VertexElementFormat.Color, VertexElementUsage.Color, 0),
            };
            VertexDeclaration = new VertexDeclaration(elements);
        }

        #endregion ======== 静态函数 ========

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
            return "{{Position:" + Position.ToString() + " Normal:" + Normal.ToString() + " Color:" + Color.ToString() + "}}";
        }
        /// <summary>
        /// 比较两个点
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VertexWithNormalColor && Equals((VertexWithNormalColor)obj);
        }
        /// <summary>
        /// 获取Hash值
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Position.GetHashCode();
                hashCode = (hashCode * 397) ^ Normal.GetHashCode();
                hashCode = (hashCode * 397) ^ Color.GetHashCode();
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
        private bool Equals(VertexWithNormalColor other)
        {
            return Position.Equals(other.Position) && Normal.Equals(other.Normal) && Color.Equals(other.Color);
        }

        #endregion ======== 核心函数 ========
    }
}
