using BasilAndBasilica;
using System.IO;
using System.Reflection;

namespace MonsterEdit.monsters
{
    public class MonsterCatalog
    {
        internal static void Read(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            MonsterCatalog.catalog = new MonsterDef[num];
            for (int i = 0; i < num; i++)
            {
                MonsterCatalog.catalog[i] = new MonsterDef(reader);
            }
        }

        public static int GetIdxFromString(string monster)
        {
            for (int i = 0; i < MonsterCatalog.catalog.Length; i++)
            {
                if (MonsterCatalog.catalog[i].name == monster)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void ReadMaster()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(string.Format("{0}.monsters.data.monsters.zox", Program.DATAPATH));
            BinaryReader br = new BinaryReader(_fileStream);
            MonsterCatalog.Read(br);
            br.Close();
            //for (int i = 0; i < MonsterCatalog.catalog.Length; i++)
            //{
            //    for (int j = 0; j < CharDefMgr.charDefList.Length; j++)
            //    {
            //        if (CharDefMgr.charDefList[j].path == MonsterCatalog.catalog[i].def)
            //        {
            //            MonsterCatalog.catalog[i].defIdx = j;
            //            MonsterCatalog.catalog[i].canJump = CharDefMgr.charDefList[MonsterCatalog.catalog[i].defIdx].GetHasAnimation("jump");
            //        }
            //    }
            //}
        }

        public static MonsterDef[] catalog;
    }
}
