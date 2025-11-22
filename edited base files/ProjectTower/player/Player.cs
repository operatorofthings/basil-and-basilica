using ProjectTower.character;
using ProjectTower.map.pickups;
using ProjectTower.player.challenges;
using PepperAndChurchSaveEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectTower.player
{
    public class Player
    {
        private const string DefaultSaveVersionMarker = "enh|v2";

        public Player()
        {
            this.playerInv = new PlayerInv(this);
            this.stats = new PlayerStats(this);
            this.statue = new SaltStatue();
            this.playerBeasts = new PlayerBeasts(this);
            this.challenge = new PlayerChallenges(this);
            this.Reset();
        }

        public void GetElapsedTimeStr()
        {
            int num = (int)(this.elapsedTimeTicks / 10000000L);
            int num2 = num / 60;
            num %= 60;
            int num3 = num2 / 60;
            num2 %= 60;
            this.elapsedTimeStr = new StringBuilder(string.Concat(new string[]
            {
                num3.ToString(),
                ":",
                (num2 < 10) ? "0" : "",
                num2.ToString(),
                ":",
                (num < 10) ? "0" : "",
                num.ToString()
            }));
        }

        public void Write(BinaryWriter writer)
        {
            // in the base game charequipment is a method variable, but it's a class variable in this implementation
            // that's why the "this" is ommited in the decompiled code

            // mostly base method from here on

            // the save starts with the Player.VERSION constant, which is set to 29 and is not getting increased anymore
            writer.Write(29);

            // this is the 1.09 change compared to 1.08. now all saves have this prefix (which is saved in the constant Player.SAVE_VERS2) in addition to the 29 prefix
            writer.Write(this.GetSaveVersionMarker());

            writer.Write(this.name);
            writer.Write(this.hardcore);
            writer.Write(this.kills);
            writer.Write(this.deaths);
            writer.Write(this.sanctuaryRestCount);
            writer.Write(this.corruption);
            writer.Write(this.challengeType);
            long ticks = DateTime.UtcNow.Ticks;
            this.elapsedTimeTicks += ticks - this.sessionStartTicks;
            this.sessionStartTicks = ticks;
            this.GetElapsedTimeStr();
            writer.Write(this.elapsedTimeTicks);
            writer.Write(this.playthroughNumber);
            writer.Write(this.lastSanctuaryIdx);
            this.currentCreedIdx = -1;
            for (int i = 0; i < 10; i++)
            {
                if (this.creedLevel[i] > 0)
                {
                    this.currentCreedIdx = i;
                }
            }
            writer.Write(this.currentCreedIdx);
            writer.Write(this.respawnLoc.X);
            writer.Write(this.respawnLoc.Y);
            writer.Write(this.sanctuaryRespawnLoc.X);
            writer.Write(this.sanctuaryRespawnLoc.Y);
            this.stats.Write(writer);
            for (int j = 0; j < this.creedStanding.Length; j++)
            {
                writer.Write(this.creedStanding[j]);
            }
            for (int k = 0; k < 10; k++)
            {
                for (int l = 0; l < 4; l++)
                {
                    writer.Write(this.creedUnlocks[k, l]);
                }
            }
            for (int m = 0; m < this.creedLevel.Length; m++)
            {
                writer.Write(this.creedLevel[m]);
            }
            for (int n = 0; n < this.npcStanding.Length; n++)
            {
                writer.Write(this.npcStanding[n]);
            }
            writer.Write(this.expungedCount);
            writer.Write(this.salt);
            writer.Write(this.gold);
            writer.Write(this.skinIdx);
            writer.Write(this.skinClass);
            writer.Write(this.hair);
            writer.Write(this.hairColor);
            writer.Write(this.beard);
            writer.Write(this.beardColor);
            writer.Write(this.eyeColor);
            charEquipment.Write(writer);
            this.playerInv.Write(writer);
            this.playerBeasts.Write(writer);
            this.challenge.WriteFlags();
            writer.Write(this.flags.Count);
            for (int num = 0; num < this.flags.Count; num++)
            {
                writer.Write(this.flags[num]);
            }
            for (int num2 = 0; num2 < this.sanctuaryCreed.Length; num2++)
            {
                writer.Write(this.sanctuaryCreed[num2]);
                writer.Write(this.sanctuaryVisitCount[num2]);
                for (int num3 = 0; num3 < 4; num3++)
                {
                    writer.Write(this.sanctuaryPilgrim[num2, num3]);
                }
            }
            if (this.saltOwnerVec.X != 0f || this.saltOwnerVec.Y != 0f)
            {
                writer.Write(true);
                writer.Write(this.saltTiedUp);
                writer.Write(this.saltOwnerVec.X);
                writer.Write(this.saltOwnerVec.Y);
            }
            else
            {
                writer.Write(false);
            }
            if (this.statue.exists)
            {
                writer.Write(true);
                writer.Write(this.saltStatueVec.X);
                writer.Write(this.saltStatueVec.Y);
                writer.Write(this.saltStatueAnim);
                writer.Write(this.saltStatueKey);
                writer.Write(this.saltStatueFace);
                writer.Write(this.statue.salt);
                return;
            }
            writer.Write(false);
        }

        public void Read(BinaryReader reader)
        {
            // in the base game charequipment is a method variable, but it's a class variable in this implementation
            // that's why the "this" is ommited in the decompiled code

            // this skips the Player.VERSION constant prefix (which is 29) in the save that is usually checked for before calling this method
            reader.ReadInt32();

            // mostly base method from here on (see charEquipment changes above, and I removed one line of dead code they accidentally added)

            string empty = string.Empty;
            this.sessionStartTicks = DateTime.UtcNow.Ticks;
            string possibleVersionMarker = reader.ReadString();
            if (Player.IsKnownSaveVersion(possibleVersionMarker))
            {
                empty = possibleVersionMarker;
                this.saveVersionMarker = possibleVersionMarker;
                this.name = reader.ReadString();
            }
            else
            {
                this.saveVersionMarker = DefaultSaveVersionMarker;
                this.name = possibleVersionMarker;
            }
            this.hardcore = reader.ReadBoolean();
            this.kills = reader.ReadInt32();
            this.deaths = reader.ReadInt32();
            this.sanctuaryRestCount = reader.ReadInt32();
            this.corruption = reader.ReadInt32();
            this.challengeType = reader.ReadInt32();
            this.elapsedTimeTicks = reader.ReadInt64();
            this.playthroughNumber = reader.ReadInt32();
            this.lastSanctuaryIdx = reader.ReadInt32();
            this.currentCreedIdx = reader.ReadInt32();
            this.GetElapsedTimeStr();
            this.respawnLoc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            this.sanctuaryRespawnLoc = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            this.stats.Read(reader);
            for (int i = 0; i < this.creedStanding.Length; i++)
            {
                this.creedStanding[i] = reader.ReadInt32();
            }
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    this.creedUnlocks[j, k] = reader.ReadInt32();
                }
            }
            for (int l = 0; l < this.creedLevel.Length; l++)
            {
                this.creedLevel[l] = reader.ReadInt32();
            }
            for (int m = 0; m < this.npcStanding.Length; m++)
            {
                this.npcStanding[m] = reader.ReadInt32();
            }
            this.expungedCount = reader.ReadInt32();
            this.salt = reader.ReadInt32();
            this.gold = reader.ReadInt32();
            this.skinIdx = reader.ReadInt32();
            this.skinClass = reader.ReadInt32();
            this.hair = reader.ReadInt32();
            this.hairColor = reader.ReadInt32();
            this.beard = reader.ReadInt32();
            this.beardColor = reader.ReadInt32();
            this.eyeColor = reader.ReadInt32();
            charEquipment.Read(reader);
            charEquipment.skinIdx = this.skinIdx;
            charEquipment.skinClass = this.skinClass;
            charEquipment.hair = this.hair;
            charEquipment.hairColor = this.hairColor;
            charEquipment.beard = this.beard;
            charEquipment.beardColor = this.beardColor;
            charEquipment.eyeColor = this.eyeColor;
            this.playerInv.Read(reader, empty);
            this.playerBeasts.Read(reader);
            this.flags.Clear();
            int num = reader.ReadInt32();
            for (int n = 0; n < num; n++)
            {
                this.flags.Add(reader.ReadString());
            }
            for (int num2 = 0; num2 < this.sanctuaryCreed.Length; num2++)
            {
                this.sanctuaryCreed[num2] = reader.ReadInt32();
                this.sanctuaryVisitCount[num2] = reader.ReadInt32();
                for (int num3 = 0; num3 < 4; num3++)
                {
                    this.sanctuaryPilgrim[num2, num3] = reader.ReadInt32();
                }
            }
            if (reader.ReadBoolean())
            {
                this.saltTiedUp = reader.ReadInt32();
                this.saltOwnerVec = new Vector2(reader.ReadSingle(), reader.ReadSingle());
            }
            if (reader.ReadBoolean())
            {
                this.saltStatueVec = new Vector2(reader.ReadSingle(), reader.ReadSingle());
                this.saltStatueAnim = reader.ReadInt32();
                this.saltStatueKey = reader.ReadInt32();
                this.saltStatueFace = reader.ReadInt32();
                this.statue.salt = reader.ReadInt32();
                this.needsSaltStatue = true;
            }
            else
            {
                this.statue.exists = false;
            }
            this.challenge.ReadFlags();
        }

        internal void Reset()
        {
            this.kills = 0;
            this.deaths = 0;
            this.hardcore = false;
            this.sanctuaryRestCount = 0;
            this.corruption = 0;
            this.challengeType = 0;
            this.statue.exists = false;
            this.saltStatueVec = new Vector2(0, 0);
            this.saltOwnerVec = new Vector2(0, 0);
            this.saltTiedUp = 0;
            this.lastSanctuaryIdx = -1;
            this.elapsedTimeTicks = 0L;
            this.sessionStartTicks = DateTime.UtcNow.Ticks;
            this.playthroughNumber = 0;
            this.salt = 0;
            this.gold = 0;
            this.playerBeasts.Reset();
            this.needsSaltStatue = false;
            this.runes = new bool[8];
            this.creedStanding = new int[10];
            this.creedLevel = new int[10];
            this.creedUnlocks = new int[10, 4];
            this.sanctuaryCreed = new int[40];
            this.sanctuaryVisitCount = new int[40];
            this.sanctuaryPilgrim = new int[40, 4];
            for (int i = 0; i < this.sanctuaryCreed.Length; i++)
            {
                this.sanctuaryCreed[i] = 0;
                for (int j = 0; j < 4; j++)
                {
                    this.sanctuaryPilgrim[i, j] = 0;
                }
                this.sanctuaryVisitCount[i] = 0;
            }
            this.npcStanding = new int[32];
            this.flags = new List<string>();
            this.flags.Add("___empty___");
            this.charEquipment = new CharEquipment();
            this.saveVersionMarker = DefaultSaveVersionMarker;
        }

        public PlayerStats stats;

        public PlayerInv playerInv;

        public SaltStatue statue;

        public PlayerBeasts playerBeasts;

        public PlayerChallenges challenge;

        public bool needsSaltStatue;

        public int gold;

        public int salt;

        public int drawSalt;

        public long elapsedTimeTicks;

        public StringBuilder elapsedTimeStr;

        public int playthroughNumber;

        public int lastSanctuaryIdx;

        public int currentCreedIdx;

        public long sessionStartTicks;

        public int pSanctIn;

        public int expungedCount;

        public int skinIdx;

        public int skinClass;

        public int hair;

        public int hairColor;

        public int beard;

        public int beardColor;

        public int eyeColor;

        public int deaths;

        public int kills;

        public bool hardcore;

        public int sanctuaryRestCount;

        public int corruption;

        public int challengeType;

        public string name;

        public StringBuilder nameStr;

        public Vector2 saltOwnerVec;

        public Vector2 lastSaltLocReserve;

        public int saltTiedUp;

        public Vector2 saltStatueVec;

        public int saltStatueAnim;

        public int saltStatueKey;

        public int saltStatueFace;

        public bool[] runes;

        public float consumableScroll;

        public int[] creedStanding;

        public int[] creedLevel;

        public int[] npcStanding;

        public int[,] creedUnlocks;

        public int[] sanctuaryCreed;

        public int[,] sanctuaryPilgrim;

        public int[] sanctuaryVisitCount;

        public Vector2 respawnLoc;

        public Vector2 sanctuaryRespawnLoc;

        public List<string> flags;

        public Vector2 lastSaltLoc;

        public CharEquipment charEquipment;

        private string saveVersionMarker = DefaultSaveVersionMarker;

        private static bool IsKnownSaveVersion(string value)
        {
            switch (value)
            {
                case "slv|v2":
                case "enh|v2":
                    return true;
                default:
                    return false;
            }
        }

        private string GetSaveVersionMarker()
        {
            if (!string.IsNullOrEmpty(this.saveVersionMarker))
            {
                return this.saveVersionMarker;
            }

            return DefaultSaveVersionMarker;
        }
    }
}
