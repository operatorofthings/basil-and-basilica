using DialogEdit;
using System.Text;

namespace ProjectTower.player.challenges
{
    internal class ChallengeCatLoadout : ChallengeCategory
    {
        public ChallengeCatLoadout(Player p)
        {
            this.itemStr = new StringBuilder[]
            {
                new StringBuilder(LocStrings.GetLocStr(427)),
                new StringBuilder(LocStrings.GetLocStr(428)),
                new StringBuilder(LocStrings.GetLocStr(429))
            };
            base.Init(p);
        }

        public const int MAGIC_ONLY = 0;

        public const int IRON_POT_ONLY = 1;

        public const int OAR_ONLY = 2;
    }
}