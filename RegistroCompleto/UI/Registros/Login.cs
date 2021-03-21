using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace RegistroCompleto.UI.Registros
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void InicialButton_Click(object sender, EventArgs e)
        {
            if ((UsuarioTextBox.Text == "") && (ClaveTextBox.Text == ""))
                MessageBox.Show("No puede dejar los Campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if ((UsuarioTextBox.Text != "User") && (ClaveTextBox.Text == "User"))
                MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if ((UsuarioTextBox.Text == "User") && (ClaveTextBox.Text != "User"))
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if ((UsuarioTextBox.Text != "") && (ClaveTextBox.Text != ""))
            {
                if ((UsuarioTextBox.Text != "User") && (ClaveTextBox.Text != "User"))
                    MessageBox.Show("Usuario y Contraseña Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if ((UsuarioTextBox.Text != "") && (ClaveTextBox.Text != "")){

                if ((UsuarioTextBox.Text == "User") && (ClaveTextBox.Text == "User"))
                {
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();
                }
               
            }
        }

        private void UsuarioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ClaveTextBox.Focus();
            }
        }

        private void ClaveTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if ((UsuarioTextBox.Text == "") && (ClaveTextBox.Text == ""))
                    MessageBox.Show("No puede dejar los Campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if ((UsuarioTextBox.Text != "User") && (ClaveTextBox.Text == "User"))
                    MessageBox.Show("Usuario incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if ((UsuarioTextBox.Text == "User") && (ClaveTextBox.Text != "User"))
                    MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if ((UsuarioTextBox.Text != "") && (ClaveTextBox.Text != ""))
                {
                    if ((UsuarioTextBox.Text != "User") && (ClaveTextBox.Text != "User"))
                        MessageBox.Show("Usuario y Contraseña Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if ((UsuarioTextBox.Text != "") && (ClaveTextBox.Text != ""))
                {

                    if ((UsuarioTextBox.Text == "User") && (ClaveTextBox.Text == "User"))
                    {
                        MainForm main = new MainForm();
                        main.Show();
                        this.Hide();
                    }
                }
            }
        }
    }
}
