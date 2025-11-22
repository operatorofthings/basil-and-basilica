using PepperAndChurchSaveEditor;
using System.IO;

namespace SheetEdit.TextureSheet
{
    public class XTexture
    {
        public void Read(string path)
        {
            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read));
            this.ReadData(br);
            br.Close();
        }

        public void ReadData(BinaryReader reader)
        {
            this.type = reader.ReadInt32();
            int num = reader.ReadInt32();
            this.cell = new XSprite[num];
            for (int i = 0; i < num; i++)
            {
                if (reader.ReadBoolean())
                {
                    this.cell[i] = new XSprite();
                    XSprite xsprite = this.cell[i];
                    xsprite.name = reader.ReadString();
                    xsprite.srcRect = new Rectangle(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
                    xsprite.origin = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                    switch (this.type)
                    {
                        case 1:
                            xsprite.char_ref = reader.ReadInt32();
                            xsprite.flags = reader.ReadInt32();
                            break;

                        case 2:
                            xsprite.flags = reader.ReadInt32();
                            break;

                        case 4:
                            xsprite.flags = reader.ReadInt32();
                            break;
                    }
                }
            }
        }

        public string GetSpriteName(int idx)
        {
            if (idx < this.cell.Length && this.cell[idx] != null)
            {
                return this.cell[idx].name;
            }
            return "";
        }

        public XSprite GetOriginalCell(int idx)
        {
            return this.cell[idx];
        }

        public int GetOriginalCellCount()
        {
            return this.cell.Length;
        }

        public XTexture(BinaryReader reader)
        {
            this.name = reader.ReadString();
            this.ReadData(reader);
        }

        public const int TYPE_NORMAL = 0;

        public const int TYPE_CLOTHES = 1;

        public const int TYPE_MAP = 2;

        public const int TYPE_CHARACTER = 3;

        public const int TYPE_CHAR = 4;

        public const int TYPE_CHAR_VAR = 5;

        public const int MAX_CELLS = 128;

        public XSprite[] cell;

        public string name = "";

        public int ugcPackageIdx = -1;

        public int ugcSheetIdx = -1;

        public bool needsUnload;

        public int type;
    }
}