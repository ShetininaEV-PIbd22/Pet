namespace PetClinicClientView
{
    partial class FormReportServices
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(337, 94);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Выберите формат, в котором вы бы хотели получить список услуг ветеринарной клиник" +
    "и \"Айболит\". Отчет, в выбранном формете, придет на почту, указанную при регистра" +
    "ции. ";
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(267, 120);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(82, 41);
            this.buttonExcel.TabIndex = 1;
            this.buttonExcel.Text = "Excel формат";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonWord
            // 
            this.buttonWord.Location = new System.Drawing.Point(12, 119);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(75, 42);
            this.buttonWord.TabIndex = 2;
            this.buttonWord.Text = "Word формат ";
            this.buttonWord.UseVisualStyleBackColor = true;
            this.buttonWord.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // FormReportServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 182);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FormReportServices";
            this.Text = "Выбор формата отчета";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Button buttonWord;
    }
}