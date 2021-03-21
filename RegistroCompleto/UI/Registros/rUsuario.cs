using RegistroCompleto.BLL;
using RegistroCompleto.Entidades;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class rUsuario : Form
    {
        public rUsuario()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuario usuarios = UsuariosBLL.Buscar((int)IdNumericUpDown.Value);

            return (usuarios != null);
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            AliasTextBox.Clear();
            NombreTextBox.Clear();
            EmailTextBox.Clear();
            ClaveTextBox.Clear();
            ConfirmClaveTextBox.Clear();
            FechaDateTimePicker.CustomFormat = "";
            ActivoCheckBox.Checked = false;
            RolComboBox.Text = "";
        }

        private void LlenarCampos(Usuario usuarios)
        {
            IdNumericUpDown.Value = usuarios.UsuarioID;
            NombreTextBox.Text = usuarios.Nombres;
            EmailTextBox.Text = usuarios.Email;
            AliasTextBox.Text = usuarios.Alias;
            ClaveTextBox.Text = usuarios.Clave;
            FechaDateTimePicker.Value = usuarios.FechaIngreso;
            ActivoCheckBox.Checked = usuarios.Activo;
        }

        private Usuario LlenarClase()
        {
            Usuario usuarios = new Usuario();
            usuarios.UsuarioID = (int)IdNumericUpDown.Value;
            usuarios.Clave = ClaveTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.Nombres = NombreTextBox.Text;
            usuarios.FechaIngreso = FechaDateTimePicker.Value;
            usuarios.Alias = AliasTextBox.Text;
            usuarios.Activo = ActivoCheckBox.Checked;

            return usuarios;
        }

        private bool Validar()
        {
            bool paso = true;

            if (NombreTextBox.Text == string.Empty)
            {
                Errores.SetError(NombreTextBox, "El campo nombre no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(RolComboBox.Text))
            {
                Errores.SetError(RolComboBox, "Debe agregar un rol especifico");
                RolComboBox.Focus();
                paso = false;
            }

            if(AliasTextBox.Text == string.Empty)
            {
                Errores.SetError(AliasTextBox, "El campo de alias no puede estar vacio");
                AliasTextBox.Focus();
                paso = false;
            }

            if(ClaveTextBox.Text == string.Empty)
            {
                Errores.SetError(ClaveTextBox, "El campo de clave no puede estar vacio");
                ClaveTextBox.Focus();
                paso = false;
            }

            if(ConfirmClaveTextBox.Text == string.Empty)
            {
                Errores.SetError(ConfirmClaveTextBox, "El campo de confirmar clave no puede estar vacio");
                ConfirmClaveTextBox.Focus();
                paso = false;
            }

            if(EmailTextBox.Text == string.Empty)
            {
                Errores.SetError(EmailTextBox, "El campo de email no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if (UsuariosBLL.ExisteAlias(AliasTextBox.Text))
            {
                Errores.SetError(AliasTextBox, "Este Alias ya existe");
                AliasTextBox.Focus();
                paso = false;
            }
            if(string.Equals(ClaveTextBox.Text, ConfirmClaveTextBox.Text) != true)
            {
                Errores.SetError(ConfirmClaveTextBox, "La clave es distinta");
                ConfirmClaveTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuario usuario = new Usuario();
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            usuario = UsuariosBLL.Buscar(id);

            if (usuario != null)
            {
                MessageBox.Show("Persona Encotrada");
                LlenarCampos(usuario);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            bool paso = false;
            if (!Validar())
            {
                return;
            }
            usuario = LlenarClase();
            paso = UsuariosBLL.Guardar(usuario);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Transacciones exitosa", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Transaccion fallida", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Errores.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);
            Limpiar();
            if (UsuariosBLL.Eliminar(id))
                MessageBox.Show("Usuario eliminado correctamente", "Proceso exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                Errores.SetError(IdNumericUpDown, "ID no existente");
        }

        private void rUsuario_Load(object sender, EventArgs e)
        {
            RolComboBox.DataSource = RolesBLL.GetRoles();
            RolComboBox.DisplayMember = "Descripcion";
            RolComboBox.ValueMember = "RolId";
        }
    }
}
