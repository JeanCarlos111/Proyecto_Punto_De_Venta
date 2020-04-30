using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.Proveedor
{
    public interface IProveedorDAL : IDisposable
    {
        void AddProveedor(Provedor proveedor);

        void UpdateProveedor(Provedor proveedor);

        void DeleteProveedor(string nombre);

        Provedor GetProveedor(int nombre);

        List<Provedor> GetProveedores();
    }
}
