//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    基本渲染单元模型  空心圆环体
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class TorusPrimitive : GeometricPrimitive
    {
        public TorusPrimitive(GraphicsDevice graphicsDevice)
            : this(graphicsDevice, 1, 0.333f, 32)
        {
        }

        public TorusPrimitive(GraphicsDevice graphicsDevice,
                              float diameter, float thickness, int tessellation)
        {
            if (tessellation < 3)
                throw new ArgumentOutOfRangeException("tessellation");

            for (int i = 0; i < tessellation; i++)
            {
                float outerAngle = i * MathHelper.TwoPi / tessellation;

                Matrix transform = Matrix.CreateTranslation(diameter / 2, 0, 0) *
                                   Matrix.CreateRotationY(outerAngle);

                for (int j = 0; j < tessellation; j++)
                {
                    float innerAngle = j * MathHelper.TwoPi / tessellation;

                    float dx = (float)Math.Cos(innerAngle);
                    float dy = (float)Math.Sin(innerAngle);

                    Vector3 normal = new Vector3(dx, dy, 0);
                    Vector3 position = normal * thickness / 2;

                    position = Vector3.Transform(position, transform);
                    normal = Vector3.TransformNormal(normal, transform);

                    AddVertex(position, normal);

                    int nextI = (i + 1) % tessellation;
                    int nextJ = (j + 1) % tessellation;

                    AddIndex(i * tessellation + j);
                    AddIndex(i * tessellation + nextJ);
                    AddIndex(nextI * tessellation + j);

                    AddIndex(i * tessellation + nextJ);
                    AddIndex(nextI * tessellation + nextJ);
                    AddIndex(nextI * tessellation + j);
                }
            }

            InitializePrimitive(graphicsDevice);
        }
    }
}
