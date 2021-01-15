using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class Armour : EquipmentItems
    {
        private int ArmourClass;

        public int armourClass
        {
            get
            {
                return ArmourClass;
            }
        }

        private bool UseableByThieves;

        public bool useableByThieves
        {
            get
            {
                return UseableByThieves;
            }
        }

        private int Cost;

        public int cost
        {
           get
            {
                return Cost;
            }
        }

        private EquipsTo EquipsTo;

        public EquipsTo equipsTo
        {
            get
            {
                return EquipsTo;
            }
        }

        private ArmourType Type;

        public ArmourType type
        {
            get
            {
                return Type;
            }
        }


        public Armour(string name, int armourClass, int cost, bool useableByThieves, EquipsTo equipsTo, ArmourType type) : base(EquipmentCategory.Armour, name)
        {
            ArmourClass = armourClass;
            Cost = cost;
            UseableByThieves = useableByThieves;
            EquipsTo = equipsTo;
            Type = type;
        }
    }
}
