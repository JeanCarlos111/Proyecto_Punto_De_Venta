using BackEnd.DAL.Proveedor;
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

namespace FrontEnd.Administracion
{
    public partial class FrmProveedor : Form
    {
        private IProveedorDAL proveedorDAL = new ProveedorDALImpl();
        private List<Provedor> provedor = new List<Provedor>();

        public FrmProveedor()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void llenarTabla()
        {
            try
            {
                provedor = proveedorDAL.GetProveedores();

                lsvProveedor.View = View.Details;
                lsvProveedor.Focus();
                lsvProveedor.FullRowSelect = true;
                foreach (var item in provedor)
                {
                    ListViewItem itemAgregar = new ListViewItem();
                    itemAgregar.Text = Convert.ToString(item.id_provedor);
                    itemAgregar.SubItems.Add(item.nombre_provedor);
                    itemAgregar.SubItems.Add(item.direccion_provedor);
                    itemAgregar.SubItems.Add(item.correo_provedor);
                    lsvProveedor.Items.Add(itemAgregar);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int cantidadActual = proveedorDAL.GetProveedores().Count;
            int cantidadNueva = cantidadActual + 1;
            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtCorreo.Text) &&
                   !String.IsNullOrEmpty(txtDireccion.Text) )
                {
                    Provedor provedor = new Provedor();
                    provedor.id_provedor = cantidadNueva;
                    provedor.nombre_provedor = txtNombre.Text;
                    provedor.direccion_provedor = txtDireccion.Text;
                    provedor.correo_provedor = txtCorreo.Text;
                    provedor.tipo_provedor = "Varios";
                    proveedorDAL.AddProveedor(provedor);

                    MessageBox.Show("Proveedor insertado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.Show();
            this.Hide();
        }

        private void provedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor frmProveedor = new FrmProveedor();
            frmProveedor.Show();
            this.Hide();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaProductos frmProdcutos = new VistaProductos();
            frmProdcutos.Show();
            this.Hide();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaFacturas frmFacturas = new VistaFacturas();
            frmFacturas.Show();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtCorreo.Text) &&
                   !String.IsNullOrEmpty(txtDireccion.Text))
                {
                    Provedor provedor = new Provedor();
                    provedor.id_provedor = int.Parse(lblID.Text);
                    provedor.nombre_provedor = txtNombre.Text;
                    provedor.direccion_provedor = txtDireccion.Text;
                    provedor.correo_provedor = txtCorreo.Text;
                    provedor.tipo_provedor = "Varios";
                    proveedorDAL.UpdateProveedor(provedor);

                    MessageBox.Show("Proveedor Modificado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            lblID.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
          

            try
            {
                if (!String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtCorreo.Text) &&
                   !String.IsNullOrEmpty(txtDireccion.Text))
                {
                    proveedorDAL.DeleteProveedor(txtNombre.Text);
                    MessageBox.Show("Proveedor Eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lsvProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvProveedor.SelectedItems.Count > 0)
            {
                ListViewItem listItem = lsvProveedor.SelectedItems[0];
                lblID.Text = listItem.Text;
                txtNombre.Text = listItem.SubItems[1].Text;
                txtCorreo.Text = listItem.SubItems[3].Text;
                txtDireccion.Text = listItem.SubItems[2].Text;
            }
        }
    }
}
