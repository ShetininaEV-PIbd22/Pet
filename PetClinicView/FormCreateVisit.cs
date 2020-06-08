using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.BusinessLogics;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PetClinicView
{
    public partial class FormCreateVisit : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IServiceLogic logicP;
        private readonly IClientLogic logicC;
        private readonly MainLogic logicM;

        public FormCreateVisit(IServiceLogic logicP, IClientLogic logicC, MainLogic logicM)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicC = logicC;
            this.logicM = logicM;
        }

        private void FormCreateVisit_Load(object sender, EventArgs e)
        {
            try
            { //  Логика загрузки списка в выпадающий список
                List<ServiceViewModel> list = logicP.Read(null);
                if (list != null)
                {
                    comboBoxService.DisplayMember = "ServiceName";
                    comboBoxService.ValueMember = "Id";
                    comboBoxService.DataSource = list;
                    comboBoxService.SelectedItem = null;
                }
                List<ClientViewModel> listC = logicC.Read(null);
                if (listC != null)
                {
                    comboBoxClient.DisplayMember = "FIO";
                    comboBoxClient.ValueMember = "Id";
                    comboBoxClient.DataSource = listC;
                    comboBoxClient.SelectedItem = null;
                }
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
                    ServiceViewModel product = logicP.Read(new ServiceBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAnimal.Text))
            {
                MessageBox.Show("Заполните поле Вид животного", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxAnimalName.Text))
            {
                MessageBox.Show("Заполните поле Имя животного", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxService.SelectedValue == null)
            {
                MessageBox.Show("Выберите услугу", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateVisit(new CreateVisitBindingModel
                {
                    ServiceId = Convert.ToInt32(comboBoxService.SelectedValue),
                    ClientFIO = (comboBoxClient.SelectedItem as ClientViewModel).FIO,
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                    Animal=textBoxAnimal.Text,
                    AnimalName=textBoxAnimalName.Text,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
