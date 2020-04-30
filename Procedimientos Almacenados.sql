---Procedimientos almacenados:
----Guia 
USE [tienda];
go
CREATE PROCEDURE sp_actualizar_Categoria  
(@id int , @nombre varchar(100))as
begin
update Categoria set nombre_categoria=@nombre
where id_categoria=@id;
end;

go
CREATE PROCEDURE sp_actualizar_Factura( @usuario int,@fecha varchar(100) ,@producto int 
,@cantidad int  ,@total int)as
begin
update Factura set  fecha_factura=@fecha,id_producto=@producto ,cantidad=@cantidad,total=@total
where id_usuario=@usuario;
end;

go
CREATE  PROCEDURE sp_actualizar_Producto ( @id_producto int,@nombre varchar (100),
@categoria int ,@precio int  ,@proveedor int, @costo int ,@cantidad int )as
begin

update Producto set nombre_producto=@nombre ,id_categoria=@categoria ,precio_producto=@precio,
        id_prodProvedor=@proveedor,costo_producto=@costo, cantidad= @cantidad
        where id_producto=@id_producto;
end;

go
CREATE PROCEDURE sp_actualizar_Proveedor ( @id int , @nombre varchar (45),@dirreccion varchar(100) 
,@correo varchar(100)   ,@tipo varchar(100))as
begin

update Provedor set nombre_provedor=@nombre ,direccion_provedor=@dirreccion,
        correo_provedor=@correo,tipo_provedor=@tipo
        where id_provedor=@id;
end;

go
CREATE PROCEDURE sp_actualizar_Usuario (@id int , @nombre varchar (100),@pass varchar(100) 
,@rol int ,@correo varchar(100)  ,@telefono varchar(100),@dirreccion varchar(100))as
begin

update Usuario set nombre_usuario=@nombre ,contrasena=@pass,
        id_usuario=@rol,correo_usuario=@correo,telefono_usuario=@telefono,direccion=@dirreccion
        where id_usuario=@id;
end;

go
CREATE PROCEDURE so_eliminar_Categoria(@id int)as
begin
delete  from Categoria where id_categoria=@id;
end;

go
CREATE PROCEDURE sp_eliminar_Factura(@id int)as
begin
delete  from Factura where id_usuario=@id;
end;

go
CREATE PROCEDURE sp_eliminar_Producto(@id_producto int)as
begin
delete  from Producto where id_producto=@id_producto;
end;

go
CREATE PROCEDURE sp_eliminar_Proveedor(@id int)as
begin

delete  from Provedor where id_provedor=@id;
end;

go
CREATE PROCEDURE sp_eliminar_Usuario( @id int)as
begin
delete  from Usuario where id_usuario=@id;
end;

go
CREATE PROCEDURE so_iniciar_Sesion(@usuario varchar(100))as
begin
SELECT id_usuario,nombre_usuario,correo_usuario,id_rol,contrasena FROM Usuario 
where nombre_usuario=@usuario;
end;

go
CREATE PROCEDURE sp_insertar_Categoria( @id int , @nombre varchar(100))as
begin
insert into Categoria(id_categoria,nombre_categoria)
values(@id,@nombre);
end;

go
CREATE PROCEDURE sp_insertar_Factura( @usuario int,@fecha varchar(100) ,@producto int 
,@cantidad int  ,@total int)as
begin
insert into Factura(id_usuario,fecha_factura,id_producto ,cantidad,total)
values(@usuario,@fecha,@producto,@cantidad,@total);
end;

go
CREATE PROCEDURE sp_insertar_Producto(@id_producto int,@nombre varchar (100),
@categoria int ,@precio int  ,@proveedor int, @costo int ,@cantidad int)as
begin
insert into Producto(id_producto,nombre_producto ,id_categoria , precio_producto,id_prodProvedor,
costo_producto,cantidad)values(@id_producto,@nombre,@categoria,@precio,@proveedor,@costo,@cantidad);
end;

go
CREATE PROCEDURE sp_insertar_Proveedor(@id int ,@nombre varchar (100),@dirreccion varchar(100) 
,@correo varchar(100)   ,@tipo varchar(100))as
begin

insert into Provedor (id_provedor,nombre_provedor ,direccion_provedor,
        correo_provedor,tipo_provedor) values(@id,@nombre,@dirreccion,@correo,@tipo);
      
end;

go
CREATE PROCEDURE sp_insertar_Usuario (@id int , @nombre varchar (100),@pass varchar(100) 
,@rol int ,@correo varchar(100)  ,@telefono varchar(100),@dirreccion varchar(100))as
begin

insert into Usuario (id_usuario,nombre_usuario,contrasena,id_rol,correo_usuario
        ,telefono_usuario,direccion) values(@id,@nombre,@pass,@rol,@correo,@telefono,@dirreccion);
      
end;

go
CREATE PROCEDURE sp_mostrar_Categorias as
begin
SELECT* from Categoria;
end;

go
CREATE PROCEDURE so_mostrar_CategoriasID(@id int)as
begin
SELECT* from Categoria where id_categoria=@id;
end;

go
CREATE PROCEDURE sp_mostrar_Factura as
begin
SELECT* from Factura;
end;

go
CREATE PROCEDURE sp_mostrar_FacturasID(@id int)as
begin
SELECT* from Factura where id_usuario=@id;
end;

go
CREATE PROCEDURE sp_mostrar_Productos as
begin
select * from Producto;
end;

go
CREATE PROCEDURE sp_mostrar_ProductosCategoria(@producto int)as
begin
select * from Producto where id_categoria=@producto;
end;

go
CREATE PROCEDURE sp_mostrar_ProductosID(@producto int)as
begin
select * from Producto where id_producto=@producto;
end;

go
CREATE PROCEDURE sp_mostrar_ProdProveedor as
begin
SELECT* from ProdProvedor;
end;

go
CREATE PROCEDURE sp_mostrar_Proveedor as
begin
SELECT* from Provedor;
end;

go
CREATE PROCEDURE sp_mostrar_ProveedorID(@id int)as
begin
SELECT* from Provedor where id_provedor=@id;
end;

go
CREATE PROCEDURE sp_mostrar_Usuario as
begin
SELECT* from Usuario;
end;

go
CREATE PROCEDURE sp_mostrar_UsuarioID(@id int)as
begin
SELECT* from Usuario where id_usuario=@id;
end;


