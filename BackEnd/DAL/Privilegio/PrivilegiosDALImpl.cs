using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.Privilegio
{
    public class PrivilegiosDALImpl : IPrivilegiosDAL
    {
        private BDContext context;
        public void AddPrivilegio(Privilegios privilegios)
        {
            using (context = new BDContext())
            {
                context.Privilegios.Add(privilegios);
                context.SaveChanges();
            }
        }

        public void DeletePrivilegio(int idprivilegio)
        {
            using (context = new BDContext())
            {
                Privilegios privilegios;
                privilegios = (from c in context.Privilegios
                           where c.id_privilegio == idprivilegio
                           select c).Single();
                context.Privilegios.Remove(privilegios);
                context.SaveChanges();
            }
        }

        public void UpdatePrivilegio(Privilegios privilegios)
        {
            using (context = new BDContext())
            {
                context.Entry(privilegios).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Privilegios> GetPrivilegios()
        {
            List<Privilegios> result;
            using (context = new BDContext())
            {
                result = (from c in context.Privilegios
                          select c).ToList();
            }
            return result;
        }

        public Privilegios Privilegio(int idprivilegio)
        {
            Privilegios result;
            using (context = new BDContext())
            {
                result = (from c in context.Privilegios
                          where c.id_privilegio == idprivilegio
                          select c).FirstOrDefault();
            }
            return result;
        }

       
    }
}
