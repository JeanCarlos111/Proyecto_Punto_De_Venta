using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.DAL.Usuarios;
using BackEnd.ENTITIES;

namespace BackEnd.BLL.Usuarios
{
    public class UsuariosBLLImpl : IUsuariosBLL
    {
        private IUsuariosDAL usuariosDAL;

        public bool AddUsuario(Usuario usuario)
        {
            usuariosDAL = new UsuariosDALImpl();
            usuario.contrasena = Encriptador.Encrypt(usuario.contrasena, true);
            usuariosDAL.AddUsuario(usuario);
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
