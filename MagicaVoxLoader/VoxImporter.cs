//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    MagicaVox格式加载器
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;
//-------------------------------------------------
namespace MagicaVoxLoader
{
    [ContentImporter(".vox", DisplayName = "Vox Importer", DefaultProcessor = "ChunkProcessor")]
    public class VoxImporter : ContentImporter<VoxContent>
    {
        #region ======== 常量 ========

        private const string ExpectedMagicNumber = "VOX ";
        private const string MainChunkHeader = "MAIN";
        private const string SizeChunkHeader = "SIZE";
        private const string VoxelChunkHeader = "XYZI";
        private const string PaletteChunkHeader = "RGBA";

        #endregion ======== 常量 ========

        #region ======== 成员变量 ========

        private ContentImporterContext  m_ContentImporterContext;
        private string                  m_strFileName;
        private bool                    m_bIsCustomPalette;
        private static Color[]          s_DefaultPalette;

        #endregion ======== 成员变量 ========

        #region ======== 便捷接口 ========

        private static Color[] DefaultPalette
        {
            get
            {
                if (s_DefaultPalette == null)
                {
                    s_DefaultPalette = new Color[255];
                    for (var i = 0; i < 255; i++)
                    {
                        var v = DefaultColor.DefaultColorValues[i];
                        s_DefaultPalette[i] = new Color((int)((v >> 0) & 0xFF), 
                            (int)((v >> 8) & 0xFF), (int)((v >> 16) & 0xFF), (int)((v >> 24) & 0xFF));
                    }
                }

                return s_DefaultPalette;
            }
        }

        #endregion ======== 成员变量 ========


        #region ======== 对外接口 ========

        public override VoxContent Import(string fileName, ContentImporterContext context)
        {
            m_ContentImporterContext = context;
            m_strFileName = fileName;

            using (var fileStream = File.OpenRead(fileName))
            using (var binaryReader = new BinaryReader(fileStream))
            {
                return ReadVoxFile(binaryReader);
            }
        }

        #endregion ======== 便捷接口 ========

        #region ======== 核心函数 ========

        private VoxContent ReadVoxFile(BinaryReader reader)
        {
            var result = new VoxContent();
            result.Palette = new Color[255];

            var magicNumber = new string(reader.ReadChars(4));
            if (magicNumber != ExpectedMagicNumber)
            {
                throw new InvalidContentException(
                    $"File {m_strFileName} is not a valid .vox file, it does not start with '{ExpectedMagicNumber}'.",
                    new ContentIdentity(m_strFileName));
            }

            var version = reader.ReadInt32();
            m_ContentImporterContext.Logger.LogMessage($"加载 Magica Voxel 生成的 .vox 文件,版本: {version}.");

            var mainId = new string(reader.ReadChars(4));
            var mainSize = reader.ReadInt32();
            var mainChildrenSize = reader.ReadInt32();

            if (mainId != MainChunkHeader)
                throw new InvalidContentException(
                    $"File {m_strFileName} is not a valid .vox file, it does not start with the MAIN chunk.",
                    new ContentIdentity(m_strFileName));

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                // each chunk has an ID, size and child chunks
                var chunkId = new string(reader.ReadChars(4));
                var chunkSize = reader.ReadInt32();
                var childrenSize = reader.ReadInt32();

                switch (chunkId)
                {
                    case SizeChunkHeader:
                        // SIZE chunk
                        ReadSize(result, reader);
                        break;
                    case VoxelChunkHeader:
                        // VOXEL chunk
                        ReadVoxel(result, reader);
                        break;
                    case PaletteChunkHeader:
                        // PALETTE chunk (optional)
                        ReadPalette(result, reader);
                        break;
                    default:
                        m_ContentImporterContext.Logger.LogMessage($"跳过不识别的块：{chunkId}");
                        reader.BaseStream.Seek(chunkSize + childrenSize, SeekOrigin.Current);
                        break;
                }
            }

            if (result.Voxels == null)
                throw new InvalidContentException("No voxels were loaded.");

            if (!m_bIsCustomPalette)
                result.Palette = DefaultPalette;

            m_ContentImporterContext.Logger.LogMessage($"转换结束");
            return result;
        }

        private void ReadSize(VoxContent voxContent, BinaryReader reader)
        {
            m_ContentImporterContext.Logger.LogMessage("加载 大小 块信息...");
            voxContent.SizeX = reader.ReadInt32();
            // Z-axis points up for MV but backwards (towards us) for MG. 
            // So MG axes are rotated a quarter over the positive x-axis relative to MV
            voxContent.SizeZ = reader.ReadInt32();
            voxContent.SizeY = reader.ReadInt32();
        }

        private void ReadVoxel(VoxContent voxContent, BinaryReader reader)
        {
            m_ContentImporterContext.Logger.LogMessage("加载 体素 块信息...");
            voxContent.VoxelCount = reader.ReadInt32();

            var voxels = new MagicaVoxel[voxContent.VoxelCount];
            for (var i = 0; i < voxContent.VoxelCount; i++)
            {
                voxels[i] = new MagicaVoxel();
                voxels[i].X = reader.ReadByte();
                // Z-axis points up for MV but backwards (towards us) for MG. 
                // So MG axes are rotated a quarter over the positive x-axis relative to MV
                voxels[i].Z = (byte)(voxContent.SizeZ - 1 - reader.ReadByte());
                voxels[i].Y = reader.ReadByte();
                voxels[i].ColorIndex = reader.ReadByte();
            }

            voxContent.Voxels = voxels;
        }

        private void ReadPalette(VoxContent voxContent, BinaryReader reader)
        {
            m_ContentImporterContext.Logger.LogMessage("加载 调色板 块信息...");

            // - last color is not used ( only the first 255 colors are used ). 
            // - the first color ( at position 0 ) is corresponding to color index 1.
            //   -> we need to subtract 1 to get the correct index!

            for (var i = 0; i < 255; i++)
            {
                var r = reader.ReadByte();
                var g = reader.ReadByte();
                var b = reader.ReadByte();
                var a = reader.ReadByte();

                voxContent.Palette[i] = new Color(r, g, b, a);
            }

            // skip the last color
            reader.BaseStream.Seek(4, SeekOrigin.Current);

            m_bIsCustomPalette = true;
        }

        #endregion ======== 核心函数 ========
    }
}
