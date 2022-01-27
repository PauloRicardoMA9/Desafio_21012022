CREATE DATABASE [Api.Cliente];

GO

USE [Api.Cliente];

GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Clientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(60) NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [Sexo] varchar(50) NOT NULL,
    [Email] varchar(100) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [IdCliente] uniqueidentifier NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(10) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    [Principal] varchar(10) NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Clientes_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Telefones] (
    [Id] uniqueidentifier NOT NULL,
    [IdCliente] uniqueidentifier NOT NULL,
    [Ddd] varchar(2) NOT NULL,
    [Numero] varchar(9) NOT NULL,
    [Principal] varchar(10) NOT NULL,
    CONSTRAINT [PK_Telefones] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Telefones_Clientes_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Enderecos_IdCliente] ON [Enderecos] ([IdCliente]);

GO

CREATE INDEX [IX_Telefones_IdCliente] ON [Telefones] ([IdCliente]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220124215037_Initial', N'3.1.22');

GO

