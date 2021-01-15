using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class Mace : MeleeWeapon
    {
        public Mace() : base("Mace", DiceType.D6, 5, false, false, false, WeaponType.Mace)
        {
        }
    }
}
