using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class WarHammer : MeleeWeapon
    {
        public WarHammer() : base ("War Hammer", DiceType.D6, 5, false, false, false, WeaponType.WarHammer)
        {
        }
    }
}
