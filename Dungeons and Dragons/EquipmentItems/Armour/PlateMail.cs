using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class PlateMail : Armour
    {
        public PlateMail() : base("Plate Mail Armour", -6, 60, false, EquipsTo.Body, ArmourType.PlateMail)
        {
        }
    }
}
