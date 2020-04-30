using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Facturas
{
    public interface IFacturasDAL:IDisposable
    {
        void AddFactura(Factura factura);
        void UpdateFactura(Factura factura);
        void DeleteFactura(int idfactura);

        Factura GetFactura(int idfactura);
        List<Factura> GetFacturas();
        List<Factura> GetFacturaUsuario(int id_usuario);
    }
}
