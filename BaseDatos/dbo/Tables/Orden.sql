CREATE TABLE [dbo].[Orden] (
    [IdOrden]          INT          IDENTITY (1, 1) NOT NULL,
    [IdProducto]       INT          NOT NULL,
    [CantidadProducto] INT          NOT NULL,
    [Estado]           VARCHAR (50) NULL,
    CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED ([IdOrden] ASC) WITH (DATA_COMPRESSION = PAGE),
    CONSTRAINT [FK_Producto] FOREIGN KEY ([IdProducto]) REFERENCES [dbo].[Producto] ([IdProducto])
);

