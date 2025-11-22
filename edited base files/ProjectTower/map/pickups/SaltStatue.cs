using BasilAndBasilica;
using System.IO;

namespace ProjectTower.map.pickups
{
    public class SaltStatue
    {
        public SaltStatue()
        {
            this.exists = false;
        }

        internal void Write(BinaryWriter writer)
        {
            writer.Write(this.loc.X);
            writer.Write(this.loc.Y);
        }

        internal void Read(BinaryReader reader)
        {
            this.loc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            this.exists = true;
        }

        public Vector2 loc;

        public bool exists;

        public float frame;

        public int salt;

        public float destroyFrame;
    }
}