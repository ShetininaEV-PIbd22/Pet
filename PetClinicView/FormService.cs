using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace PetClinicView
{
    public partial class FormService : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IServiceLogic logic;

        private int? id;

        private Dictionary<int, (string, int)> serviceMedicines;

        public FormService(IServiceLogic service)
        {
            InitializeComponent();
            logic = service;
            LoadData();
        }

        private void FormShip_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ServiceViewModel view = logic.Read(new ServiceBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.ServiceName;
                        textBoxPrice.Text = view.Price.ToString();
                        serviceMedicines = view.ServiceMedicines;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                serviceMedicines = new Dictionary<int, (string, int)>();
        }

        private void LoadData()
        {
            try
            {
                dataGridView.Columns.Clear();
                dataGridView.Columns.Add("Number", "№");
                dataGridView.Columns.Add("Medicines", "Медикаменты");
                dataGridView.Columns.Add("Count", "Количество"); 
                dataGridView.Columns[0].Visible = false;
                if (serviceMedicines != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pi in serviceMedicines)
                        dataGridView.Rows.Add(new object[] { pi.Key, pi.Value.Item1, pi.Value.Item2 });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServiceMedicine>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (serviceMedicines.ContainsKey(form.Id))
                {
                    serviceMedicines[form.Id] = (form.MedicineName, form.Count);
                }
                else
                {
                    serviceMedicines.Add(form.Id, (form.MedicineName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormServiceMedicine>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = serviceMedicines[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    serviceMedicines[form.Id] = (form.MedicineName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        serviceMedicines.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (serviceMedicines == null || serviceMedicines.Count == 0)
            {
                MessageBox.Show("Заполните ингредиенты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (var pi in serviceMedicines)
                {
                    Console.WriteLine(pi);
                }
                logic.CreateOrUpdate(new ServiceBindingModel
                {
                    Id = id,
                    ServiceName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    ServiceMedicines = serviceMedicines
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
