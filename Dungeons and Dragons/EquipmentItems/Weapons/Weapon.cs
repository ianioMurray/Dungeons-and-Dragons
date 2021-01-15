using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public abstract class Weapon : EquipmentItems
    {
        private DiceType Damage;

        private int Cost;

        public int cost
        {
            get
            {
                return Cost;
            }
        }

        private bool TwoHanded;

        public bool twoHanded
        {
            get
            {
                return TwoHanded;
            }
        }

        private bool Bladed;

        public bool bladed
        {
            get
            {
                return Bladed;
            }
        }

        public bool UseableByMagicUser;

        public bool useableByMagicUser
        {
            get
            {
                return UseableByMagicUser;
            }
        }

        private WeaponType Type;

        public WeaponType type
        {
            get
            {
                return Type;
            }
        }


        public Weapon(string name, DiceType damage, int cost, bool twoHanded, bool bladed, bool usableByMagicUser, WeaponType type) : base(EquipmentCategory.Weapon, name)
        {
            Damage = damage;
            Cost = cost;
            TwoHanded = twoHanded;
            Bladed = bladed;
            UseableByMagicUser = usableByMagicUser;
            Type = type;
        }
    }
}
