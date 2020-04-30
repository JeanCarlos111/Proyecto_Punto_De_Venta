using BackEnd.BLL.Usuarios;
using BackEnd.DAL.Usuarios;
using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class frmRegistro : Form
    {
        private IUsuariosDAL usuariosDAL = new UsuariosDALImpl();
        private List<Usuario> usuarios = new List<Usuario>();

        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IUsuariosBLL usuariosBLL = new UsuariosBLLImpl();

            int cantidadActual = usuariosDAL.GetUsuarios().Count;
            int cantidadNueva = usuariosDAL.GetUsuarios().Count + 1;

            try
            {
                //if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtCorreo.Text) && !String.IsNullOrEmpty(txtDireccion.Text)
                //   && String.IsNullOrEmpty(txtTelefono.Text))
                //{
                    Usuario usuario = new Usuario();
                    usuario.id_usuario = cantidadNueva;
                    usuario.nombre_usuario = txtNombre.Text;
                    usuario.contrasena = txtContrasenna.Text;
                    //rol
                    usuario.id_rol = 2;
                    usuario.correo_usuario = txtCorreo.Text;
                    usuario.telefono_usuario = txtTelefono.Text;
                    usuario.direccion = txtDireccion.Text;
                    usuariosBLL.AddUsuario(usuario);

                    MessageBox.Show("Usuario Insertado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Login frmLogin = new Login();
                    frmLogin.Show();
                    this.Hide();
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y numero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtContrasenna_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y numero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y numero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }
    }
}
