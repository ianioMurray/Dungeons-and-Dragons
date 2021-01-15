using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class HandAxe : MeleeWeapon
    {
        public HandAxe() : base ("Hand Axe", DiceType.D6, 4, false, true, false, WeaponType.HandAxe)
        {

        }
    }
}
