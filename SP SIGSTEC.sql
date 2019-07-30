use SIGSTEC
go


CREATE PROCEDURE SP_REGISTRO_TECNICO @nombre varchar(128), @correo varchar(64), @identificacion varchar(13), @sector varchar(64), @alcance varchar(256)
as
begin
insert into persona (nombre, correo, identificacion) values (@nombre, @correo,@identificacion); 
insert into tecnico(idpersona, sector, alcance, estado, situacion) values((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @sector,@alcance,'DISPONIBLE', 'ACTIVO');
end
go

CREATE PROCEDURE SP_REGISTRO_TELEFONO_CONVENCIONAL1 @telefono varchar(10)
as
begin
insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL1');
end
go

CREATE PROCEDURE SP_REGISTRO_TELEFONO_CONVENCIONAL2 @telefono varchar(10)
as
begin
insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL2');
end
go

CREATE PROCEDURE SP_REGISTRO_TECNICO @nombre varchar(128), @correo varchar(64), @identificacion varchar(13), @sector varchar(64), @alcance varchar(256)
as
begin
insert into persona (nombre, correo, identificacion) values (@nombre, @correo,@identificacion); 
insert into tecnico(idpersona, sector, alcance, estado, situacion) values((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @sector,@alcance,'DISPONIBLE', 'ACTIVO');
end
go

CREATE PROCEDURE SP_REGISTRO_TELEFONO_CONVENCIONAL1 @telefono varchar(10)
as
begin
insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL1');
end
go

CREATE PROCEDURE SP_REGISTRO_TELEFONO_CONVENCIONAL2 @telefono varchar(10)
as
begin
insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL2');
end
go

create procedure SP_REGISTRO_CELULAR1 @telefono varchar(10)
as
begin
	insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona 
	where idpersona = (select max(idpersona) from persona)), @telefono,'CELULAR1');
end
go

create procedure SP_REGISTRO_CELULAR2 @telefono varchar(10)
as
begin
	insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona 
	where idpersona = (select max(idpersona) from persona)), @telefono,'CELULAR2');
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA;
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS_NOMBRE @nombre varchar(128)
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%'+@nombre+'%' order by t.sector;
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS_IDENTIFICACION @identificacion varchar(128)
as
begin
select t.estado, p.nombre, p.identificacion,  t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where p.identificacion like '%' + @identificacion + '%' order by t.sector;
end
go

CREATE PROCEDURE SP_REGISTRO_CASO @IDUSUARIO varchar(128), @IDTECNICO numeric, @IDCLIENTE numeric, @NUMERO varchar(16), @FECHA datetime, @SLA varchar(16), @INFORME_INICIAL varchar(2048), @SECTOR varchar(64)
as
begin
insert into caso(IDUSUARIO, IDTECNICO, IDCLIENTE, NUMERO, FECHA, SLA, INFORME_INICIAL, SECTOR, ESTADO, PARTE_PATH, INFORME_FINAL, NUMERO_FACTURA) 
values((select u.idusuario from usuario as u join persona as p on u.idpersona = p.idpersona where p.nombre like @IDUSUARIO), @IDTECNICO, @IDCLIENTE, @NUMERO, @FECHA, @SLA, @INFORME_INICIAL, @SECTOR, 'ABIERTO', 'No Asignado', 'No Asigando', 'No Asigando')
end
go

create procedure SP_SELECCION_TECNICO_PARA_CASO1 @IDCASO numeric 
as
begin 
select p.nombre from PERSONA as p join TECNICO as t on p.idpersona = t.idpersona join CASO as c on c.IDTECNICO = t.IDTECNICO where idcaso = @IDCASO
end
go

create procedure SP_SELECCION_TECNICO_PARA_CASO2 @IDCASO numeric 
as
begin 
select p.nombre from PERSONA as p join USUARIO as u on p.idpersona = u.idpersona join CASO as c on c.IDUSUARIO = u.IDUSUARIO where idcaso = @IDCASO
end
go

