using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class Sword : MeleeWeapon
    {
        public Sword() : base ("Sword", DiceType.D8, 10, false, true, false, WeaponType.Sword)
        {
        }
    }
}
