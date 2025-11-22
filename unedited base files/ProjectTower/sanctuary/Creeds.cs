namespace ProjectTower.sanctuary
{
    public class Creeds
    {
        public static void Init()
        {
            Creeds.creedDef = new Creeds.CreedDef[10];
            Creeds.creedDef[1] = new Creeds.CreedDef(1, "_iron", "roll", "mana_crystal", "buff_sanclit", "horn_sanc_will");
            Creeds.creedDef[2] = new Creeds.CreedDef(2, "_cleric", "water", "mana_cloth", "potion_holy", "buff_sancholy");
            Creeds.creedDef[3] = new Creeds.CreedDef(3, "_three", "potion", "mana_mead", "buff_sancfire", "buff_threelit");
            Creeds.creedDef[4] = new Creeds.CreedDef(4, "_woods", "heal_herb", "mana_herb", "buff_sancpoison", "throw_w_dagger/25");
            Creeds.creedDef[8] = new Creeds.CreedDef(8, "_fire", "fire_flask", "blue_sky", "buff_crystal", "buff_sancfocus");
            Creeds.creedDef[5] = new Creeds.CreedDef(5, "_dark", "blood_vial", "black_salt", "buff_sancdark", "blood_pot/3");
            Creeds.creedDef[6] = new Creeds.CreedDef(6, "_splendor", "red_wine", "blue_wine", "gold_wine", "cleansing_cloth/2");
            Creeds.creedDef[7] = new Creeds.CreedDef(7, "_fool", "potion", "mana_mead", "buff_sancfire", "buff_threelit");
            Creeds.creedDef[9] = new Creeds.CreedDef(9, "_bones", "potion", "mana_mead", "buff_sancfire", "buff_threelit");
        }

        public const int CREED_NONE = 0;

        public const int CREED_IRON = 1;

        public const int CREED_CLERIC = 2;

        public const int CREED_THREE = 3;

        public const int CREED_WOODS = 4;

        public const int CREED_DARK = 5;

        public const int CREED_SPLENDOR = 6;

        public const int CREED_UNUSED_1 = 7;

        public const int CREED_FIRE = 8;

        public const int CREED_UNUSED_2 = 9;

        public const int CREED_CANDLE = 10;

        public const int TOTAL_CREEDS = 10;

        public const int CREED_LEVEL_APOSTATE = -1;

        public const int CREED_LEVEL_UNAFFILIATED = 0;

        public const int CREED_LEVEL_BUFF = 1;

        public const int TOTAL_UNLOCKS = 4;

        public static Creeds.CreedDef[] creedDef;

        public struct CreedDef
        {
            public CreedDef(int ID, string altMonsterStr, string consumableHP, string consumableMP, string consumableSlot1, string consumableSlot2)
            {
                this.ID = ID;
                this.altMonsterStr = altMonsterStr;
                this.consumable = new string[]
                {
                    consumableHP,
                    consumableMP,
                    consumableSlot1,
                    consumableSlot2
                };
            }

            public const int CONSUMABLE_HP = 0;

            public const int CONSUMABLE_MP = 1;

            public const int CONSUMABLE_SLOT_1 = 2;

            public const int CONSUMABLE_SLOT_2 = 3;

            public int ID;

            public string altMonsterStr;

            public string[] consumable;
        }
    }
}