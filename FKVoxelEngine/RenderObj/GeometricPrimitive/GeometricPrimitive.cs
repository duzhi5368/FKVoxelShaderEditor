//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    基本渲染单元模型 基类
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public abstract class GeometricPrimitive : IDisposable
    {
        #region ======== 成员变量 ========

        List<VertexWithNormal> vertices = new List<VertexWithNormal>();
        List<ushort> indices = new List<ushort>();
        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;
        BasicEffect basicEffect;

        #endregion ======== 成员变量 ========

        protected void AddVertex(Vector3 position, Vector3 normal)
        {
            vertices.Add(new VertexWithNormal(position, normal));
        }

        protected void AddIndex(int index)
        {
            if (index > ushort.MaxValue)
                throw new ArgumentOutOfRangeException("index");

            indices.Add((ushort)index);
        }

        protected int CurrentVertex
        {
            get { return vertices.Count; }
        }

        protected void InitializePrimitive(GraphicsDevice graphicsDevice)
        {
            // 创建顶点
            vertexBuffer = new VertexBuffer(graphicsDevice,
                                            typeof(VertexWithNormal),
                                            vertices.Count, BufferUsage.None);

            vertexBuffer.SetData(vertices.ToArray());
            // 创建索引
            indexBuffer = new IndexBuffer(graphicsDevice, typeof(ushort),
                                          indices.Count, BufferUsage.None);

            indexBuffer.SetData(indices.ToArray());
            // 创建基本效果
            basicEffect = new BasicEffect(graphicsDevice);

            basicEffect.EnableDefaultLighting();
        }

        ~GeometricPrimitive()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (vertexBuffer != null)
                    vertexBuffer.Dispose();

                if (indexBuffer != null)
                    indexBuffer.Dispose();

                if (basicEffect != null)
                    basicEffect.Dispose();
            }
        }

        /// <summary>
        /// 实际绘制
        /// </summary>
        /// <param name="effect"></param>
        public void Draw(Effect effect)
        {
            if (effect == null)
                return;
            GraphicsDevice graphicsDevice = effect.GraphicsDevice;

            graphicsDevice.SetVertexBuffer(vertexBuffer);
            graphicsDevice.Indices = indexBuffer;

            foreach (EffectPass effectPass in effect.CurrentTechnique.Passes)
            {
                effectPass.Apply();

                int primitiveCount = indices.Count / 3;

                graphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,
                                                     vertices.Count, 0, primitiveCount);

            }
        }

        public void Draw(Matrix world, Matrix view, Matrix projection, Color color)
        {
            basicEffect.World = world;
            basicEffect.View = view;
            basicEffect.Projection = projection;
            basicEffect.DiffuseColor = color.ToVector3();
            basicEffect.Alpha = color.A / 255.0f;

            GraphicsDevice device = basicEffect.GraphicsDevice;
            device.DepthStencilState = DepthStencilState.Default;

            if (color.A < 255)
            {
                device.BlendState = BlendState.AlphaBlend;
            }
            else
            {
                device.BlendState = BlendState.Opaque;
            }

            Draw(basicEffect);
        }

    }
}
