using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class NormalDagger : MeleeWeapon
    {
        public NormalDagger() : base ("Normal Dagger", DiceType.D4, 3, false, true, true, WeaponType.Dagger)
        {

        }
    }
}
