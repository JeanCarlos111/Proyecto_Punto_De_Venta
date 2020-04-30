using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.Categorias
{
    public class CategoriasDALImpl : ICategoriasDAL
    {

        private BDContext context;

        public void AddCategoria(Categoria categoria)
        {
            using (context = new BDContext())
            {
                context.Categoria.Add(categoria);
                context.SaveChanges();
            }
        }

        public void DeleteCategoria(int idCategoria)
        {
            using (context = new BDContext())
            {
                Categoria categoria;
                categoria = (from c in context.Categoria
                              where c.id_categoria == idCategoria
                              select c).Single();
                context.Categoria.Remove(categoria);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Categoria GetCategoria(int idCategoria)
        {
            Categoria result;
            using (context = new BDContext())
            {
                result = (from c in context.Categoria
                          where c.id_categoria == idCategoria
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<Categoria> GetCategoria(string nombre)
        {
            List<Categoria> result;
            using (context = new BDContext())
            {
                result = (from c in context.Categoria
                          where c.nombre_categoria.Contains(nombre)
                          select c).ToList();
            }
            return result;
        }

        public List<Categoria> GetCategorias()
        {
            List<Categoria> result;
            using (context = new BDContext())
            {
                result = (from c in context.Categoria
                          select c).ToList();
            }
            return result;
        }

        public void UpdateCategoria(Categoria categoria)
        {
            using (context = new BDContext())
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
