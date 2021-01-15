using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems.Weapons.RangedWeapons
{
    public class CrossBow : RangedWeapon
    {
        public CrossBow() : base("Crossbow", DiceType.D6, 30, true, true, false, WeaponType.Crossbow)
        {
        }
    }
}
