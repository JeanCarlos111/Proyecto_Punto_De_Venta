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
using BackEnd.DAL.Usuarios;

namespace FrontEnd.Cliente.Facturacion
{
    public partial class Facturacion : Form
    {
        IUsuariosDAL usuarioDAL = new UsuariosDALImpl();
        List<Producto> lista = new List<Producto>();
        int total;
        int idus;
        Usuario usuario = new Usuario();

        public Facturacion(List<Producto> productos, int id)
        {
            InitializeComponent();
            lista = productos;
            idus = id;
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToLongDateString();


            foreach (Producto producto in lista)
            {

                this.dataGridView1.Rows.Insert(0, producto.nombre_producto, producto.precio_producto, producto.cantidad);
                total = total + producto.precio_producto;
            }
            lblTotal.Text = total.ToString();
            usuario = usuarioDAL.GetUsuarioById(idus);
            lblUsuario.Text = "Usuario: " + (usuario.nombre_usuario).ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Catalogo frmCatalogo = new Catalogo(idus);
            frmCatalogo.Show();
            this.Hide();
        }
    }
}
