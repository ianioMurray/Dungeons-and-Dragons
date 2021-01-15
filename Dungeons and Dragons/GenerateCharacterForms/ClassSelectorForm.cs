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
    public partial class ClassSelectorForm : Form
    {
        private CharacterCreator CharacterCreator;
        private ClassType classType;

        public ClassSelectorForm(CharacterCreator characterCreator)
        {
            InitializeComponent();
            CharacterCreator = characterCreator;
            DisplayAttributes(characterCreator.originalAttributes);

            classSuggestionLabel.Text = characterCreator.GetSuggestedClass();
            
            //if the character does not have an assigned class then fighter will be selected by default
            //if the character has previously been assigned a class then that class will be selected.
            if(characterCreator.classType == 0)
            {
                classType = ClassType.Fighter;
                fighterRadio.Checked = true;
            }
            else
            {
                classType = characterCreator.classType;
                CheckAppropriateClassRadioButton();
            }

            SetClassSelectorDescription();
            SetPrimeRequisiteDescripton();
        }

        private void CheckAppropriateClassRadioButton()
        {
            switch(classType)
            {
                case ClassType.Fighter:
                    {
                        fighterRadio.Checked = true;
                        break;
                    }
                case ClassType.Thief:
                    {
                        thiefRadio.Checked = true;
                        break;
                    }
                case ClassType.MagicUser:
                    {
                        magicuserRadio.Checked = true;
                        break;
                    }
                case ClassType.Cleric:
                    {
                        clericRadio.Checked = true;
                        break;
                    }
            }
        }

        private void SetClassSelectorDescription()
        {
            classDescriptionLabel.Text = CharacterCreator.GetClassDescription(classType);
        }

        public void SetPrimeRequisiteDescripton()
        {
            strPrimeRequisiteBonusText.Text = "";
            dexPrimeRequisiteBonusText.Text = "";
            intelPrimeRequisiteBonusText.Text = "";
            wisPrimeRequisiteBonusText.Text = "";

            switch (classType)
            {
                case ClassType.Fighter:
                    {
                        strPrimeRequisiteBonusText.Text = CharacterCreator.GetPrimeRequisiteBonusText(Attribute.Strength);
                        SetPrimeRequisiteDescriptionColour(strPrimeRequisiteBonusText, CharacterCreator.originalAttributes[Attribute.Strength]);
                        break;
                    }
                case ClassType.Thief:
                    {
                        dexPrimeRequisiteBonusText.Text = CharacterCreator.GetPrimeRequisiteBonusText(Attribute.Dexterity);
                        SetPrimeRequisiteDescriptionColour(dexPrimeRequisiteBonusText, CharacterCreator.originalAttributes[Attribute.Dexterity]);
                        break;
                    }
                case ClassType.MagicUser:
                    {
                        intelPrimeRequisiteBonusText.Text = CharacterCreator.GetPrimeRequisiteBonusText(Attribute.Intelligence);
                        SetPrimeRequisiteDescriptionColour(intelPrimeRequisiteBonusText, CharacterCreator.originalAttributes[Attribute.Intelligence]);
                        break;
                    }
                case ClassType.Cleric:
                    {
                        wisPrimeRequisiteBonusText.Text = CharacterCreator.GetPrimeRequisiteBonusText(Attribute.Wisdom);
                        SetPrimeRequisiteDescriptionColour(wisPrimeRequisiteBonusText, CharacterCreator.originalAttributes[Attribute.Wisdom]);
                        break;
                    }
            }
        }

        private void SetPrimeRequisiteDescriptionColour(Control control, int attributeVal)
        {
            if (attributeVal < 9)
            {
                control.ForeColor = System.Drawing.Color.Red;
            }
            else if (attributeVal >= 9 && attributeVal <=12)
            {
                control.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                control.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void DisplayAttributes(Dictionary<Attribute, int> dict)
        {
            strText.Text = dict[Attribute.Strength].ToString();
            dexText.Text = dict[Attribute.Dexterity].ToString();
            intelText.Text = dict[Attribute.Intelligence].ToString();
            wisText.Text = dict[Attribute.Wisdom].ToString();
            conText.Text = dict[Attribute.Constitution].ToString();
            chaText.Text = dict[Attribute.Charisma].ToString();
        }

        private void fighterRadio_CheckedChanged(object sender, EventArgs e)
        {
            classType = ClassType.Fighter;
            SetClassSelectorDescription();
            SetPrimeRequisiteDescripton();
        }

        private void thiefRadio_CheckedChanged(object sender, EventArgs e)
        {
            classType = ClassType.Thief;
            SetClassSelectorDescription();
            SetPrimeRequisiteDescripton();
        }

        private void magicuserRadio_CheckedChanged(object sender, EventArgs e)
        {
            classType = ClassType.MagicUser;
            SetClassSelectorDescription();
            SetPrimeRequisiteDescripton();
        }

        private void clericRadio_CheckedChanged(object sender, EventArgs e)
        {
            classType = ClassType.Cleric;
            SetClassSelectorDescription();
            SetPrimeRequisiteDescripton();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CharacterCreator.SetClass(classType);
            this.Close();
        }
    }
}
