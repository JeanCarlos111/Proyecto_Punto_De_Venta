using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.Usuarios
{
    public class UsuariosDALImpl : IUsuariosDAL
    {
        private BDContext context;

        public void AddUsuario(Usuario usuario)
        {
            using (context = new BDContext())
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
            }
        }

        public void DeleteUsuario(int id_usuario)
        {
            using (context = new BDContext())
            {
                Usuario usuario;
                usuario = (from c in context.Usuario
                            where c.id_usuario == id_usuario
                            select c).FirstOrDefault();
                context.Usuario.Remove(usuario);
                context.SaveChanges();
            }
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(string nombre)
        {
            Usuario result;
            using (context = new BDContext())
            {
                result = (from u in context.Usuario
                          where u.nombre_usuario == nombre
                          select u).FirstOrDefault();
            }
            return result;
        }

        public Usuario GetUsuarioById(int id)
        {
            Usuario result;
            using (context = new BDContext())
            {
                result = (from u in context.Usuario
                          where u.id_usuario == id
                          select u).FirstOrDefault();
            }
            return result;
        }

        public Usuario GetUsuarioID(int nombre)
        {
            Usuario result;
            using (context = new BDContext())
            {
                result = (from u in context.Usuario
                          where u.id_usuario == nombre
                          select u).FirstOrDefault();
            }
            return result;
        }
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> result;
            using (context = new BDContext())
            {
                result = (from u in context.Usuario
                          select u).ToList();
            }
            return result;
        }

        public Usuario InicioSesion(string nombre)
        {
            try {

                using (context = new BDContext())
                {
                    Usuario result = context.so_iniciar_Sesion1(nombre).FirstOrDefault();
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return result = null;
                    }
                }

         } catch(Exception ex)
             {
                throw new Exception("Error:"+ex); ;
             }
            
        }

        public void UpdateUsuario(Usuario usuario)
        {
            using (context = new BDContext())
            {
                context.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
