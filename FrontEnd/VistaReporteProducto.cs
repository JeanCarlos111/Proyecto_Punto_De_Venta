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
    public partial class VistaReporteProducto : Form
    {
        public VistaReporteProducto()
        {
            InitializeComponent();
        }

        private void VistaReporteProducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ProyectoDataSet.Producto' Puede moverla o quitarla según sea necesario.
            this.ProductoTableAdapter.Fill(this.ProyectoDataSet.Producto);

            this.reportViewer1.RefreshReport();
        }
    }
}
