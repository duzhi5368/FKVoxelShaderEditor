//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170708
// Desc:    光照计算增强类
//-------------------------------------------------
using Microsoft.Xna.Framework;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public static class LightViewExtensions
    {
        /// <summary>
        /// Creates the ViewProjection matrix from the perspective of the directional
        /// light using the cameras bounding frustum to determine what is visible 
        /// in the scene.
        /// </summary>
        /// <returns>The ViewProjection for the light</returns>
        public static Matrix GetViewProjectionMatrix(this Vector3 lightDirection, BoundingFrustum cameraFrustrum)
        {
            // Matrix with that will rotate in points the direction of the light
            var lightRotation = Matrix.CreateLookAt(Vector3.Zero,
                                                       lightDirection,
                                                       Vector3.Up);

            // Get the corners of the frustum
            var frustumCorners = cameraFrustrum.GetCorners();

            // Transform the positions of the corners into the direction of the light
            for (var i = 0; i < frustumCorners.Length; i++)
                frustumCorners[i] = Vector3.Transform(frustumCorners[i], lightRotation);

            // Find the smallest box around the points
            var lightBox = BoundingBox.CreateFromPoints(frustumCorners);

            var boxSize = lightBox.Max - lightBox.Min;
            var halfBoxSize = boxSize * 0.5f;

            // The position of the light should be in the center of the back
            // panel of the box. 
            var lightPosition = lightBox.Min + halfBoxSize;
            lightPosition.Z = lightBox.Min.Z;

            // We need the position back in world coordinates so we transform 
            // the light position by the inverse of the lights rotation
            lightPosition = Vector3.Transform(lightPosition, Matrix.Invert(lightRotation));

            // Create the view matrix for the light
            var lightView = Matrix.CreateLookAt(lightPosition, lightPosition + lightDirection, Vector3.Up);

            // Create the projection matrix for the light
            // The projection is orthographic since we are using a directional light
            var lightProjection = Matrix.CreateOrthographic(boxSize.X, boxSize.Y, -boxSize.Z, boxSize.Z);

            return lightView * lightProjection;

        }
    }
}
