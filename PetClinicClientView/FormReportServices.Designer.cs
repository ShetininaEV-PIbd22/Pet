﻿namespace PetClinicClientView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportServices));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(14, 14);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(392, 108);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Выберите формат, в котором вы бы хотели получить список услуг ветеринарной клиник" +
    "и \"Айболит\". Отчет, в выбранном формете, придет на почту, указанную при регистра" +
    "ции. ";
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(312, 138);
            this.buttonExcel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(96, 47);
            this.buttonExcel.TabIndex = 1;
            this.buttonExcel.Text = "Excel формат";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonWord
            // 
            this.buttonWord.Location = new System.Drawing.Point(14, 137);
            this.buttonWord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(88, 48);
            this.buttonWord.TabIndex = 2;
            this.buttonWord.Text = "Word формат ";
            this.buttonWord.UseVisualStyleBackColor = true;
            this.buttonWord.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // FormReportServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 210);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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