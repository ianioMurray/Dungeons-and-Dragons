
namespace Dungeons_and_Dragons
{
    partial class CharacterGeneratorForm
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
            this.generateButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.strText = new System.Windows.Forms.TextBox();
            this.chaText = new System.Windows.Forms.TextBox();
            this.conText = new System.Windows.Forms.TextBox();
            this.wisText = new System.Windows.Forms.TextBox();
            this.intelText = new System.Windows.Forms.TextBox();
            this.dexText = new System.Windows.Forms.TextBox();
            this.chaBonusText = new System.Windows.Forms.Label();
            this.conBonusText = new System.Windows.Forms.Label();
            this.wisBonusText = new System.Windows.Forms.Label();
            this.intelBonusText = new System.Windows.Forms.Label();
            this.dexBonusText = new System.Windows.Forms.Label();
            this.strBonusText = new System.Windows.Forms.Label();
            this.amendButton = new System.Windows.Forms.Button();
            this.classButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.raceLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.raceButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(33, 420);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(179, 45);
            this.generateButton.TabIndex = 13;
            this.generateButton.Text = "Generate Attributes";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(113, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Charima";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(113, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Constitution";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(113, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Wisdom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Intelligence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Dexterity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(113, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Strength";
            // 
            // strText
            // 
            this.strText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strText.Location = new System.Drawing.Point(33, 104);
            this.strText.Name = "strText";
            this.strText.ReadOnly = true;
            this.strText.Size = new System.Drawing.Size(57, 26);
            this.strText.TabIndex = 19;
            this.strText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chaText
            // 
            this.chaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chaText.Location = new System.Drawing.Point(33, 354);
            this.chaText.Name = "chaText";
            this.chaText.ReadOnly = true;
            this.chaText.Size = new System.Drawing.Size(57, 26);
            this.chaText.TabIndex = 18;
            this.chaText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // conText
            // 
            this.conText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conText.Location = new System.Drawing.Point(33, 304);
            this.conText.Name = "conText";
            this.conText.ReadOnly = true;
            this.conText.Size = new System.Drawing.Size(57, 26);
            this.conText.TabIndex = 17;
            this.conText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // wisText
            // 
            this.wisText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wisText.Location = new System.Drawing.Point(33, 254);
            this.wisText.Name = "wisText";
            this.wisText.ReadOnly = true;
            this.wisText.Size = new System.Drawing.Size(57, 26);
            this.wisText.TabIndex = 16;
            this.wisText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // intelText
            // 
            this.intelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intelText.Location = new System.Drawing.Point(33, 204);
            this.intelText.Name = "intelText";
            this.intelText.ReadOnly = true;
            this.intelText.Size = new System.Drawing.Size(57, 26);
            this.intelText.TabIndex = 15;
            this.intelText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dexText
            // 
            this.dexText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dexText.Location = new System.Drawing.Point(33, 154);
            this.dexText.Name = "dexText";
            this.dexText.ReadOnly = true;
            this.dexText.Size = new System.Drawing.Size(57, 26);
            this.dexText.TabIndex = 14;
            this.dexText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chaBonusText
            // 
            this.chaBonusText.AutoSize = true;
            this.chaBonusText.Location = new System.Drawing.Point(242, 362);
            this.chaBonusText.Name = "chaBonusText";
            this.chaBonusText.Size = new System.Drawing.Size(0, 13);
            this.chaBonusText.TabIndex = 40;
            // 
            // conBonusText
            // 
            this.conBonusText.AutoSize = true;
            this.conBonusText.Location = new System.Drawing.Point(242, 312);
            this.conBonusText.Name = "conBonusText";
            this.conBonusText.Size = new System.Drawing.Size(0, 13);
            this.conBonusText.TabIndex = 39;
            // 
            // wisBonusText
            // 
            this.wisBonusText.AutoSize = true;
            this.wisBonusText.Location = new System.Drawing.Point(242, 260);
            this.wisBonusText.Name = "wisBonusText";
            this.wisBonusText.Size = new System.Drawing.Size(0, 13);
            this.wisBonusText.TabIndex = 38;
            // 
            // intelBonusText
            // 
            this.intelBonusText.AutoSize = true;
            this.intelBonusText.Location = new System.Drawing.Point(242, 210);
            this.intelBonusText.Name = "intelBonusText";
            this.intelBonusText.Size = new System.Drawing.Size(0, 13);
            this.intelBonusText.TabIndex = 37;
            // 
            // dexBonusText
            // 
            this.dexBonusText.AutoSize = true;
            this.dexBonusText.Location = new System.Drawing.Point(242, 162);
            this.dexBonusText.Name = "dexBonusText";
            this.dexBonusText.Size = new System.Drawing.Size(0, 13);
            this.dexBonusText.TabIndex = 36;
            // 
            // strBonusText
            // 
            this.strBonusText.AutoSize = true;
            this.strBonusText.Location = new System.Drawing.Point(242, 113);
            this.strBonusText.Name = "strBonusText";
            this.strBonusText.Size = new System.Drawing.Size(0, 13);
            this.strBonusText.TabIndex = 35;
            // 
            // amendButton
            // 
            this.amendButton.Location = new System.Drawing.Point(218, 420);
            this.amendButton.Name = "amendButton";
            this.amendButton.Size = new System.Drawing.Size(179, 45);
            this.amendButton.TabIndex = 41;
            this.amendButton.Text = "Amend Attributes";
            this.amendButton.UseVisualStyleBackColor = true;
            this.amendButton.Click += new System.EventHandler(this.amendButton_Click);
            // 
            // classButton
            // 
            this.classButton.Location = new System.Drawing.Point(403, 420);
            this.classButton.Name = "classButton";
            this.classButton.Size = new System.Drawing.Size(179, 45);
            this.classButton.TabIndex = 42;
            this.classButton.Text = "Choose Class";
            this.classButton.UseVisualStyleBackColor = true;
            this.classButton.Click += new System.EventHandler(this.classButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(36, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "Class:";
            this.label7.UseMnemonic = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(36, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 44;
            this.label8.Text = "Race:";
            this.label8.UseMnemonic = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(36, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 45;
            this.label9.Text = "Name:";
            this.label9.UseMnemonic = false;
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.classLabel.Location = new System.Drawing.Point(94, 22);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(114, 20);
            this.classLabel.TabIndex = 46;
            this.classLabel.Text = "To Be Decided";
            // 
            // raceLabel
            // 
            this.raceLabel.AutoSize = true;
            this.raceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.raceLabel.Location = new System.Drawing.Point(94, 42);
            this.raceLabel.Name = "raceLabel";
            this.raceLabel.Size = new System.Drawing.Size(114, 20);
            this.raceLabel.TabIndex = 47;
            this.raceLabel.Text = "To Be Decided";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nameLabel.Location = new System.Drawing.Point(94, 62);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(114, 20);
            this.nameLabel.TabIndex = 48;
            this.nameLabel.Text = "To Be Decided";
            // 
            // raceButton
            // 
            this.raceButton.Location = new System.Drawing.Point(588, 420);
            this.raceButton.Name = "raceButton";
            this.raceButton.Size = new System.Drawing.Size(179, 45);
            this.raceButton.TabIndex = 49;
            this.raceButton.Text = "Choose Race and Name";
            this.raceButton.UseVisualStyleBackColor = true;
            this.raceButton.Click += new System.EventHandler(this.raceButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(312, 480);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(179, 45);
            this.saveButton.TabIndex = 50;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // CharacterGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 537);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.raceButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.raceLabel);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.classButton);
            this.Controls.Add(this.amendButton);
            this.Controls.Add(this.chaBonusText);
            this.Controls.Add(this.conBonusText);
            this.Controls.Add(this.wisBonusText);
            this.Controls.Add(this.intelBonusText);
            this.Controls.Add(this.dexBonusText);
            this.Controls.Add(this.strBonusText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.strText);
            this.Controls.Add(this.chaText);
            this.Controls.Add(this.conText);
            this.Controls.Add(this.wisText);
            this.Controls.Add(this.intelText);
            this.Controls.Add(this.dexText);
            this.Controls.Add(this.generateButton);
            this.Name = "CharacterGeneratorForm";
            this.Text = "Character Generator";
            this.Activated += new System.EventHandler(this.CharacterGeneratorForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox strText;
        private System.Windows.Forms.TextBox chaText;
        private System.Windows.Forms.TextBox conText;
        private System.Windows.Forms.TextBox wisText;
        private System.Windows.Forms.TextBox intelText;
        private System.Windows.Forms.TextBox dexText;
        private System.Windows.Forms.Label chaBonusText;
        private System.Windows.Forms.Label conBonusText;
        private System.Windows.Forms.Label wisBonusText;
        private System.Windows.Forms.Label intelBonusText;
        private System.Windows.Forms.Label dexBonusText;
        private System.Windows.Forms.Label strBonusText;
        private System.Windows.Forms.Button amendButton;
        private System.Windows.Forms.Button classButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.Label raceLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button raceButton;
        private System.Windows.Forms.Button saveButton;
    }
}