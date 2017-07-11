//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    Mesh优化组合
// http://0fps.wordpress.com/2012/06/30/meshing-in-a-minecraft-game/
// https://www.giawa.com/journal-entry-6-greedy-mesh-optimization/
// https://github.com/mikolalysenko/mikolalysenko.github.com/blob/gh-pages/MinecraftMeshes/js/greedy.js
//-------------------------------------------------
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public static class GreedyMesh
    {
        #region ======== 对外接口 ========

        public static void Generate<T>(BlockContainer blocks, Func<int[], int[], int[], int, bool, VoxelFace, bool, IEnumerable<T>> createQuad,
    out T[] vertices, out int[] indices, bool cw = false) where T : IVertexType
        {
            try
            {
                var verts = new List<T>();
                var inds = new List<int>();

                int[] size = { blocks.SizeX(), blocks.SizeY(), blocks.SizeZ() };
                // loop over the three directions; x -> 0, y -> 1, z -> 2
                for (var direction = 0; direction < 3; direction++)
                {
                    // u and v are the other two directions
                    var u = (direction + 1) % 3;
                    var v = (direction + 2) % 3;

                    // pos holds the current position in the grid
                    var pos = new int[3];
                    // 1 for the current direction and 0 for others, unit vector of the axis we're handling
                    var nextPos = new int[3];
                    // contains the rendering data for each face in the current layers, a layer being a slice of the grid; Note that this is linearized
                    var backFaces = new VoxelFace[blocks.GetBlockContainerSize(u) * blocks.GetBlockContainerSize(v)];
                    var frontFaces = new VoxelFace[blocks.GetBlockContainerSize(u) * blocks.GetBlockContainerSize(v)];

                    nextPos[direction] = 1;

                    // outer loop goes through all layers
                    // we start at -1 because we check for faces *between* blocks and have to get the outer faces too
                    for (pos[direction] = -1; pos[direction] < blocks.GetBlockContainerSize(direction); pos[direction]++)
                    {
                        var noBack = true;
                        var noFront = true;
                        // Get all faces that need to be rendered in the current layer (front and back seperately)
                        for (pos[v] = 0; pos[v] < size[v]; pos[v]++)
                        {
                            for (pos[u] = 0; pos[u] < size[u]; pos[u]++)
                            {
                                // if this block is visible and the one behind it is not we need to render the backface of the current block
                                // if this one is not visible but the one behind it is, we need to render the frontface of the 'behind' block
                                var index = pos[v] * size[u] + pos[u];
                                var current = pos[direction] >= 0 && !blocks[(byte)pos[0], (byte)pos[1], (byte)pos[2]].IsEmpty();
                                var behind = pos[direction] + 1 < blocks.GetBlockContainerSize(direction) &&
                                             !blocks[(byte)(pos[0] + nextPos[0]), (byte)(pos[1] + nextPos[1]), (byte)(pos[2] + nextPos[2])].IsEmpty();

                                if (current && !behind)
                                {
                                    backFaces[index] = new VoxelFace(blocks[(byte)pos[0], (byte)pos[1], (byte)pos[2]]);
                                    noBack = false;
                                }
                                else if (!current && behind)
                                {
                                    frontFaces[index] = new VoxelFace(blocks[(byte)(pos[0] + nextPos[0]), (byte)(pos[1] + nextPos[1]), (byte)(pos[2] + nextPos[2])]);
                                    noFront = false;
                                }
                            }
                        }

                        // Then process both layers to build quads
                        if (!noFront)
                            ProcessLayer(frontFaces, createQuad, verts, inds, pos[direction] + 1, direction, size, cw, false);
                        if (!noBack)
                            ProcessLayer(backFaces, createQuad, verts, inds, pos[direction] + 1, direction, size, !cw, true);
                    }
                }

                vertices = verts.ToArray();
                indices = inds.ToArray();
            }
            catch (Exception e)
            {
                throw new Exception("Generate GreedyMesh failed!\r\n " + e.ToString());
            }
        }

        #endregion ======== 对外接口 ========

        #region ======== 核心函数 ========

        private static int GetBlockContainerSize(this BlockContainer container, int dimension)
        {
            switch (dimension)
            {
                case 0:
                    return container.SizeX();
                case 1:
                    return container.SizeY();
                case 2:
                    return container.SizeZ();
                default:
                    throw new ArgumentOutOfRangeException(nameof(dimension));
            }
        }

        private static void ProcessLayer<T>(
            VoxelFace[] faces, Func<int[], int[], int[], int, bool, VoxelFace, bool, IEnumerable<T>> createQuad,
            List<T> vertices, List<int> indices,
            int depth, int dir, int[] size, bool cw, bool positiveNormal) where T : IVertexType
        {
            var u = (dir + 1) % 3;
            var v = (dir + 2) % 3;


            // Generate mesh for mask using lexicographic ordering
            for (var v0 = 0; v0 < size[v]; v0++)
            {
                for (var u0 = 0; u0 < size[u]; u0++)
                {
                    var n = v0 * size[u] + u0;
                    if (faces[n].IsEmpty) continue;

                    var currentFace = faces[n];
                    // Compute width
                    var u1 = 1;
                    while (u0 + u1 < size[u] && currentFace == faces[n + u1]) u1++;

                    // Compute height
                    int v1;
                    for (v1 = 1; v0 + v1 < size[v]; v1++)
                    {
                        for (var k = 0; k < u1; k++)
                        {
                            if (faces[n + k + v1 * size[u]] != currentFace)
                                goto EndLoop;
                        }
                    }

                    EndLoop:

                    // contains starting position
                    var pos = new int[3];
                    pos[dir] = depth;
                    pos[u] = u0;
                    pos[v] = v0;
                    // contains width and height
                    var du = new int[3];
                    du[u] = u1;
                    var dv = new int[3];
                    dv[v] = v1;

                    // Add quad
                    indices.AddRange(CreateQuadIndices(vertices.Count, cw));
                    var quadVerts = createQuad(pos, du, dv, dir, positiveNormal, currentFace, cw);
                    vertices.AddRange(quadVerts);

                    // Zero-out mask
                    for (var l = 0; l < v1; ++l)
                        for (var k = 0; k < u1; ++k)
                            faces[n + k + l * size[u]] = VoxelFace.Empty;

                    u0 += u1 - 1;
                }
            }
        }

        private static int[] CreateQuadIndices(int start, bool cw)
        {
            if (cw)
            {
                return new[]
                {
                    start, start + 3, start + 2,
                    start + 2, start + 1, start
                };
            }
            return new[]
            {
                start, start + 1, start + 2,
                start + 2, start + 3, start
            };
        }

        #endregion ======== 核心函数 ========
    }
}
