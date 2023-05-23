USE Negocios2023
GO

--PREGUNTA1

create or alter proc usp_listapedidos
As
Select idpedido,fechapedido,NombreCia,DireccionDestinatario
from tb_pedidoscabe p join tb_clientes c on p.IdCliente=c.IdCliente
go

exec usp_listapedidos
go

--

create or alter proc usp_listapedidos_year
@y int
As
Select idpedido,fechapedido,NombreCia,DireccionDestinatario
from tb_pedidoscabe p join tb_clientes c on p.IdCliente=c.IdCliente
Where Year(FechaPedido)=@y
go

exec usp_listapedidos_year '1997'
go


--PREGUNTA02

Create table tb_Insumos(
	codIns int primary key,
	desIns varchar(255) not null,
	idcategoria int references tb_categorias,
	preUni decimal,
	stock int
)
go

--listar

create or alter proc usp_insumos
as
Select codIns,desIns,NombreCategoria,preUni,stock from tb_Insumos i Inner join tb_categorias c on i.idcategoria=c.IdCategoria
go

exec usp_insumos
go

--
create or alter proc usp_insertarInsumos
@cod int,
@des varchar(25),
@idCate int,
@precio decimal,
@stock int
As
Begin
insert tb_Insumos values(@cod,@des,@idCate,@precio,@stock)
End
go

exec usp_insertarInsumos '3','Mantequilla','4','2.50','22'
go


--

create or alter proc usp_categorias
as
Select idCategoria,NombreCategoria from tb_categorias
go

exec usp_categorias
go
