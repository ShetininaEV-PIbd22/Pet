using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace PetClinicView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MainLogic logic;

        private readonly IVisitLogic orderLogic;
        private readonly ReportLogic report;

        public FormMain(MainLogic logic, IVisitLogic orderLogic, ReportLogic report)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.report = report;
        }

        private void медикаментыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMedicines>();
            form.ShowDialog();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServices>();
            form.ShowDialog();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = orderLogic.Read(null);
                if (list != null)
                {

                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateRemont_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateVisit>();
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void buttonTakeRemontInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.TakeVisitInWork(new ChangeStatusBindingModel { VisitId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRemontReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.FinishVisit(new ChangeStatusBindingModel { VisitId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPayRemont_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.PayVisit(new ChangeStatusBindingModel { VisitId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void списокУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    report.SaveServicesToWordFile(new ReportBindingModel { FileName = dialog.FileName });//!!!!!!!!!!
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void услугиСТребуемымиМедикаментамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportServiceMedicines>();
            form.ShowDialog();
        }

        private void списокВизитовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportVisits>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }
    }
}
