using Dungeons_and_Dragons.DatabaseStuff;

namespace Dungeons_and_Dragons
{
    partial class MainScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.createCharacterButton = new System.Windows.Forms.Button();
            this.dnD_DatabaseDataSet = new Dungeons_and_Dragons.DatabaseStuff.DnD_DatabaseDataSet();
            this.characterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.characterTableAdapter = new Dungeons_and_Dragons.DatabaseStuff.DnD_DatabaseDataSetTableAdapters.CharacterTableAdapter();
            this.tableAdapterManager = new Dungeons_and_Dragons.DatabaseStuff.DnD_DatabaseDataSetTableAdapters.TableAdapterManager();
            this.chooseCharacterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dnD_DatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // createCharacterButton
            // 
            this.createCharacterButton.Location = new System.Drawing.Point(23, 36);
            this.createCharacterButton.Name = "createCharacterButton";
            this.createCharacterButton.Size = new System.Drawing.Size(179, 45);
            this.createCharacterButton.TabIndex = 14;
            this.createCharacterButton.Text = "Create Character";
            this.createCharacterButton.UseVisualStyleBackColor = true;
            this.createCharacterButton.Click += new System.EventHandler(this.createCharacterButton_Click);
            // 
            // dnD_DatabaseDataSet
            // 
            this.dnD_DatabaseDataSet.DataSetName = "DnD_DatabaseDataSet";
            this.dnD_DatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // characterBindingSource
            // 
            this.characterBindingSource.DataMember = "Character";
            this.characterBindingSource.DataSource = this.dnD_DatabaseDataSet;
            // 
            // characterTableAdapter
            // 
            this.characterTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CharacterTableAdapter = this.characterTableAdapter;
            this.tableAdapterManager.UpdateOrder = Dungeons_and_Dragons.DatabaseStuff.DnD_DatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // chooseCharacterButton
            // 
            this.chooseCharacterButton.Location = new System.Drawing.Point(23, 107);
            this.chooseCharacterButton.Name = "chooseCharacterButton";
            this.chooseCharacterButton.Size = new System.Drawing.Size(179, 45);
            this.chooseCharacterButton.TabIndex = 15;
            this.chooseCharacterButton.Text = "Choose Character to Add to the Party";
            this.chooseCharacterButton.UseVisualStyleBackColor = true;
            this.chooseCharacterButton.Click += new System.EventHandler(this.chooseCharacterButton_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 450);
            this.Controls.Add(this.chooseCharacterButton);
            this.Controls.Add(this.createCharacterButton);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.dnD_DatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createCharacterButton;
        private DnD_DatabaseDataSet dnD_DatabaseDataSet;
        private System.Windows.Forms.BindingSource characterBindingSource;
        private DatabaseStuff.DnD_DatabaseDataSetTableAdapters.CharacterTableAdapter characterTableAdapter;
        private DatabaseStuff.DnD_DatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button chooseCharacterButton;
    }
}