using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.ProdProveedor
{
    public class ProdProveedorDALImpl : IProdProveedorDAL
    {
        private BDContext context;

        public void AddProdProveedor(ProdProvedor prodproveedor)
        {
            using (context = new BDContext())
            {
                context.ProdProvedor.Add(prodproveedor);
                context.SaveChanges();
            }
        }

        public void DeleteProdProveedor(int idprodproveedor)
        {
            ProdProvedor prodProvedor = this.GetProdProveedor(idprodproveedor);
            using (context = new BDContext())
            {
                ProdProvedor prodproveedor;
                prodproveedor = (from c in context.ProdProvedor
                                 where c.id_prodprovedor == idprodproveedor
                                 select c).Single();
                context.ProdProvedor.Remove(prodproveedor);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ProdProvedor GetProdProveedor(int idprodproveedor)
        {
            ProdProvedor result;
            using (context = new BDContext())
            {
                result = (from c in context.ProdProvedor
                          where c.id_prodprovedor == idprodproveedor
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<ProdProvedor> GetProdProveedores()
        {
            List<ProdProvedor> result;
            using (context = new BDContext())
            {
                result = (from c in context.ProdProvedor
                          select c).ToList();
            }
            return result;
        }

        public void UpdateProdProveedor(ProdProvedor prodproveedor)
        {
            using (context = new BDContext())
            {
                context.Entry(prodproveedor).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
