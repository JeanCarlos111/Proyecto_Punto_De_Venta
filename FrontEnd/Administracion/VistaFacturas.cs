using BackEnd.DAL.Facturas;
using BackEnd.DAL.Productos;
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

namespace FrontEnd.Administracion
{
    public partial class VistaFacturas : Form
    {
        private IFacturasDAL facturasDAL = new FacturasDALImpl();
        private IUsuariosDAL usuariosDAL = new UsuariosDALImpl();
        private IProductosDAL productosDAL = new ProductosDALImpl();
        private List<Factura> facturas = new List<Factura>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Producto> productos = new List<Producto>();
        public static int id;
        public VistaFacturas()
        {
            InitializeComponent();
            llenarTabla();
            llenarComboBox1();
            llenarComboBox2();
        }

        private void llenarTabla()
        {
            try
            {
                facturas = facturasDAL.GetFacturas();

                listView1.View = View.Details;
                listView1.Focus();
                listView1.FullRowSelect = true;
                foreach (var item in facturas)
                {
                    ListViewItem itemAgregar = new ListViewItem();
                    itemAgregar.Text = Convert.ToString(item.id_factura);
                    itemAgregar.SubItems.Add(Convert.ToString(item.id_usuario));
                    itemAgregar.SubItems.Add(Convert.ToString(item.fecha_factura));
                    itemAgregar.SubItems.Add(Convert.ToString(item.id_producto));
                    itemAgregar.SubItems.Add(Convert.ToString(item.cantidad));
                    itemAgregar.SubItems.Add(Convert.ToString(item.total));

                    listView1.Items.Add(itemAgregar);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }
        private void llenarComboBox1()
        {
            try
            {
                usuarios = usuariosDAL.GetUsuarios();
                foreach (var item in usuarios)
                {

                    comboBox1.Items.Add(item.id_usuario);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void llenarComboBox2()
        {
            try
            {
                productos = productosDAL.GetProductos();
                foreach (var item in productos)
                {

                    comboBox2.Items.Add(item.id_producto);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario;
            Producto producto;
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem listItem = listView1.SelectedItems[0];
                textBox1.Text = listItem.Text;
                comboBox1.Text= listItem.SubItems[1].Text;
                dateTimePicker2.Text = listItem.SubItems[2].Text;
                comboBox2.Text = listItem.SubItems[3].Text;
                textBox5.Text = listItem.SubItems[4].Text;
                textBox6.Text = listItem.SubItems[5].Text;

                usuario = usuariosDAL.GetUsuarioID(int.Parse(comboBox1.Text));
                producto = productosDAL.GetProducto(int.Parse(comboBox2.Text));
                textBox7.Text = usuario.nombre_usuario;
                textBox8.Text = producto.nombre_producto;

            }
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidadActual = facturasDAL.GetFacturas().Count;
            int cantidadNueva = facturasDAL.GetFacturas().Count + 1;

            try
            {
                if (!String.IsNullOrEmpty(textBox5.Text) && !(String.IsNullOrEmpty(textBox6.Text)))
                {
                    Factura factura = new Factura();
                    factura.id_factura = cantidadNueva;
                    factura.id_usuario = int.Parse(comboBox1.Text);
                    factura.fecha_factura = dateTimePicker2.Text;
                    factura.id_producto = int.Parse(comboBox2.Text);
                    factura.cantidad = int.Parse(textBox5.Text);
                    factura.total = int.Parse(textBox6.Text);
                    facturasDAL.AddFactura(factura);
                    MessageBox.Show("Factura Insertada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCampos();
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("No se permite espacion en blanco", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void LimpiarCampos()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            dateTimePicker2.Text = "";
            comboBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
                    }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox5.Text)&&!(String.IsNullOrEmpty(textBox6.Text)))
                {


                    Factura factura = new Factura();
                    factura.id_factura = int.Parse(textBox1.Text);
                    factura.id_usuario = int.Parse(comboBox1.Text);
                    factura.fecha_factura = dateTimePicker2.Text;
                    factura.id_producto = int.Parse(comboBox2.Text);
                    factura.cantidad = int.Parse(textBox5.Text);
                    factura.total = int.Parse(textBox6.Text);
                    facturasDAL.UpdateFactura(factura);

                    MessageBox.Show("Factura Actualizada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCampos();
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("No se permite espacion en blanco","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {

                    facturasDAL.DeleteFactura(int.Parse(textBox1.Text));
                    MessageBox.Show("Factura Eliminada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarCampos();
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("Escoga a un usuario del la lista para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VistaFacturas frmFactura = new VistaFacturas();
            frmFactura.Show();
            this.Hide();
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
            VistaProductos frmProductos = new VistaProductos();
            frmProductos.Show();
            this.Hide();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuario;
            int selectedIndex = comboBox1.SelectedIndex;
            if (selectedIndex > 0)
            {
                usuario =usuariosDAL.GetUsuarioID(int.Parse(comboBox1.Text));
                textBox7.Text = usuario.nombre_usuario;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto producto;
            int selectedIndex = comboBox2.SelectedIndex;
            if (selectedIndex > 0)
            {
                producto = productosDAL.GetProducto(int.Parse(comboBox2.Text));
                textBox8.Text = producto.nombre_producto;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VistaReporteFactura reporteFactura = new VistaReporteFactura(); ;
            reporteFactura.ShowDialog();
            
        }
    }
}
