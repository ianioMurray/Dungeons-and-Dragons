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
    public partial class MainScreenForm : Form
    {
        DungeonsNDragons game;

        public MainScreenForm()
        {
            InitializeComponent();
            game = new DungeonsNDragons();
        }

        private void createCharacterButton_Click(object sender, EventArgs e)
        {
            using(CharacterGeneratorForm generatorForm = new CharacterGeneratorForm())
            {
                generatorForm.ShowDialog();
            }
        }

        private void characterBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.characterBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dnD_DatabaseDataSet);

        }

        private void chooseCharacterButton_Click(object sender, EventArgs e)
        {
            SelectCharacterForm selectCharacter = new SelectCharacterForm();
            selectCharacter.ShowDialog();
        }
    }
}
