﻿using PetClinicBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text) && !string.IsNullOrEmpty(textBoxPassword.Text) 
                && !string.IsNullOrEmpty(textBoxClientFIO.Text) && !string.IsNullOrEmpty(textBoxEmail.Text))
            {
                try
                {
                    APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                    {
                        Id = Program.Client.Id,
                        FIO = textBoxClientFIO.Text,
                        Login = textBoxLogin.Text,
                        Email=textBoxEmail.Text,
                        Password = textBoxPassword.Text
                    });

                    MessageBox.Show("Обновление прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Program.Client.FIO = textBoxClientFIO.Text;
                    Program.Client.Login = textBoxLogin.Text;
                    Program.Client.Email = textBoxEmail.Text;
                    Program.Client.Password = textBoxPassword.Text;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин, пароль, почту и ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
