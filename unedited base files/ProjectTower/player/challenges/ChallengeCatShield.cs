using DialogEdit;
using System.Text;

namespace ProjectTower.player.challenges
{
    internal class ChallengeCatShield : ChallengeCategory
    {
        public ChallengeCatShield(Player p)
        {
            this.itemStr = new StringBuilder[]
            {
                new StringBuilder(LocStrings.GetLocStr(430))
            };
            base.Init(p);
        }

        public const int NO_BLOCKING = 0;
    }
}