using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Roles
{
    public class RolesDALImpl:IRolesDAL
    {
        private BDContext context;

        public void AddRol(Rol rol)
        {
            using (context = new BDContext())
            {
                context.Rol.Add(rol);
                context.SaveChanges();
            }
        }

        public void DeleteRol(int id_Rol)
        {
            using (context = new BDContext())
            {
                Rol rol;
                rol = (from c in context.Rol
                       where c.id_rol == id_Rol
                       select c).Single();
                context.Rol.Remove(rol);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Rol GetRol(int nombre)
        {
            Rol result;
            using (context = new BDContext())
            {
                result = (from c in context.Rol
                          where c.id_rol == nombre
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<Rol> GetRol1(string nombre)
        {
            List<Rol> result;
            using (context = new BDContext())
            {
                result = (from c in context.Rol
                          where c.nombre_rol.Contains(nombre)
                          select c).ToList();
            }
            return result;
        }

        public List<Rol> GetRoles()
        {
            List<Rol> result;
            using (context = new BDContext())
            {
                result = (from c in context.Rol
                          select c).ToList();
            }
            return result;
        }

        public void UpdateRol(Rol rol)
        {
            using (context = new BDContext())
            {
                context.Entry(rol).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

