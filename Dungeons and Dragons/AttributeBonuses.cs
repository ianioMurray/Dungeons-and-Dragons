using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeons_and_Dragons
{
    public static class AttributeBonuses
    {
        public static int GetStrenghtBonus(int value)
        {
            int bonus;
            if (value == 3)
            {
                bonus = -3;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = -2;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = -1;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 0;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 1;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 2;
            }
            else
            {
                bonus = 3;
            }
            return bonus;
        }

        public static int GetDexterity_ToHitMissilesBonus(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = -3;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = -2;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = -1;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 0;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 1;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 2;
            }
            else
            {
                bonus = 3;
            }
            return bonus;
        }

        public static int GetDexterity_AcAdjustmentBonus(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = 3;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = 2;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = 1;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 0;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = -1;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = -2;
            }
            else
            {
                bonus = -3;
            }
            return bonus;
        }

        public static int GetDexterity_InitiativeBonus(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = -2;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = -1;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = -1;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 0;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 1;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 1;
            }
            else
            {
                bonus = 2;
            }
            return bonus;
        }

        public static int GetWisdomBonus(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = -3;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = -2;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = -1;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 0;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 1;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 2;
            }
            else
            {
                bonus = 3;
            }

            return bonus;
        }

        public static int GetConstitution_HitPointBonus(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = -3;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = -2;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = -1;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 0;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 1;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 2;
            }
            else
            {
                bonus = 3;
            }

            return bonus;
        }

        public static int GetCharimsaBonus_ReactionAdjustment(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = -2;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = -1;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = -1;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 0;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 1;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 1;
            }
            else
            {
                bonus = 2;
            }
            return bonus;
        }

        public static int GetCharimsaBonus_NoOfRetainers(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = 1;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = 2;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = 3;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 4;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 5;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 6;
            }
            else
            {
                bonus = 7;
            }
            return bonus;
        }
        public static int GetCharimsaBonus_RetainersMorale(int value)
        {
            int bonus;

            if (value == 3)
            {
                bonus = 4;
            }
            else if (value >= 4 && value < 6)
            {
                bonus = 5;
            }
            else if (value >= 6 && value < 9)
            {
                bonus = 6;
            }
            else if (value >= 9 && value < 13)
            {
                bonus = 7;
            }
            else if (value >= 13 && value < 16)
            {
                bonus = 8;
            }
            else if (value >= 16 && value < 18)
            {
                bonus = 9;
            }
            else
            {
                bonus = 10;
            }
            return bonus;
        }

        public static int GetPrimeRequisiteXPBonus(int attributeScore)
        {
            int bonusPercent;

            if (attributeScore >= 3 && attributeScore < 6)
            {
                bonusPercent = -20;
            }
            else if (attributeScore >= 6 && attributeScore < 9)
            {
                bonusPercent = -10;
            }
            else if (attributeScore >= 9 && attributeScore < 13)
            {
                bonusPercent = 0;
            }
            else if (attributeScore >= 13 && attributeScore < 16)
            {
                bonusPercent = 5;
            }
            else
            {
                bonusPercent = 10;
            }
            return bonusPercent;
        }
    }
}
