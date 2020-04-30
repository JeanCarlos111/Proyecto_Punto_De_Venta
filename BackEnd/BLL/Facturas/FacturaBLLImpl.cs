using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.DAL.Facturas;
using BackEnd.ENTITIES;

namespace BackEnd.BLL.Factura
{
    public class FacturaBLLImpl : IFacturaBLL
    {
        IFacturasDAL facturaDAL = new FacturasDALImpl();



        public void AddFactura(ENTITIES.Factura factura)
        {
            facturaDAL.AddFactura(factura);
        }

        public void DeleteFactura(int idfactura)
        {
            facturaDAL.DeleteFactura(idfactura);
        }

        public ENTITIES.Factura GetFactura(int idfactura)
        {
           return facturaDAL.GetFactura(idfactura);
        }

        public List<ENTITIES.Factura> GetFacturas()
        {
            return facturaDAL.GetFacturas();
        }

        public List<ENTITIES.Factura> GetFacturaUsuario(int id_usuario)
        {
            return facturaDAL.GetFacturaUsuario(id_usuario);
        }

        public int obtenerUltimoId()
        {
            List<ENTITIES.Factura> facturas = new List<ENTITIES.Factura>();
            List<int> ids = new List<int>();
            facturas = facturaDAL.GetFacturas();

            foreach (ENTITIES.Factura fac in facturas)
            {
                ids.Add(fac.id_factura);
            }

            return ids.Max() + 1;
            
        }

        public void UpdateFactura(ENTITIES.Factura factura)
        {
            facturaDAL.UpdateFactura(factura);
        }
    }
}
