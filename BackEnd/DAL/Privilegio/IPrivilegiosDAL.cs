using System;
using System.Collections.Generic;
using BackEnd.ENTITIES;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Privilegio
{
  public interface IPrivilegiosDAL:IDisposable
    {
        void AddPrivilegio(Privilegios privilegios);
        void UpdatePrivilegio(Privilegios privilegios);
        void DeletePrivilegio(int idprivilegio);

        Privilegios Privilegio(int idprivilegio);
        List<Privilegios> GetPrivilegios();
    }
}
