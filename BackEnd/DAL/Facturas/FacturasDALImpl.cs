using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;
 
namespace BackEnd.DAL.Facturas
{
    public class FacturasDALImpl : IFacturasDAL
    {
        private BDContext context;

        public void AddFactura(Factura factura)
        {
            using (context = new BDContext())
            {
                context.Factura.Add(factura);
                context.SaveChanges();
            }
        }

        public void DeleteFactura(int idfactura)
        {
            using (context = new BDContext())
            {
                Factura factura;
                factura = (from c in context.Factura
                             where c.id_factura == idfactura
                             select c).Single();
                context.Factura.Remove(factura);
                context.SaveChanges();
            }
        }

        public void UpdateFactura(Factura factura)
        {
            using (context = new BDContext())
            {
                context.Entry(factura).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Factura GetFactura(int idfactura)
        {
            Factura result;
            using (context = new BDContext())
            {
                result = (from c in context.Factura
                          where c.id_factura == idfactura
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<Factura> GetFacturaUsuario(int id_usuario)
        {
            List<Factura> result;
            using (context = new BDContext())
            {
                result = (from c in context.Factura
                          where c.id_usuario==id_usuario
                          select c).ToList();
            }
            return result;
        }

        public List<Factura> GetFacturas()
        {
            List<Factura> result;
            using (context = new BDContext())
            {
                result = (from c in context.Factura
                          select c).ToList();
            }
            return result;
        }
    }

}
