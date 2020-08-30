using PetClinicBusinessLogic.ViewModels;
using PetClinicDatabaseImplement.Implements;
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
        BackupLogic backUpAbstractLogic = new BackupLogic();
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }
        private void LoadList()
        {
            try
            {
                Program.ConfigGrid(APIClient.GetRequest<List<VisitViewModel>>($"api/main/getvisits?clientId={Program.Client.Id}")
                    , dataGridView);
                dataGridView.Columns[1].Visible = false;

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
        
        private void XmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                    backUpAbstractLogic.CreateArchive(fbd.SelectedPath, "xml");
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void JsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpAbstractLogic.CreateArchive(fbd.SelectedPath, "json");
                        MessageBox.Show("Бекап создан", "Сообщение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

    }
}