create procedure SP_LLENAR_TABLA_CASO 
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA WHERE c.estado = 'ABIERTO' order by c.estado
end
go

create procedure SP_BUSCAR_CASO_POR_NUMERO_DE_CASO @NUMERO varchar(16)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where c.numero like '%' + @NUMERO + '%' and c.estado = 'ABIERTO' order by c.estado
end
go

create PROCEDURE SP_BUSCAR_CASO_POR_NOMBRE @NOMBRE varchar(128)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where p.NOMBRE like '%' + @NOMBRE + '%' and c.estado = 'ABIERTO' order by c.estado
end
go

create procedure SP_BUSCAR_CASO_POR_CUENTA @CUENTA varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where cl.cuenta like '%' + @CUENTA + '%' and c.estado = 'ABIERTO' order by c.estado
end
go

create procedure SP_BUSCAR_CASO_POR_SECTOR @SECTOR varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where c.sector like '%' + @SECTOR + '%' and c.estado = 'ABIERTO' order by c.estado
end
go

create procedure SP_MUESTRA_BUSCAR_CASO_POR_NUMERO_DE_CASO @NUMERO varchar(16)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where c.numero like '%' + @NUMERO + '%' order by c.estado
end
go

create  procedure SP_MUESTRA_BUSCAR_CASO_POR_NOMBRE @NOMBRE varchar(128)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where p.NOMBRE like '%' + @NOMBRE + '%'  order by c.estado
end
go

create procedure SP_MUESTRA_BUSCAR_CASO_POR_CUENTA @CUENTA varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where cl.cuenta like '%' + @CUENTA + '%'order by c.estado
end
go

create procedure SP_MUESTRA_BUSCAR_CASO_POR_SECTOR @SECTOR varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where c.sector like '%' + @SECTOR + '%' order by c.estado
end
go

CREATE PROCEDURE SP_REGISTRO_PRODUCTO @codigo varchar(8), @descripcion varchar(1024), @cantidad int, @precio varchar(100)
as
begin
insert into producto (codigo,descripcion, cantidad, precio) values (@codigo,@descripcion,@cantidad,CAST(@precio AS FLOAT));
end
go

CREATE PROCEDURE SP_MUESTRA_PRODUCTO 
AS
BEGIN
select codigo, descripcion, cantidad, precio from producto;
END
GO

CREATE PROCEDURE SP_MUESTRA_PRODUCTO_CODIGO @codigo varchar(8)
AS
BEGIN
select codigo, descripcion, cantidad, precio from producto where codigo like '%' + @codigo + '%'; 
END
GO

CREATE PROCEDURE SP_MUESTRA_PRODUCTO_DESCRIPCION @descripcion varchar(1024)
AS
BEGIN
select codigo, descripcion, cantidad, precio from producto where descripcion like '%' + @descripcion + '%'; 
END
GO

CREATE PROCEDURE SP_AUMENTO_PRODUCTO @cantidad int, @codigo varchar(8)
AS
BEGIN
UPDATE PRODUCTO SET CANTIDAD = CANTIDAD + @cantidad where CODIGO = @codigo; 
END
GO

create procedure SP_MUESTRA_LLENAR_TABLA_CASO 
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA order by c.estado
end

---PROCEDURE CLIENTE
create procedure SP_REGISTRO_CLIENTE @nombre varchar(128), @correo varchar(64), @identificacion varchar(13), @nombre_contacto varchar(128), @descripcion_contacto varchar(256), @sla varchar(16), @cuenta varchar(64), @tipo_pago varchar(20), @tipo varchar(16)
as
begin
	insert into persona (nombre, correo, identificacion) values (@nombre, @correo,@identificacion);  
	insert into cliente ( idpersona, nombre_contacto, descripcion_contacto,sla,cuenta,tipo_pago, situacion, tipo) values ((select idpersona from persona 
	where idpersona = (select max(idpersona) from persona)), @nombre_contacto, @descripcion_contacto, @sla, @cuenta, @tipo_pago,'ACTIVO', @tipo);
