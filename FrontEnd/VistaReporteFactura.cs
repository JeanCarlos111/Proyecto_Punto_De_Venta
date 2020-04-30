using FrontEnd.Administracion;
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
    public partial class VistaReporteFactura : Form
    {
        public VistaReporteFactura()
        {
            InitializeComponent();
        }

        private void ReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'FacturaDataSet.sp_mostrar_FacturasID' Puede moverla o quitarla según sea necesario.
            this.sp_mostrar_FacturasIDTableAdapter.Fill(this.FacturaDataSet.sp_mostrar_FacturasID,VistaFacturas.id);

            this.reportViewer1.RefreshReport();
        }
    }
}
