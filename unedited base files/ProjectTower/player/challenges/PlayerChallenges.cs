using System;

namespace ProjectTower.player.challenges
{
    public class PlayerChallenges
    {
        public PlayerChallenges(Player p)
        {
            this.p = p;
            this.category = new ChallengeCategory[5];
            this.category[0] = new ChallengeCatHardcoreMode(p);
            this.category[1] = new ChallengeCatLoadout(p);
            this.category[2] = new ChallengeCatArmor(p);
            this.category[3] = new ChallengeCatShield(p);
            this.category[4] = new ChallengeCatHealing(p);
        }

        public void WriteFlags()
        {
            for (int i = 0; i < this.category.Length; i++)
            {
                ChallengeCategory challengeCategory = this.category[i];
                if (challengeCategory.activeChallenge > -1)
                {
                    string item = "ch@n_" + i.ToString() + "_" + challengeCategory.activeChallenge.ToString();
                    if (!this.p.flags.Contains(item))
                    {
                        this.p.flags.Add(item);
                    }
                }
            }
        }

        public void ReadFlags()
        {
            ChallengeCategory[] array = this.category;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].activeChallenge = -1;
            }
            foreach (string text in this.p.flags)
            {
                if (text.StartsWith("ch@n_"))
                {
                    string[] array2 = text.Split(new char[]
                    {
                        '_'
                    });
                    if (array2.Length > 2)
                    {
                        try
                        {
                            int num = Convert.ToInt32(array2[1]);
                            int activeChallenge = Convert.ToInt32(array2[2]);
                            this.category[num].activeChallenge = activeChallenge;
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        internal bool CanCoop()
        {
            for (int i = 0; i < this.category.Length; i++)
            {
                if (this.category[i].activeChallenge > -1)
                {
                    return false;
                }
            }
            return true;
        }

        internal void Reset()
        {
            ChallengeCategory[] array = this.category;
            for (int i = 0; i < array.Length; i++)
            {
                array[i].activeChallenge = -1;
            }
        }

        public const int CATEGORY_HARDCORE = 0;

        public const int CATEGORY_LOADOUT = 1;

        public const int CATEGORY_ARMOR = 2;

        public const int CATEGORY_SHIELDS = 3;

        public const int CATEGORY_HEALING = 4;

        public const int TOTAL_CATEGORIES = 5;

        private const string CHALLENGE_STR = "ch@n_";

        public ChallengeCategory[] category;

        private Player p;
    }
}