using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class PoleArm : MeleeWeapon
    {
        public PoleArm() : base("Pole Arm", DiceType.D10, 7, true, true, false, WeaponType.PoleArm)
        {
        }
    }
}
