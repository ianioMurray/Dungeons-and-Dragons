using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    public abstract class Individual
    {
        private int HitPoints;
        
        public int hitPoints
        {
            get
            {
                return HitPoints;
            }
            protected set
            {
                HitPoints = value;
            }
        }
    }
}
