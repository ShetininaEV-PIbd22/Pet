using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.BindingModels;
using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Unity;
using System.Linq;
using System.Collections.Generic;

namespace PetClinicView
{
    public partial class FormReportVisits : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportAdminLogic logic;
        public FormReportVisits(ReportAdminLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void ButtonSaveToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date>=dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveAllVisitsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = dateTimePickerFrom.Value.Date,
                            DateTo = dateTimePickerTo.Value.Date
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

        private void ButtonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = logic.GetAllVisits(new ReportBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value.Date,
                    DateTo = dateTimePickerTo.Value.Date
                });
                Console.WriteLine("DateFrom= " + dateTimePickerFrom.Value.Date);
                Console.WriteLine("DateTo= " + dateTimePickerTo.Value.Date);
                foreach (var data in dataSource)
                {
                    Console.WriteLine(data.Animal + ", " + data.AnimalName);
                }
                ReportDataSource source = new ReportDataSource("DataSetVisits", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}

