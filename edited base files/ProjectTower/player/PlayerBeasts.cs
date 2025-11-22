using System.Collections.Generic;
using System.IO;

namespace ProjectTower.player
{
    public class PlayerBeasts
    {
        public PlayerBeasts(Player player)
        {
            this.player = player;
            this.playerBeast = new Dictionary<string, PlayerBeast>();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(this.playerBeast.Count);
            foreach (KeyValuePair<string, PlayerBeast> keyValuePair in this.playerBeast)
            {
                writer.Write(keyValuePair.Key);
                keyValuePair.Value.Write(writer);
            }
        }

        public void Read(BinaryReader reader)
        {
            this.playerBeast = new Dictionary<string, PlayerBeast>();
            int num = reader.ReadInt32();
            for (int i = 0; i < num; i++)
            {
                string key = reader.ReadString();
                PlayerBeast value = new PlayerBeast(reader);
                this.playerBeast.Add(key, value);
            }
        }

        internal void Reset()
        {
            this.playerBeast = new Dictionary<string, PlayerBeast>();
        }

        private Player player;

        public Dictionary<string, PlayerBeast> playerBeast;
    }
}