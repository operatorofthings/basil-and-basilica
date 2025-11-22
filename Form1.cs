using LootEdit;
using LootEdit.loot;
using MapEdit.map;
using ProjectTower;
using ProjectTower.character;
using ProjectTower.player;
using ProjectTower.sanctuary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace PepperAndChurchSaveEditor
{
    public partial class Form1 : Form
    {
        private string filePath = "";

        private BindingList<string> bindinglist = new BindingList<string>();

        private readonly BindingList<Sanctuary> sanctuaryBindingList = new BindingList<Sanctuary>();

        private readonly BindingList<Sanctuary> lastSanctuaryBindingList = new BindingList<Sanctuary>();

        public Form1(string[] args)
        {
            InitializeComponent();
            Game1.Init(args);

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
    }
}
