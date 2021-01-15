using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class LeatherArmour : Armour
    {
        public LeatherArmour() : base ("Leather Armour", -2, 20, true, EquipsTo.Body, ArmourType.LeatherArmour)
        {
        }
    }
}
