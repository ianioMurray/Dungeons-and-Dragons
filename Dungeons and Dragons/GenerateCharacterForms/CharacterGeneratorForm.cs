using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeons_and_Dragons
{
    public partial class CharacterGeneratorForm : Form
    {
        private CharacterCreator characterCreator;

        public CharacterGeneratorForm()
        {
            InitializeComponent();
            characterCreator = new CharacterCreator();
            EnableButtons(true);
        }

        private void EnableButtons(bool originalDisplay)
        {
            if (originalDisplay)
            {
                generateButton.Enabled = true;
                amendButton.Enabled = false;
                classButton.Enabled = false;
                raceButton.Enabled = false;
                saveButton.Enabled = false;
            }
            else
            {
                generateButton.Enabled = false;
                amendButton.Enabled = true;
                classButton.Enabled = true;
                raceButton.Enabled = true;
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Dictionary<Attribute, int> orininalAttributes = characterCreator.RollAttibutes();
            DisplayAttributes(orininalAttributes);
        }

        private void DisplayAttributes(Dictionary<Attribute, int> dict)
        {
            strText.Text = dict[Attribute.Strength].ToString();
            dexText.Text = dict[Attribute.Dexterity].ToString();
            intelText.Text = dict[Attribute.Intelligence].ToString();
            wisText.Text = dict[Attribute.Wisdom].ToString();
            conText.Text = dict[Attribute.Constitution].ToString();
            chaText.Text = dict[Attribute.Charisma].ToString();

            strBonusText.Text = characterCreator.UpdateStrengthBonusText(dict[Attribute.Strength]);
            dexBonusText.Text = characterCreator.UpdateDexterityBonusText(dict[Attribute.Dexterity]);
            intelBonusText.Text = characterCreator.UpdateIntelligenceBonusText(dict[Attribute.Intelligence]);
            wisBonusText.Text = characterCreator.UpdateWisdomBonusText(dict[Attribute.Wisdom]);
            conBonusText.Text = characterCreator.UpdateConstitutionBonusText(dict[Attribute.Constitution]);
            chaBonusText.Text = characterCreator.UpdateCharismaBonusText(dict[Attribute.Charisma]);

            EnableButtons(false);
        }

        private void amendButton_Click(object sender, EventArgs e)
        {
            using (AttributeAmenderForm attributeAmendForm = new AttributeAmenderForm(characterCreator))
            {
                attributeAmendForm.ShowDialog();
            }
        }

        private void classButton_Click(object sender, EventArgs e)
        {
            using (ClassSelectorForm selectClass = new ClassSelectorForm(characterCreator))
            {
                selectClass.ShowDialog();
            }
        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            using(RaceAndNameSelectorForm selectRace = new RaceAndNameSelectorForm(characterCreator))
            {
                selectRace.ShowDialog();
            }
        }

        private void CharacterGeneratorForm_Activated(object sender, EventArgs e)
        {
            //when form become active refresh the attributes shown so that any amendments done on the AmendAttributes page are shown on the this screen
            if(characterCreator.originalAttributes.Count > 0)

            {
                DisplayAttributes(characterCreator.originalAttributes);
            }

            if (characterCreator.classType != 0)
            {
                classLabel.Text = characterCreator.classType.ToString();
            }

            if(characterCreator.characterRace != 0)
            {
                raceLabel.Text = characterCreator.characterRace.ToString();
            }

            if(!String.IsNullOrEmpty(characterCreator.characterName))
            {
                nameLabel.Text = characterCreator.characterName;
            }

            if(characterCreator.classType != 0 && !String.IsNullOrEmpty(characterCreator.characterName) && characterCreator.characterRace != 0)
            {
                saveButton.Enabled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            characterCreator.SaveCharacter();
            this.Close();
        }
    } 
}