end


---PROCEDURE TELEFONOS MOVILES
create procedure SP_REGISTRO_CELULAR1 @telefono varchar(10)
as
begin
	insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona 
	where idpersona = (select max(idpersona) from persona)), @telefono,'CELULAR1');
end

create procedure SP_REGISTRO_CELULAR2 @telefono varchar(10)
as
begin
	insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona 
	where idpersona = (select max(idpersona) from persona)), @telefono,'CELULAR2');
end

---PROCEDURE TELEFONOS CONVENCIONALES
CREATE PROCEDURE SP_REGISTRO_TELEFONO_CONVENCIONAL1 @telefono varchar(10)
as
begin
insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL1');
end
go

CREATE PROCEDURE SP_REGISTRO_TELEFONO_CONVENCIONAL2 @telefono varchar(10)
as
begin
insert into telefono (idpersona,telefono,tipo) values ((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @telefono,'CONVENCIONAL2');
end
go

---PROCEDURE DAR DE BAJA CLIENTE
CREATE PROCEDURE SP_DADO_DE_BAJA @identificacion varchar(10)
as
begin
update CLIENTE set situacion = 'INACTIVO' where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion)
end
go

---PROCEDURE DAR DE ALTA CLIENTE
CREATE PROCEDURE SP_DADO_DE_ALTA @identificacion varchar(10)
as
begin
update CLIENTE set situacion = 'ACTIVO' where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion)
end
go


---PROCEDURE MUESTRA DE CLIENTES DAR DE BAJA
CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_NOMBRE @NOMBRE VARCHAR(128)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla 
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.nombre like '%' + @NOMBRE + '%' AND c.SITUACION ='ACTIVO' order by c.tipo;
end
go

CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_CEDULA @CEDULA varchar(13)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.identificacion like '%'+ @CEDULA + '%'  and c.tipo = 'Persona' and c.SITUACION = 'ACTIVO' order by c.tipo;
end
go

CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_RUC @RUC varchar(13)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.identificacion like '%' + @RUC + '%'  and c.tipo = 'Empresa' and c.SITUACION = 'ACTIVO' order by c.tipo;
end
go

CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_CUENTA @CUENTA varchar(64)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where c.cuenta like '%' + @CUENTA + '%'  and c.tipo = 'Empresa' and c.SITUACION='ACTIVO' order by c.tipo;
end
go

---PROCEDURE MUESTRA DE CLIENTES DAR DE ALTA
CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_NOMBRE2 @NOMBRE VARCHAR(128)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla 
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.nombre like '%' + @NOMBRE + '%' AND c.SITUACION ='INACTIVO' order by c.tipo;
end
go


CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_CEDULA2 @CEDULA varchar(13)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.identificacion like '%'+ @CEDULA + '%'  and c.tipo = 'Persona' and c.SITUACION = 'INACTIVO' order by c.tipo;
end
go


CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_RUC2 @RUC varchar(13)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.identificacion like '%' + @RUC + '%'  and c.tipo = 'Empresa' and c.SITUACION = 'INACTIVO' order by c.tipo;
end
go


CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_CUENTA2 @CUENTA varchar(64)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where c.cuenta like '%' + @CUENTA + '%'  and c.tipo = 'Empresa' and c.SITUACION='INACTIVO' order by c.tipo;
end
go

---PROCEDURE LLNAR TABLA CLIENTE
CREATE PROCEDURE SP_LLENADO_TABLA_CLIENTE
AS
BEGIN
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA AND c.SITUACION = 'ACTIVO'  order by c.tipo;
END
go


CREATE PROCEDURE SP_LLENADO_TABLA_CLIENTE2
AS
BEGIN
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla  from persona as p join cliente as c on p.idpersona = c.IDPERSONA  AND C.SITUACION = 'INACTIVO' order by c.tipo;
END
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA;
end
go


CREATE PROCEDURE SP_MUESTRA_TECNICOS_NOMBRE @nombre varchar(128)
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%'+@nombre+'%' order by t.sector;
end
go


