using DialogEdit;
using System.Text;

namespace ProjectTower.player.challenges
{
    internal class ChallengeCatHardcoreMode : ChallengeCategory
    {
        public ChallengeCatHardcoreMode(Player p)
        {
            this.itemStr = new StringBuilder[]
            {
                new StringBuilder(LocStrings.GetLocStr(425))
            };
            base.Init(p);
        }

        public const int HARDCORE = 0;

        public const string HARDCORE_STR = "_#_DED4EVAR_#_";
    }
}