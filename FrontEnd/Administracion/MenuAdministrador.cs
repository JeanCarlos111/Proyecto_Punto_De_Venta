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
    public partial class MenuAdministrador : Form
    {
        public MenuAdministrador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaFacturas vistaFacturas = new VistaFacturas();
            vistaFacturas.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VistaProductos vistaProductos = new VistaProductos();
            vistaProductos.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
