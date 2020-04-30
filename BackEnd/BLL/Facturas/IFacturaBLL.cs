using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.BLL.Factura
{
    public interface IFacturaBLL
    {
        void AddFactura(ENTITIES.Factura factura);
        void UpdateFactura(ENTITIES.Factura factura);
        void DeleteFactura(int idfactura);
        int obtenerUltimoId();

        ENTITIES.Factura GetFactura(int idfactura);
        List<ENTITIES.Factura> GetFacturas();
        List<ENTITIES.Factura> GetFacturaUsuario(int id_usuario);
    }
}
