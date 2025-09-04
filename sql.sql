CREATE DATABASE [dbo.Facturas]
go
USE [dbo.Facturas]
go
CREATE TABLE FormaPago(
	id_formaPago int identity (1,1),
	nombre varchar (50),

)

CREATE TABLE Factura(
	id_nroFactura int identity (1,1),
	fecha date not null,
	id_formaPago int not null,
	id_cliente varchar (50),

	CONSTRAINT pk_facturas PRIMARY KEY (id_nroFactura) , 
	CONSTRAINT fk_facturas_formaPago FOREIGN KEY (id_formaPago) REFERENCES formaPago
);
