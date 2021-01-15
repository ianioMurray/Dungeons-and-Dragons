using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class LongBow : RangedWeapon
    {
        public LongBow() : base("Long Bow", DiceType.D6, 40, true, true, false, WeaponType.Longbow)
        {
        }
    }
}
