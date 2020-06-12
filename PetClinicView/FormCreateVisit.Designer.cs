namespace PetClinicView
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
            this.labelService = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.labelAnimal = new System.Windows.Forms.Label();
            this.textBoxAnimal = new System.Windows.Forms.TextBox();
            this.labelAnimalName = new System.Windows.Forms.Label();
            this.textBoxAnimalName = new System.Windows.Forms.TextBox();
            this.labelVisit = new System.Windows.Forms.Label();
            this.dateTimePickerVisit = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // labelService
            // 
            this.labelService.AutoSize = true;
            this.labelService.Location = new System.Drawing.Point(12, 21);
            this.labelService.Name = "labelService";
            this.labelService.Size = new System.Drawing.Size(46, 13);
            this.labelService.TabIndex = 0;
            this.labelService.Text = "Услуга:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(10, 57);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(12, 198);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(44, 13);
            this.labelSum.TabIndex = 2;
            this.labelSum.Text = "Сумма:";
            // 
            // comboBoxService
            // 
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(119, 21);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(209, 21);
            this.comboBoxService.TabIndex = 3;
            this.comboBoxService.SelectedIndexChanged += new System.EventHandler(this.comboBoxService_SelectedIndexChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(115, 198);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(213, 20);
            this.textBoxSum.TabIndex = 4;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(119, 57);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(209, 20);
            this.textBoxCount.TabIndex = 5;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(15, 277);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(83, 32);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(245, 277);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 32);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(12, 96);
            this.labelClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(46, 13);
            this.labelClient.TabIndex = 8;
            this.labelClient.Text = "Клиент:";
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(119, 96);
            this.comboBoxClient.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(209, 21);
            this.comboBoxClient.TabIndex = 9;
            // 
            // labelAnimal
            // 
            this.labelAnimal.AutoSize = true;
            this.labelAnimal.Location = new System.Drawing.Point(10, 131);
            this.labelAnimal.Name = "labelAnimal";
            this.labelAnimal.Size = new System.Drawing.Size(86, 13);
            this.labelAnimal.TabIndex = 10;
            this.labelAnimal.Text = "Вид животного:";
            // 
            // textBoxAnimal
            // 
            this.textBoxAnimal.Location = new System.Drawing.Point(115, 131);
            this.textBoxAnimal.Name = "textBoxAnimal";
            this.textBoxAnimal.Size = new System.Drawing.Size(213, 20);
            this.textBoxAnimal.TabIndex = 11;
            // 
            // labelAnimalName
            // 
            this.labelAnimalName.AutoSize = true;
            this.labelAnimalName.Location = new System.Drawing.Point(10, 171);
            this.labelAnimalName.Name = "labelAnimalName";
            this.labelAnimalName.Size = new System.Drawing.Size(89, 13);
            this.labelAnimalName.TabIndex = 12;
            this.labelAnimalName.Text = "Имя животного:";
            // 
            // textBoxAnimalName
            // 
            this.textBoxAnimalName.Location = new System.Drawing.Point(115, 164);
            this.textBoxAnimalName.Name = "textBoxAnimalName";
            this.textBoxAnimalName.Size = new System.Drawing.Size(213, 20);
            this.textBoxAnimalName.TabIndex = 13;
            // 
            // labelVisit
            // 
            this.labelVisit.AutoSize = true;
            this.labelVisit.Location = new System.Drawing.Point(14, 236);
            this.labelVisit.Name = "labelVisit";
            this.labelVisit.Size = new System.Drawing.Size(74, 13);
            this.labelVisit.TabIndex = 14;
            this.labelVisit.Text = "Дата визита:";
            // 
            // dateTimePickerVisit
            // 
            this.dateTimePickerVisit.Location = new System.Drawing.Point(115, 236);
            this.dateTimePickerVisit.Name = "dateTimePickerVisit";
            this.dateTimePickerVisit.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerVisit.TabIndex = 15;
            // 
            // FormCreateVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 321);
            this.Controls.Add(this.dateTimePickerVisit);
            this.Controls.Add(this.labelVisit);
            this.Controls.Add(this.textBoxAnimalName);
            this.Controls.Add(this.labelAnimalName);
            this.Controls.Add(this.textBoxAnimal);
            this.Controls.Add(this.labelAnimal);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.comboBoxService);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelService);
            this.Controls.Add(this.labelClient);
            this.Name = "FormCreateVisit";
            this.Text = "Визит в ветиринарную клинику \"Айболит\"";
            this.Load += new System.EventHandler(this.FormCreateVisit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelService;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelAnimal;
        private System.Windows.Forms.TextBox textBoxAnimal;
        private System.Windows.Forms.Label labelAnimalName;
        private System.Windows.Forms.TextBox textBoxAnimalName;
        private System.Windows.Forms.Label labelVisit;
        private System.Windows.Forms.DateTimePicker dateTimePickerVisit;
    }
}