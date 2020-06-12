namespace PetClinicClientView
{
    partial class FormCreateVisit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAnimal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAnimalName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerVisit = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Услуга:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сумма:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(118, 45);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(231, 23);
            this.textBoxCount.TabIndex = 3;
            this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(118, 20);
            this.comboBoxService.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(231, 23);
            this.comboBoxService.TabIndex = 4;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.ComboBoxService_SelectedIndexChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(118, 144);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(231, 23);
            this.textBoxSum.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(289, 223);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 29);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Вид животного:";
            // 
            // textBoxAnimal
            // 
            this.textBoxAnimal.Location = new System.Drawing.Point(118, 81);
            this.textBoxAnimal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAnimal.Name = "textBoxAnimal";
            this.textBoxAnimal.Size = new System.Drawing.Size(231, 23);
            this.textBoxAnimal.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Имя животного:";
            // 
            // textBoxAnimalName
            // 
            this.textBoxAnimalName.Location = new System.Drawing.Point(118, 114);
            this.textBoxAnimalName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAnimalName.Name = "textBoxAnimalName";
            this.textBoxAnimalName.Size = new System.Drawing.Size(231, 23);
            this.textBoxAnimalName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 182);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Дата визита:";
            // 
            // dateTimePickerVisit
            // 
            this.dateTimePickerVisit.Location = new System.Drawing.Point(118, 182);
            this.dateTimePickerVisit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePickerVisit.Name = "dateTimePickerVisit";
            this.dateTimePickerVisit.Size = new System.Drawing.Size(233, 23);
            this.dateTimePickerVisit.TabIndex = 8;
            // 
            // FormCreateVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 264);
            this.Controls.Add(this.dateTimePickerVisit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAnimalName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAnimal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.comboBoxService);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCreateVisit";
            this.Text = "Визит в ветиринарную клинику \"Айболит\"";
            this.Load += new System.EventHandler(this.FormCreateVisit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAnimal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAnimalName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePickerVisit;
    }
}