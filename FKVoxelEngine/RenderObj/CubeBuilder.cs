//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    立方体对象
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public static class CubeBuilder
    {
        private static VertexPosition[] m_VectexPosition;
        private static VertexWithNormal[] m_VertexNormal;
        private static VertexWithNormalColor[] m_VertexNormalColor;

        private static VertexBuffer m_NormalBuffer;
        private static IndexBuffer m_ShortIndexBuffer;

        public static VertexPosition[] GetPosition(bool bNeedCopy = false)
        {
            if (m_VectexPosition == null)
            {
                m_VectexPosition = new[]
                {
                    // Front
                    new VertexPosition(new Vector3(-0.5f, -0.5f, -0.5f)),
                    new VertexPosition(new Vector3(0.5f, -0.5f, -0.5f)),
                    new VertexPosition(new Vector3(0.5f, 0.5f, -0.5f)),
                    new VertexPosition(new Vector3(-0.5f, 0.5f, -0.5f)),

                    // Back
                    new VertexPosition(new Vector3(-0.5f, -0.5f, 0.5f)),
                    new VertexPosition(new Vector3(0.5f, -0.5f, 0.5f)),
                    new VertexPosition(new Vector3(0.5f, 0.5f, 0.5f)),
                    new VertexPosition(new Vector3(-0.5f, 0.5f, 0.5f)),

                    // Top
                    new VertexPosition(new Vector3(-0.5f, -0.5f, -0.5f)),
                    new VertexPosition(new Vector3(0.5f, -0.5f, -0.5f)),
                    new VertexPosition(new Vector3(0.5f, -0.5f, 0.5f)),
                    new VertexPosition(new Vector3(-0.5f, -0.5f, 0.5f)),

                    // Bottom
                    new VertexPosition(new Vector3(-0.5f, 0.5f, -0.5f)),
                    new VertexPosition(new Vector3(0.5f, 0.5f, -0.5f)),
                    new VertexPosition(new Vector3(0.5f, 0.5f, 0.5f)),
                    new VertexPosition(new Vector3(-0.5f, 0.5f, 0.5f)),

                    // Left
                    new VertexPosition(new Vector3(-0.5f, -0.5f, -0.5f)),
                    new VertexPosition(new Vector3(-0.5f, -0.5f, 0.5f)),
                    new VertexPosition(new Vector3(-0.5f, 0.5f, 0.5f)),
                    new VertexPosition(new Vector3(-0.5f, 0.5f, -0.5f)),

                    // Right
                    new VertexPosition(new Vector3(0.5f, -0.5f, -0.5f)),
                    new VertexPosition(new Vector3(0.5f, -0.5f, 0.5f)),
                    new VertexPosition(new Vector3(0.5f, 0.5f, 0.5f)),
                    new VertexPosition(new Vector3(0.5f, 0.5f, -0.5f)),
                };
            }
            return bNeedCopy ? m_VectexPosition.Copy() : m_VectexPosition;
        }
        public static VertexPosition[] GetPosition(Vector3 position)
        {
            return new[]
            {
                // Front
                new VertexPosition(position + new Vector3(-0.5f, -0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(0.5f, -0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(0.5f, 0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(-0.5f, 0.5f, -0.5f)),

                // Back
                new VertexPosition(position + new Vector3(-0.5f, -0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(0.5f, -0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(0.5f, 0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(-0.5f, 0.5f, 0.5f)),

                // Top
                new VertexPosition(position + new Vector3(-0.5f, -0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(0.5f, -0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(0.5f, -0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(-0.5f, -0.5f, 0.5f)),

                // Bottom
                new VertexPosition(position + new Vector3(-0.5f, 0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(0.5f, 0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(0.5f, 0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(-0.5f, 0.5f, 0.5f)),

                // Left
                new VertexPosition(position + new Vector3(-0.5f, -0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(-0.5f, -0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(-0.5f, 0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(-0.5f, 0.5f, -0.5f)),

                // Right
                new VertexPosition(position + new Vector3(0.5f, -0.5f, -0.5f)),
                new VertexPosition(position + new Vector3(0.5f, -0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(0.5f, 0.5f, 0.5f)),
                new VertexPosition(position + new Vector3(0.5f, 0.5f, -0.5f)),
            };
        }

        public static VertexWithNormal[] GetNormal(bool bNeedCopy = false)
        {
            if (m_VertexNormal == null)
            {
                m_VertexNormal = new[]
                {
                    // Front
                    new VertexWithNormal(new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitZ),
                    new VertexWithNormal(new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitZ),
                    new VertexWithNormal(new Vector3(0.5f, 0.5f, -0.5f), -Vector3.UnitZ),
                    new VertexWithNormal(new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitZ),

                    // Back
                    new VertexWithNormal(new Vector3(-0.5f, -0.5f, 0.5f), Vector3.UnitZ),
                    new VertexWithNormal(new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitZ),
                    new VertexWithNormal(new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitZ),
                    new VertexWithNormal(new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitZ),

                    // Top
                    new VertexWithNormal(new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitY),
                    new VertexWithNormal(new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitY),
                    new VertexWithNormal(new Vector3(0.5f, -0.5f, 0.5f), -Vector3.UnitY),
                    new VertexWithNormal(new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitY),

                    // Bottom
                    new VertexWithNormal(new Vector3(-0.5f, 0.5f, -0.5f), Vector3.UnitY),
                    new VertexWithNormal(new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitY),
                    new VertexWithNormal(new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitY),
                    new VertexWithNormal(new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitY),

                    // Left
                    new VertexWithNormal(new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitX),
                    new VertexWithNormal(new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitX),
                    new VertexWithNormal(new Vector3(-0.5f, 0.5f, 0.5f), -Vector3.UnitX),
                    new VertexWithNormal(new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitX),

                    // Right
                    new VertexWithNormal(new Vector3(0.5f, -0.5f, -0.5f), Vector3.UnitX),
                    new VertexWithNormal(new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitX),
                    new VertexWithNormal(new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitX),
                    new VertexWithNormal(new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitX),
                };
            }

            return bNeedCopy ? m_VertexNormal.Copy() : m_VertexNormal;
        }
        public static VertexWithNormal[] GetNormal(Vector3 position)
        {
            return new[]
            {
                // Front
                new VertexWithNormal(position + new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitZ),
                new VertexWithNormal(position + new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitZ),
                new VertexWithNormal(position + new Vector3(0.5f, 0.5f, -0.5f), -Vector3.UnitZ),
                new VertexWithNormal(position + new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitZ),

                // Back
                new VertexWithNormal(position + new Vector3(-0.5f, -0.5f, 0.5f), Vector3.UnitZ),
                new VertexWithNormal(position + new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitZ),
                new VertexWithNormal(position + new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitZ),
                new VertexWithNormal(position + new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitZ),

                // Top
                new VertexWithNormal(position + new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitY),
                new VertexWithNormal(position + new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitY),
                new VertexWithNormal(position + new Vector3(0.5f, -0.5f, 0.5f), -Vector3.UnitY),
                new VertexWithNormal(position + new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitY),

                // Bottom
                new VertexWithNormal(position + new Vector3(-0.5f, 0.5f, -0.5f), Vector3.UnitY),
                new VertexWithNormal(position + new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitY),
                new VertexWithNormal(position + new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitY),
                new VertexWithNormal(position + new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitY),

                // Left
                new VertexWithNormal(position + new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitX),
                new VertexWithNormal(position + new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitX),
                new VertexWithNormal(position + new Vector3(-0.5f, 0.5f, 0.5f), -Vector3.UnitX),
                new VertexWithNormal(position + new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitX),

                // Right
                new VertexWithNormal(position + new Vector3(0.5f, -0.5f, -0.5f), Vector3.UnitX),
                new VertexWithNormal(position + new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitX),
                new VertexWithNormal(position + new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitX),
                new VertexWithNormal(position + new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitX),
            };
        }
        public static VertexBuffer GetNormalBuffer(GraphicsDevice graphicsDevice)
        {
            if (m_NormalBuffer == null)
            {
                m_NormalBuffer = new VertexBuffer(graphicsDevice, VertexWithNormal.VertexDeclaration,
                    24, BufferUsage.WriteOnly);
                VertexWithNormal[] normalInfos = GetNormal();
                m_NormalBuffer.SetData(normalInfos);
            }
            return m_NormalBuffer;
        }

        public static VertexWithNormalColor[] GetNormalColor()
        {
            if (m_VertexNormalColor == null)
            {
                m_VertexNormalColor = new[]
                {
                    // Front
                    new VertexWithNormalColor(new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitZ, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitZ, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, 0.5f, -0.5f), -Vector3.UnitZ, Color.White),
                    new VertexWithNormalColor(new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitZ, Color.White),

                    // Back
                    new VertexWithNormalColor(new Vector3(-0.5f, -0.5f, 0.5f), Vector3.UnitZ, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitZ, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitZ, Color.White),
                    new VertexWithNormalColor(new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitZ, Color.White),

                    // Top
                    new VertexWithNormalColor(new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitY, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitY, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, -0.5f, 0.5f), -Vector3.UnitY, Color.White),
                    new VertexWithNormalColor(new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitY, Color.White),

                    // Bottom
                    new VertexWithNormalColor(new Vector3(-0.5f, 0.5f, -0.5f), Vector3.UnitY, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitY, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitY, Color.White),
                    new VertexWithNormalColor(new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitY, Color.White),

                    // Left
                    new VertexWithNormalColor(new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitX, Color.White),
                    new VertexWithNormalColor(new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitX, Color.White),
                    new VertexWithNormalColor(new Vector3(-0.5f, 0.5f, 0.5f), -Vector3.UnitX, Color.White),
                    new VertexWithNormalColor(new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitX, Color.White),

                    // Right
                    new VertexWithNormalColor(new Vector3(0.5f, -0.5f, -0.5f), Vector3.UnitX, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitX, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitX, Color.White),
                    new VertexWithNormalColor(new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitX, Color.White),
                };
            }
            return m_VertexNormalColor;
        }
        public static VertexWithNormalColor[] GetNormalColor(Vector3 position, Color? color = null)
        {
            var c = color ?? Color.White;

            return new[]
            {
                // Front
                new VertexWithNormalColor(position + new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitZ, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitZ, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, 0.5f, -0.5f), -Vector3.UnitZ, c),
                new VertexWithNormalColor(position + new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitZ, c),

                // Back
                new VertexWithNormalColor(position + new Vector3(-0.5f, -0.5f, 0.5f), Vector3.UnitZ, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitZ, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitZ, c),
                new VertexWithNormalColor(position + new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitZ, c),

                // Top
                new VertexWithNormalColor(position + new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitY, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, -0.5f, -0.5f), -Vector3.UnitY, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, -0.5f, 0.5f), -Vector3.UnitY, c),
                new VertexWithNormalColor(position + new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitY, c),

                // Bottom
                new VertexWithNormalColor(position + new Vector3(-0.5f, 0.5f, -0.5f), Vector3.UnitY, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitY, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitY, c),
                new VertexWithNormalColor(position + new Vector3(-0.5f, 0.5f, 0.5f), Vector3.UnitY, c),

                // Left
                new VertexWithNormalColor(position + new Vector3(-0.5f, -0.5f, -0.5f), -Vector3.UnitX, c),
                new VertexWithNormalColor(position + new Vector3(-0.5f, -0.5f, 0.5f), -Vector3.UnitX, c),
                new VertexWithNormalColor(position + new Vector3(-0.5f, 0.5f, 0.5f), -Vector3.UnitX, c),
                new VertexWithNormalColor(position + new Vector3(-0.5f, 0.5f, -0.5f), -Vector3.UnitX, c),

                // Right
                new VertexWithNormalColor(position + new Vector3(0.5f, -0.5f, -0.5f), Vector3.UnitX, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, -0.5f, 0.5f), Vector3.UnitX, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, 0.5f, 0.5f), Vector3.UnitX, c),
                new VertexWithNormalColor(position + new Vector3(0.5f, 0.5f, -0.5f), Vector3.UnitX, c),
            };
        }

        public static short[] GetShortIndices(int nStart = 0)
        {
            return new[]
            {
                // Front
                (short) (nStart + 0), (short) (nStart + 1), (short) (nStart + 2),
                (short) (nStart + 2), (short) (nStart + 3), (short) (nStart + 0),

                // Back
                (short) (nStart + 6), (short) (nStart + 5), (short) (nStart + 4),
                (short) (nStart + 4), (short) (nStart + 7), (short) (nStart + 6),

                // Top
                (short) (nStart + 10), (short) (nStart + 9), (short) (nStart + 8),
                (short) (nStart + 8), (short) (nStart + 11), (short) (nStart + 10),

                // Bottom
                (short) (nStart + 12), (short) (nStart + 13), (short) (nStart + 14),
                (short) (nStart + 14), (short) (nStart + 15), (short) (nStart + 12),

                // Left
                (short) (nStart + 18), (short) (nStart + 17), (short) (nStart + 16),
                (short) (nStart + 16), (short) (nStart + 19), (short) (nStart + 18),

                // Right
                (short) (nStart + 20), (short) (nStart + 21), (short) (nStart + 22),
                (short) (nStart + 22), (short) (nStart + 23), (short) (nStart + 20),
            };
        }
        public static IndexBuffer GetShortIndexBuffer(GraphicsDevice graphicsDevice)
        {
            if (m_ShortIndexBuffer == null)
            {
                m_ShortIndexBuffer = new IndexBuffer(graphicsDevice, IndexElementSize.SixteenBits,
                    36, BufferUsage.WriteOnly);
                m_ShortIndexBuffer.SetData(GetShortIndices());
            }
            return m_ShortIndexBuffer;
        }

        public static int[] GetIndices(int nStart = 0)
        {
            return new[]
            {
                // Front
                nStart + 0, nStart + 1, nStart + 2,
                nStart + 2, nStart + 3, nStart + 0,

                // Back
                nStart + 6, nStart + 5, nStart + 4,
                nStart + 4, nStart + 7, nStart + 6,

                // Top
                nStart + 10, nStart + 9, nStart + 8,
                nStart + 8, nStart + 11, nStart + 10,

                // Bottom
                nStart + 12, nStart + 13, nStart + 14,
                nStart + 14, nStart + 15, nStart + 12,

                // Left
                nStart + 18, nStart + 17, nStart + 16,
                nStart + 16, nStart + 19, nStart + 18,

                // Right
                nStart + 20, nStart + 21, nStart + 22,
                nStart + 22, nStart + 23, nStart + 20,
            };
        }
        public static Vector3[] GetNormals()
        {
            return new[]
            {
                Vector3.UnitX,
                -Vector3.UnitX,
                Vector3.UnitY,
                -Vector3.UnitY,
                Vector3.UnitZ,
                -Vector3.UnitZ,
            };
        }
    }
}
