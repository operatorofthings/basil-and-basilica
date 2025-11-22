using ProjectTower.texturesheet;
using BasilAndBasilica;
using SheetEdit.TextureSheet;
using System.IO;

namespace MapEdit.map
{
    public class Seg
    {
        internal void Read(BinaryReader reader)
        {
            this.idx = reader.ReadInt32();
            this.loc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            this.rotation = reader.ReadSingle();
            this.scaling = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            this.texture = reader.ReadString();
            this.hasVisRect = false;
            this.textureIdx = Textures.GetTextureIdx(this.texture);
            XTexture xtexture = Textures.tex[this.textureIdx];
            if (xtexture.type == 3)
            {
                this.strFlag = reader.ReadString();
                this.intFlag = reader.ReadInt32();
            }
            if (xtexture.type == 2)
            {
                XSprite originalCell = xtexture.GetOriginalCell(this.idx);
                int flags = originalCell.flags;
                switch (flags)
                {
                    case 9:
                    case 10:
                    case 11:
                    case 13:
                    case 14:
                    case 15:
                        break;

                    case 12:
                        return;

                    default:
                        if (flags != 22)
                        {
                            switch (flags)
                            {
                                case 29:
                                case 30:
                                    break;

                                default:
                                    return;
                            }
                        }
                        break;
                }
                string a = reader.ReadString();
                if (a == "")
                {
                    this.strFlag = null;
                }
                else
                {
                    this.strFlag = a;
                }
                this.intFlag = reader.ReadInt32();
                if (originalCell.flags == 22)
                {
                    this.intFlag = -1;
                }
            }
        }

        internal void ReadEntity(BinaryReader reader)
        {
            this.idx = reader.ReadInt32();
            this.loc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            this.intFlag = reader.ReadInt32();
            this.texture = reader.ReadString();
            this.strFlag = reader.ReadString();
        }

        public Vector2 loc;

        public int idx;

        public string texture;

        public int textureIdx;

        public float rotation;

        public Vector2 scaling;

        public bool hasVisRect;

        public Vector2 visTL;

        public Vector2 visBR;

        public int intFlag;

        public string strFlag;

        public float depth;
    }
}