using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class Sling : RangedWeapon
    {
        public Sling() : base("Sling Shot", DiceType.D4, 2, true, false, false, WeaponType.Sling)
        {
        }
    }
}
