using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class ShortBow : RangedWeapon
    {
        public ShortBow() : base("Short Bow", DiceType.D6, 25, true, true, false, WeaponType.ShortBow)
        {
        }
    }
}
