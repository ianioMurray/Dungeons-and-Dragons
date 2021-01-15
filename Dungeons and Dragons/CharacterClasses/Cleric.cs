using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons
{
    public class Cleric : Character
    {
        private List<int> levelThreshold = new List<int>
        {
            0,
            1500,
            3000,
        };

        public Cleric(string name, Race characterRace, Dictionary<Attribute, int> attributes, int hitPoints, int xp) 
            : base(name, characterRace, attributes, hitPoints, xp)
        {
            SetPrimeRequisite(Attribute.Wisdom);
            SetExperiencePointMultiplier(AttributeBonuses.GetPrimeRequisiteXPBonus(attributes[Attribute.Wisdom]));
            CurrentLevel = GetClericLevel();
        }

        public override void Save()
        {
            Repository rep = new Repository();
            rep.SaveCharacter(this, ClassType.Cleric);
        }

        public int GetClericLevel()
        {
            return GetLevel(levelThreshold);
        }

        public override void IncreaseExperiencePoints(int xpPoints)
        {
            base.IncreaseExperiencePoints(xpPoints);
            int newLevel = GetClericLevel();

            if(newLevel > CurrentLevel)
            {
                LevelUpCharacter();
            }

            CurrentLevel = newLevel;
        }

        public void LevelUpCharacter()
        {
            hitPoints += Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D6),
                ConBonus_HitPointAdjustment);
        }

        public override bool ItemUseable(EquipmentItems item)
        {
            if(item is Weapon)
            {
                Weapon weapon = (Weapon)item;
                if (weapon.bladed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
