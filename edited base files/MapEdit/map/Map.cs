using PepperAndChurchSaveEditor;
using System.IO;
using System.Reflection;

namespace MapEdit.map
{
    public class Map
    {
        public static void ResetLayers()
        {
            Map.layer = new Layer[20];
            for (int i = 0; i < Map.layer.Length; i++)
            {
                Map.layer[i] = new Layer();
            }
            Map.layer[0].depth = 20f;
            Map.layer[1].depth = 12f;
            Map.layer[2].depth = 8f;
            Map.layer[3].depth = 4f;
            Map.layer[4].depth = 2f;
            Map.layer[5].depth = 1f;
            Map.layer[6].depth = 1f;
            Map.layer[7].depth = 0f;
            Map.layer[8].depth = -1f;
            Map.layer[9].depth = -2f;
            Map.layer[10].depth = -4f;
            Map.layer[11].depth = 12f;
            Map.layer[12].depth = 8f;
            Map.layer[13].depth = 4f;
            Map.layer[14].depth = 2f;
            Map.layer[15].depth = 1f;
            Map.layer[16].depth = 1f;
            Map.layer[17].depth = 0f;
            Map.layer[18].depth = -1f;
            Map.layer[19].depth = 1f;
        }

        public static void RefreshDepths()
        {
            for (int i = 0; i < 20; i++)
            {
                Map.layer[i].RefreshDepths();
            }
        }

        public static void Read()
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _fileStream = _assembly.GetManifestResourceStream(string.Format("{0}.map.data.fortress.zax", Program.DATAPATH));
            BinaryReader br = new BinaryReader(_fileStream);

            //FileMgr.Open(string.Concat("map/data/", "fortress", ".zax"));
            Map.ResetLayers();
            Map.xUnits = br.ReadInt32();
            Map.yUnits = br.ReadInt32();
            Map.col = new Map.Col[Map.xUnits, Map.yUnits];

            for (int i = 0; i < Map.layer.Length; i++)
            {
                if (i == 19)
                {
                    Map.layer[i].ReadEntities(br);
                }
                else
                {
                    Map.layer[i].Read(br);
                }
            }
            for (int j = 0; j < Map.xUnits; j++)
            {
                int num = 0;
                while (true)
                {
                    int num2 = br.ReadInt32();
                    if (num2 == -1)
                    {
                        break;
                    }
                    int num3 = (int)br.ReadByte();
                    for (int k = 0; k < num2; k++)
                    {
                        Map.col[j, num].col = num3;
                        num++;
                    }
                }
            }
            for (int l = 0; l < Map.xUnits; l++)
            {
                int num4 = 0;
                while (true)
                {
                    int num5 = br.ReadInt32();
                    if (num5 == -1)
                    {
                        break;
                    }
                    int num6 = (int)br.ReadByte();
                    for (int m = 0; m < num5; m++)
                    {
                        Map.col[l, num4].layer = num6;
                        num4++;
                    }
                }
            }
            br.Close();
            Map.RefreshDepths();
        }

        public static Layer[] layer;

        public static int xUnits;

        public static int yUnits;

        public static Map.Col[,] col;

        public struct Col
        {
            internal void Read(BinaryReader reader)
            {
                this.col = (int)reader.ReadByte();
                this.layer = (int)reader.ReadByte();
            }

            internal void Write(BinaryWriter writer)
            {
                writer.Write((byte)this.col);
                writer.Write((byte)this.layer);
            }

            public int col;

            public int layer;
        }
    }
}
