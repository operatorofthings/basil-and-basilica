using System.IO;

namespace ProjectTower.player
{
    public class PlayerBeast
    {
        public PlayerBeast()
        {
            this.kills = 0;
            this.killedBy = 0;
            this.drops = new int[6];
        }

        public PlayerBeast(BinaryReader reader)
        {
            this.kills = reader.ReadInt32();
            this.killedBy = reader.ReadInt32();
            this.drops = new int[6];
            for (int i = 0; i < this.drops.Length; i++)
            {
                this.drops[i] = reader.ReadInt32();
            }
        }

        public PlayerBeast(PlayerBeast playerBeast)
        {
            this.kills = playerBeast.kills;
            this.killedBy = playerBeast.killedBy;
            this.drops = new int[6];
            for (int i = 0; i < this.drops.Length; i++)
            {
                this.drops[i] = playerBeast.drops[i];
            }
        }

        internal void Write(BinaryWriter writer)
        {
            writer.Write(this.kills);
            writer.Write(this.killedBy);
            for (int i = 0; i < this.drops.Length; i++)
            {
                writer.Write(this.drops[i]);
            }
        }

        public int kills;

        public int killedBy;

        public int[] drops;
    }
}