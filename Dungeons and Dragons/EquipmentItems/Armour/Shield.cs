using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class Shield : Armour
    {
        public Shield() : base ("Shield", -1, 10, false, EquipsTo.Hand, ArmourType.Shield)
        {
        }
    }
}
