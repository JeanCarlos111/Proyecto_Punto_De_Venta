using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.DAL.Facturas;
using BackEnd.ENTITIES;

namespace PruebasProyecto
{
  
  [TestClass]
    public class TestFacturasDAL
    {
      #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddUsuario()
        {
            IFacturasDAL facturaDAL = new FacturasDALImpl();
            int cant = facturaDAL.GetFacturas().Count;

            Factura factura = new Factura();
            factura.id_factura = 1;
            factura.id_producto = 2;
            factura.id_usuario = 1;
            factura.total = 232432;
            factura.cantidad= 5;
            facturaDAL.AddFactura(factura);

            int cantNueva = facturaDAL.GetFacturas().Count;
            Assert.AreEqual(cant + 1, cantNueva);
        }

        [TestMethod]
        public void DeleteUsuario()
        {
            IFacturasDAL facturaDAL = new FacturasDALImpl();
           facturaDAL.DeleteFactura(1); 
        }

        [TestMethod]
        public void UpdateCategory()
        {
            IFacturasDAL facturaDAL = new FacturasDALImpl();
            Factura factura = facturaDAL.GetFactura(1);
            factura.id_usuario = 2;
            facturaDAL.UpdateFactura(factura);
        }
    }
    }


