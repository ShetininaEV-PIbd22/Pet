using PetClinicBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PetClinicClientView
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text) 
                && !string.IsNullOrEmpty(textBoxClientFIO.Text) && !string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrEmpty(textBoxPhone.Text))
            {
                try
                {
                    APIClient.PostRequest("api/client/register", new ClientBindingModel
                    {
                        FIO = textBoxClientFIO.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text,
                        Email=textBoxEmail.Text,
                        Phone=textBoxPhone.Text,
                    });
                MessageBox.Show("Регистрация прошла успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин, пароль, ФИО, почту и номер телефона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}