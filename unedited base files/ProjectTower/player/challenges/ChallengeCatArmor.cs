using DialogEdit;
using System.Text;

namespace ProjectTower.player.challenges
{
    internal class ChallengeCatArmor : ChallengeCategory
    {
        public ChallengeCatArmor(Player p)
        {
            this.itemStr = new StringBuilder[]
            {
                new StringBuilder(LocStrings.GetLocStr(424))
            };
            base.Init(p);
        }

        public const int NAKED = 0;
    }
}