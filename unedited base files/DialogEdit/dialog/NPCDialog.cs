using LootEdit.loot;
using ProjectTower.player;
using System.IO;

namespace DialogEdit.dialog
{
    public class NPCDialog
    {
        internal void Read(BinaryReader reader)
        {
            this.name = reader.ReadString();
            this.rune = -1;
            int num = reader.ReadInt32();
            InvLoot invLoot = new InvLoot();
            this.nodeList = new DialogNode[num];
            for (int i = 0; i < num; i++)
            {
                this.nodeList[i] = new DialogNode();
                this.nodeList[i].Read(reader);
                if (this.nodeList[i].giveScript != null)
                {
                    foreach (string text in this.nodeList[i].giveScript)
                    {
                        invLoot.InitFromName(text);
                        if (invLoot != null && invLoot.category == 3 && LootCatalog.category[invLoot.category].loot[invLoot.catalogIdx].type == 2)
                        {
                            this.rune = LootCatalog.category[invLoot.category].loot[invLoot.catalogIdx].flags;
                        }
                    }
                }
            }
        }

        internal int GetNodeIdx(string p)
        {
            for (int i = 0; i < this.nodeList.Length; i++)
            {
                if (this.nodeList[i].name == p)
                {
                    return i;
                }
            }
            return -1;
        }

        public string name;

        public DialogNode[] nodeList;

        public int rune;
    }
}