using BackEnd.DAL.Productos;
using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;

namespace FrontEnd.Cliente
{
    public partial class Catalogo : Form
    {
     
        public static int idproducto ;
        public static int cantidad;
        public static List<Producto> carrito = new List<Producto>();
       
        private IProductosDAL productosDAL = new ProductosDALImpl();
        private List<Producto> productos;
        int idus;

        public Catalogo(int id)
        {
            InitializeComponent();
            CargarTabla();
            idus = id;
        }

        private void CargarTabla()
        {
            try
            {


                productos = productosDAL.spMostrar();

               
                LVCatalogo.View = View.Details;
                LVCatalogo.FullRowSelect = true;

                // Initialize the tile size.
                //LVCatalogo.TileSize = new Size(400, 45);

                foreach (var item in productos)
                {
                    ListViewItem itemAgregar = new ListViewItem();
                    itemAgregar.Text = Convert.ToString(item.id_producto);
                    itemAgregar.SubItems.Add(item.nombre_producto);
                   // itemAgregar.SubItems.Add(Convert.ToString(item.id_categoria));
                    itemAgregar.SubItems.Add(Convert.ToString(item.precio_producto));
                  //  itemAgregar.SubItems.Add(Convert.ToString(item.id_prodprovedor));
                 //   itemAgregar.SubItems.Add(Convert.ToString(item.costo_producto));
                    itemAgregar.SubItems.Add(Convert.ToString(item.cantidad));
                    LVCatalogo.Items.Add(itemAgregar);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex);
            }
        }
        

        private void btnAgregarPro_Click(object sender, EventArgs e)
        {
            guardarlista();


        }

        private void LVCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVCatalogo.SelectedItems.Count > 0)
            {
                ListViewItem listItem = LVCatalogo.SelectedItems[0];
                idproducto = int.Parse(listItem.Text);
                cantidad = int.Parse(listItem.SubItems[3].Text);

            }
        }


        private void Catalogo_Load(object sender, EventArgs e)
        {

        }

        

     

        public void guardarlista()
        {
            try
            {
              Producto producto;
                Producto producto2;

                //Mensaje para obtener la cantidad
                cantidad = int.Parse(Interaction.InputBox("Inserte cantidad del producto", "Cantidad", "", -1, -1));
                producto = productosDAL.GetProducto(idproducto);
                producto2 = productosDAL.GetProducto(idproducto);
                producto.cantidad = cantidad;
                if (producto2.cantidad >= cantidad)
                {
                    carrito.Add(producto);
                    MessageBox.Show("Se agregó al carrito", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else if(producto2.cantidad < cantidad){
                    MessageBox.Show("No hay suficientes productos en inventario", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch (Exception ex)
            {

                throw new Exception("Error:" + ex);
            }

        }



        private void btnCarrito_Click(object sender, EventArgs e)
        {
            Agregar frmAgregar = new Agregar(idus);
            frmAgregar.Show();
            this.Hide();
        }
    }
 }