create procedure SP_MUESTRA_LLENAR_TABLA_CASO 
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA order by c.estado
end
go


create procedure SP_CANCELAR_CASO @IDCASO numeric 
as
begin 
UPDATE Caso SET ESTADO = 'CANCELADO' WHERE IDCASO = @IDCASO
end
go

drop procedure SP_MUESTRA_USUARIO_NOMBRE
go

CREATE PROCEDURE SP_MUESTRA_USUARIO
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona order by u.tipo;
END
GO


CREATE PROCEDURE SP_MUESTRA_USUARIO_NOMBRE @nombre varchar(128)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%' + @nombre + '%' order by u.tipo;
END
GO

CREATE PROCEDURE SP_MUESTRA_USUARIO_IDENTIFICACION @identificacion varchar(10)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%' + @identificacion + '%' order by u.tipo;
END
GO

CREATE PROCEDURE SP_ELIMINACION_USUARIO @identificacion varchar(10)
AS
BEGIN
delete from persona where identificacion = @identificacion;
END
GO

---PROCEDURE LLNAR TABLA TECNICO
CREATE PROCEDURE SP_LLENADO_TABLA_TECNICO
AS
BEGIN
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA AND T.SITUACION = 'ACTIVO'
END
go

CREATE PROCEDURE SP_LLENADO_TABLA_TECNICO2
AS
BEGIN
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA AND T.SITUACION = 'INACTIVO'
END
go

---PROCEDURE DAR DE BAJA TECNICO
CREATE PROCEDURE SP_DADO_DE_BAJA_TECNICO @identificacion varchar(10)
as
begin
update TECNICO set situacion = 'INACTIVO' where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion)
end
go

---PROCEDURE DAR DE ALTA CLIENTE
CREATE PROCEDURE SP_DADO_DE_ALTA_TECNICO @identificacion varchar(10)
as
begin
update TECNICO set situacion = 'ACTIVO' where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion)
end
go


---PROCEDURE MUESTRA DE TECNICOS DAR DE BAJA Y ALTA
CREATE PROCEDURE SP_MUESTRA_TECNICOS
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA AND T.SITUACION = 'ACTIVO';
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS2
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA AND T.SITUACION = 'INACTIVO';
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS_NOMBRE @nombre varchar(128)
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%'+@nombre+'%' AND T.SITUACION = 'ACTIVO' order by t.sector;
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS_NOMBRE2 @nombre varchar(128)
as
begin
select t.estado, p.nombre, p.identificacion, t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where nombre like '%'+@nombre+'%' AND T.SITUACION = 'INACTIVO' order by t.sector;
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS_IDENTIFICACION1 @identificacion varchar(128)
as
begin
select t.estado, p.nombre, p.identificacion,  t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where p.identificacion like '%' + @identificacion + '%' AND T.SITUACION='ACTIVO' order by t.sector;
end
go

CREATE PROCEDURE SP_MUESTRA_TECNICOS_IDENTIFICACION2 @identificacion varchar(128)
as
begin
select t.estado, p.nombre, p.identificacion,  t.sector,t.alcance from persona as p join tecnico as t on p.IDPERSONA = t.IDPERSONA where p.identificacion like '%' + @identificacion + '%' AND T.SITUACION='INACTIVO' order by t.sector;
end
go

CREATE PROCEDURE SP_GENERAR_INFORME_FINAL @FECHAI datetime, @FECHAF datetime
AS
BEGIN
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso 
from caso as c join cliente as cl 
on c.IDCLIENTE = cl.IDCLIENTE 
join persona as p on cl.IDPERSONA = p.IDPERSONA
WHERE cast(c.FECHA as date)
BETWEEN @FECHAI AND @FECHAF order by c.estado
END
GO

use SIGSTEC
GO


CREATE PROCEDURE SP_MUESTRA_PRODUCTO_DISMINUCION 
AS
BEGIN
select codigo, descripcion, cantidad from producto;
END
GO


