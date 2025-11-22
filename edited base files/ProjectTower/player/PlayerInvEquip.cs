using LootEdit.loot;
using ProjectTower.character;

namespace ProjectTower.player
{
    public class PlayerInvEquip
    {
        public PlayerInvEquip(Player p)
        {
            this.p = p;
        }

        public InvLoot GetLootFromEquipItem(Character c, int e)
        {
            switch (e)
            {
                case 0:
                    if (c.equipment.helm.catalogIdx > -1 && c.equipment.helm.catalogIdx < LootCatalog.category[2].loot.Length && c.equipment.helm.invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.helm.invIdx];
                    }
                    break;

                case 1:
                    if (c.equipment.armor.catalogIdx > -1 && c.equipment.armor.catalogIdx < LootCatalog.category[2].loot.Length && c.equipment.armor.invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.armor.invIdx];
                    }
                    break;

                case 2:
                    if (c.equipment.gloves.catalogIdx > -1 && c.equipment.gloves.catalogIdx < LootCatalog.category[2].loot.Length && c.equipment.gloves.invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.gloves.invIdx];
                    }
                    break;

                case 3:
                    if (c.equipment.boots.catalogIdx > -1 && c.equipment.boots.catalogIdx < LootCatalog.category[2].loot.Length && c.equipment.boots.invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.boots.invIdx];
                    }
                    break;

                case 4:
                case 5:
                case 6:
                    if (c.equipment.loadout[0, e - 4].catalogIdx > -1 && c.equipment.loadout[0, e - 4].invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.loadout[0, e - 4].invIdx];
                    }
                    break;

                case 7:
                case 8:
                case 9:
                    if (c.equipment.loadout[1, e - 7].catalogIdx > -1 && c.equipment.loadout[1, e - 7].invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.loadout[1, e - 7].invIdx];
                    }
                    break;

                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    if (c.equipment.consumable[e - 10].catalogIdx > -1 && c.equipment.consumable[e - 10].catalogIdx < LootCatalog.category[4].loot.Length && c.equipment.consumable[e - 10].invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.consumable[e - 10].invIdx];
                    }
                    break;

                case 16:
                case 17:
                case 18:
                case 19:
                    if (c.equipment.ring[e - 16].catalogIdx > -1 && c.equipment.ring[e - 16].catalogIdx < LootCatalog.category[3].loot.Length && c.equipment.ring[e - 16].invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.ring[e - 16].invIdx];
                    }
                    break;

                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                    if (c.equipment.incantation[e - 20].catalogIdx > -1 && c.equipment.incantation[e - 20].catalogIdx < LootCatalog.category[5].loot.Length && c.equipment.incantation[e - 20].invIdx > -1)
                    {
                        return this.p.playerInv.inventory[c.equipment.incantation[e - 20].invIdx];
                    }
                    break;
            }
            return null;
        }

        private Player p;
    }
}