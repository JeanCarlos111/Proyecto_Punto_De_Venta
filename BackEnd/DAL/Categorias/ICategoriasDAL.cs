using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Categorias
{
    public interface ICategoriasDAL : IDisposable
    {
        void AddCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        void DeleteCategoria(int idCategoria);

        Categoria GetCategoria(int idCategoria);
        List<Categoria> GetCategorias();
        List<Categoria> GetCategoria(String nombre);
    }
}
