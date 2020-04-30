namespace FrontEnd.Cliente
{
    partial class Catalogo
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
            this.LVCatalogo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAgregarPro = new System.Windows.Forms.Button();
            this.btnCarrito = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LVCatalogo
            // 
            this.LVCatalogo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader7});
            this.LVCatalogo.Location = new System.Drawing.Point(33, 156);
            this.LVCatalogo.Margin = new System.Windows.Forms.Padding(6);
            this.LVCatalogo.Name = "LVCatalogo";
            this.LVCatalogo.Size = new System.Drawing.Size(974, 664);
            this.LVCatalogo.TabIndex = 0;
            this.LVCatalogo.UseCompatibleStateImageBehavior = false;
            this.LVCatalogo.View = System.Windows.Forms.View.Details;
            this.LVCatalogo.SelectedIndexChanged += new System.EventHandler(this.LVCatalogo_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID ";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nombre";
            this.columnHeader2.Width = 190;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Precio";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Cantidad";
            // 
            // btnAgregarPro
            // 
            this.btnAgregarPro.Location = new System.Drawing.Point(1100, 288);
            this.btnAgregarPro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarPro.Name = "btnAgregarPro";
            this.btnAgregarPro.Size = new System.Drawing.Size(196, 68);
            this.btnAgregarPro.TabIndex = 2;
            this.btnAgregarPro.Text = "Agregar";
            this.btnAgregarPro.UseVisualStyleBackColor = true;
            this.btnAgregarPro.Click += new System.EventHandler(this.btnAgregarPro_Click);
            // 
            // btnCarrito
            // 
            this.btnCarrito.Location = new System.Drawing.Point(1100, 204);
            this.btnCarrito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCarrito.Name = "btnCarrito";
            this.btnCarrito.Size = new System.Drawing.Size(196, 65);
            this.btnCarrito.TabIndex = 5;
            this.btnCarrito.Text = "Carrito de Compras";
            this.btnCarrito.UseVisualStyleBackColor = true;
            this.btnCarrito.Click += new System.EventHandler(this.btnCarrito_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 51);
            this.label1.TabIndex = 6;
            this.label1.Text = "Catalogo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrontEnd.Properties.Resources.cesta_de_la_compra__1_;
            this.pictureBox1.Location = new System.Drawing.Point(1114, 479);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 201);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Catalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 917);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCarrito);
            this.Controls.Add(this.btnAgregarPro);
            this.Controls.Add(this.LVCatalogo);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Catalogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo";
            this.Load += new System.EventHandler(this.Catalogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LVCatalogo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnAgregarPro;
        private System.Windows.Forms.Button btnCarrito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}