using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;


namespace BackEnd.DAL.Bitacora
{
    public class BitacoraDALImpl : IBitacoraDAL
    {
        private BDContext context;

        public void AddBitacora(BackEnd.ENTITIES.Bitacora bitacora)
        {
            using (context = new BDContext())
            {
                context.Bitacora.Add(bitacora);
                context.SaveChanges();
            }
        }

        public void DeleteBitacora(int id_bitacora)
        {
            using (context = new BDContext())
            {
                BackEnd.ENTITIES.Bitacora bitacora;
                bitacora = (from c in context.Bitacora
                             where c.id_bitacora == id_bitacora
                             select c).Single();
                context.Bitacora.Remove(bitacora);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public BackEnd.ENTITIES.Bitacora GetBitacora(int id_Bitacora)
        {
            BackEnd.ENTITIES.Bitacora result;
            using (context = new BDContext())
            {
                result = (from c in context.Bitacora
                          where c.id_bitacora == id_Bitacora
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<BackEnd.ENTITIES.Bitacora> GetBitacoraPorFecha(string fecha)
        {
            List<BackEnd.ENTITIES.Bitacora> result;
            using (context = new BDContext())
            {
                 result = (from c in context.Bitacora
                          where c.fecha == fecha
                          select c).ToList();
            }
            return result;
        }

        public List<BackEnd.ENTITIES.Bitacora> GetBitacoras()
        {
            List<BackEnd.ENTITIES.Bitacora> result;
            using (context = new BDContext())
            {
                result = (from c in context.Bitacora
                          select c).ToList();
            }
            return result;
        }

        public void UpdateBitacora(BackEnd.ENTITIES.Bitacora bitacora)
        {
            using (context = new BDContext())
            {
                context.Entry(bitacora).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
