namespace FrontEnd
{
    partial class VistaReporteFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sp_mostrar_FacturasIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FacturaDataSet = new FrontEnd.FacturaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_mostrar_FacturasIDTableAdapter = new FrontEnd.FacturaDataSetTableAdapters.sp_mostrar_FacturasIDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_mostrar_FacturasIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_mostrar_FacturasIDBindingSource
            // 
            this.sp_mostrar_FacturasIDBindingSource.DataMember = "sp_mostrar_FacturasID";
            this.sp_mostrar_FacturasIDBindingSource.DataSource = this.FacturaDataSet;
            // 
            // FacturaDataSet
            // 
            this.FacturaDataSet.DataSetName = "FacturaDataSet";
            this.FacturaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_mostrar_FacturasIDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FrontEnd.Reportes.ReporteFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1254, 659);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_mostrar_FacturasIDTableAdapter
            // 
            this.sp_mostrar_FacturasIDTableAdapter.ClearBeforeFill = true;
            // 
            // VistaReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 659);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VistaReporteFactura";
            this.Text = "Reporte Factura";
            this.Load += new System.EventHandler(this.ReporteFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_mostrar_FacturasIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacturaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_mostrar_FacturasIDBindingSource;
        private FacturaDataSet FacturaDataSet;
        private FacturaDataSetTableAdapters.sp_mostrar_FacturasIDTableAdapter sp_mostrar_FacturasIDTableAdapter;
    }
}