//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170711
// Desc:    轨道摄像机
//-------------------------------------------------
using Microsoft.Xna.Framework;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class OrbitCamera : Camera
    {
        private Vector3 m_targetPos;
        private float m_fTargetDistance;
        public Vector3 TargetPosition
        {
            get { return m_targetPos; }
            set { m_targetPos = value; }
        }

        public float TargetDistance
        {
            get { return m_fTargetDistance; }
            set { m_fTargetDistance = value; }
        }

        public OrbitCamera(Game gameObj)
            : base(gameObj)
        {
            m_fTargetDistance = 3;
        }

        public override void Update()
        {
            Matrix rotPitch = Matrix.CreateRotationX(m_AngleRadian.X); //Pitch
            Matrix rotYaw = Matrix.CreateRotationY(m_AngleRadian.Y);   //yaw
            Vector3 v = Vector3.Backward * TargetDistance;
            v = Vector3.Transform(v, rotPitch);
            v = Vector3.Transform(v, rotYaw);

            Position = TargetPosition + v;

            Ratio = m_GameObj.GraphicsDevice.Viewport.AspectRatio;
            float fFOV = 100.0f;
            m_Projection = Matrix.CreatePerspectiveFieldOfView((fFOV / 2.0f) * MathHelper.Pi / 180.0f, Ratio, 0.1f, 500.0f);
            m_View = Matrix.CreateLookAt(Position, TargetPosition, Vector3.Up);
        }
    }
}
