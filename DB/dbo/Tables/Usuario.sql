CREATE TABLE [dbo].[Usuario] (
    [UsuarioId]   INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (MAX) NOT NULL,
    [Apellido]    NVARCHAR (MAX) NOT NULL,
    [Telefono]    NVARCHAR (MAX) NOT NULL,
    [Direccion]   NVARCHAR (MAX) NOT NULL,
    [Correo]      NVARCHAR (450) NOT NULL,
    [FechaNac]    DATETIME2 (7)  NOT NULL,
    [RolId]       INT            NOT NULL,
    [Activo]      INT            NOT NULL,
    [Contrasenia] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([UsuarioId] ASC),
    CONSTRAINT [FK_Usuario_Rol_RolId] FOREIGN KEY ([RolId]) REFERENCES [dbo].[Rol] ([RolId]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuario_Correo]
    ON [dbo].[Usuario]([Correo] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Usuario_RolId]
    ON [dbo].[Usuario]([RolId] ASC);

