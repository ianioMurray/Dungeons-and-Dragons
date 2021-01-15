using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class Spear : MeleeWeapon
    {
        public Spear() : base ("Spear", DiceType.D6, 3, false, true, false, WeaponType.Spear)
        {
        }
    }
}
