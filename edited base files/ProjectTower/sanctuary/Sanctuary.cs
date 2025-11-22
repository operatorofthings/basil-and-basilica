using MapEdit.map;
using BasilAndBasilica;

namespace ProjectTower.sanctuary
{
    public class Sanctuary
    {
        public Sanctuary(Seg seg, int ID)
        {
            this.SanctuaryDisplayName = Game1.GetSanctNameFromId(ID);
            this.ID = ID;
            if (seg != null)
            {
                this.x = (int)(seg.loc.X / 64f);
                this.y = (int)(seg.loc.Y / 32f);
                this.loc = new Vector2((float)this.x * 64f + 32f, (float)this.y * 64f * 0.5f + 6.4f);
            }
            else
            {
                this.x = -1;
                this.y = -1;
                this.loc = new Vector2(-1, -1);
            }
        }

        public string SanctuaryDisplayName { get; set; }

        public const int MERCHANT_OFF = 0;

        public const int MERCHANT_PRIEST = 1;

        public const int MERCHANT_MERCHANT = 2;

        public const int MERCHANT_BLACKSMITH = 3;

        public const int MERCHANT_MAGE = 4;

        public const int MERCHANT_ALCHEMIST = 5;

        public const int MERCHANT_GUIDE = 6;

        public const int MERCHANT_LEADER = 7;

        public const int MERCHANT_SELLSWORD = 8;

        public int x;

        public int y;

        public Vector2 loc;

        public int ID;
    }
}