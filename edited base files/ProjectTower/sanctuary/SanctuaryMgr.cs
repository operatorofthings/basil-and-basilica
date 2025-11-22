using MapEdit.map;
using ProjectTower.texturesheet;

namespace ProjectTower.sanctuary
{
    public class SanctuaryMgr
    {
        public static void Init()
        {
            int num = 0;
            SanctuaryMgr.sanctuaries = new Sanctuary[40];
            for (int i = 0; i < SanctuaryMgr.sanctuaries.Length; i++)
            {
                SanctuaryMgr.sanctuaries[i] = null;
            }
            for (int j = 0; j < 2; j++)
            {
                Layer layer = Map.layer[(!(j != 0)) ? 15 : 5];
                for (int k = 0; k < layer.seg.Length; k++)
                {
                    Seg seg = layer.seg[k];
                    if (seg != null && Textures.tex[seg.textureIdx].GetOriginalCell(seg.idx).flags == 11 && num < SanctuaryMgr.sanctuaries.Length)
                    {
                        SanctuaryMgr.sanctuaries[num] = new Sanctuary(seg, num);
                        num++;
                    }
                }
            }
        }

        public const int SANCTUARY_ASHEN_SHORE = 0;

        public const int SANCTUARY_FORSAKEN_VILLAGE = 1;

        public const int SANCTUARY_BANDITS_PASS = 2;

        public const int SANCTUARY_CASTLE_OF_STORMS = 3;

        public const int SANCTUARY_SUNKEN_KEEP = 4;

        public const int SANCTUARY_RED_DUNGEON = 5;

        public const int SANCTUARY_LOST_WOODS = 6;

        public const int SANCTUARY_CAVES = 7;

        public const int SANCTUARY_SWAMP = 8;

        public const int SANCTUARY_DOME = 9;

        public const int SANCTUARY_SKY_CASTLE = 10;

        public const int SANCTUARY_DUNGEON_CAVE = 11;

        public const int SANCTUARY_FAR_BEACH = 12;

        public const int SANCTUARY_COASTAL_FORT = 13;

        public const int SANCTUARY_SIAM_LAKE = 14;

        public const int SANCTUARY_DARKWOOD = 15;

        public const int SANCTUARY_ZIGGURAT = 16;

        public const int SANCTUARY_RUINS = 17;

        public const int SHRINE_PARTY_FORT = 18;

        public const int SHRINE_SUNKEN_KEEP = 19;

        public const int SHRINE_RED_DUNGEON = 20;

        public const int SHRINE_DOME = 21;

        public const int SANCTUARY_LAB = 22;

        public const int SHRINE_SWAMP = 23;

        public const int SHRINE_CASTLE_OF_STORMS = 24;

        public const int SHRINE_CAVES = 25;

        public const int SANCTUARY_TOMB = 26;

        public const int SHRINE_TOMB = 27;

        public const int SHRINE_PALACE = 28;

        public const int SHRINE_DARKWOODS = 29;

        public const int SHRINE_UNKNOWN = 30;

        public const int SANCTUARY_BLACKEST_VAULT = 31;

        public const int MAX_SANCTUARIES = 40;

        public const int SANCTUARY_OTHER_CREED = 1000;

        public static Sanctuary[] sanctuaries;
    }
}