CREATE TABLE [dbo].[Producto] (
    [IdProducto]     INT             IDENTITY (1, 1) NOT NULL,
    [NombreProducto] VARCHAR (50)    NOT NULL,
    [PrecioProducto] DECIMAL (10, 2) NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED ([IdProducto] ASC) WITH (DATA_COMPRESSION = PAGE)
);

