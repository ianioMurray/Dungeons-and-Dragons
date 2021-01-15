using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class TwoHandedSword : MeleeWeapon
    {
        public TwoHandedSword() : base ("Two-Handed Sword", DiceType.D10, 15, true, true, false, WeaponType.TwoHandedSword)
        {
        }
    }
}
