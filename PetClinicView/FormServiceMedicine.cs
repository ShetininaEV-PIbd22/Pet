using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PetClinicView
{
    public partial class FormServiceMedicine : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxMedicine.SelectedValue); }
            set { comboBoxMedicine.SelectedValue = value; }
        }
        public string MedicineName { get { return comboBoxMedicine.Text; } }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set { textBoxCount.Text = value.ToString(); }
        }

        public FormServiceMedicine(IMedicineLogic logic)
        {
            InitializeComponent();
            //  Получаем список и заносим его в выпадающий список
            List<MedicineViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxMedicine.DisplayMember = "MedicineName";
                comboBoxMedicine.ValueMember = "Id";
                comboBoxMedicine.DataSource = list;
                comboBoxMedicine.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxMedicine.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
