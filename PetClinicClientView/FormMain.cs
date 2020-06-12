using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace PetClinicClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<VisitViewModel>>($"api/main/getvisits?clientId={Program.Client.Id}");
                foreach (var data in APIClient.GetRequest<List<VisitViewModel>>($"api/main/getvisits?clientId={Program.Client.Id}"))
                {
                    Console.WriteLine("FormMain: " + data.Animal + ", " + data.AnimalName + ", " + data.ClientFIO + ", "
                        + data.ServiceName + ", " + data.Count + ", " + data.Sum + ", " + data.Status + ", " + 
                        data.DateVisit.Date);
                }
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUpdateData();
            form.ShowDialog();
        }

        private void CreateVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateVisit();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }
        private void RefreshVisitListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }
        private void ReportVisitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReportVisits();
            form.ShowDialog();
        }
        private void ReportServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReportServices();
            form.ShowDialog();
        }
    }
}
