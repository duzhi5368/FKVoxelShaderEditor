//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170711
// Desc:    摄像机
//-------------------------------------------------
using Microsoft.Xna.Framework;
//-------------------------------------------------
namespace FKVoxelEngine
{
    public class Camera
    {
        #region ======== 成员变量 ========

        protected static    Camera s_ActiveCamera = null;

        protected Matrix    m_Projection = Matrix.Identity;
        protected Matrix    m_View = Matrix.Identity;
        protected Vector3   m_Position = new Vector3(0, 0, 1000);
        protected Vector3   m_AngleRadian = new Vector3();
        protected Game      m_GameObj = null;

        public float Ratio { get; set; }
        public float FOV { get; set; }
        public float OrthoWidth { get; set; }
        public float OrthoHeight { get; set; }

        #endregion ======== 成员变量 ========

        #region ======== 便捷接口 ========

        public static Camera ActiveCamera
        {
            get { return s_ActiveCamera; }
            set { s_ActiveCamera = value; }
        }

        public Matrix Projection
        {
            get { return m_Projection; }
            set { m_Projection = value; }
        }

        public Matrix View
        {
            get { return m_View; }
            set { m_View = value; }
        }

        public Vector3 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public Vector3 AngleDegree
        {
            get { return new Vector3(MathHelper.ToDegrees(m_AngleRadian.X), MathHelper.ToDegrees(m_AngleRadian.Y), MathHelper.ToDegrees(m_AngleRadian.Z)); }
            set { m_AngleRadian.X = MathHelper.ToRadians(value.X); m_AngleRadian.Y = MathHelper.ToRadians(value.Y); m_AngleRadian.Z = MathHelper.ToRadians(value.Z); }
        }

        public Vector3 AngleRadian
        {
            get { return m_AngleRadian; }
            set { m_AngleRadian = value; }
        }

        #endregion

        #region ==== 核心函数 ====

        public Camera(Game gameObj)
        {
            m_GameObj = gameObj;
            FOV = 100;
            if (ActiveCamera == null)
                ActiveCamera = this;
        }

        virtual public void Update()
        {
            Ratio = m_GameObj.GraphicsDevice.Viewport.AspectRatio;

            if (OrthoWidth != 0 && OrthoHeight != 0)
            {
                m_Projection = Matrix.CreateOrthographic(OrthoWidth, OrthoHeight, 1.0f, 500.0f);
            }
            else
            {
                m_Projection = Matrix.CreatePerspectiveFieldOfView((FOV / 2.0f) * MathHelper.Pi / 180.0f, Ratio, 1.0f, 500.0f); //1.74
            }

            // Update Matrix
            m_View.M11 = 1.00000000f;
            m_View.M12 = 0.00000000f;
            m_View.M13 = 0.00000000f;
            m_View.M14 = 0.00000000f;

            m_View.M21 = 0.00000000f;
            m_View.M22 = 1.00000000f;
            m_View.M23 = 0.00000000f;
            m_View.M24 = 0.00000000f;

            m_View.M31 = 0.00000000f;
            m_View.M32 = 0.00000000f;
            m_View.M33 = 1.00000000f;
            m_View.M44 = 0.00000000f;

            m_View.M41 = 0.00000000f;
            m_View.M42 = 0.00000000f;
            m_View.M43 = 0.00000000f;
            m_View.M44 = 1.00000000f;

            m_View *= Matrix.CreateTranslation(-m_Position);
            m_View *= Matrix.CreateRotationZ(m_AngleRadian.Z); //Roll
            m_View *= Matrix.CreateRotationY(m_AngleRadian.Y); //yaw
            m_View *= Matrix.CreateRotationX(m_AngleRadian.X); //Pitch
        }

        #endregion ==== 核心函数 ====
    }
}
