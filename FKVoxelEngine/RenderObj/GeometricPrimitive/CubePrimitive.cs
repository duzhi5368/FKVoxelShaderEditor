//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    基本渲染单元模型  立方体
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class CubePrimitive : GeometricPrimitive
    {
        public CubePrimitive(GraphicsDevice graphicsDevice)
            : this(graphicsDevice, 1)
        {
        }

        public CubePrimitive(GraphicsDevice graphicsDevice, float size)
        {
            Vector3[] normals =
            {
                new Vector3(0, 0, 1),
                new Vector3(0, 0, -1),
                new Vector3(1, 0, 0),
                new Vector3(-1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, -1, 0),
            };

            foreach (Vector3 normal in normals)
            {
                Vector3 side1 = new Vector3(normal.Y, normal.Z, normal.X);
                Vector3 side2 = Vector3.Cross(normal, side1);

                AddIndex(CurrentVertex + 0);
                AddIndex(CurrentVertex + 1);
                AddIndex(CurrentVertex + 2);

                AddIndex(CurrentVertex + 0);
                AddIndex(CurrentVertex + 2);
                AddIndex(CurrentVertex + 3);

                AddVertex((normal - side1 - side2) * size / 2, normal);
                AddVertex((normal - side1 + side2) * size / 2, normal);
                AddVertex((normal + side1 + side2) * size / 2, normal);
                AddVertex((normal + side1 - side2) * size / 2, normal);
            }

            InitializePrimitive(graphicsDevice);
        }
    }
}
