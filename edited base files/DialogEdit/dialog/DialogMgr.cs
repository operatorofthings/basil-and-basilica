using LootEdit;
using PepperAndChurchSaveEditor;
using ProjectTower;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DialogEdit.dialog
{
    public class DialogMgr
    {
        public static void Init()
        {
            DialogMgr.locStrings = new List<LocPair>();
        }

        public static StringBuilder GetLocString(int i)
        {
            return new StringBuilder(DialogMgr.locStrings[i].locStr[Game1.language]);
        }

        public static string GetLocStr(int i)
        {
            return DialogMgr.locStrings[i].locStr[Game1.language];
        }

        public static string GetEnglishLocStr(int i)
        {
            return DialogMgr.locStrings[i].locStr[0];
        }

        public static void ReadLocText()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(string.Format("{0}.dialog.data.strings.ztx", Program.DATAPATH));
            BinaryReader br = new BinaryReader(_fileStream);
            DialogMgr.ReadLocText(br);
            br.Close();
            DialogMgr.locStringsLoaded = true;
        }

        public static void ReadLocText(BinaryReader reader)
        {
            DialogMgr.locStrings = new List<LocPair>();
            int num = reader.ReadInt32();
            for (int i = 0; i < num; i++)
            {
                LocPair locPair = new LocPair(reader.ReadString());
                for (int j = 0; j < 13; j++)
                {
                    locPair.locStr[j] = reader.ReadString();
                }
                DialogMgr.locStrings.Add(locPair);
            }
        }

        public static void WriteLocText(BinaryWriter writer)
        {
            writer.Write(DialogMgr.locStrings.Count);
            foreach (LocPair locPair in DialogMgr.locStrings)
            {
                writer.Write(locPair.orig);
                for (int i = 0; i < 13; i++)
                {
                    if (i < locPair.locStr.Length)
                    {
                        writer.Write((locPair.locStr[i] == null) ? "" : locPair.locStr[i]);
                    }
                    else
                    {
                        writer.Write(locPair.locStr[0] + " - " + TranslationMgr.GetLangStrFromIdx(i));
                    }
                }
            }
        }

        public static void Read(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            DialogMgr.dialogList = new NPCDialog[num];
            for (int i = 0; i < num; i++)
            {
                DialogMgr.dialogList[i] = new NPCDialog();
                DialogMgr.dialogList[i].Read(reader);
            }
        }

        public static void ReadMaster()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(string.Format("{0}.dialog.data.dialog.zdx", Program.DATAPATH));
            BinaryReader br = new BinaryReader(_fileStream);
            DialogMgr.Read(br);
            br.Close();
        }

        public static NPCDialog[] dialogList;

        public static bool locStringsLoaded;

        public static List<LocPair> locStrings;
    }
}
