using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.BusinessLogics;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;
using Unity;

namespace PetClinicView
{
    public partial class FormReportServiceMedicines : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportServiceMedicines(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveServiceMedicinesToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void reportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetServiceMedicine();
                ReportDataSource source = new ReportDataSource("DataServiceMedicine", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormReportServiceMedicines_Load(object sender, EventArgs e)
        {

        }
    }
}