CREATE PROCEDURE SP_MUESTRA_PRODUCTO_CODIGO_DISMINUCION @codigo varchar(8)
AS
BEGIN
select codigo, descripcion, cantidad from producto where codigo like '%' + @codigo + '%'; 
END
GO

CREATE PROCEDURE SP_MUESTRA_PRODUCTO_DESCRIPCION_DISMINUCION @descripcion varchar(1024)
AS
BEGIN
select codigo, descripcion, cantidad from producto where descripcion like '%' + @descripcion + '%'; 
END
GO


CREATE PROCEDURE SP_REGISTRO_ENTREGA @entrega varchar(16)
AS
BEGIN
insert into entrega (numero) values (@entrega);
END
GO

CREATE PROCEDURE SP_DISMINUCION_PRODUCTO @codigo varchar(8), @cantidad int
AS
BEGIN
insert into producto_entrega(identrega, idproducto, cantidad) values ((select max(identrega) from entrega),(select idproducto from producto where codigo = @codigo),@cantidad);
update producto set cantidad = cantidad -@cantidad where codigo = @codigo;
END
GO

CREATE PROCEDURE SP_REGISTRO_USUARIO @nombre varchar(128), @correo varchar(64), @identificacion varchar(13), @tipo varchar(64), @username varchar(10), @pass varchar(32), @salt varchar(64)
as
begin
insert into persona(nombre, correo, identificacion) values(@nombre, @correo, @identificacion); 
insert into usuario(idpersona, tipo, username, [password], salt, estado) values((select idpersona from persona where idpersona = (select max(idpersona) from persona)), @tipo,@username,@pass, @salt, 'ACTIVO');  
end
go


CREATE PROCEDURE SP_INICIO_DE_SESION @username varchar(10)
AS
BEGIN
select [password] , salt, idusuario from usuario where username = @username;
END
GO

CREATE PROCEDURE SP_CAMBIO_DE_PASSWORD @pass varchar(32), @id int
AS
BEGIN
update usuario set [password] = @pass where idusuario = @id; 
END
GO

CREATE PROCEDURE SP_REGISTRO_INFORME_FINAL_PATH @INFORME_FINAL varchar(2048), @PARTE_PATH varchar(128), @IDCASO numeric              
as
begin
UPDATE Caso SET ESTADO = 'CERRADO', INFORME_FINAL = @INFORME_FINAL, PARTE_PATH = @PARTE_PATH WHERE IDCASO = @IDCASO
end
go

CREATE PROCEDURE SP_MODIFICACION_TELFONOS @convencional1 varchar(9), @convencional2 varchar(9), @movil1 varchar(10), @movil2 varchar(10), @idpersona int
as
BEGIN
update telefono set TELEFONO= @convencional1 where tipo = 'CONVENCIONAL1' and telefono.IDPERSONA = @idpersona;
update telefono set TELEFONO= @movil1 where tipo = 'CELULAR1' and telefono.IDPERSONA = @idpersona;
if(@convencional2 = '')
begin
	if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CONVENCIONAL2')=1)  
	BEGIN
		DELETE TELEFONO WHERE IDPERSONA = @idpersona and tipo = 'CONVENCIONAL2'
	END
end
else 
begin
if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CONVENCIONAL2')=1)  
	BEGIN
		 update telefono set TELEFONO= @convencional2 where tipo = 'CONVENCIONAL2' and telefono.IDPERSONA = @idpersona;
	END
else
	Begin
		insert into telefono values (@idpersona,@convencional2,'CONVENCIONAL2'); 
	end
end 

if(@movil2 = '')
begin
	if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CELULAR2')=1)  
	BEGIN
		DELETE TELEFONO WHERE IDPERSONA = @idpersona and tipo = 'CELULAR2'
	END
end
else 
begin
if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CELULAR2')=1)  
	BEGIN
		 update telefono set TELEFONO= @movil2 where tipo = 'CELULAR2' and telefono.IDPERSONA = @idpersona;
	END
else
	Begin
		insert into telefono values (@idpersona,@movil2,'CELULAR2'); 
	end
