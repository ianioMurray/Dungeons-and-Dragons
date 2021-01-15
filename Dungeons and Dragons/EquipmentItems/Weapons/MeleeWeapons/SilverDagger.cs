using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class SilverDagger : MeleeWeapon
    {
        public SilverDagger() : base("Silver Dagger", DiceType.D4, 30, false, true, true, WeaponType.SilverDagger)
        {
        }
    }
}
