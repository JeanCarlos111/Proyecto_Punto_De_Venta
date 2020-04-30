using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.DAL.Categorias;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.Productos
{
    public class ProductosDALImpl : IProductosDAL
    {
        private ICategoriasDAL cateriasDAL = new CategoriasDALImpl();
        private BDContext context;

        public void AddProducto(Producto producto)
        {
            using (context = new BDContext())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
            }
        }

        public void DeleteProducto(int idProducto)
        {
            using (context = new BDContext())
            {
                Producto producto;
                producto = (from c in context.Producto
                             where c.id_producto == idProducto
                             select c).Single();
                context.Producto.Remove(producto);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Producto GetProducto(int idProducto)
        {
            Producto result;
            using (context = new BDContext())
            {
                result = (from c in context.Producto
                          where c.id_producto == idProducto
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<Producto> GetProducto(string nombre)
        {
            List<Producto> result;
            using (context = new BDContext())
            {
                result = (from c in context.Producto
                          where c.nombre_producto.Contains(nombre)
                          select c).ToList();
            }
            return result;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> result;
            using (context = new BDContext())
            {
                result = (from c in context.Producto
                          select c).ToList();
                
            }
            foreach (var item in result)
            {
                item.Categoria = cateriasDAL.GetCategoria(item.id_categoria);
            }
            return result;
        }

        public List<Producto> spMostrar()
        {
            List<Producto> productos = new List<Producto>();
            using (context = new BDContext())
            {
                productos = context.sp_mostrar_Productos1().ToList();

            }
           
            return productos;
        }

        public void UpdateProducto(Producto producto)
        {
            using (context = new BDContext())
            {
                context.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
