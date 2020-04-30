using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Roles
{
   public interface IRolesDAL:IDisposable
    {
        void AddRol(Rol rol);
        void UpdateRol(Rol rol);
        void DeleteRol(int id_Rol);

        Rol GetRol(int id_Rol);
        List<Rol> GetRoles();
        List<Rol> GetRol1(string nombre);
    }
}
