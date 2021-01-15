using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons.InteractItems
{
    public class ChainMail : Armour
    {
        public ChainMail() : base("Chain Mail Armour", -4, 40, false, EquipsTo.Body, ArmourType.ChainMail)
        {
        }
    }
}
