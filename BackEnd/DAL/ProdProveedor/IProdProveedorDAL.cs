using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.ProdProveedor
{
    public interface IProdProveedorDAL : IDisposable
    {
        void AddProdProveedor(ProdProvedor prodroveedor);

        void UpdateProdProveedor(ProdProvedor prodproveedor);

        void DeleteProdProveedor(int idprodproveedor);

        ProdProvedor GetProdProveedor(int idprodproveedor);

        List<ProdProvedor> GetProdProveedores();
    }
}
