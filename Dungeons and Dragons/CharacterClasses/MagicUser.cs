using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons
{
    public class MagicUser : Character
    {
        private List<int> levelThreshold = new List<int>
        {
            0,
            2500,
            5000,
        };


        public MagicUser(string name, Race characterRace, Dictionary<Attribute, int> attributes, int hitPoints, int xp) 
            : base(name, characterRace, attributes, hitPoints, xp)
        {
            SetPrimeRequisite(Attribute.Intelligence);
            SetExperiencePointMultiplier(AttributeBonuses.GetPrimeRequisiteXPBonus(attributes[Attribute.Intelligence]));
            CurrentLevel = GetMagicUserLevel();
        }

        public override void Save()
        {
            Repository rep = new Repository();
            rep.SaveCharacter(this, ClassType.MagicUser);
        }

        public int GetMagicUserLevel()
        {
            return GetLevel(levelThreshold);
        }

        public override void IncreaseExperiencePoints(int xpPoints)
        {
            base.IncreaseExperiencePoints(xpPoints);
            int newLevel = GetMagicUserLevel();

            if(newLevel > CurrentLevel)
            {
                LevelUpCharacter();
            }

            CurrentLevel = newLevel;
        }

        public void LevelUpCharacter()
        {
            hitPoints += Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D4),
                ConBonus_HitPointAdjustment);
        }

        public override bool ItemUseable(EquipmentItems item)
        {
            if (item is Weapon)
            {
                Weapon weapon = (Weapon)item;
                if (!weapon.UseableByMagicUser)
                {
                    return false;
                }
            }

            if(item is Armour)
            {
                return false;
            }

            return true;
        }
    }
}
