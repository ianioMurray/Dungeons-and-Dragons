using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dungeons_and_Dragons.InteractItems;

namespace Dungeons_and_Dragons
{
    public partial class SelectCharacterForm : Form
    {
        private List<Character> characters;
        private Character character;

        public SelectCharacterForm()
        {
            InitializeComponent();
            characters = new List<Character>();
        }

        private void SelectCharacterForm_Load(object sender, EventArgs e)
        {
            Repository rep = new Repository();
            characters = rep.LoadCharacters();

            foreach(Character character in characters)
            {
                characterNameCombo.Items.Add(character.name);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void characterNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexOfCharacterinList = characterNameCombo.SelectedIndex;
            character = characters[indexOfCharacterinList];

            if (character is Fighter)
            {
                classLabel.Text = ClassType.Fighter.ToString();
            }
            else if (character is Thief)
            {
                classLabel.Text = ClassType.Thief.ToString();
            }
            else if (character is MagicUser)
            {
                classLabel.Text = ClassType.MagicUser.ToString();
            }
            else if (character is Cleric)
            {
                classLabel.Text = ClassType.MagicUser.ToString();
            }
            else
            {
                throw new Exception("Unknown character type");
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            raceLabel.Text = character.characterRace.ToString();
            levelLabel.Text = character.currentLevel.ToString();
            xpLabel.Text = character.experiencePoints.ToString();
            hpLabel.Text = character.hitPoints.ToString();
            armourClassLabel.Text = character.armourClass.ToString();
            bodyEquipLabel.Text = getEquipmentName(character.equippedToBody);
            rightHandEquipLabel.Text = getEquipmentName(character.equippedInRightHand);
            leftHandEquipLabel.Text = getEquipmentName(character.equippedInLeftHand);

            strText.Text = character.attributes[Attribute.Strength].ToString();
            dexText.Text = character.attributes[Attribute.Dexterity].ToString();
            intelText.Text = character.attributes[Attribute.Intelligence].ToString();
            wisText.Text = character.attributes[Attribute.Wisdom].ToString();
            conText.Text = character.attributes[Attribute.Constitution].ToString();
            chaText.Text = character.attributes[Attribute.Charisma].ToString();
        }

        private string getEquipmentName(EquipmentItems item)
        {
            if (item != null)
            {
               return item.name;
            }
            else
            {
                return "Nothing equipped";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fighter c = character as Fighter;
            c.EquipToBody(new ChainMail());
            c.EquipToHand(new Spear(), Hand.Right);
            c.EquipToHand(new NormalDagger(), Hand.Left);

            c.Save();
            UpdateUI();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fighter c = character as Fighter;
            c.EquipToBody(new PlateMail());
            c.EquipToHand(new Sword(), Hand.Right);
            c.EquipToHand(new Shield(), Hand.Left);

            c.Save();
            UpdateUI();
        }
    }
}
