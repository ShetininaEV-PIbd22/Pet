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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.короблиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКораблейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоКораблямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМедикаментовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьБекапToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateVisit = new System.Windows.Forms.Button();
            this.buttonVisitReady = new System.Windows.Forms.Button();
            this.buttonPayVisit = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonTakeInWork = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.создатьБекапToolStripMenuItem});
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
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.компонентыToolStripMenuItem.Text = "Медикаменты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.медикаментыToolStripMenuItem_Click);
            // 
            // короблиToolStripMenuItem
            // 
            this.короблиToolStripMenuItem.Name = "короблиToolStripMenuItem";
            this.короблиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.короблиToolStripMenuItem.Text = "Услуги";
            this.короблиToolStripMenuItem.Click += new System.EventHandler(this.услугиToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click_1);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКораблейToolStripMenuItem,
            this.компонентыПоКораблямToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокМедикаментовToolStripMenuItem});
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
            // списокМедикаментовToolStripMenuItem
            // 
            this.списокМедикаментовToolStripMenuItem.Name = "списокМедикаментовToolStripMenuItem";
            this.списокМедикаментовToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.списокМедикаментовToolStripMenuItem.Text = "Список медикаментов";
            this.списокМедикаментовToolStripMenuItem.Click += new System.EventHandler(this.списокМедикаментовToolStripMenuItem_Click);
            // 
            // создатьБекапToolStripMenuItem
            // 
            this.создатьБекапToolStripMenuItem.Name = "создатьБекапToolStripMenuItem";
            this.создатьБекапToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.создатьБекапToolStripMenuItem.Text = "Создать бекап";
            this.создатьБекапToolStripMenuItem.Click += new System.EventHandler(this.создатьБекапToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(565, 420);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateVisit
            // 
            this.buttonCreateVisit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateVisit.Location = new System.Drawing.Point(604, 47);
            this.buttonCreateVisit.Name = "buttonCreateVisit";
            this.buttonCreateVisit.Size = new System.Drawing.Size(156, 42);
            this.buttonCreateVisit.TabIndex = 2;
            this.buttonCreateVisit.Text = "Создать заявку на визит в ветиринарную клинику";
            this.buttonCreateVisit.UseVisualStyleBackColor = true;
            this.buttonCreateVisit.Click += new System.EventHandler(this.buttonCreateRemont_Click);
            // 
            // buttonVisitReady
            // 
            this.buttonVisitReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVisitReady.Location = new System.Drawing.Point(604, 146);
            this.buttonVisitReady.Name = "buttonVisitReady";
            this.buttonVisitReady.Size = new System.Drawing.Size(156, 23);
            this.buttonVisitReady.TabIndex = 4;
            this.buttonVisitReady.Text = "Визит выполнен";
            this.buttonVisitReady.UseVisualStyleBackColor = true;
            this.buttonVisitReady.Click += new System.EventHandler(this.buttonRemontReady_Click);
            // 
            // buttonPayVisit
            // 
            this.buttonPayVisit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPayVisit.Location = new System.Drawing.Point(604, 191);
            this.buttonPayVisit.Name = "buttonPayVisit";
            this.buttonPayVisit.Size = new System.Drawing.Size(156, 23);
            this.buttonPayVisit.TabIndex = 5;
            this.buttonPayVisit.Text = "Визит оплачен";
            this.buttonPayVisit.UseVisualStyleBackColor = true;
            this.buttonPayVisit.Click += new System.EventHandler(this.buttonPayRemont_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRef.AutoSize = true;
            this.buttonRef.Location = new System.Drawing.Point(604, 415);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(156, 23);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDel.Location = new System.Drawing.Point(604, 371);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(156, 23);
            this.buttonDel.TabIndex = 7;
            this.buttonDel.Text = "Удалить заявку";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonTakeInWork
            // 
            this.buttonTakeInWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTakeInWork.Location = new System.Drawing.Point(604, 106);
            this.buttonTakeInWork.Name = "buttonTakeInWork";
            this.buttonTakeInWork.Size = new System.Drawing.Size(156, 23);
            this.buttonTakeInWork.TabIndex = 8;
            this.buttonTakeInWork.Text = "Начать выполнять визит";
            this.buttonTakeInWork.UseVisualStyleBackColor = true;
            this.buttonTakeInWork.Click += new System.EventHandler(this.buttonTakeRemontInWork_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTakeInWork);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayVisit);
            this.Controls.Add(this.buttonVisitReady);
            this.Controls.Add(this.buttonCreateVisit);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button buttonCreateVisit;
        private System.Windows.Forms.Button buttonVisitReady;
        private System.Windows.Forms.Button buttonPayVisit;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКораблейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоКораблямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокМедикаментовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьБекапToolStripMenuItem;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonTakeInWork;
    }
}