end

END
GO

CREATE PROCEDURE SP_VERIFICAR_CEDULA @identificacion varchar(13)
AS
BEGIN
select count(identificacion) from persona where identificacion = @identificacion;
END
GO

create procedure SP_MUESTRA_LLENAR_TABLA_CASO_PARA_ASIGANCION_PRODUCTO 
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
WHERE c.estado = 'CERRADO' order by c.estado
end
go

create procedure SP_MUESTRA_BUSCAR_CASO_POR_SECTOR_PARA_ASIGANCION_PRODUCTO @SECTOR varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where c.sector like '%' + @SECTOR + '%' and c.estado = 'CERRADO' order by c.estado
end
go

create procedure SP_MUESTRA_BUSCAR_CASO_POR_CUENTA_PARA_ASIGANCION_PRODUCTO @CUENTA varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where cl.cuenta like '%' + @CUENTA + '%' and c.estado = 'CERRADO' order by c.estado
end
go

create  procedure SP_MUESTRA_BUSCAR_CASO_POR_NOMBRE_PARA_ASIGANCION_PRODUCTO @NOMBRE varchar(128)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where p.NOMBRE like '%' + @NOMBRE + '%' and c.estado = 'CERRADO' order by c.estado
end
go

create procedure SP_MUESTRA_BUSCAR_CASO_POR_NUMERO_DE_CASO_PARA_ASIGANCION_PRODUCTO @NUMERO varchar(16)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where c.numero like '%' + @NUMERO + '%' and c.estado = 'CERRADO' order by c.estado
end
go

CREATE PROCEDURE SP_MODIFICACION_TELFONOS @convencional1 varchar(9), @convencional2 varchar(9), @movil1 varchar(10), @movil2 varchar(10), @idpersona int
as
BEGIN
update telefono set TELEFONO= @convencional1 where tipo = 'CONVENCIONAL1' and telefono.IDPERSONA = @idpersona;
update telefono set TELEFONO= @movil1 where tipo = 'CELULAR1' and telefono.IDPERSONA = @idpersona;
if(@convencional2 = '')
begin
	if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CONVENCIONAL2')=1)  
	BEGIN
		DELETE TELEFONO WHERE IDPERSONA = @idpersona and tipo = 'CONVENCIONAL2'
	END
end
else 
begin
if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CONVENCIONAL2')=1)  
	BEGIN
		 update telefono set TELEFONO= @convencional2 where tipo = 'CONVENCIONAL2' and telefono.IDPERSONA = @idpersona;
	END
else
	Begin
		insert into telefono values (@idpersona,@convencional2,'CONVENCIONAL2'); 
	end
end 

if(@movil2 = '')
begin
	if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CELULAR2')=1)  
	BEGIN
		DELETE TELEFONO WHERE IDPERSONA = @idpersona and tipo = 'CELULAR2'
	END
end
else 
begin
if ((select count(telefono) from telefono where IDPERSONA = @idpersona and tipo = 'CELULAR2')=1)  
	BEGIN
		 update telefono set TELEFONO= @movil2 where tipo = 'CELULAR2' and telefono.IDPERSONA = @idpersona;
	END
else
	Begin
		insert into telefono values (@idpersona,@movil2,'CELULAR2'); 
	end
end

END
GO


create procedure SP_SACAR_NUMEROCASO_MAXIMO
as
begin 
select top 1 NUMERO from caso order by IDCASO desc
end
go

CREATE PROCEDURE SP_ASIGNACION_PRODUCTO_CASO @numero varchar(16), @codigo varchar(8), @cantidad int
AS
BEGIN
insert into CASO_PRODUCTO(IDCASO, idproducto, cantidad) values 
((select IDCASO from caso where NUMERO = @numero)
,(select idproducto from producto where codigo = @codigo)
,@cantidad);
update producto set cantidad = cantidad -@cantidad where codigo = @codigo;
update CASO set ESTADO = 'POR FACTURAR' where NUMERO = @numero;
END
GO

