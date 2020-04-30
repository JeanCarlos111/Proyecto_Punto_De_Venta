using BackEnd.DAL.Usuarios;
using BackEnd.ENTITIES;
using FrontEnd.Administracion;
using FrontEnd.Cliente;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            IUsuariosDAL usuariosDAL = new UsuariosDALImpl();
            Usuario usuario= usuariosDAL.InicioSesion(TxtName.Text);
           if (usuario == null)
            {
                MessageBox.Show("Acceso Denegado");
            }
            else
            {
                if ((usuario.nombre_usuario == TxtName.Text) && (usuario.contrasena == TxtPass.Text) && (usuario.id_rol==1))
                {
                    MessageBox.Show("Bienvenido Administrador, "+usuario.nombre_usuario, "Inicio Sesion");
                    MenuAdministrador form2 = new MenuAdministrador();

                    form2.Show();
                    Hide();
                }
                else
                { 
                   if ((usuario.nombre_usuario == TxtName.Text) && (usuario.contrasena == TxtPass.Text) && (usuario.id_rol == 2))
                    {
                        MessageBox.Show("Bienvenido "+usuario.nombre_usuario+"!", "Inicio Sesion");
                        Catalogo frmCatalogo = new Catalogo(usuario.id_usuario);
                        frmCatalogo.Show();
                        this.Hide();
                        
                    }
                   
                }
             }

         }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros y letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            frmRegistro frmRegistro = new frmRegistro();
            frmRegistro.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
