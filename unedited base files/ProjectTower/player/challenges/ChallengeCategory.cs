using System.Text;

namespace ProjectTower.player.challenges
{
    public class ChallengeCategory
    {
        public virtual void Init(Player p)
        {
            this.p = p;
            this.activeChallenge = -1;
        }

        private Player p;

        public StringBuilder[] itemStr;

        public int activeChallenge;
    }
}