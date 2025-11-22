using ProjectTower;
using System.Collections.Generic;

namespace LootEdit
{
    /// <summary>
    /// This class exists only, so that LootDef does not need to be edited to only add a single property
    /// The ListControl of the UI requires a property as the display parameter, so an extension method wouldn't work
    /// </summary>
    public class LootDefWrapper
    {
        public LootDefWrapper(LootDef lootDef)
        {
            this.LootDef = lootDef;
        }

        public LootDef LootDef { get; private set; }

        private string displayNameBackingField = null;

        public string DisplayName
        {
            get
            {
                if (displayNameBackingField == null)
                {
                    displayNameBackingField = LootDef.title[Game1.language];
                }

                return displayNameBackingField;
            }
        }

        public class SortLootDefByName : Comparer<LootDefWrapper>
        {
            public override int Compare(LootDefWrapper a, LootDefWrapper b)
            {
                return a.DisplayName.CompareTo(b.DisplayName);
            }
        }
    }
}
