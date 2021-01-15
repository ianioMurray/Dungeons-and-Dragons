using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class BattleAxe : MeleeWeapon
    {
        public BattleAxe() : base("Battle Axe", DiceType.D8, 7, true, true, false, WeaponType.BattleAxe)
        {
        }
    }
}
