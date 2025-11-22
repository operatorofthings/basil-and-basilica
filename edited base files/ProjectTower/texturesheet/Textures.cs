using BasilAndBasilica;
using SheetEdit.TextureSheet;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ProjectTower.texturesheet
{
    public class Textures
    {
        public static int GetTextureIdx(string s)
        {
            if (Textures.textures.ContainsKey(s))
            {
                return Textures.textures[s];
            }
            return 0;
        }

        public static void Init()
        {
            Textures.textureSemaphore = new object();
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(string.Format("{0}.texturesheet.data.master.zcm", Program.DATAPATH));
            BinaryReader br = new BinaryReader(_fileStream);
            int num = br.ReadInt32();
            Textures.tex = new XTexture[num + 1];
            Textures.textures = new Dictionary<string, int>();
            for (int i = 0; i < num; i++)
            {
                XTexture xtexture = new XTexture(br);
                Textures.textures.Add(xtexture.name, i);
                Textures.tex[i] = xtexture;
            }
            br.Close();
        }

        public static long saveTick;

        public static XTexture[] tex;

        private static Dictionary<string, int> textures;

        public static object textureSemaphore;

        public static bool loading;
    }
}
