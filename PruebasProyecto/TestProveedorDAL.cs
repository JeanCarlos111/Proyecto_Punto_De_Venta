using System;
using BackEnd.DAL.Proveedor;
using BackEnd.ENTITIES;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasProyecto
{
    [TestClass]
    public class TestProveedorDAL
    {
        [TestMethod]
        public void AddProveedor()
        {
            IProveedorDAL proveedorDAL = new ProveedorDALImpl();
            int cant = proveedorDAL.GetProveedores().Count;

            Provedor provedor = new Provedor();
            provedor.correo_provedor = "Prueba";
            provedor.id_provedor = 99;
            provedor.nombre_provedor = "Prueba";
            provedor.direccion_provedor = "Prueba";
            provedor.tipo_provedor = "Prueba";

            proveedorDAL.AddProveedor(provedor);

            int cantNueva = proveedorDAL.GetProveedores().Count;
            Assert.AreEqual(cant + 1, cantNueva);
        }

        [TestMethod]
        public void DeleteProveedor()
        {
            IProveedorDAL proveedorDAL = new ProveedorDALImpl();
            Provedor provedor = proveedorDAL.GetProveedor(1);
            proveedorDAL.DeleteProveedor(provedor.nombre_provedor);
        }

        [TestMethod]
        public void UpdateProveedor()
        {
            IProveedorDAL proveedorDAL = new ProveedorDALImpl();
            Provedor provedor = proveedorDAL.GetProveedor(1);
            provedor.nombre_provedor = "Prueba";
            proveedorDAL.UpdateProveedor(provedor);
        }
    }
}
