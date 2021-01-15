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
    public partial class AttributeAmenderForm : Form
    {
        CharacterCreator CharacterCreator;


        public AttributeAmenderForm(CharacterCreator createCharacter)
        {
            InitializeComponent();
            CharacterCreator = createCharacter;
            DisplayAttributes(CharacterCreator.originalAttributes);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            DisplayAttributes(CharacterCreator.originalAttributes);
            CharacterCreator.SetAmendedAttributesToOriginal();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            if(CharacterCreator.unassignedPoints > 0)
            {
                var result = MessageBox.Show("You still have unassigned points if you continue these will be lost.  Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo); 
                if(result == DialogResult.No)
                {
                    return;
                }
                CharacterCreator.AlterUnassignedPoints(-1 * CharacterCreator.unassignedPoints);
            }
            CharacterCreator.SetOriginalAttributesToAmended();
            this.Close();
        }

        private void DisplayAttributes(Dictionary<Attribute, int> dict)
        {
            strText.Text = dict[Attribute.Strength].ToString();
            dexText.Text = dict[Attribute.Dexterity].ToString();
            intelText.Text = dict[Attribute.Intelligence].ToString();
            wisText.Text = dict[Attribute.Wisdom].ToString();
            conText.Text = dict[Attribute.Constitution].ToString();
            chaText.Text = dict[Attribute.Charisma].ToString();

            unassginedPointsText.Text = CharacterCreator.unassignedPoints.ToString();

            strBonusText.Text = CharacterCreator.UpdateStrengthBonusText(dict[Attribute.Strength]);
            dexBonusText.Text = CharacterCreator.UpdateDexterityBonusText(dict[Attribute.Dexterity]);
            intelBonusText.Text = CharacterCreator.UpdateIntelligenceBonusText(dict[Attribute.Intelligence]);
            wisBonusText.Text = CharacterCreator.UpdateWisdomBonusText(dict[Attribute.Wisdom]);
            conBonusText.Text = CharacterCreator.UpdateConstitutionBonusText(dict[Attribute.Constitution]);
            chaBonusText.Text = CharacterCreator.UpdateCharismaBonusText(dict[Attribute.Charisma]);
        }

        private void IncreaseAttribute(Attribute attribute)
        {
            string warning = CharacterCreator.IncreaseAttribute(attribute);
            UpdateUIWithAttributeChange(warning);
        }

        private void DecreaseAttribute(Attribute attribute)
        {
            string warning = CharacterCreator.DecreaseAttribute(attribute);
            UpdateUIWithAttributeChange(warning);
        }

        private void UpdateUIWithAttributeChange(string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Warning", MessageBoxButtons.OK);
            }

            DisplayAttributes(CharacterCreator.amendedAttributes);
        }

        private void strIncreaseButton_Click(object sender, EventArgs e)
        {
            IncreaseAttribute(Attribute.Strength);
        }

        private void strDecreaseButton_Click(object sender, EventArgs e)
        {
            DecreaseAttribute(Attribute.Strength);
        }

        private void dexIncreaseButton_Click(object sender, EventArgs e)
        {
            IncreaseAttribute(Attribute.Dexterity);
        }

        private void dexDecreaseButton_Click(object sender, EventArgs e)
        {
            DecreaseAttribute(Attribute.Dexterity);
        }

        private void intellIncreaseButton_Click(object sender, EventArgs e)
        {
            IncreaseAttribute(Attribute.Intelligence);
        }

        private void intelDecreaseButton_Click(object sender, EventArgs e)
        {
            DecreaseAttribute(Attribute.Intelligence);
        }

        private void wisIncreaseButton_Click(object sender, EventArgs e)
        {
            IncreaseAttribute(Attribute.Wisdom);
        }

        private void wisDecreaseButton_Click(object sender, EventArgs e)
        {
            DecreaseAttribute(Attribute.Wisdom);
        }

        private void conIncreaseButton_Click(object sender, EventArgs e)
        {
            IncreaseAttribute(Attribute.Constitution);
        }

        private void conDecreaseButton_Click(object sender, EventArgs e)
        {
            DecreaseAttribute(Attribute.Constitution);
        }

        private void chaIncreaseButton_Click(object sender, EventArgs e)
        {
            IncreaseAttribute(Attribute.Charisma);
        }

        private void chaDecreaseButton_Click(object sender, EventArgs e)
        {
            DecreaseAttribute(Attribute.Charisma);
        }
    }
}
