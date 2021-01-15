using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public enum EquipmentCategory
    {
        Armour = 1,
        Weapon = 2
    };

    public enum ArmourType
    {
        PlateMail = 1,
        ChainMail = 2,
        LeatherArmour = 3,
        Shield = 4
    };

    public enum WeaponType
    {
        //Melee weapons
        Sword = 1,
        TwoHandedSword = 2,
        ShortSword = 3,
        Dagger = 4,
        SilverDagger = 5,
        Spear = 6,
        HandAxe = 7,
        BattleAxe = 8,
        PoleArm = 9,
        Mace = 10,
        Club = 11,
        WarHammer = 12,
        //ranged weapons
        Sling = 13,
        ShortBow = 14,
        Crossbow = 15, 
        Longbow = 16
    };

    public abstract class EquipmentItems
    {
        private EquipmentCategory Category;

        public EquipmentCategory category
        {
            get
            {
                return Category;
            }
        }

        private string Name;

        public string name
        {
            get
            {
                return Name;
            }
        }

        public EquipmentItems(EquipmentCategory category, string name)
        {
            Category = category;
            Name = name;
        }
    }
}
