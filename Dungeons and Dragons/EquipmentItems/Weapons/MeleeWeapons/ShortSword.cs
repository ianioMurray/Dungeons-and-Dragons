using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class ShortSword : MeleeWeapon
    {
        public ShortSword() : base ("Short Sword", DiceType.D6, 7, false, true, false, WeaponType.ShortSword)
        {

        }
    }
}
