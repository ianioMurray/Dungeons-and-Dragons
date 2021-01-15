using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons
{
    public class Fighter : Character
    {
        private List<int> levelThreshold = new List<int>
        {
            0,
            2000,
            4000,
        };


        public Fighter(string name, Race characterRace, Dictionary<Attribute, int> attributes, int hitPoints, int xp) 
            : base(name, characterRace, attributes, hitPoints, xp)
        {
            SetPrimeRequisite(Attribute.Strength);
            SetExperiencePointMultiplier(AttributeBonuses.GetPrimeRequisiteXPBonus(attributes[Attribute.Strength]));
            CurrentLevel = GetFighterLevel();
        }

        public override void Save()
        {
            Repository rep = new Repository();
            rep.SaveCharacter(this, ClassType.Fighter);
        }

        public int GetFighterLevel()
        {
            return GetLevel(levelThreshold);
        }

        public override void IncreaseExperiencePoints(int xpPoints)
        {
            base.IncreaseExperiencePoints(xpPoints);
            int newLevel = GetFighterLevel();

            if(newLevel > CurrentLevel)
            {
                LevelUpCharacter();
            }

            CurrentLevel = newLevel;
        }

        public void LevelUpCharacter()
        {
            hitPoints += Character.GetAdditionalHitPointsForNewLevel(DiceRoll.Roll(1, DiceType.D8),
                ConBonus_HitPointAdjustment);
        }

        public override bool ItemUseable(EquipmentItems item)
        {
            return true;
        }
    }
}
