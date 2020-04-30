using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.Proveedor
{
    public class ProveedorDALImpl : IProveedorDAL
    {
        private BDContext context;
        public void AddProveedor(Provedor proveedor)
        {
            using (context = new BDContext())
            {
                context.Provedor.Add(proveedor);
                context.SaveChanges();
            }
        }

        public void DeleteProveedor(string nombre)
        {
            using (context = new BDContext())
            {
                using (context = new BDContext())
                {
                    Provedor provedor;
                    provedor = (from c in context.Provedor
                               where c.nombre_provedor == nombre
                               select c).Single();
                    context.Provedor.Remove(provedor);
                    context.SaveChanges();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Provedor GetProveedor(int nombre)
        {
            Provedor result;
            using (context = new BDContext())
            {
                result = (from p in context.Provedor
                          where p.id_provedor == nombre
                          select p).FirstOrDefault();
            }
            return result;
        }

        public List<Provedor> GetProveedores()
        {
            List<Provedor> result;
            using (context = new BDContext())
            {
                result = (from p in context.Provedor
                          select p).ToList();
            }
            return result;
        }

        public void UpdateProveedor(Provedor proveedor)
        {
            using (context = new BDContext())
            {
                context.Entry(proveedor).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
