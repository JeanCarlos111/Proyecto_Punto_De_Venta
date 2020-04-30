using BackEnd.BLL;
using BackEnd.BLL.Usuarios;
using BackEnd.DAL.Roles;
using BackEnd.DAL.Usuarios;
using BackEnd.ENTITIES;
using FrontEnd.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Administracion
{
    public partial class FrmUsuarios : Form
    {
        private IUsuariosDAL usuariosDAL = new UsuariosDALImpl();
        private List<Usuario> usuarios = new List<Usuario>();
        private IRolesDAL RolesDAL = new RolesDALImpl();
        private List<Rol> rol = new List<Rol>();
       

        public FrmUsuarios()
        {
            InitializeComponent();
            llenarTabla();
            LlenarComboBox();
                    }

        private void LlenarComboBox()
        {
            try
            {
                rol = RolesDAL.GetRoles();
                foreach (var item in rol)
                {
                    cbRol.Items.Add(item.id_rol);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void llenarTabla()
        {
           

            try
            {

                usuarios = usuariosDAL.GetUsuarios();

                lsvUsuarios.View = View.Details;
                lsvUsuarios.Focus();
                lsvUsuarios.FullRowSelect = true;
                foreach (var item in usuarios)
                {
                    ListViewItem itemAgregar = new ListViewItem();
                    itemAgregar.Text = Convert.ToString(item.id_usuario);
                    itemAgregar.SubItems.Add(item.nombre_usuario);
                    itemAgregar.SubItems.Add(item.contrasena);

                    itemAgregar.SubItems.Add(item.correo_usuario);
                    itemAgregar.SubItems.Add(Convert.ToString(item.telefono_usuario));
                    itemAgregar.SubItems.Add(item.direccion);
                    itemAgregar.SubItems.Add(Convert.ToString(item.id_rol));
                    lsvUsuarios.Items.Add(itemAgregar);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }


        private void lsvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rol rol;

            if (lsvUsuarios.SelectedItems.Count > 0)
            {
                ListViewItem listItem = lsvUsuarios.SelectedItems[0];
                lblD.Text = listItem.Text;
                txtNombre.Text = listItem.SubItems[1].Text;
                txtCorreo.Text = listItem.SubItems[3].Text;
                txtContrasenna.Text = listItem.SubItems[2].Text;
                txtTelefono.Text = listItem.SubItems[4].Text;
                txtDireccion.Text = listItem.SubItems[5].Text;
                cbRol.Text = listItem.SubItems[6].Text;
                rol = RolesDAL.GetRol(int.Parse(cbRol.Text));
                txtRol.Text = rol.nombre_rol;
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaProductos frmVistaProductos = new VistaProductos();
            frmVistaProductos.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IUsuariosBLL usuariosBLL = new UsuariosBLLImpl();

            int cantidadActual = usuariosDAL.GetUsuarios().Count;
            int cantidadNueva = usuariosDAL.GetUsuarios().Count + 1;

            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text)&& !String.IsNullOrEmpty(txtCorreo.Text)&& 
                    !String.IsNullOrEmpty(txtContrasenna.Text)&&!String.IsNullOrEmpty(txtTelefono.Text))
                {
                    Usuario usuario = new Usuario();
                    usuario.id_usuario = cantidadNueva;
                    usuario.nombre_usuario = txtNombre.Text;
                    usuario.contrasena = txtContrasenna.Text;
                    //rol
                    usuario.id_rol = int.Parse(cbRol.Text);
                    usuario.correo_usuario = txtCorreo.Text;
                    usuario.telefono_usuario = txtTelefono.Text;
                    usuario.direccion = txtDireccion.Text;
                    usuariosBLL.AddUsuario(usuario);

                    MessageBox.Show("Usuario Insertado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // LimpiarlistView();
                    LimpiarCampos();
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("No se permiten en campos en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void LimpiarlistView()
        {
            lsvUsuarios.Clear();
            llenarTabla();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtContrasenna.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            lblD.Text = "";
            cbRol.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtCorreo.Text) &&
                      !String.IsNullOrEmpty(txtContrasenna.Text) && !String.IsNullOrEmpty(txtTelefono.Text))
                {
                    Usuario usuario = new Usuario();
                    usuario.id_usuario = int.Parse(lblD.Text);
                    usuario.nombre_usuario = txtNombre.Text;
                    usuario.contrasena = txtContrasenna.Text;
                    //rol
                    usuario.id_rol = int.Parse(cbRol.Text);
                    usuario.correo_usuario = txtCorreo.Text;
                    usuario.telefono_usuario = txtTelefono.Text;
                    usuario.direccion = txtDireccion.Text;
                    usuariosDAL.UpdateUsuario(usuario);

                    MessageBox.Show("Usuario Actualizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // LimpiarlistView();
                    LimpiarCampos();
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("No se permiten en campos en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           

            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtCorreo.Text) &&
                         !String.IsNullOrEmpty(txtContrasenna.Text) && !String.IsNullOrEmpty(txtTelefono.Text))
                {
                    usuariosDAL.DeleteUsuario(int.Parse(lblD.Text));
                    MessageBox.Show("Usuario Eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // LimpiarlistView();
                    LimpiarCampos();
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("No se permiten en campos en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void provedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor frmProveedor = new FrmProveedor();
            frmProveedor.Show();
            this.Hide();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaFacturas frmFacturas = new VistaFacturas();
            frmFacturas.Show();
            this.Hide();
        }

        private void provedorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmProveedor frmProveedor = new FrmProveedor();
            frmProveedor.Show();
            this.Hide();
        }

        private void btnDescriptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La contraseña es: "+Encriptador.Decrypt(txtContrasenna.Text, true), "Clave Desencriptada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Encriptador.Decrypt(txtContrasenna.Text, true);
        }

        private void txtRol_TextChanged(object sender, EventArgs e)
        {
            Rol rol;
            rol = RolesDAL.GetRol(int.Parse(cbRol.Text));
            txtRol.Text = rol.nombre_rol;
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rol rol;
            
            int selectedIndex = cbRol.SelectedIndex;
            if (selectedIndex > 0)
            {
                rol = RolesDAL.GetRol(int.Parse(cbRol.Text));
                txtRol.Text = rol.nombre_rol;
            }
        }
    }
}
