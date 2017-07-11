//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170709
// Desc:    简单的辅助函数
//-------------------------------------------------
using System.Collections.Generic;
using System.IO;
using System.Linq;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public static class Utils
    {
        /// <summary>
        /// 读取工作目录下的Vox模型列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetModelFileNameList()
        {
            List<string> listRet = new List<string>();

            // 后面带 "\" 的工作路径
            string strWorkDir = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            strWorkDir += "Content\\VoxModel\\";
            var modelFiles = Directory.EnumerateFiles(strWorkDir, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".xnb"));

            foreach (string modelFileName in modelFiles)
            {
                listRet.Add(Path.GetFileNameWithoutExtension(modelFileName));
            }
            return listRet;
        }
        /// <summary>
        /// 获取引擎支持的基本图元名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDefaultGeoPrimitiveNameList()
        {
            List<string> listRet = new List<string>();

            listRet.Add("球体");
            listRet.Add("立方体");
            listRet.Add("圆环体");
            listRet.Add("茶壶体");

            return listRet;
        }
    }
}
