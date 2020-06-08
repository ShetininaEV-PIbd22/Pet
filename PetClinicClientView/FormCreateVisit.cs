using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
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
                comboBoxProduct.DisplayMember = "ServiceName";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = APIClient.GetRequest<List<ServiceViewModel>>("api/main/getservicelist");
                comboBoxProduct.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    ServiceViewModel product = APIClient.GetRequest<ServiceViewModel>($"api/main/getship?productId={id}");
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
            if (comboBoxProduct.SelectedValue == null)
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
                APIClient.PostRequest("api/main/createvisit", new CreateVisitBindingModel
                {
                    ClientId = Program.Client.Id,
                    ClientFIO = Program.Client.FIO,
                    ServiceId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    Animal=textBoxAnimal.Text,
                    AnimalName=textBoxAnimalName.Text,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    DataVisit=dateTimePickerVisit.Value.Date
                });

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