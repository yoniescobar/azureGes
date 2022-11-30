CREATE TABLE [dbo].[Rol] (
    [RolId]       INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED ([RolId] ASC)
);

