//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    块 对象渲染管理
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class PolygonChunkRenderer : ChunkRenderer
    {
        #region ======== 成员变量 ========

        private VertexWithIndexNormal[] m_Vertices;
        private int[]                   m_Indices;

        #endregion ======== 成员变量 ========

        #region ======== 构造函数 ========

        public PolygonChunkRenderer(GraphicsDevice graphicsDevice, Vector4[] palette) 
            : base(graphicsDevice, palette)
        {
        }

        #endregion ======== 构造函数 ========

        #region ======== 继承实现 ========

        protected override void InitInternal(Chunk chunk, VertexWithIndex[] blocks, int active, int maxBlocks)
        {
            GreedyMesh.Generate(chunk.Blocks, CreateQuad, out m_Vertices, out m_Indices);
        }

        protected override void RebuildInternal(int maxBlocks)
        {
            throw new NotImplementedException();
        }

        protected override void DrawInternal()
        {
            m_GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, m_Vertices,
                0, m_Vertices.Length, m_Indices, 0, m_Indices.Length / 3, VertexWithIndexNormal.VertexDeclaration);
        }

        public override void SetBlock(VertexWithIndex block, int index)
        {
            throw new NotImplementedException();
        }

        public override void RemoveBlock(int index)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_Vertices = null;
                m_Indices = null;
            }
        }

        protected override void PreDraw()
        {
            m_DefaultEffect.CurrentTechnique = m_DefaultEffect.MeshTechnique;
        }

        #endregion ======== 继承实现 ========

        #region ======== 核心函数 ========

        private IEnumerable<VertexWithIndexNormal> CreateQuad(int[] p, int[] du, int[] dv, 
            int normal, bool normalPos, VoxelFace voxelFace, bool backFace)
        {
            // 法线垂直于宽高面
            var norm = DirectionToFace(normal, normalPos);

            return new[]
            {
                new VertexWithIndexNormal((byte) p[0], (byte) p[1], (byte) p[2], voxelFace.Index, norm),
                new VertexWithIndexNormal((byte) (p[0] + du[0]), (byte) (p[1] + du[1]), (byte) (p[2] + du[2]), voxelFace.Index, norm),
                new VertexWithIndexNormal((byte) (p[0] + du[0] + dv[0]), (byte) (p[1] + du[1] + dv[1]), (byte) (p[2] + du[2] + dv[2]), voxelFace.Index, norm),
                new VertexWithIndexNormal((byte) (p[0] + dv[0]), (byte) (p[1] + dv[1]), (byte) (p[2] + dv[2]), voxelFace.Index, norm),
            };
        }
        

        private byte DirectionToFace(int direction, bool positive)
        {
            return (byte)(direction * 2 + (positive ? 0 : 1));
        }

        #endregion ======== 核心函数 ========
    }
}
