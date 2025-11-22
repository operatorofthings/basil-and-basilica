using BasilAndBasilica;
using System.IO;
using System.Reflection;

namespace SkillTreeEdit.skilltree
{
    public class SkillTree
    {
        public static void Init()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(string.Format("{0}.skilltree.data.skilltree.zsx", Program.DATAPATH));
            BinaryReader br = new BinaryReader(_fileStream);
            SkillTree.Read(br);
            br.Close();
        }

        internal static void Read(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            SkillTree.nodes = new SkillNode[num];
            for (int i = 0; i < num; i++)
            {
                SkillTree.nodes[i] = new SkillNode(reader, i);
            }
            num = reader.ReadInt32();
            for (int j = 0; j < num; j++)
            {
                reader.ReadInt32();
                reader.ReadSingle();
                reader.ReadSingle();
                reader.ReadSingle();
                reader.ReadSingle();
                reader.ReadSingle();
            }
        }

        public static SkillNode[] nodes;
    }
}
