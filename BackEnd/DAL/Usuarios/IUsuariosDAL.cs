using BackEnd.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL.Usuarios
{
    public interface IUsuariosDAL : IDisposable
    {
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id_usuario);

        Usuario GetUsuario(string nombre);
        Usuario GetUsuarioById(int id);
        Usuario GetUsuarioID(int nombre);
        List<Usuario> GetUsuarios();
        Usuario InicioSesion(string nombre);
    }
}
