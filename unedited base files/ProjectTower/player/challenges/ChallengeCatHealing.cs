using DialogEdit;
using System.Text;

namespace ProjectTower.player.challenges
{
    internal class ChallengeCatHealing : ChallengeCategory
    {
        public ChallengeCatHealing(Player p)
        {
            this.itemStr = new StringBuilder[]
            {
                new StringBuilder(LocStrings.GetLocStr(426))
            };
            base.Init(p);
        }

        public const int NO_HEALING = 0;
    }
}