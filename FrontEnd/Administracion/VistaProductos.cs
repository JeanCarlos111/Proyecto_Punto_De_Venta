using BackEnd.DAL.Categorias;
using BackEnd.DAL.Privilegio;
using BackEnd.DAL.ProdProveedor;
using BackEnd.DAL.Productos;
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
    public partial class VistaProductos : Form
    {
        private IProductosDAL productoDAL = new ProductosDALImpl();
        private ICategoriasDAL categoriasDAL = new CategoriasDALImpl();
        private IProdProveedorDAL prodProveedorDAL = new ProdProveedorDALImpl();
        private IProveedorDAL proveedorDAL = new ProveedorDALImpl();
        private List<Producto> productos = new List<Producto>();
        private List<Categoria> categorias = new List<Categoria>();
        private List<ProdProvedor> prodprovedor = new List<ProdProvedor>();
        public VistaProductos()
        {     
            InitializeComponent();
            llenarTabla();
            LlenarComboBox();
            LlenarComboBox2();
        }

        private void llenarTabla() {
            try
            {
                productos = productoDAL.GetProductos();

                listView1.View = View.Details;
                listView1.Focus();
                listView1.FullRowSelect = true;
                foreach (var item in productos)
                {
                    ListViewItem itemAgregar = new ListViewItem();
                    itemAgregar.Text = Convert.ToString(item.id_producto);
                    itemAgregar.SubItems.Add(item.nombre_producto);
                    itemAgregar.SubItems.Add(Convert.ToString(item.id_categoria));
                    itemAgregar.SubItems.Add(Convert.ToString(item.precio_producto));
                    itemAgregar.SubItems.Add(Convert.ToString(item.id_prodprovedor));
                    itemAgregar.SubItems.Add(Convert.ToString(item.costo_producto));
                    itemAgregar.SubItems.Add(Convert.ToString(item.cantidad));
                    listView1.Items.Add(itemAgregar);

                }
            } catch (Exception ex) {
                throw new Exception("Error:"+ex);
            }
        }

        private void LlenarComboBox() {
            try
            {
              categorias = categoriasDAL.GetCategorias();
              foreach (var item in categorias)
              {
              comboBox1.Items.Add(item.id_categoria);
              }
            }
            catch (Exception ex )
            {
             throw new Exception("Error:"+ex);
            }
        }
        private void LlenarComboBox2()
        {
            try
            {
                prodprovedor = prodProveedorDAL.GetProdProveedores();
                foreach (var item in prodprovedor)
                {
                    comboBox2.Items.Add(item.id_prodprovedor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int cantidadActual = productoDAL.GetProductos().Count;
            int cantidadNueva = cantidadActual+1;
           try
            {

                if (!String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox6.Text) && !String.IsNullOrEmpty(textBox7.Text))
                {
                    Producto producto = new Producto();
                    producto.id_producto = cantidadNueva;
                    producto.nombre_producto = textBox2.Text;
                    producto.id_categoria = int.Parse(comboBox1.Text);
                    producto.precio_producto = int.Parse(textBox4.Text);
                    producto.id_prodprovedor = int.Parse(comboBox2.Text);
                    producto.costo_producto = int.Parse(textBox6.Text);
                    producto.cantidad = int.Parse(textBox7.Text);
                    productoDAL.AddProducto(producto);

                    MessageBox.Show("Producto Insertado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
             throw new Exception("Error:"+ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(textBox6.Text)&& !String.IsNullOrEmpty(textBox7.Text))
                {
                    Producto producto = new Producto();
                    producto.id_producto = int.Parse(textBox1.Text);
                    producto.nombre_producto = textBox2.Text;
                    producto.id_categoria = int.Parse(comboBox1.Text);
                    producto.precio_producto = int.Parse(textBox4.Text);
                    producto.id_prodprovedor = int.Parse(comboBox2.Text);
                    producto.costo_producto = int.Parse(textBox6.Text);
                    producto.cantidad = int.Parse(textBox7.Text);
                    productoDAL.UpdateProducto(producto);

                    MessageBox.Show("Producto Actualizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    productoDAL.DeleteProducto(int.Parse(textBox1.Text));
                    MessageBox.Show("Producto Eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
             throw new Exception("Error:"+ex);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria categoria;
            ProdProvedor prodprovedor;
            Provedor provedor;
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem listItem = listView1.SelectedItems[0];
                textBox1.Text = listItem.Text;
                textBox2.Text = listItem.SubItems[1].Text;
                comboBox1.Text=listItem.SubItems[2].Text;
                textBox4.Text = listItem.SubItems[3].Text;
                comboBox2.Text = listItem.SubItems[4].Text;
                textBox6.Text = listItem.SubItems[5].Text;
                textBox7.Text = listItem.SubItems[6].Text;

                categoria = categoriasDAL.GetCategoria(int.Parse(comboBox1.Text));
                prodprovedor = prodProveedorDAL.GetProdProveedor(int.Parse(comboBox2.Text));
                provedor = proveedorDAL.GetProveedor(prodprovedor.id_provedor);
                textBox3.Text=categoria.nombre_categoria;
                textBox5.Text = provedor.nombre_provedor;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria categoria;
            int selectedIndex = comboBox1.SelectedIndex;
            if (selectedIndex > 0)
            { 
              categoria = categoriasDAL.GetCategoria(int.Parse(comboBox1.Text));
              textBox3.Text = categoria.nombre_categoria;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Provedor provedor;
            int selectedIndex = comboBox2.SelectedIndex;
            if (selectedIndex > 0)
            {
                provedor = proveedorDAL.GetProveedor(int.Parse(comboBox2.Text));
                textBox5.Text = provedor.nombre_provedor;
            }
        }

        private void LimpiarCampos() {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VistaReporteProducto vistaReporteProducto = new VistaReporteProducto();
            vistaReporteProducto.ShowDialog();
        }
    }
}
