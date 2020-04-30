using BackEnd.BLL.Factura;
using BackEnd.DAL.Productos;
using BackEnd.ENTITIES;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Cliente
{
    public partial class Agregar : Form
    {
        IFacturaBLL facturaBLL = new FacturaBLLImpl();
        IProductosDAL productoDAL = new ProductosDALImpl();

        public static List<Producto> temporal = new List<Producto>();
        Factura factura = new Factura();
        Producto producto = new Producto();
        int idus;

        public Agregar(int id)
        {
            InitializeComponent();
            llenar();
            idus = id;
        }



        private void llenar()
        {
            temporal = Catalogo.carrito;

            
            listView1.View = View.Details;
            listView1.FullRowSelect = true;



            foreach (var item in temporal)
            {
                ListViewItem itemAgregar = new ListViewItem();
                itemAgregar.Text = Convert.ToString(item.cantidad);
                itemAgregar.SubItems.Add(Convert.ToString(item.id_producto));
                itemAgregar.SubItems.Add(item.nombre_producto);
                itemAgregar.SubItems.Add(Convert.ToString(item.precio_producto));
                listView1.Items.Add(itemAgregar);

            }
        }


        
        private void btnCantidad_Click(object sender, EventArgs e)
        {
          //  ListViewItem item = new ListViewItem(txtCant.Text);   
           // listView1.Items.Add(item);
            
        }

        string cat,Id, Nm, pr;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem listItem = listView1.SelectedItems[0];
                cat = listItem.Text;
                Id = listItem.SubItems[1].Text;
                Nm = listItem.SubItems[2].Text;
                pr = listItem.SubItems[3].Text;
               
                lblprueba.Text = Id;
               

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Catalogo catalogo = new Catalogo(idus);
            catalogo.Show();
            this.Hide();
        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
           
            
        }

       

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        Producto producto;


        ListViewItem listItem = listView1.SelectedItems[0];
        lblprueba.Text = listItem.SubItems[1].Text;

        listItem.SubItems[0].Text = txtPrecio.Text;

        producto = temporal.Find(x => x.id_producto == Convert.ToInt32(lblprueba.Text));
      //  temporal.RemoveAll(x => x.id_producto == Convert.ToInt32(lblprueba.Text));
            temporal.Remove(producto);

            listItem.SubItems[1].Text = "";
            listItem.SubItems[2].Text = "";
            listItem.SubItems[3].Text = "";

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            foreach (var item in temporal)
            {
                producto = productoDAL.GetProducto(item.id_producto);
                producto.cantidad -= item.cantidad;

                productoDAL.UpdateProducto(producto);

                factura.cantidad += item.cantidad;
                factura.total += item.precio_producto;
                
            }
            factura.id_producto = 1;
            factura.id_factura = facturaBLL.obtenerUltimoId();
            factura.fecha_factura = DateTime.Today.ToShortDateString();
            factura.id_usuario = idus;

            facturaBLL.AddFactura(factura);

            FrontEnd.Cliente.Facturacion.Facturacion frmFacturar = new FrontEnd.Cliente.Facturacion.Facturacion(temporal, idus);
            frmFacturar.Show();
            this.Hide();
            temporal.Clear();
        }

        private void Agregar_Load(object sender, EventArgs e)
        {

        }

        public static string cambio = "";
        public static int comp;


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto producto;


                ListViewItem listItem = listView1.SelectedItems[0];
                lblprueba.Text = listItem.SubItems[1].Text;

                listItem.SubItems[0].Text = txtPrecio.Text;

                producto = temporal.Find(x => x.id_producto == Convert.ToInt32(lblprueba.Text));
                producto.cantidad = int.Parse(txtPrecio.Text);
                temporal.RemoveAll(x => x.id_producto == Convert.ToInt32(lblprueba.Text));
                temporal.Add(producto);
                
                


                    


               /*     producto = temporal.Find(x => x.id_producto ==Convert.ToInt32( listItem.Text));
                    temporal.Remove( producto);
                    producto.cantidad = Int32.Parse(txtPrecio.Text);
                    temporal.Add(producto);

    */
                
                
            


          // listView1.SelectedItems[0].SubItems[0].Text = txtPrecio.Text;
           // comp = 1;
           // cambio = txtPrecio.Text;

        }
    }
}
