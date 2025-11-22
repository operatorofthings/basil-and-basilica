using System.IO;

namespace MapEdit.map
{
    public class Layer
    {
        public void Read(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            this.seg = new Seg[num];
            for (int i = 0; i < num; i++)
            {
                this.seg[i] = new Seg();
                this.seg[i].Read(reader);
            }
        }

        public void RefreshDepths()
        {
            float num = this.depth;
            for (int i = 0; i < this.seg.Length; i++)
            {
                this.seg[i].depth = num;
            }
        }

        public void ReadEntities(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            this.seg = new Seg[num];
            for (int i = 0; i < num; i++)
            {
                this.seg[i] = new Seg();
                this.seg[i].ReadEntity(reader);
            }
        }

        public Seg[] seg;

        public float depth;

        public const int O_BACK_5 = 0;

        public const int O_BACK_4 = 1;

        public const int O_BACK_3 = 2;

        public const int O_BACK_2 = 3;

        public const int O_BACK_1 = 4;

        public const int O_MID = 5;

        public const int O_FORE_1 = 6;

        public const int O_FORE_2 = 7;

        public const int O_FORE_3 = 8;

        public const int O_FORE_4 = 9;

        public const int O_FORE_5 = 10;

        public const int I_BACK_4 = 11;

        public const int I_BACK_3 = 12;

        public const int I_BACK_2 = 13;

        public const int I_BACK_1 = 14;

        public const int I_MID = 15;

        public const int I_FORE_1 = 16;

        public const int I_FORE_2 = 17;

        public const int I_FORE_3 = 18;

        public const int LAYER_ENTITIES = 19;

        public const int TOTAL_LAYERS = 20;

        public const int LAYER_COL = 20;

        public const int LAYER_LAYER = 21;

        public const int LAYER_SEQUENCE = 22;
    }
}