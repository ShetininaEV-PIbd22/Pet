using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace PetClinicClientView
{
    public partial class FormReportServices : Form
    {
        public FormReportServices()
        {
            InitializeComponent();
        }
        private void buttonWord_Click(object sender, EventArgs e)
        {
            APIClient.PostRequest($"api/main/saveservicestowordfile", new ReportBindingModel
            {
                FileName = "C:\\Users\\sheti\\Desktop\\PetClinic.docx", 
            });
            
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "C:\\Users\\sheti\\Desktop\\PetClinic.docx",
                Email = Program.Client.Email
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            APIClient.PostRequest($"api/main/saveservicestoexcelfile", new ReportBindingModel
            {
                FileName = "C:\\Users\\sheti\\Desktop\\PetClinic.xlsx",
            });
            
            APIClient.PostRequest($"api/main/sendmessage", new ReportBindingModel
            {
                FileName = "C:\\Users\\sheti\\Desktop\\PetClinic.xlsx",
                Email = Program.Client.Email
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