CREATE PROCEDURE SP_ASIGNACION_PRODUCTO_CASO @numero varchar(16), @codigo varchar(8), @cantidad int
AS
BEGIN
insert into CASO_PRODUCTO(IDCASO, idproducto, cantidad) values 
((select IDCASO from caso where NUMERO = @numero)
,(select idproducto from producto where codigo = @codigo)
,@cantidad);
update producto set cantidad = cantidad -@cantidad where codigo = @codigo;
update CASO set ESTADO = 'POR FACTURAR' where NUMERO = @numero;
END
GO



create procedure SP_BUSCAR_CASO_PORFACTURAR_POR_NUMERO_DE_CASO @NUMERO varchar(16)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
where c.numero like '%' + @NUMERO + '%' and c.estado = 'POR FACTURAR' order by c.estado
end
GO


create procedure SP_LLENAR_TABLA_CASO_PORFACTURAR 
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
WHERE c.estado = 'POR FACTURAR' order by c.estado
end
GO

create procedure SP_BUSCAR_CASO_PORFACTURAR_POR_NOMBRE @NOMBRE varchar(128)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA
 = p.IDPERSONA 
where p.NOMBRE like '%' + @NOMBRE + '%' and c.estado = 'POR FACTURAR' order by c.estado
end
GO


create procedure SP_BUSCAR_CASO_PORFACTURAR_POR_CUENTA @CUENTA varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA =
 p.IDPERSONA 
where cl.cuenta like '%' + @CUENTA + '%' and c.estado = 'POR FACTURAR' order by c.estado
end
GO


create procedure SP_BUSCAR_CASO_PORFACTURAR_POR_SECTOR @SECTOR varchar(64)
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla, c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA 
= p.IDPERSONA 
where c.sector like '%' + @SECTOR + '%' and c.estado = 'POR FACTURAR' order by c.estado
end
GO

CREATE PROCEDURE SP_MUESTRA_USUARIO_ACTIVO
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona WHERE U.ESTADO = 'ACTIVO' order by u.tipo;
END
GO




/**************************************************/
CREATE PROCEDURE SP_MUESTRA_USUARIO_NOMBRE_ACTIVO @nombre varchar(128)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%' + @nombre + '%' AND U.ESTADO='ACTIVO' order by u.tipo;
END
GO

CREATE PROCEDURE SP_MUESTRA_USUARIO_IDENTIFICACION_ACTIVO @identificacion varchar(10)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%' + @identificacion + '%' AND U.ESTADO='ACTIVO' order by u.tipo;
END
GO


CREATE PROCEDURE SP_MUESTRA_USUARIO_ACTIVO_INACTIVO
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona WHERE U.ESTADO = 'INACTIVO' order by u.tipo;
END
GO
CREATE PROCEDURE SP_MUESTRA_USUARIO_NOMBRE_INACTIVO @nombre varchar(128)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%' + @nombre + '%' AND U.ESTADO='INACTIVO' order by u.tipo;
END
GO

CREATE PROCEDURE SP_MUESTRA_USUARIO_IDENTIFICACION_INACTIVO @identificacion varchar(10)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%' + @identificacion + '%' AND U.ESTADO='INACTIVO' order by u.tipo;
END
GO

create procedure SP_MUESTRA_LLENAR_VISTA_DETALLES
as
begin
select c.estado, c.numero, p.nombre, cl.cuenta, c.fecha, c.sla , c.sector, c.idcaso 
from caso as c join cliente as cl on c.IDCLIENTE = cl.IDCLIENTE join persona as p on cl.IDPERSONA = p.IDPERSONA 
WHERE C.ESTADO = 'FACTURADO'
order by c.estado
end
GO

CREATE PROCEDURE SP_CAMBIO_DE_PASSWORD @pass varchar(32), @id int
AS
BEGIN
update usuario set ESTADO = 'ACTIVO', [password] = @pass where idusuario = @id; 
END
GO

CREATE PROCEDURE SP_MUESTRA_USUARIO_ACTIVO
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona WHERE U.ESTADO = 'ACTIVO' order by u.tipo;
END
GO





