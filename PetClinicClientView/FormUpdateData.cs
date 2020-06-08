using PetClinicBusinessLogic.BindingModels;
using PetClinicClientView;
using System;
using System.Windows.Forms;

namespace PetClinicClientView
{
    public partial class FormUpdateData : Form
    {
        public FormUpdateData()
        {
            InitializeComponent();
            textBoxClientFIO.Text = Program.Client.FIO;
            textBoxLogin.Text = Program.Client.Login;
            textBoxPassword.Text = Program.Client.Password;
            textBoxEmail.Text = Program.Client.Email;
            textBoxPhone.Text = Program.Client.Phone;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text) && !string.IsNullOrEmpty(textBoxClientFIO.Text))
            {
                try
                {
                    APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                    {
                        FIO = textBoxClientFIO.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text,
                        Email = textBoxEmail.Text,
                        Phone = textBoxPhone.Text,
                    });

                    MessageBox.Show("Обновление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.Client.FIO = textBoxClientFIO.Text;
                    Program.Client.Login = textBoxLogin.Text;
                    Program.Client.Password = textBoxPassword.Text;
                    Program.Client.Email = textBoxEmail.Text;
                    Program.Client.Phone = textBoxPhone.Text;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин, пароль, ФИО, почту и номер телефона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}