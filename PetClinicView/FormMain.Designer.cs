namespace PetClinicView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.короблиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКораблейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоКораблямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateRemont = new System.Windows.Forms.Button();
            this.buttonTakeRemontInWork = new System.Windows.Forms.Button();
            this.buttonRemontReady = new System.Windows.Forms.Button();
            this.buttonPayRemont = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.короблиToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.компонентыToolStripMenuItem.Text = "Медикаменты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.медикаментыToolStripMenuItem_Click);
            // 
            // короблиToolStripMenuItem
            // 
            this.короблиToolStripMenuItem.Name = "короблиToolStripMenuItem";
            this.короблиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.короблиToolStripMenuItem.Text = "Услуги";
            this.короблиToolStripMenuItem.Click += new System.EventHandler(this.услугиToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click_1);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКораблейToolStripMenuItem,
            this.компонентыПоКораблямToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокКораблейToolStripMenuItem
            // 
            this.списокКораблейToolStripMenuItem.Name = "списокКораблейToolStripMenuItem";
            this.списокКораблейToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.списокКораблейToolStripMenuItem.Text = "Список услуг";
            this.списокКораблейToolStripMenuItem.Click += new System.EventHandler(this.списокУслугToolStripMenuItem_Click);
            // 
            // компонентыПоКораблямToolStripMenuItem
            // 
            this.компонентыПоКораблямToolStripMenuItem.Name = "компонентыПоКораблямToolStripMenuItem";
            this.компонентыПоКораблямToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.компонентыПоКораблямToolStripMenuItem.Text = "Услуги с требуемыми медикаментами";
            this.компонентыПоКораблямToolStripMenuItem.Click += new System.EventHandler(this.услугиСТребуемымиМедикаментамиToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список визитов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокВизитовToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(565, 420);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateRemont
            // 
            this.buttonCreateRemont.Location = new System.Drawing.Point(604, 47);
            this.buttonCreateRemont.Name = "buttonCreateRemont";
            this.buttonCreateRemont.Size = new System.Drawing.Size(156, 42);
            this.buttonCreateRemont.TabIndex = 2;
            this.buttonCreateRemont.Text = "Создать заявку на визит в ветиринарную клинику";
            this.buttonCreateRemont.UseVisualStyleBackColor = true;
            this.buttonCreateRemont.Click += new System.EventHandler(this.buttonCreateRemont_Click);
            // 
            // buttonTakeRemontInWork
            // 
            this.buttonTakeRemontInWork.Location = new System.Drawing.Point(604, 112);
            this.buttonTakeRemontInWork.Name = "buttonTakeRemontInWork";
            this.buttonTakeRemontInWork.Size = new System.Drawing.Size(156, 23);
            this.buttonTakeRemontInWork.TabIndex = 3;
            this.buttonTakeRemontInWork.Text = "Выполнить заявку на визит";
            this.buttonTakeRemontInWork.UseVisualStyleBackColor = true;
            this.buttonTakeRemontInWork.Click += new System.EventHandler(this.buttonTakeRemontInWork_Click);
            // 
            // buttonRemontReady
            // 
            this.buttonRemontReady.Location = new System.Drawing.Point(604, 152);
            this.buttonRemontReady.Name = "buttonRemontReady";
            this.buttonRemontReady.Size = new System.Drawing.Size(156, 23);
            this.buttonRemontReady.TabIndex = 4;
            this.buttonRemontReady.Text = "Визит выполнен";
            this.buttonRemontReady.UseVisualStyleBackColor = true;
            this.buttonRemontReady.Click += new System.EventHandler(this.buttonRemontReady_Click);
            // 
            // buttonPayRemont
            // 
            this.buttonPayRemont.Location = new System.Drawing.Point(604, 215);
            this.buttonPayRemont.Name = "buttonPayRemont";
            this.buttonPayRemont.Size = new System.Drawing.Size(156, 23);
            this.buttonPayRemont.TabIndex = 5;
            this.buttonPayRemont.Text = "Ремонт оплачен";
            this.buttonPayRemont.UseVisualStyleBackColor = true;
            this.buttonPayRemont.Click += new System.EventHandler(this.buttonPayRemont_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(604, 415);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(156, 23);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayRemont);
            this.Controls.Add(this.buttonRemontReady);
            this.Controls.Add(this.buttonTakeRemontInWork);
            this.Controls.Add(this.buttonCreateRemont);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Ветеринарная клиника \"Айболит\"";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem короблиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateRemont;
        private System.Windows.Forms.Button buttonTakeRemontInWork;
        private System.Windows.Forms.Button buttonRemontReady;
        private System.Windows.Forms.Button buttonPayRemont;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКораблейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоКораблямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    }
}