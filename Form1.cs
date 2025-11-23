using LootEdit;
using LootEdit.loot;
using MapEdit.map;
using ProjectTower;
using ProjectTower.character;
using ProjectTower.player;
using ProjectTower.sanctuary;
using SkillTreeEdit.skilltree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BasilAndBasilica
{
    public partial class Form1 : Form
    {
        private string filePath = "";

        private BindingList<string> bindinglist = new BindingList<string>();

        private readonly BindingList<Sanctuary> sanctuaryBindingList = new BindingList<Sanctuary>();

        private readonly BindingList<Sanctuary> lastSanctuaryBindingList = new BindingList<Sanctuary>();

        private readonly Color formBackColor = Color.FromArgb(246, 248, 252);

        private readonly Color panelBackColor = Color.White;

        private readonly Color accentColor = Color.FromArgb(94, 129, 244);

        private readonly Font baseFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

        private readonly List<SanctuaryPreset> sanctuaryPresets = new List<SanctuaryPreset>();

        private readonly List<FlagInfo> flagCatalog = new List<FlagInfo>
        {
            new FlagInfo("___empty___", "Placeholder flag used in empty saves."),
            new FlagInfo("Quest_MerchantRescued", "Marks that the seaside merchant has been rescued."),
            new FlagInfo("Quest_JesterMet", "Indicates the player met the Jester NPC."),
            new FlagInfo("Boss_QueenOfSmiles_Defeated", "Set after defeating the Queen of Smiles."),
            new FlagInfo("Boss_SoddenKnight_Defeated", "Set after defeating the Sodden Knight."),
            new FlagInfo("Boss_DriedKing_Defeated", "Set after defeating the Dried King."),
            new FlagInfo("Boss_MadAlchemist_Defeated", "Set after defeating the Mad Alchemist."),
            new FlagInfo("Boss_ThirdLamb_Defeated", "Set after defeating the Third Lamb."),
            new FlagInfo("Boss_DisinheritedPrince_Defeated", "Set after defeating the Disinherited Prince."),
            new FlagInfo("Quest_BanditsPassGateOpened", "Gate in Bandit's Pass unlocked."),
            new FlagInfo("Quest_LadyOfSmileFreed", "Lady of Smile rescued from her cage."),
            new FlagInfo("Quest_MirandaJoined", "Miranda the Herbalist joined the sanctuary."),
            new FlagInfo("Quest_WarriorPoetFreed", "Warrior Poet rescued."),
            new FlagInfo("Quest_BlacksmithHired", "Blacksmith hired for the sanctuary.")
        };

        private readonly Random rng = new Random();

        // Game language indices per TranslationMgr: 0=EN, 1=FR, 2=IT, 3=DE, etc.
        private const int LANGUAGE_ENGLISH = 0;
        private const int LANGUAGE_GERMAN = 3;

        private readonly Dictionary<int, string> skillTypeLegend = new Dictionary<int, string>
        {
            { SkillNode.TYPE_SWORD_CLASS, "Sword class" },
            { SkillNode.TYPE_AXE_CLASS_DEP, "Axe class (dep)" },
            { SkillNode.TYPE_MACE_CLASS, "Mace class" },
            { SkillNode.TYPE_DAGGER_CLASS, "Dagger class" },
            { SkillNode.TYPE_SPEAR_CLASS_DEP, "Spear class (dep)" },
            { SkillNode.TYPE_SHIELD_CLASS, "Shield class" },
            { SkillNode.TYPE_GREATSWORD_CLASS_DEP, "Greatsword class (dep)" },
            { SkillNode.TYPE_GREATAXE_CLASS_DEP, "Greataxe class (dep)" },
            { SkillNode.TYPE_GREATHAMMER_CLASS, "Greathammer class" },
            { SkillNode.TYPE_WHIP_CLASS, "Whip class" },
            { SkillNode.TYPE_STAFF_CLASS, "Staff class" },
            { SkillNode.TYPE_BOW_CLASS, "Bow class" },
            { SkillNode.TYPE_CROSSBOW_CLASS, "Crossbow class" },
            { SkillNode.TYPE_PISTOL_CLASS_DEP, "Pistol class (dep)" },
            { SkillNode.TYPE_POLEAXE_CLASS, "Poleaxe class" },
            { SkillNode.TYPE_HALBERD_CLASS_DEP, "Halberd class (dep)" },
            { SkillNode.TYPE_ARMOR_CLASS, "Armor class" },
            { SkillNode.TYPE_STR, "Strength +" },
            { SkillNode.TYPE_DEX, "Dexterity +" },
            { SkillNode.TYPE_MAG, "Magic +" },
            { SkillNode.TYPE_WIS, "Wisdom +" },
            { SkillNode.TYPE_END, "Endurance +" },
            { SkillNode.TYPE_WILL, "Willpower +" },
            { SkillNode.TYPE_HEALTH_POT, "Health potion tier" },
            { SkillNode.TYPE_MANA_POT, "Mana potion tier" },
            { SkillNode.TYPE_PRAYER_CLASS, "Prayer class" },
            { SkillNode.TYPE_MAGIC_CLASS, "Magic class" },
            { SkillNode.TYPE_WAND_CLASS, "Wand class" },
            { SkillNode.TYPE_LIGHT_ARMOR_CLASS, "Light armor class" }
        };

        public Form1(string[] args)
        {
            InitializeComponent();
            Game1.Init(args);
            this.DoubleBuffered = true;

            InitializeSanctuaryLists();
            EnsureLastSanctuarySelection(Game1.p.lastSanctuaryIdx);

            creedBox.Items.Add("None");
            creedBox.Items.Add("The Iron Ones");
            creedBox.Items.Add("Devara's Light");
            creedBox.Items.Add("The Three");
            creedBox.Items.Add("The Stone Roots");
            creedBox.Items.Add("Order of the Betrayer");
            creedBox.Items.Add("The House of Splendor");
            creedBox.Items.Add("Keepers of Fire and Sky");

            foreach (var item in creedBox.Items)
            {
                sanctuaryCreedComboBox.Items.Add(item);
            }

            var standing = new string[] { "Desecrated", "Normal", "Buff" };

            ironStanding.Items.AddRange(standing);
            devaraStanding.Items.AddRange(standing);
            threeStanding.Items.AddRange(standing);
            stoneStanding.Items.AddRange(standing);
            darkStanding.Items.AddRange(standing);
            splendorStanding.Items.AddRange(standing);
            keeperStanding.Items.AddRange(standing);

            var levels = new string[9];
            levels[0] = "-1 (Apostate)";
            levels[1] = "0 (Unaffiliated)";

            for (int i = 1; i <= 7; i++)
            {
                levels[i + 1] = i.ToString();
            }

            ironLevel.Items.AddRange(levels);
            devaraLevel.Items.AddRange(levels);
            threeLevel.Items.AddRange(levels);
            stoneLevel.Items.AddRange(levels);
            darkLevel.Items.AddRange(levels);
            splendorLevel.Items.AddRange(levels);
            keeperLevel.Items.AddRange(levels);

            var merchants = new string[]
            {
                "None", "Priest", "Sellsword", "Leader", "Mage", "Alchemist", "Guide", "Blacksmith", "Merchant"
            };

            merchant1ComboBox.Items.AddRange(merchants);
            merchant2ComboBox.Items.AddRange(merchants);
            merchant3ComboBox.Items.AddRange(merchants);
            merchant4ComboBox.Items.AddRange(merchants);

            // set the correct default value, this also calls UpdateCreeds(), so no need to call it twice
            creedBox.SelectedIndex = 0;

            UpdateSanctuaries();
            ApplyModernTheme();

            // sync language toggle and indicators on startup (default to English)
            if (Game1.language != LANGUAGE_ENGLISH && Game1.language != LANGUAGE_GERMAN)
            {
                Game1.language = LANGUAGE_ENGLISH;
            }
            SetLanguage(Game1.language);
        }

        private void InitializeSanctuaryLists()
        {
            sanctuaryBindingList.Clear();
            lastSanctuaryBindingList.Clear();

            if (SanctuaryMgr.sanctuaries != null)
            {
                foreach (var sanctuary in SanctuaryMgr.sanctuaries)
                {
                    if (sanctuary != null)
                    {
                        if (string.IsNullOrWhiteSpace(sanctuary.SanctuaryDisplayName))
                        {
                            sanctuary.SanctuaryDisplayName = "Sanctuary #" + sanctuary.ID;
                        }
                        sanctuaryBindingList.Add(sanctuary);
                    }
                }
            }

            lastSanctuaryBindingList.Add(CreatePlaceholderSanctuary(-1));
            foreach (var sanctuary in sanctuaryBindingList)
            {
                lastSanctuaryBindingList.Add(sanctuary);
            }

            sanctuaryCreedListComboBox.DataSource = sanctuaryBindingList;
            sanctuaryCreedListComboBox.DisplayMember = "SanctuaryDisplayName";

            lastSanctuaryComboBox.DataSource = lastSanctuaryBindingList;
            lastSanctuaryComboBox.DisplayMember = "SanctuaryDisplayName";
        }

        private Sanctuary CreatePlaceholderSanctuary(int id)
        {
            var sanctuary = new Sanctuary(null, id);
            if (string.IsNullOrWhiteSpace(sanctuary.SanctuaryDisplayName))
            {
                sanctuary.SanctuaryDisplayName = string.Format("Unknown Sanctuary ({0})", id);
            }
            return sanctuary;
        }

        private int FindSanctuaryIndex(BindingList<Sanctuary> list, int id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == id)
                {
                    return i;
                }
            }

            return -1;
        }

        private void EnsureLastSanctuarySelection(int sanctId)
        {
            int index = FindSanctuaryIndex(lastSanctuaryBindingList, sanctId);
            if (index == -1)
            {
                lastSanctuaryBindingList.Add(CreatePlaceholderSanctuary(sanctId));
                index = lastSanctuaryBindingList.Count - 1;
            }

            if (index >= 0 && index < lastSanctuaryBindingList.Count)
            {
                lastSanctuaryComboBox.SelectedIndex = index;
            }
        }

        private int GetSelectedSanctuaryId()
        {
            Sanctuary sanctuary = sanctuaryCreedListComboBox.SelectedItem as Sanctuary;
            if (sanctuary != null)
            {
                return sanctuary.ID;
            }

            return -1;
        }

        private void SetMerchant(ComboBox comboBox, int slotIdx)
        {
            Player player = Game1.p;
            if (player == null || player.sanctuaryPilgrim == null || comboBox.SelectedItem == null)
            {
                return;
            }

            int selectedSanctId = GetSelectedSanctuaryId();
            if (selectedSanctId < 0 || selectedSanctId >= player.sanctuaryPilgrim.GetLength(0))
            {
                return;
            }

            int selectedMerchantId = Game1.GetMerchantIdFromName((string)comboBox.SelectedItem);
            player.sanctuaryPilgrim[selectedSanctId, slotIdx] = selectedMerchantId;
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName;
                this.filePath = path;
                BinaryReader binaryReader = new BinaryReader(File.OpenRead(path));
                Game1.p = new Player();
                Game1.c = new Character();
                Player p = Game1.p;
                p.Read(binaryReader);
                binaryReader.Close();

                nameBox.Text = p.name;
                hardcoreCheck.Checked = p.hardcore;
                killsBox.Text = p.kills.ToString();
                deathsBox.Text = p.deaths.ToString();
                restCountBox.Text = p.sanctuaryRestCount.ToString();
                corruptionBox.Text = p.corruption.ToString();
                playthroughBox.Text = p.playthroughNumber.ToString();
                string creed = Game1.GetCreedFromId(p.currentCreedIdx);
                creedBox.SelectedIndex = creedBox.FindStringExact(creed);
                EnsureLastSanctuarySelection(p.lastSanctuaryIdx);

                UpdateCreeds();

                expungedBox.Text = p.expungedCount.ToString();
                saltBox.Text = p.salt.ToString();
                goldBox.Text = p.gold.ToString();

                UpdateInventories();

                UpdateSanctuaries();

                UpdateFlags();
            }
        }

        private void UpdateInventories()
        {
            Player p = Game1.p;

            List<InvLoot> weapons = new List<InvLoot>();
            List<InvLoot> shields = new List<InvLoot>();
            List<InvLoot> armor = new List<InvLoot>();
            List<InvLoot> rings = new List<InvLoot>();
            List<InvLoot> utility = new List<InvLoot>();
            List<InvLoot> spells = new List<InvLoot>();
            List<InvLoot> keys = new List<InvLoot>();
            List<InvLoot> materials = new List<InvLoot>();

            foreach (var item in p.playerInv.inventory)
            {
                if (item != null)
                {
                    switch (item.category)
                    {
                        case 0:
                            weapons.Add(item);
                            break;

                        case 1:
                            if (!IsOneHandedShieldHack(item))
                            {
                                shields.Add(item);
                            }
                            break;

                        case 2:
                            armor.Add(item);
                            break;

                        case 3:
                            rings.Add(item);
                            break;

                        case 4:
                            utility.Add(item);
                            break;

                        case 5:
                            spells.Add(item);
                            break;

                        case 6:
                            keys.Add(item);
                            break;

                        case 7:
                            materials.Add(item);
                            break;
                    }
                }
            }

            var comparator = new InvLoot.SortInvLootByName();

            weapons.Sort(comparator);
            shields.Sort(comparator);
            armor.Sort(comparator);
            rings.Sort(comparator);
            utility.Sort(comparator);
            spells.Sort(comparator);
            keys.Sort(comparator);
            materials.Sort(comparator);

            weaponComboBox.DataSource = weapons;
            weaponComboBox.DisplayMember = "DisplayName";
            shieldsComboBox.DataSource = shields;
            shieldsComboBox.DisplayMember = "DisplayName";
            armorComboBox.DataSource = armor;
            armorComboBox.DisplayMember = "DisplayName";
            ringsComboBox.DataSource = rings;
            ringsComboBox.DisplayMember = "DisplayName";
            utilityComboBox.DataSource = utility;
            utilityComboBox.DisplayMember = "DisplayName";
            spellsComboBox.DataSource = spells;
            spellsComboBox.DisplayMember = "DisplayName";
            keysComboBox.DataSource = keys;
            keysComboBox.DisplayMember = "DisplayName";
            materialsComboBox.DataSource = materials;
            materialsComboBox.DisplayMember = "DisplayName";
        }

        private void UpdateCreeds()
        {
            SetStanding(ironStanding, Creeds.CREED_IRON);
            SetStanding(devaraStanding, Creeds.CREED_CLERIC);
            SetStanding(threeStanding, Creeds.CREED_THREE);
            SetStanding(darkStanding, Creeds.CREED_DARK);
            SetStanding(stoneStanding, Creeds.CREED_WOODS);
            SetStanding(splendorStanding, Creeds.CREED_SPLENDOR);
            SetStanding(keeperStanding, Creeds.CREED_FIRE);

            SetLevel(ironLevel, Creeds.CREED_IRON);
            SetLevel(devaraLevel, Creeds.CREED_CLERIC);
            SetLevel(threeLevel, Creeds.CREED_THREE);
            SetLevel(darkLevel, Creeds.CREED_DARK);
            SetLevel(stoneLevel, Creeds.CREED_WOODS);
            SetLevel(splendorLevel, Creeds.CREED_SPLENDOR);
            SetLevel(keeperLevel, Creeds.CREED_FIRE);
        }

        private void SetStanding(ComboBox a, int id)
        {
            int[] stand = Game1.p.creedStanding;
            int standing = stand[id];
            switch (standing)
            {
                case -1:
                    a.SelectedIndex = a.FindStringExact("Desecrated");
                    break;

                case 0:
                    a.SelectedIndex = a.FindStringExact("Normal");
                    break;

                case 1:
                    a.SelectedIndex = a.FindStringExact("Buff");
                    break;
            }
        }

        private void SetLevel(ComboBox a, int id)
        {
            int[] levels = Game1.p.creedLevel;
            int level = levels[id];
            switch (level)
            {
                case -1:
                    a.SelectedIndex = a.FindStringExact("-1 (Apostate)");
                    break;

                case 0:
                    a.SelectedIndex = a.FindStringExact("0 (Unaffiliated)");
                    break;

                case 1:
                    a.SelectedIndex = a.FindStringExact("1");
                    break;

                case 2:
                    a.SelectedIndex = a.FindStringExact("2");
                    break;

                case 3:
                    a.SelectedIndex = a.FindStringExact("3");
                    break;

                case 4:
                    a.SelectedIndex = a.FindStringExact("4");
                    break;

                case 5:
                    a.SelectedIndex = a.FindStringExact("5");
                    break;

                case 6:
                    a.SelectedIndex = a.FindStringExact("6");
                    break;

                case 7:
                    a.SelectedIndex = a.FindStringExact("7");
                    break;
            }
        }

        private void UpdateSanctuaries()
        {
            Sanctuary selectedSanctuary = sanctuaryCreedListComboBox.SelectedItem as Sanctuary;
            if (selectedSanctuary == null)
            {
                return;
            }

            Player player = Game1.p;
            if (player == null || player.sanctuaryCreed == null || player.sanctuaryPilgrim == null)
            {
                return;
            }

            int selectedSanctId = selectedSanctuary.ID;
            if (selectedSanctId < 0 || selectedSanctId >= player.sanctuaryCreed.Length)
            {
                return;
            }

            int selectedSanctCreed = player.sanctuaryCreed[selectedSanctId];
            sanctuaryCreedComboBox.SelectedIndex = sanctuaryCreedComboBox.FindStringExact(Game1.GetCreedFromId(selectedSanctCreed));
            merchant1ComboBox.SelectedIndex = merchant1ComboBox.FindStringExact(Game1.GetMerchantNameFromId(player.sanctuaryPilgrim[selectedSanctId, 0]));
            merchant2ComboBox.SelectedIndex = merchant2ComboBox.FindStringExact(Game1.GetMerchantNameFromId(player.sanctuaryPilgrim[selectedSanctId, 1]));
            merchant3ComboBox.SelectedIndex = merchant3ComboBox.FindStringExact(Game1.GetMerchantNameFromId(player.sanctuaryPilgrim[selectedSanctId, 2]));
            merchant4ComboBox.SelectedIndex = merchant4ComboBox.FindStringExact(Game1.GetMerchantNameFromId(player.sanctuaryPilgrim[selectedSanctId, 3]));
        }

        private void UpdateFlags()
        {
            bindinglist = new BindingList<string>();

            for (int i = 0; i < Game1.p.flags.Count; i++)
            {
                bindinglist.Add(Game1.p.flags[i]);
            }

            BindingSource bSource = new BindingSource
            {
                DataSource = bindinglist
            };

            playerflagsComboBox.DataSource = bSource;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath != "")
            {
                string backupPath = filePath + ".bak";
                while (File.Exists(backupPath))
                {
                    backupPath += ".bak";
                }
                File.Copy(filePath, backupPath, true);

                BinaryWriter binaryWriter = new BinaryWriter(File.Open(filePath, FileMode.Truncate, FileAccess.Write));
                Game1.p.Write(binaryWriter);
                binaryWriter.Close();
            }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.name = nameBox.Text;
        }

        private void HardcoreCheck_CheckedChanged(object sender, EventArgs e)
        {
            Game1.p.hardcore = hardcoreCheck.Checked;
        }

        private void KillsBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.kills = Int32.Parse(killsBox.Text);
        }

        private void DeathsBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.deaths = Int32.Parse(deathsBox.Text);
        }

        private void RestCountBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.sanctuaryRestCount = Int32.Parse(restCountBox.Text);
        }

        private void CorruptionBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.corruption = Int32.Parse(corruptionBox.Text);
        }

        private void PlaythroughBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.playthroughNumber = Int32.Parse(playthroughBox.Text);
        }

        private void ExpungedBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.expungedCount = Int32.Parse(expungedBox.Text);
        }

        private void SaltBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.salt = Int32.Parse(saltBox.Text);
        }

        private void GoldBox_TextChanged(object sender, EventArgs e)
        {
            Game1.p.gold = Int32.Parse(goldBox.Text);
        }

        private void CreedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int creedId = Game1.GetIdFromCreed((string)creedBox.SelectedItem);
            Player p = Game1.p;
            p.currentCreedIdx = creedId;

            UpdateCreeds();
        }

        private void LastSanctuaryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sanctuary selectedSanctuary = lastSanctuaryComboBox.SelectedItem as Sanctuary;
            if (selectedSanctuary == null)
            {
                return;
            }

            int sanctId = selectedSanctuary.ID;
            Player p = Game1.p;
            if (p == null)
            {
                return;
            }

            p.lastSanctuaryIdx = sanctId;

            if (sanctId >= 0 && sanctId < SanctuaryMgr.sanctuaries.Length && SanctuaryMgr.sanctuaries[sanctId] != null)
            {
                Sanctuary newSanct = SanctuaryMgr.sanctuaries[sanctId];
                p.respawnLoc = newSanct.loc;
                p.sanctuaryRespawnLoc = newSanct.loc;
            }
        }

        private void IronStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)ironStanding.SelectedItem;
            switch (selection)
            {
                case "Desecrated":
                    Game1.p.creedStanding[Creeds.CREED_IRON] = -1;
                    break;

                case "Normal":
                    Game1.p.creedStanding[Creeds.CREED_IRON] = 0;
                    break;

                case "Buff":
                    Game1.p.creedStanding[Creeds.CREED_IRON] = 1;
                    break;
            }
        }

        private void DevaraStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)devaraStanding.SelectedItem;
            switch (selection)
            {
                case "Desecrated":
                    Game1.p.creedStanding[Creeds.CREED_CLERIC] = -1;
                    break;

                case "Normal":
                    Game1.p.creedStanding[Creeds.CREED_CLERIC] = 0;
                    break;

                case "Buff":
                    Game1.p.creedStanding[Creeds.CREED_CLERIC] = 1;
                    break;
            }
        }

        private void ThreeStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)threeStanding.SelectedItem;
            switch (selection)
            {
                case "Desecrated":
                    Game1.p.creedStanding[Creeds.CREED_THREE] = -1;
                    break;

                case "Normal":
                    Game1.p.creedStanding[Creeds.CREED_THREE] = 0;
                    break;

                case "Buff":
                    Game1.p.creedStanding[Creeds.CREED_THREE] = 1;
                    break;
            }
        }

        private void StoneStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)stoneStanding.SelectedItem;
            switch (selection)
            {
                case "Desecrated":
                    Game1.p.creedStanding[Creeds.CREED_WOODS] = -1;
                    break;

                case "Normal":
                    Game1.p.creedStanding[Creeds.CREED_WOODS] = 0;
                    break;

                case "Buff":
                    Game1.p.creedStanding[Creeds.CREED_WOODS] = 1;
                    break;
            }
        }

        private void DarkStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)darkStanding.SelectedItem;
            switch (selection)
            {
                case "Desecrated":
                    Game1.p.creedStanding[Creeds.CREED_DARK] = -1;
                    break;

                case "Normal":
                    Game1.p.creedStanding[Creeds.CREED_DARK] = 0;
                    break;

                case "Buff":
                    Game1.p.creedStanding[Creeds.CREED_DARK] = 1;
                    break;
            }
        }

        private void SplendorStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)splendorStanding.SelectedItem;
            switch (selection)
            {
                case "Desecrated":
                    Game1.p.creedStanding[Creeds.CREED_SPLENDOR] = -1;
                    break;

                case "Normal":
                    Game1.p.creedStanding[Creeds.CREED_SPLENDOR] = 0;
                    break;

                case "Buff":
                    Game1.p.creedStanding[Creeds.CREED_SPLENDOR] = 1;
                    break;
            }
        }

        private void KeeperStanding_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)keeperStanding.SelectedItem;
            switch (selection)
            {
                case "Desecrated":
                    Game1.p.creedStanding[Creeds.CREED_FIRE] = -1;
                    break;

                case "Normal":
                    Game1.p.creedStanding[Creeds.CREED_FIRE] = 0;
                    break;

                case "Buff":
                    Game1.p.creedStanding[Creeds.CREED_FIRE] = 1;
                    break;
            }
        }

        private void IronLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)ironLevel.SelectedItem;
            switch (selection)
            {
                case "-1 (Apostate)":
                    Game1.p.creedLevel[Creeds.CREED_IRON] = -1;
                    break;

                case "0 (Unaffiliated)":
                    Game1.p.creedLevel[Creeds.CREED_IRON] = 0;
                    break;

                default:
                    Game1.p.creedLevel[Creeds.CREED_IRON] = Int32.Parse(selection);
                    break;
            }
        }

        private void DevaraLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)devaraLevel.SelectedItem;
            switch (selection)
            {
                case "-1 (Apostate)":
                    Game1.p.creedLevel[Creeds.CREED_CLERIC] = -1;
                    break;

                case "0 (Unaffiliated)":
                    Game1.p.creedLevel[Creeds.CREED_CLERIC] = 0;
                    break;

                default:
                    Game1.p.creedLevel[Creeds.CREED_CLERIC] = Int32.Parse(selection);
                    break;
            }
        }

        private void ThreeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)threeLevel.SelectedItem;
            switch (selection)
            {
                case "-1 (Apostate)":
                    Game1.p.creedLevel[Creeds.CREED_THREE] = -1;
                    break;

                case "0 (Unaffiliated)":
                    Game1.p.creedLevel[Creeds.CREED_THREE] = 0;
                    break;

                default:
                    Game1.p.creedLevel[Creeds.CREED_THREE] = Int32.Parse(selection);
                    break;
            }
        }

        private void StoneLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)stoneLevel.SelectedItem;
            switch (selection)
            {
                case "-1 (Apostate)":
                    Game1.p.creedLevel[Creeds.CREED_WOODS] = -1;
                    break;

                case "0 (Unaffiliated)":
                    Game1.p.creedLevel[Creeds.CREED_WOODS] = 0;
                    break;

                default:
                    Game1.p.creedLevel[Creeds.CREED_WOODS] = Int32.Parse(selection);
                    break;
            }
        }

        private void DarkLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)darkLevel.SelectedItem;
            switch (selection)
            {
                case "-1 (Apostate)":
                    Game1.p.creedLevel[Creeds.CREED_DARK] = -1;
                    break;

                case "0 (Unaffiliated)":
                    Game1.p.creedLevel[Creeds.CREED_DARK] = 0;
                    break;

                default:
                    Game1.p.creedLevel[Creeds.CREED_DARK] = Int32.Parse(selection);
                    break;
            }
        }

        private void SplendorLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)splendorLevel.SelectedItem;
            switch (selection)
            {
                case "-1 (Apostate)":
                    Game1.p.creedLevel[Creeds.CREED_SPLENDOR] = -1;
                    break;

                case "0 (Unaffiliated)":
                    Game1.p.creedLevel[Creeds.CREED_SPLENDOR] = 0;
                    break;

                default:
                    Game1.p.creedLevel[Creeds.CREED_SPLENDOR] = Int32.Parse(selection);
                    break;
            }
        }

        private void KeeperLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selection = (string)keeperLevel.SelectedItem;
            switch (selection)
            {
                case "-1 (Apostate)":
                    Game1.p.creedLevel[Creeds.CREED_FIRE] = -1;
                    break;

                case "0 (Unaffiliated)":
                    Game1.p.creedLevel[Creeds.CREED_FIRE] = 0;
                    break;

                default:
                    Game1.p.creedLevel[Creeds.CREED_FIRE] = Int32.Parse(selection);
                    break;
            }
        }

        private void WeaponAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(0);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        private void ShieldAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(1);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        private void ArmorAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(2);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        private void RingsAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(3);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        private void UtilityAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(4);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        private void SpellsAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(5);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        private void KeysAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(6);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        private void MaterialsAdd_Click(object sender, EventArgs e)
        {
            InvLoot item = AddPrompt.ShowDialog(7);
            if (item != null)
            {
                Game1.p.playerInv.Add(item, false, item.count);
                UpdateInventories();
            }
        }

        public static class EditPrompt
        {
            public static void ShowDialog(InvLoot loot, bool isUpgradable)
            {
                Form prompt = new Form
                {
                    Text = "Edit " + loot.DisplayName
                };
                ComboBox upgradeComboBox = new ComboBox();
                TextBox qtyBox;

                if (isUpgradable)
                {
                    prompt.Width = 300;
                    prompt.Height = 130;
                    upgradeComboBox.FormattingEnabled = true;
                    upgradeComboBox.Location = new System.Drawing.Point(90, 10);
                    upgradeComboBox.Size = new System.Drawing.Size(50, 200);
                    upgradeComboBox.TabIndex = 0;

                    for (int i = 0; i <= 7; i++)
                    {
                        upgradeComboBox.Items.Add(i.ToString());
                    }

                    upgradeComboBox.SelectedIndex = loot.upgrade;
                    Label upgrade = new Label() { Text = "Upgrade Level", Width = 90, Left = 10, Top = 13 };

                    Label qty = new Label() { Text = "Quantity", Width = 50, Left = 10, Top = 43 };
                    qtyBox = new TextBox { Text = loot.count.ToString(), Left = 60, Width = 40, Top = 40 };

                    Button confirmation = new Button
                    {
                        Text = "Ok",
                        Left = 50,
                        Width = 80,
                        Top = 65,
                        DialogResult = DialogResult.OK
                    };

                    prompt.Controls.Add(upgradeComboBox);
                    prompt.Controls.Add(upgrade);
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(qty);
                    prompt.Controls.Add(qtyBox);
                }
                else
                {
                    prompt.Width = 300;
                    prompt.Height = 115;

                    Label qty = new Label() { Text = "Quantity", Width = 50, Left = 10, Top = 13 };
                    qtyBox = new TextBox { Text = loot.count.ToString(), Left = 60, Width = 40, Top = 10 };

                    Button confirmation = new Button
                    {
                        Text = "Ok",
                        Left = 50,
                        Width = 80,
                        Top = 35,
                        DialogResult = DialogResult.OK
                    };

                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(qty);
                    prompt.Controls.Add(qtyBox);
                }

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    if (isUpgradable)
                    {
                        loot.upgrade = Int32.Parse((string)upgradeComboBox.SelectedItem);
                    }
                    loot.count = Int32.Parse(qtyBox.Text);
                }
            }
        }

        public static class AddPrompt
        {
            public static InvLoot ShowDialog(int category)
            {
                Form prompt = new Form
                {
                    Width = 205,
                    Height = 390,
                    Text = "Add Item"
                };
                ComboBox lootComboBox = new ComboBox
                {
                    DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple,
                    FormattingEnabled = true,
                    Location = new System.Drawing.Point(10, 10),
                    Size = new System.Drawing.Size(170, 300),
                    TabIndex = 0
                };

                Label qty = new Label() { Text = "Quantity", Width = 50, Left = 10, Top = 324 };
                TextBox qtyBox = new TextBox { Text = "1", Left = 60, Width = 40, Top = 320 };

                List<LootDefWrapper> wrappedItems = new List<LootDefWrapper>();

                foreach (var item in LootCatalog.category[category].loot)
                {
                    if (category != 1 || !IsOneHandedShieldHack(item))
                    {
                        wrappedItems.Add(new LootDefWrapper(item));
                    }
                }

                wrappedItems.Sort(new LootDefWrapper.SortLootDefByName());

                lootComboBox.DataSource = wrappedItems;
                lootComboBox.DisplayMember = "DisplayName";

                Button confirmation = new Button
                {
                    Text = "Add",
                    Left = 110,
                    Width = 55,
                    Top = 320,
                    DialogResult = DialogResult.OK
                };
                prompt.Controls.Add(lootComboBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(qty);
                prompt.Controls.Add(qtyBox);
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    InvLoot res = new InvLoot();
                    res.InitFromName(((LootDefWrapper)lootComboBox.SelectedItem).LootDef.name);
                    res.count = Int32.Parse(qtyBox.Text);
                    return res;
                }
                else
                {
                    return (InvLoot)null;
                }
            }
        }

        private static bool IsOneHandedShieldHack(InvLoot loot)
        {
            return loot.category == 1 && loot.catalogIdx > -1 && LootCatalog.category[1].loot[loot.catalogIdx].type == 4;
        }

        private static bool IsOneHandedShieldHack(LootDef loot)
        {
            return loot.category == 1 && loot.type == 4;
        }

        private void WeaponEdit_Click(object sender, EventArgs e)
        {
            if (weaponComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)weaponComboBox.SelectedItem, true);
            }
        }

        private void MaterialsEdit_Click(object sender, EventArgs e)
        {
            if (materialsComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)materialsComboBox.SelectedItem, false);
            }
        }

        private void ShieldEdit_Click(object sender, EventArgs e)
        {
            if (shieldsComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)shieldsComboBox.SelectedItem, true);
            }
        }

        private void ArmorEdit_Click(object sender, EventArgs e)
        {
            if (armorComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)armorComboBox.SelectedItem, true);
            }
        }

        private void RingsEdit_Click(object sender, EventArgs e)
        {
            if (ringsComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)ringsComboBox.SelectedItem, false);
            }
        }

        private void UtilityEdit_Click(object sender, EventArgs e)
        {
            if (utilityComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)utilityComboBox.SelectedItem, false);
            }
        }

        private void SpellsEdit_Click(object sender, EventArgs e)
        {
            if (spellsComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)spellsComboBox.SelectedItem, false);
            }
        }

        private void KeysEdit_Click(object sender, EventArgs e)
        {
            if (keysComboBox.SelectedItem != null)
            {
                EditPrompt.ShowDialog((InvLoot)keysComboBox.SelectedItem, false);
            }
        }

        private void SanctuaryCreedListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSanctuaries();
        }

        private void SanctuaryCreedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedSanctId = GetSelectedSanctuaryId();
            Player player = Game1.p;
            if (selectedSanctId < 0 || player == null || player.sanctuaryCreed == null || selectedSanctId >= player.sanctuaryCreed.Length || sanctuaryCreedComboBox.SelectedItem == null)
            {
                return;
            }

            int selectedCreedId = Game1.GetIdFromCreed((string)sanctuaryCreedComboBox.SelectedItem);
            player.sanctuaryCreed[selectedSanctId] = selectedCreedId;
        }

        private void Merchant1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMerchant(merchant1ComboBox, 0);
        }

        private void Merchant2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMerchant(merchant2ComboBox, 1);
        }

        private void Merchant3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMerchant(merchant3ComboBox, 2);
        }

        private void Merchant4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMerchant(merchant4ComboBox, 3);
        }

        private void SanctuaryPresetsMenuItem_Click(object sender, EventArgs e)
        {
            ShowSanctuaryPresetManager();
        }

        private void FlagExplorerMenuItem_Click(object sender, EventArgs e)
        {
            ShowFlagExplorer();
        }

        private void StatsDashboardMenuItem_Click(object sender, EventArgs e)
        {
            ShowStatsDashboard();
        }

        private void InventoryHelperMenuItem_Click(object sender, EventArgs e)
        {
            ShowInventoryHelper();
        }

        private void SkillTreeMenuItem_Click(object sender, EventArgs e)
        {
            ShowSkillTreeBuilder();
        }

        private void BackupManagerMenuItem_Click(object sender, EventArgs e)
        {
            ShowBackupManager();
        }

        private void LanguageEnglishMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(LANGUAGE_ENGLISH);
        }

        private void LanguageGermanMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage(LANGUAGE_GERMAN);
        }

        private void SetLanguage(int languageIndex)
        {
            int lang = languageIndex;
            if (lang != LANGUAGE_ENGLISH && lang != LANGUAGE_GERMAN)
            {
                lang = LANGUAGE_ENGLISH;
            }

            Game1.language = lang;
            UpdateLanguageMenuVisuals(lang);

            ResetDisplayNameCache();
            UpdateInventories();
            UpdateSanctuaries();
            ApplyThemeToControl(tabs); // force redraw of tab headers
        }

        private void UpdateLanguageMenuVisuals(int lang)
        {
            languageEnglishTopMenuItem.Checked = lang == LANGUAGE_ENGLISH;
            languageGermanTopMenuItem.Checked = lang == LANGUAGE_GERMAN;

            Action<ToolStripMenuItem, bool> style = (item, isSelected) =>
            {
                item.BackColor = isSelected ? Color.FromArgb(224, 232, 255) : Color.Transparent;
                item.Font = isSelected ? new Font(baseFont, FontStyle.Bold) : baseFont;
            };

            style(languageEnglishTopMenuItem, lang == LANGUAGE_ENGLISH);
            style(languageGermanTopMenuItem, lang == LANGUAGE_GERMAN);
        }

        private void ResetDisplayNameCache()
        {
            foreach (var item in Game1.p.playerInv.inventory)
            {
                if (item != null)
                {
                    item.ResetDisplayName();
                }
            }
        }

        private void ShowSanctuaryPresetManager()
        {
            Form dialog = new Form
            {
                Text = "Sanctuary Presets",
                Size = new Size(420, 360),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            ListBox presetList = new ListBox
            {
                Dock = DockStyle.Top,
                Height = 200,
                DisplayMember = "DisplayLabel"
            };

            Action refreshList = () =>
            {
                presetList.DataSource = null;
                presetList.DataSource = sanctuaryPresets.ToList();
                presetList.DisplayMember = "DisplayLabel";
            };

            refreshList();

            Button saveButton = new Button { Text = "Save Current", Width = 120, Top = 210, Left = 10 };
            Button applyButton = new Button { Text = "Apply to Current", Width = 120, Top = 210, Left = 150 };
            Button deleteButton = new Button { Text = "Delete Preset", Width = 120, Top = 210, Left = 290 };
            Button closeButton = new Button { Text = "Close", Width = 120, Top = 260, Left = 150, DialogResult = DialogResult.OK };

            saveButton.Click += (s, e) =>
            {
                int sanctId = GetSelectedSanctuaryId();
                if (sanctId < 0)
                {
                    MessageBox.Show("Select a sanctuary first.", "Sanctuaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string presetName = ShowTextPrompt("Save Preset", "Preset name:", string.Format("Sanctuary {0}", sanctId));
                if (string.IsNullOrWhiteSpace(presetName))
                {
                    return;
                }

                var preset = new SanctuaryPreset
                {
                    Name = presetName.Trim(),
                    SanctuaryId = sanctId,
                    CreedId = Game1.p.sanctuaryCreed[sanctId],
                    Merchants = new int[4]
                    {
                        Game1.p.sanctuaryPilgrim[sanctId,0],
                        Game1.p.sanctuaryPilgrim[sanctId,1],
                        Game1.p.sanctuaryPilgrim[sanctId,2],
                        Game1.p.sanctuaryPilgrim[sanctId,3]
                    }
                };

                sanctuaryPresets.RemoveAll(p => string.Equals(p.Name, preset.Name, StringComparison.OrdinalIgnoreCase));
                sanctuaryPresets.Add(preset);
                refreshList();
            };

            applyButton.Click += (s, e) =>
            {
                SanctuaryPreset selectedPreset = presetList.SelectedItem as SanctuaryPreset;
                if (selectedPreset == null)
                {
                    MessageBox.Show("Select a preset to apply.", "Sanctuaries", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ApplySanctuaryPreset(selectedPreset);
                refreshList();
            };

            deleteButton.Click += (s, e) =>
            {
                SanctuaryPreset selectedPreset = presetList.SelectedItem as SanctuaryPreset;
                if (selectedPreset == null)
                {
                    return;
                }
                sanctuaryPresets.Remove(selectedPreset);
                refreshList();
            };

            dialog.Controls.Add(presetList);
            dialog.Controls.Add(saveButton);
            dialog.Controls.Add(applyButton);
            dialog.Controls.Add(deleteButton);
            dialog.Controls.Add(closeButton);
            ApplyThemeToForm(dialog);
            dialog.ShowDialog(this);
        }

        private void ApplySanctuaryPreset(SanctuaryPreset preset)
        {
            int sanctId = GetSelectedSanctuaryId();
            if (sanctId < 0 || sanctId >= Game1.p.sanctuaryCreed.Length)
            {
                MessageBox.Show("Select a valid sanctuary first.", "Sanctuaries", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Game1.p.sanctuaryCreed[sanctId] = preset.CreedId;
            for (int i = 0; i < 4; i++)
            {
                Game1.p.sanctuaryPilgrim[sanctId, i] = preset.Merchants[i];
            }

            UpdateSanctuaries();
        }

        private void ShowFlagExplorer()
        {
            Form dialog = new Form
            {
                Text = "Flag Explorer",
                Size = new Size(520, 420),
                StartPosition = FormStartPosition.CenterParent
            };

            TextBox searchBox = new TextBox { Dock = DockStyle.Top };
            ListBox flagList = new ListBox { Dock = DockStyle.Top, Height = 220, DisplayMember = "Id" };
            Label descriptionLabel = new Label { Dock = DockStyle.Top, Height = 80, Text = "Select a flag to see details.", Padding = new Padding(4) };

            Action refresh = () =>
            {
                var filtered = flagCatalog
                    .Where(f => f.Id.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                f.Description.IndexOf(searchBox.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
                flagList.DataSource = filtered;
                flagList.DisplayMember = "Id";
            };

            searchBox.TextChanged += (s, e) => refresh();
            flagList.SelectedIndexChanged += (s, e) =>
            {
                FlagInfo info = flagList.SelectedItem as FlagInfo;
                if (info != null)
                {
                    descriptionLabel.Text = info.Description;
                }
            };
            refresh();

            FlowLayoutPanel buttonsPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 50, FlowDirection = FlowDirection.RightToLeft };
            Button addButton = new Button { Text = "Add to Save", Width = 120 };
            Button removeButton = new Button { Text = "Remove from Save", Width = 150 };
            Button closeButton = new Button { Text = "Close", Width = 100, DialogResult = DialogResult.OK };

            addButton.Click += (s, e) =>
            {
                FlagInfo info = flagList.SelectedItem as FlagInfo;
                if (info != null)
                {
                    AddFlagToSave(info.Id);
                }
            };

            removeButton.Click += (s, e) =>
            {
                FlagInfo info = flagList.SelectedItem as FlagInfo;
                if (info != null)
                {
                    RemoveFlagFromSave(info.Id);
                }
            };

            buttonsPanel.Controls.Add(closeButton);
            buttonsPanel.Controls.Add(removeButton);
            buttonsPanel.Controls.Add(addButton);

            dialog.Controls.Add(buttonsPanel);
            dialog.Controls.Add(descriptionLabel);
            dialog.Controls.Add(flagList);
            dialog.Controls.Add(searchBox);
            ApplyThemeToForm(dialog);
            dialog.ShowDialog(this);
        }

        private void ShowStatsDashboard()
        {
            Player p = Game1.p;
            Form dialog = new Form
            {
                Text = "Stats Dashboard",
                Size = new Size(420, 420),
                StartPosition = FormStartPosition.CenterParent
            };

            TableLayoutPanel table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                AutoScroll = true
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60f));

            Action<string, string> addRow = (label, value) =>
            {
                int rowIndex = table.RowCount++;
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                table.Controls.Add(new Label { Text = label, AutoSize = true, Padding = new Padding(4) }, 0, rowIndex);
                table.Controls.Add(new Label { Text = value, AutoSize = true, Padding = new Padding(4), ForeColor = Color.FromArgb(30, 34, 45) }, 1, rowIndex);
            };

            addRow("Name", p.name);
            addRow("Current Creed", Game1.GetCreedFromId(p.currentCreedIdx));
            addRow("Last Sanctuary", Game1.GetSanctNameFromId(p.lastSanctuaryIdx));
            addRow("Playthrough", p.playthroughNumber.ToString());
            addRow("Kills", p.kills.ToString());
            addRow("Deaths", p.deaths.ToString());
            addRow("Salt", p.salt.ToString());
            addRow("Gold", p.gold.ToString());
            addRow("Corruption", p.corruption.ToString());
            addRow("Expunged", p.expungedCount.ToString());
            addRow("Elapsed Time (ticks)", p.elapsedTimeTicks.ToString());

            dialog.Controls.Add(table);
            ApplyThemeToForm(dialog);
            dialog.ShowDialog(this);
        }

        private void ShowInventoryHelper()
        {
            Form dialog = new Form
            {
                Text = "Inventory Helper",
                Size = new Size(520, 460),
                StartPosition = FormStartPosition.CenterParent
            };

            Label infoLabel = new Label
            {
                Left = 10,
                Top = 10,
                Width = 490,
                Height = 44,
                Text = "Filter by category and text. Select an item and use quick add buttons to bump its count. Bulk buttons: give materials or remove duplicates. Save afterward to commit to disk."
            };

            ComboBox categoryCombo = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Left = 10, Top = 10, Width = 200 };
            categoryCombo.Items.AddRange(new object[]
            {
                "All",
                "Weapons",
                "Shields",
                "Armor",
                "Rings / Charms / Brands",
                "Utility",
                "Spells",
                "Keys",
                "Materials"
            });
            categoryCombo.SelectedIndex = 0;

            TextBox filterBox = new TextBox { Left = 10, Top = 50, Width = 490 };
            ListBox resultList = new ListBox { Left = 10, Top = 80, Width = 490, Height = 230 };
            Label selectionLabel = new Label { Left = 10, Top = 315, Width = 300, Height = 20, Text = "Selected: (none)" };
            Label statusLabel = new Label { Left = 10, Top = 340, Width = 490, Height = 18, ForeColor = Color.FromArgb(60, 64, 78) };

            Action refresh = () =>
            {
                int selectedCategory = categoryCombo.SelectedIndex - 1;
                string filter = filterBox.Text ?? string.Empty;
                InvLoot selectedLoot = resultList.SelectedItem as InvLoot;
                int previousIndex = resultList.SelectedIndex;

                var items = Game1.p.playerInv.inventory
                    .Where(i => i != null)
                    .Where(i => selectedCategory < 0 || i.category == selectedCategory)
                    .Where(i => i.DisplayName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(i => i.DisplayName)
                    .ToList();

                resultList.DataSource = null;
                resultList.DataSource = items;
                resultList.DisplayMember = "DisplayName";

                int foundIndex = selectedLoot != null ? items.IndexOf(selectedLoot) : -1;
                if (foundIndex >= 0)
                {
                    resultList.SelectedIndex = foundIndex;
                }
                else if (previousIndex >= 0 && previousIndex < items.Count)
                {
                    resultList.SelectedIndex = previousIndex;
                }
                else
                {
                    resultList.ClearSelected();
                }
            };

            resultList.SelectedIndexChanged += (s, e) =>
            {
                InvLoot loot = resultList.SelectedItem as InvLoot;
                if (loot != null)
                {
                    selectionLabel.Text = string.Format("Selected: {0} (x{1})", loot.DisplayName, loot.count);
                }
                else
                {
                    selectionLabel.Text = "Selected: (none)";
                }
            };

            categoryCombo.SelectedIndexChanged += (s, e) => refresh();
            filterBox.TextChanged += (s, e) => refresh();
            refresh();

            Button add1Button = new Button { Text = "+1", Width = 50, Left = 320, Top = 310 };
            Button add10Button = new Button { Text = "+10", Width = 50, Left = 375, Top = 310 };
            Button add50Button = new Button { Text = "+50", Width = 50, Left = 430, Top = 310 };
            Button add100Button = new Button { Text = "+100", Width = 50, Left = 485, Top = 310 };

            Action<int> bumpSelected = (amount) =>
            {
                InvLoot loot = resultList.SelectedItem as InvLoot;
                if (loot != null)
                {
                    loot.count += amount;
                    selectionLabel.Text = string.Format("Selected: {0} (x{1})", loot.DisplayName, loot.count);
                    statusLabel.Text = string.Format("Queued change: +{0} to {1}. Save to commit.", amount, loot.DisplayName);
                    refresh();
                }
            };

            add1Button.Click += (s, e) => bumpSelected(1);
            add10Button.Click += (s, e) => bumpSelected(10);
            add50Button.Click += (s, e) => bumpSelected(50);
            add100Button.Click += (s, e) => bumpSelected(100);

            Button addMaterialsButton = new Button { Text = "Give 20 of each material", Width = 200, Left = 10, Top = 370 };
            Button clearDuplicatesButton = new Button { Text = "Remove duplicates", Width = 150, Left = 220, Top = 370 };
            Button refreshButton = new Button { Text = "Refresh", Width = 100, Left = 380, Top = 370 };

            addMaterialsButton.Click += (s, e) =>
            {
                AddAllMaterials(20);
                statusLabel.Text = "Materials granted. Save to commit.";
                refresh();
            };

            clearDuplicatesButton.Click += (s, e) =>
            {
                ClearDuplicateInventoryItems();
                statusLabel.Text = "Duplicates removed. Save to commit.";
                refresh();
            };

            refreshButton.Click += (s, e) => refresh();

            dialog.Controls.Add(infoLabel);
            dialog.Controls.Add(categoryCombo);
            dialog.Controls.Add(filterBox);
            dialog.Controls.Add(resultList);
            dialog.Controls.Add(selectionLabel);
            dialog.Controls.Add(statusLabel);
            dialog.Controls.Add(add1Button);
            dialog.Controls.Add(add10Button);
            dialog.Controls.Add(add50Button);
            dialog.Controls.Add(add100Button);
            dialog.Controls.Add(addMaterialsButton);
            dialog.Controls.Add(clearDuplicatesButton);
            dialog.Controls.Add(refreshButton);
            ApplyThemeToForm(dialog);
            dialog.ShowDialog(this);
        }

        private void ShowBackupManager()
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Load a save file first.", "Backups", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form dialog = new Form
            {
                Text = "Backup Manager",
                Size = new Size(520, 400),
                StartPosition = FormStartPosition.CenterParent
            };

            ListBox backupList = new ListBox { Dock = DockStyle.Top, Height = 250 };

            Func<List<string>> getBackups = () =>
            {
                string directory = Path.GetDirectoryName(filePath);
                string name = Path.GetFileName(filePath);
                return Directory.GetFiles(directory, name + ".bak*").OrderByDescending(File.GetCreationTime).ToList();
            };

            Action refresh = () =>
            {
                var items = getBackups();
                backupList.DataSource = items;
            };

            refresh();

            FlowLayoutPanel buttons = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 70, FlowDirection = FlowDirection.RightToLeft };
            Button closeButton = new Button { Text = "Close", Width = 100, DialogResult = DialogResult.OK };
            Button restoreButton = new Button { Text = "Restore Selected", Width = 140 };
            Button deleteButton = new Button { Text = "Delete Selected", Width = 140 };
            Button createButton = new Button { Text = "Create Manual Backup", Width = 170 };
            Button refreshButton = new Button { Text = "Refresh List", Width = 110 };

            restoreButton.Click += (s, e) =>
            {
                string selected = backupList.SelectedItem as string;
                if (string.IsNullOrEmpty(selected))
                {
                    return;
                }
                if (MessageBox.Show(string.Format("Overwrite current save with:\n{0}?", selected), "Restore Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    File.Copy(selected, filePath, true);
                }
            };

            deleteButton.Click += (s, e) =>
            {
                string selected = backupList.SelectedItem as string;
                if (string.IsNullOrEmpty(selected))
                {
                    return;
                }
                File.Delete(selected);
                refresh();
            };

            createButton.Click += (s, e) =>
            {
                if (!File.Exists(filePath))
                {
                    return;
                }
                string manualBackup = filePath + ".manual_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                File.Copy(filePath, manualBackup, true);
                refresh();
            };

            refreshButton.Click += (s, e) => refresh();

            buttons.Controls.Add(closeButton);
            buttons.Controls.Add(refreshButton);
            buttons.Controls.Add(deleteButton);
            buttons.Controls.Add(restoreButton);
            buttons.Controls.Add(createButton);

            dialog.Controls.Add(buttons);
            dialog.Controls.Add(backupList);
            ApplyThemeToForm(dialog);
            dialog.ShowDialog(this);
        }

        private void ShowSkillTreeBuilder()
        {
            Form dialog = new Form
            {
                Text = "Skill Tree Builder",
                Size = new Size(880, 560),
                StartPosition = FormStartPosition.CenterParent
            };

            Label orbLabel = new Label
            {
                Left = 10,
                Top = 10,
                Width = 580,
                Height = 24,
                Font = new Font(baseFont, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 34, 45),
                Text = "Orbs spent: 0"
            };

            ListView listView = new ListView
            {
                View = View.Details,
                CheckBoxes = true,
                FullRowSelect = true,
                GridLines = false,
                Left = 10,
                Top = 40,
                Width = 520,
                Height = 420
            };
            listView.Columns.Add("ID", 50);
            listView.Columns.Add("Title", 350);
            listView.Columns.Add("Type", 80);
            listView.Columns.Add("Cost", 80);

            ListView legendList = new ListView
            {
                View = View.Details,
                FullRowSelect = false,
                GridLines = false,
                Left = listView.Right + 10,
                Top = 40,
                Width = 320,
                Height = 420,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };
            legendList.Columns.Add("Type", 60);
            legendList.Columns.Add("Meaning", 240);
            foreach (var kvp in skillTypeLegend.OrderBy(k => k.Key))
            {
                legendList.Items.Add(new ListViewItem(new string[] { kvp.Key.ToString(), kvp.Value }));
            }

            for (int i = 0; i < SkillTree.nodes.Length; i++)
            {
                SkillNode node = SkillTree.nodes[i];
                string title = node.title != null && node.title.Length > 0 ? node.title[Game1.language] : "Skill " + i;
                var item = new ListViewItem(new string[]
                {
                    i.ToString(),
                    title,
                    node.type.ToString(),
                    node.cost.ToString()
                });
                item.Checked = Game1.p.stats.treeUnlocks[i] > 0 || Game1.p.stats.classUnlocks.Contains(i);
                listView.Items.Add(item);
            }

            Button checkAll = new Button { Text = "Check All", Width = 100, Left = 10, Top = 470 };
            Button uncheckAll = new Button { Text = "Clear All", Width = 100, Left = 120, Top = 470 };
            Button randomizeBtn = new Button { Text = "Randomize", Width = 100, Left = 230, Top = 470 };
            Button importBtn = new Button { Text = "Import...", Width = 100, Left = 340, Top = 470 };
            Button exportBtn = new Button { Text = "Export...", Width = 100, Left = 450, Top = 470 };
            Button applyBtn = new Button { Text = "Apply", Width = 90, Left = legendList.Left, Top = 470 };
            Button closeBtn = new Button { Text = "Close", Width = 90, Left = legendList.Left + 100, Top = 470, DialogResult = DialogResult.OK };

            Action updateOrbs = () =>
            {
                int spent = listView.Items.Cast<ListViewItem>().Count(it => it.Checked);
                orbLabel.Text = "Orbs spent: " + spent;
            };

            listView.ItemChecked += (s, e) => updateOrbs();
            checkAll.Click += (s, e) =>
            {
                foreach (ListViewItem item in listView.Items) item.Checked = true;
                updateOrbs();
            };
            uncheckAll.Click += (s, e) =>
            {
                foreach (ListViewItem item in listView.Items) item.Checked = false;
                updateOrbs();
            };
            randomizeBtn.Click += (s, e) =>
            {
                int currentCount = listView.Items.Cast<ListViewItem>().Count(it => it.Checked);
                foreach (ListViewItem item in listView.Items) item.Checked = false;
                var shuffled = listView.Items.Cast<ListViewItem>().OrderBy(_ => rng.Next()).Take(currentCount);
                foreach (var item in shuffled) item.Checked = true;
                updateOrbs();
            };
            importBtn.Click += (s, e) =>
            {
                string input = ShowTextPrompt("Import Skill Indices", "Comma-separated skill node IDs:", "");
                if (string.IsNullOrEmpty(input)) return;
                var ids = ParseIndexList(input);
                foreach (ListViewItem item in listView.Items)
                {
                    int id = int.Parse(item.SubItems[0].Text);
                    item.Checked = ids.Contains(id);
                }
                updateOrbs();
            };
            exportBtn.Click += (s, e) =>
            {
                var ids = listView.Items.Cast<ListViewItem>().Where(it => it.Checked).Select(it => it.SubItems[0].Text);
                string export = string.Join(",", ids);
                ShowTextPrompt("Export Skills", "Copy these IDs:", export);
            };
            applyBtn.Click += (s, e) =>
            {
                var unlocks = Game1.p.stats.treeUnlocks;
                for (int i = 0; i < unlocks.Length && i < listView.Items.Count; i++)
                {
                    unlocks[i] = listView.Items[i].Checked ? 1 : 0;
                }
                Game1.p.stats.UpdateStats();
                MessageBox.Show("Skill selections applied.", "Skill Tree", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            dialog.Controls.Add(orbLabel);
            dialog.Controls.Add(listView);
            dialog.Controls.Add(legendList);
            dialog.Controls.Add(checkAll);
            dialog.Controls.Add(uncheckAll);
            dialog.Controls.Add(randomizeBtn);
            dialog.Controls.Add(importBtn);
            dialog.Controls.Add(exportBtn);
            dialog.Controls.Add(applyBtn);
            dialog.Controls.Add(closeBtn);
            ApplyThemeToForm(dialog);
            updateOrbs();
            dialog.ShowDialog(this);
        }

        private HashSet<int> ParseIndexList(string input)
        {
            var set = new HashSet<int>();
            if (string.IsNullOrEmpty(input))
            {
                return set;
            }
            var parts = input.Split(new char[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                int id;
                if (int.TryParse(part, out id))
                {
                    set.Add(id);
                }
            }
            return set;
        }


        private void AddAllMaterials(int quantity)
        {
            var materials = LootCatalog.category[7].loot;
            foreach (var loot in materials)
            {
                if (Game1.p.playerInv.inventory.Any(i => i != null && i.name == loot.name))
                {
                    continue;
                }
                InvLoot inv = new InvLoot();
                inv.InitFromName(loot.name);
                inv.count = quantity;
                Game1.p.playerInv.Add(inv, false, inv.count);
            }

            UpdateInventories();
        }

        private void ClearDuplicateInventoryItems()
        {
            var inventory = Game1.p.playerInv.inventory;
            var seen = new Dictionary<string, InvLoot>();
            for (int i = 0; i < inventory.Length; i++)
            {
                var item = inventory[i];
                if (item == null)
                {
                    continue;
                }
                string key = item.name + "|" + item.upgrade;
                InvLoot existing;
                if (seen.TryGetValue(key, out existing))
                {
                    existing.count += item.count;
                    inventory[i] = null;
                }
                else
                {
                    seen[key] = item;
                }
            }

            UpdateInventories();
        }

        private void AddFlagToSave(string flagId)
        {
            if (string.IsNullOrWhiteSpace(flagId))
            {
                return;
            }
            if (!Game1.p.flags.Contains(flagId))
            {
                Game1.p.flags.Add(flagId);
                bindinglist.Add(flagId);
            }
        }

        private void RemoveFlagFromSave(string flagId)
        {
            if (Game1.p.flags.Contains(flagId))
            {
                Game1.p.flags.Remove(flagId);
                if (bindinglist.Contains(flagId))
                {
                    bindinglist.Remove(flagId);
                }
            }
        }

        private string ShowTextPrompt(string caption, string label, string defaultValue = "")
        {
            using (Form prompt = new Form
            {
                Text = caption,
                Size = new Size(360, 160),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                Label textLabel = new Label { Left = 10, Top = 10, Text = label, AutoSize = true };
                TextBox inputBox = new TextBox { Left = 10, Top = 35, Width = 320, Text = defaultValue };
                Button confirmation = new Button { Text = "OK", Left = 170, Width = 75, Top = 70, DialogResult = DialogResult.OK };
                Button cancel = new Button { Text = "Cancel", Left = 255, Width = 75, Top = 70, DialogResult = DialogResult.Cancel };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                ApplyThemeToForm(prompt);
                return prompt.ShowDialog(this) == DialogResult.OK ? inputBox.Text : null;
            }
        }

        private void GoodbyeMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RemoveFlagButton_Click(object sender, EventArgs e)
        {
            string selectedFlag = (string)playerflagsComboBox.SelectedItem;
            Game1.p.flags.Remove(selectedFlag);
            bindinglist.Remove(selectedFlag);
        }

        private void AddFlagButton_Click(object sender, EventArgs e)
        {
            string newFlag = AddFlagPrompt.ShowDialog();
            if (newFlag != null && !bindinglist.Contains(newFlag))
            {
                Game1.p.flags.Add(newFlag);
                bindinglist.Add(newFlag);
            }
        }

        private void ApplyModernTheme()
        {
            this.Font = baseFont;
            this.BackColor = formBackColor;
            menuStrip1.Font = baseFont;
            menuStrip1.BackColor = formBackColor;
            menuStrip1.ForeColor = Color.FromArgb(30, 34, 45);

            foreach (Control control in this.Controls)
            {
                ApplyThemeToControl(control);
            }
        }

        private void ApplyThemeToControl(Control control)
        {
            if (control == menuStrip1)
            {
                return;
            }

            control.Font = baseFont;

            TabControl tabControl = control as TabControl;
            if (tabControl != null)
            {
                tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
                tabControl.Padding = new System.Drawing.Point(16, 6);
                tabControl.Appearance = TabAppearance.Normal;
                tabControl.ItemSize = new System.Drawing.Size(120, 28);
                tabControl.SizeMode = TabSizeMode.Fixed;
                tabControl.DrawItem -= ModernTabControl_DrawItem;
                tabControl.DrawItem += ModernTabControl_DrawItem;
                tabControl.BackColor = panelBackColor;
            }
            else
            {
                TabPage tabPage = control as TabPage;
                if (tabPage != null)
                {
                    tabPage.BackColor = panelBackColor;
                }
                else
                {
                    GroupBox groupBox = control as GroupBox;
                    if (groupBox != null)
                    {
                        groupBox.BackColor = panelBackColor;
                        groupBox.ForeColor = Color.FromArgb(60, 64, 78);
                    }
                    else if (control is Panel || control is FlowLayoutPanel || control is TableLayoutPanel)
                    {
                        control.BackColor = panelBackColor;
                    }
                    else
                    {
                        Button button = control as Button;
                        if (button != null)
                        {
                            button.FlatStyle = FlatStyle.Flat;
                            button.FlatAppearance.BorderSize = 0;
                            button.BackColor = accentColor;
                            button.ForeColor = Color.White;
                            button.Height = Math.Max(button.Height, 28);
                            button.Margin = new Padding(4);
                        }
                        else
                        {
                            ComboBox comboBox = control as ComboBox;
                            if (comboBox != null)
                            {
                                comboBox.FlatStyle = FlatStyle.Flat;
                                comboBox.BackColor = Color.White;
                            }
                            else
                            {
                                TextBox textBox = control as TextBox;
                                if (textBox != null)
                                {
                                    textBox.BorderStyle = BorderStyle.FixedSingle;
                                    textBox.BackColor = Color.White;
                                }
                                else
                                {
                                    CheckBox checkBox = control as CheckBox;
                                    if (checkBox != null)
                                    {
                                        checkBox.FlatStyle = FlatStyle.Flat;
                                        checkBox.BackColor = formBackColor;
                                    }
                                    else
                                    {
                                        ListBox listBox = control as ListBox;
                                        if (listBox != null)
                                        {
                                            listBox.BorderStyle = BorderStyle.FixedSingle;
                                            listBox.BackColor = Color.White;
                                        }
                                        else if (control is Label)
                                        {
                                            control.ForeColor = Color.FromArgb(60, 64, 78);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }
        }

        private void ApplyThemeToForm(Form form)
        {
            form.Font = baseFont;
            form.BackColor = formBackColor;
            foreach (Control child in form.Controls)
            {
                ApplyThemeToControl(child);
            }
        }

        private void ModernTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl != null)
            {
                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                Color tabColor = isSelected ? accentColor : Color.FromArgb(234, 237, 244);
                Color textColor = isSelected ? Color.White : Color.FromArgb(80, 86, 106);
                using (SolidBrush brush = new SolidBrush(tabColor))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                TextRenderer.DrawText(e.Graphics, tabControl.TabPages[e.Index].Text, baseFont, e.Bounds, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        public static class AddFlagPrompt
        {
            public static string ShowDialog()
            {
                Form prompt = new Form
                {
                    Width = 205,
                    Height = 390,
                    Text = "Add Flag"
                };
                ComboBox flagsComboBox = new ComboBox
                {
                    DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple,
                    FormattingEnabled = true,
                    Location = new System.Drawing.Point(10, 10),
                    Size = new System.Drawing.Size(170, 300),
                    TabIndex = 0
                };

                List<string> items = new List<string>
                {
                    "dread",
                    "bull",
                    "dragon",
                    "alchemist",
                    "gasbag",
                    "lakewitch",
                    "fauxjester",
                    "squiddragon",
                    "nameless",
                    "cloak",
                    "murderfly",
                    "cutqueen",
                    "torturetree",
                    "pirate",
                    "griffin",
                    "mummy",
                    "monster",
                    "ruinaxe",
                    "clay",
                    "deadking",
                    "inquisitor"
                };

                for (int i = 0; i < Map.layer.Length; i++)
                {
                    for (int j = 0; j < Map.layer[i].seg.Length; j++)
                    {
                        if (Map.layer[i].seg[j].strFlag != null && Map.layer[i].seg[j].strFlag.StartsWith("flag"))
                        {
                            items.Add(Map.layer[i].seg[j].strFlag.Split(new string[] { "flag " }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                        }
                    }
                }

                items.Sort();
                flagsComboBox.DataSource = items;

                Button confirmation = new Button
                {
                    Text = "Add",
                    Left = 50,
                    Width = 80,
                    Top = 320,
                    DialogResult = DialogResult.OK
                };
                prompt.Controls.Add(flagsComboBox);
                prompt.Controls.Add(confirmation);

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    return (string)flagsComboBox.SelectedItem;
                }
                else
                {
                    return null;
                }
            }
        }

        private void AddflagManuallyButton_Click(object sender, EventArgs e)
        {
            if (flagTextBox.Text != "" && !bindinglist.Contains(flagTextBox.Text))
            {
                Game1.p.flags.Add(flagTextBox.Text);
                bindinglist.Add(flagTextBox.Text);
            }
        }

        private class SanctuaryPreset
        {
            public string Name { get; set; }

            public int SanctuaryId { get; set; }

            public int CreedId { get; set; }

            public int[] Merchants { get; set; }

            public string DisplayLabel
            {
                get
                {
                    return string.Format("{0} (Creed: {1})", Name, Game1.GetCreedFromId(CreedId));
                }
            }
        }

        private class FlagInfo
        {
            public FlagInfo(string id, string description)
            {
                Id = id;
                Description = description;
            }

            public string Id { get; private set; }

            public string Description { get; private set; }
        }
    }
}
