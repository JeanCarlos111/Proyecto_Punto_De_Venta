using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Productos
{
    public interface IProductosDAL : IDisposable
    {
        void AddProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(int idProducto);

        Producto GetProducto(int idProducto);
        List<Producto> GetProductos();
        List<Producto> GetProducto(String nombre);
        List<Producto> spMostrar();
    }
}
