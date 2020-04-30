using System;
using BackEnd.DAL.Categorias;
using BackEnd.ENTITIES;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasProyecto
{
    [TestClass]
    public class TestCategoriaDAL
    {
        [TestMethod]
        public void AddCategoria()
        {
            ICategoriasDAL categoriasDAL = new CategoriasDALImpl();
            int cant = categoriasDAL.GetCategorias().Count;

            Categoria categoria = new Categoria();
            categoria.nombre_categoria = "prueba";

            categoriasDAL.AddCategoria(categoria);

            int cantNueva = categoriasDAL.GetCategorias().Count;
            Assert.AreEqual(cant + 1, cantNueva);
        }

        [TestMethod]
        public void DeleteCategory()
        {
            ICategoriasDAL categoriasDAL = new CategoriasDALImpl();
            categoriasDAL.DeleteCategoria(2);
        }

        [TestMethod]
        public void UpdateCategory()
        {
            ICategoriasDAL categoriasDAL = new CategoriasDALImpl();
            Categoria categoria = categoriasDAL.GetCategoria(3);
            categoria.nombre_categoria = "TEST";
            categoriasDAL.UpdateCategoria(categoria);
        }
    }
}
