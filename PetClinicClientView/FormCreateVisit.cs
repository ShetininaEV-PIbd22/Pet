using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetClinicClientView
{
    public partial class FormCreateVisit : Form
    {
        public FormCreateVisit()
        {
            InitializeComponent();
        }

        private void FormCreateVisit_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxService.DisplayMember = "ServiceName";
                comboBoxService.ValueMember = "Id";
                comboBoxService.DataSource = APIClient.GetRequest<List<ServiceViewModel>>("api/main/getservicelist");
                comboBoxService.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxService.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxService.SelectedValue);
                    ServiceViewModel product = APIClient.GetRequest<ServiceViewModel>($"api/main/getservice?serviceId={id}");
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Save");
            Console.WriteLine("FormCreate Visit: DataVisit= " + dateTimePickerVisit.Value.Date.Date);
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAnimal.Text))
            {
                MessageBox.Show("Заполните поле Вид животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAnimalName.Text))
            {
                MessageBox.Show("Заполните поле Имя животного", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxService.SelectedValue == null)
            {
                MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerVisit == null)
            {
                MessageBox.Show("Выберите дату визита", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Console.WriteLine("ClientView: " + dateTimePickerVisit.Value.Date);
                APIClient.PostRequest("api/main/createvisit", new CreateVisitBindingModel
                {
                    ClientId = Program.Client.Id,
                    DataVisit = dateTimePickerVisit.Value.Date,
                    ClientFIO = Program.Client.FIO,
                    ServiceId = Convert.ToInt32(comboBoxService.SelectedValue),
                    Animal = textBoxAnimal.Text.ToString(),
                    AnimalName = textBoxAnimalName.Text.ToString(),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),

                });
                foreach (var data in APIClient.GetRequest<List<VisitViewModel>>($"api/main/getvisits?clientId={Program.Client.Id}"))
                {
                    Console.WriteLine("FormCreateVisit Visits: " + data.Animal + ", " + data.AnimalName + ", " + data.ClientFIO + ", "
                        + data.ServiceName + ", " + data.Count + ", " + data.Sum + ", " + data.Status + ", " + data.DateVisit);
                }
                Console.WriteLine("FormCreate Visit: DataVisit= " + dateTimePickerVisit.Value.Date);
                MessageBox.Show("Заявка создана", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