CREATE PROCEDURE SP_MUESTRA_USUARIO_NOMBRE_ACTIVO @nombre varchar(128)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%' + @nombre + '%' AND U.ESTADO='ACTIVO' order by u.tipo;
END
GO

CREATE PROCEDURE SP_MUESTRA_USUARIO_IDENTIFICACION_ACTIVO @identificacion varchar(10)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%' + @identificacion + '%' AND U.ESTADO='ACTIVO' order by u.tipo;
END
GO


CREATE PROCEDURE SP_MUESTRA_USUARIO_INACTIVO
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona WHERE U.ESTADO = 'INACTIVO' order by u.tipo;
END
GO
CREATE PROCEDURE SP_MUESTRA_USUARIO_NOMBRE_INACTIVO @nombre varchar(128)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.nombre like '%' + @nombre + '%' AND U.ESTADO='INACTIVO' order by u.tipo;
END
GO

CREATE PROCEDURE SP_MUESTRA_USUARIO_IDENTIFICACION_INACTIVO @identificacion varchar(10)
AS
BEGIN
select u.tipo, p.nombre, p.identificacion, p.correo from persona as p join usuario as u on p.idpersona = u.idpersona where p.identificacion like '%' + @identificacion + '%' AND U.ESTADO='INACTIVO' order by u.tipo;
END
GO

CREATE PROCEDURE SP_DAR_DE_BAJA_USUARIO @identificacion varchar(10)
AS
begin
update usuario set ESTADO = 'INACTIVO'  where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion);
end
go


CREATE PROCEDURE SP_DAR_DE_ALTA_USUARIO @identificacion varchar(10)
AS
begin
update usuario set ESTADO = 'ACTIVO' where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion);
end
go


CREATE PROCEDURE SP_RECUPERAR_CONTRASEÑA @identificacion varchar(10), @pass varchar(32)
AS
begin
update usuario set estado = 'BLOQUEADO',[PASSWORD] = @pass where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion);
end
go



CREATE PROCEDURE SP_OBTENER_SALT @identificacion varchar(10)
AS
begin
SELECT SALT from USUARIO where IDPERSONA = (select PERSONA.IDPERSONA from PERSONA where IDENTIFICACION = @identificacion);
end
go

CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_CUENTA_SELECCION_PARA_CASO @CUENTA varchar(64)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.IDCLIENTE
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where c.cuenta like '%' + @CUENTA + '%'  and c.tipo = 'Empresa' and c.SITUACION='ACTIVO' order by c.tipo;
end
go


CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_NOMBRE_SELECCION_PARA_CASO @NOMBRE VARCHAR(128)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.IDCLIENTE 
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.nombre like '%' + @NOMBRE + '%' AND c.SITUACION ='ACTIVO' order by c.tipo;
end
go



CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_CEDULA_SELECCION_PARA_CASO @CEDULA varchar(13)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla , c.IDCLIENTE
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.identificacion like '%'+ @CEDULA + '%'  and c.tipo = 'Persona' and c.SITUACION = 'ACTIVO' order by c.tipo;
end
go



CREATE PROCEDURE SP_BUSCAR_CLIENTE_POR_RUC_SELECCION_PARA_CASO @RUC varchar(13)
as
begin
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla,  c.IDCLIENTE
from persona as p join cliente as c on p.idpersona = c.IDPERSONA
where p.identificacion like '%' + @RUC + '%'  and c.tipo = 'Empresa' and c.SITUACION = 'ACTIVO' order by c.tipo;
end
go


CREATE PROCEDURE SP_LLENADO_TABLA_CLIENTE_SELECCION_PARA_CASO
AS
BEGIN
select c.tipo, p.nombre, c.cuenta,  p.identificacion, c.sla, c.IDCLIENTE  from persona as p join cliente as c on p.idpersona = c.IDPERSONA AND c.SITUACION = 'ACTIVO'  order by c.tipo;
END
go

