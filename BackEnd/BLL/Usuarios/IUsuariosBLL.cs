using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Usuarios
{
    public interface IUsuariosBLL : IDisposable
    {
        bool AddUsuario(Usuario usuario);
       
    }
}
