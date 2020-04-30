using System;
using BackEnd.DAL.Usuarios;
using BackEnd.ENTITIES;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasProyecto
{
    [TestClass]
    public class TestUsuarioDAL
    {
        [TestMethod]
        public void AddUsuario()
        {
            IUsuariosDAL usuariosDAL = new UsuariosDALImpl();
            int cant = usuariosDAL.GetUsuarios().Count;

            Usuario usuario = new Usuario();
            usuario.nombre_usuario = "prueba";
            usuario.contrasena = "prueba";
            usuario.id_rol = 1;
            usuario.correo_usuario = "prueba";
            usuario.telefono_usuario = "prueba";
            usuario.direccion = "prueba";
            
            usuariosDAL.AddUsuario(usuario);

            int cantNueva = usuariosDAL.GetUsuarios().Count;
            Assert.AreEqual(cant + 1, cantNueva);
        }

        [TestMethod]
        public void DeleteUsuario()
        {
            IUsuariosDAL usuariosDAL = new UsuariosDALImpl();
            Usuario usuario = usuariosDAL.GetUsuario("mafe");
            usuariosDAL.DeleteUsuario(usuario.nombre_usuario);
        }

        [TestMethod]
        public void UpdateCategory()
        {
            IUsuariosDAL usuariosDAL = new UsuariosDALImpl();
            Usuario usuario = usuariosDAL.GetUsuario("Jemax111");
            usuario.nombre_usuario = "JEANK";
            usuariosDAL.UpdateUsuario(usuario);
        }
    }
}
