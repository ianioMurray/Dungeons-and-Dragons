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
    public partial class RaceAndNameSelectorForm : Form
    {
        private CharacterCreator CharacterCreator;


        public RaceAndNameSelectorForm(CharacterCreator characterCreator)
        {
            InitializeComponent();
            CharacterCreator = characterCreator;

            raceCombo.Items.Add(Race.Dwarf.ToString());
            raceCombo.Items.Add(Race.Elf.ToString());
            raceCombo.Items.Add(Race.Halfling.ToString());
            raceCombo.Items.Add(Race.Human.ToString());

            //if race and name prevously set then ensure the controls contain those previous values 
            if(characterCreator.characterRace != 0)
            {
                //index is the numeric value of the enum - 1 as the index is not zero based
                raceCombo.SelectedIndex = (int)characterCreator.characterRace -1;
            }

            if(!String.IsNullOrEmpty(characterCreator.characterName))
            {
                nameText.Text = characterCreator.characterName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(nameText.Text))
            {
                MessageBox.Show("You need to give you character a name", "Warning", MessageBoxButtons.OK);
            }
            else if(raceCombo.SelectedIndex == -1)
            {
                MessageBox.Show("You need to give you character a race", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                CharacterCreator.setRace((Race)raceCombo.SelectedIndex + 1);
                CharacterCreator.setCharacterName(nameText.Text);
                this.Close(); 
            }
        }
    }
}
