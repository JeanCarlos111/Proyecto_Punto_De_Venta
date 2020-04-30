using System;
using BackEnd.DAL.Facturas;
using BackEnd.DAL.Privilegio;
using BackEnd.ENTITIES;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasProyecto
{
    [TestClass]
    public class TestPrivilegioDAL
    {
        [TestMethod]
      
        public void AddPrivilegio()
            {
                IPrivilegiosDAL privilegiosDAL = new PrivilegiosDALImpl();
                int cant = privilegiosDAL.GetPrivilegios().Count;

               Privilegios privilegios = new Privilegios();
               privilegios.id_privilegio = 4;
               privilegios.nombre_privilegio = "Prueba";

               privilegiosDAL.AddPrivilegio(privilegios);

                int cantNueva = privilegiosDAL.GetPrivilegios().Count;
                Assert.AreEqual(cant + 1, cantNueva);
            }

        [TestMethod]
        public void DeletePrivilegio()
        {
            IPrivilegiosDAL privilegiosDAL = new PrivilegiosDALImpl();
            privilegiosDAL.DeletePrivilegio(4);
        }

        [TestMethod]
        public void UpdatePrivilegio()
        {
            IPrivilegiosDAL privilegiosDAL = new PrivilegiosDALImpl();
            Privilegios privilegios = privilegiosDAL.Privilegio(1);
            privilegios.nombre_privilegio="PRUEBA";
            privilegiosDAL.UpdatePrivilegio(privilegios);
        }
    }
    }

