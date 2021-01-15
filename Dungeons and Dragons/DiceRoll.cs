using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    public enum DiceType
    {
        D4 = 4,
        D6 = 6, 
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20
    }

    public static class DiceRoll
    {
        public static int Roll(int numberOfDice, DiceType type )
        {
            int TotalRolled = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                //this generates a randomly seeded random number generator - avoids duplicate random numbers
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                //add 1 as random will generate a number between 0 and 1 less than the max 
                TotalRolled += rnd.Next((int)type) + 1;
            }
            return TotalRolled;
        }
    }
}
