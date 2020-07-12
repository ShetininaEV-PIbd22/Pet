using Microsoft.Reporting.WinForms;
using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.ViewModels;
using PetClinicDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace PetClinicClientView
{
    public partial class FormReportVisits : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        //private readonly ReportLogic logic;
        public FormReportVisits()
        {
            InitializeComponent();
        }
        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Date to " + dateTimePickerTo.Value.Date);
            Console.WriteLine("Date from " + dateTimePickerFrom.Value.Date);
            if (dateTimePickerTo.Value.Date >= dateTimePickerFrom.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<ReportVisitsViewModel> list = APIClient.GetRequest<List<VisitViewModel>>($"api/main/getvisits?clientId=" +
                            $"{Program.Client.Id}")
                            .Where(rec => rec.DateVisit.Date <= dateTimePickerFrom.Value.Date)
                            .Where(rec => rec.DateVisit.Date >= dateTimePickerTo.Value.Date)
                            .Select(x => new ReportVisitsViewModel
                            {
                                DateVisit = x.DateVisit.Date,
                                ServiceName = x.ServiceName,
                                Animal = x.Animal,
                                AnimalName = x.AnimalName,
                                Count = x.Count,
                                Sum = x.Sum,
                                Status = x.Status
                            })
                            .ToList();
            APIClient.PostRequest($"api/main/savevisitstopdffile", new ReportBindingModel
            {
                FileName = "C:\\Users\\sheti\\Desktop\\PetClinic.pdf",
                DateTo= dateTimePickerTo.Value.Date,
                DateFrom= dateTimePickerFrom.Value.Date,
                Visits=list
            });
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "C:\\Users\\sheti\\Desktop\\PetClinic.pdf",
                Email = Program.Client.Email
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonReport_Click(object sender, EventArgs e)
        {
            if (dateTimePickerTo.Value.Date >= dateTimePickerFrom.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var list = APIClient.GetRequest<List<VisitViewModel>>($"api/main/getvisits?clientId=" +
                    $"{Program.Client.Id}")
                    .Where(rec=> rec.DateVisit.Date<= dateTimePickerFrom.Value.Date)
                    .Where(rec=> rec.DateVisit.Date>= dateTimePickerTo.Value.Date)
                    .ToList();
                Program.ConfigGrid(list, dataGridView);
                dataGridView.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

