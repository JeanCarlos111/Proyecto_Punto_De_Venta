using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.DAL.Productos;
using BackEnd.ENTITIES;

namespace PruebasProyecto
{
    [TestClass]
    public class TestProductosDAL
    {
        [TestMethod]
        public void AddProducto()
        {
            IProductosDAL productosDAL = new ProductosDALImpl();
            int cantidad = productosDAL.GetProductos().Count;

            Producto producto = new Producto();
            producto.nombre_producto = "Prueba";

            productosDAL.AddProducto(producto);

            int cantNueva = productosDAL.GetProductos().Count;
            Assert.AreEqual(cantidad + 1, cantNueva);
        }

        [TestMethod]
        public void DeleteProducto()
        {
            IProductosDAL productosDAL = new ProductosDALImpl();
            productosDAL.DeleteProducto(1);
        }

        [TestMethod]
        public void UpdateProducto()
        {
            IProductosDAL productosDAL = new ProductosDALImpl();
            Producto producto = productosDAL.GetProducto(3);
            producto.nombre_producto = "test";
            productosDAL.UpdateProducto(producto);
        }
    }
}
