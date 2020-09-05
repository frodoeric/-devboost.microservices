IF NOT EXISTS(
    SELECT name
    FROM sys.databases
    WHERE name = 'DroneDelivery'
)
    CREATE DATABASE [DroneDelivery]
GO

USE [DroneDelivery]
GO

CREATE TABLE [Usuario] (
    [ID] [uniqueidentifier] NOT NULL,
    [Nome] varchar(255) NOT NULL unique,
    [Senha] varchar(255),
    [Papel] varchar(255),
    PRIMARY KEY (ID)
)
GO

CREATE TABLE [Cliente] (
    [ID] [uniqueidentifier] NOT NULL,
    [Usuario_Id] [uniqueidentifier] NOT NULL,
    [Nome] varchar(255) NOT NULL,
    [email] varchar(255) NOT NULL,
    [telefone] varchar(255),
    [Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
    PRIMARY KEY (ID)
);
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([Usuario_Id])
REFERENCES [dbo].[Usuario]([Id])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drone](
	[Id] [int] NOT NULL,
	[Capacidade] [int] NOT NULL,
	[Velocidade] [int] NOT NULL,
	[Autonomia] [int] NOT NULL,
	[Carga] [int] NOT NULL,
    [Status] [int] NOT NULL
 CONSTRAINT [PK_Drone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Pedido]    Script Date: 22/08/2020 00:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [uniqueidentifier] NOT NULL,
    [Client_Id] [uniqueidentifier] NOT NULL,
	[Peso] [int] NOT NULL,
	[DataHora] [datetime] NOT NULL,
    [DistanciaParaOrigem] [float] NOT NULL,
	[StatusPedido] [int] NULL
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Cliente]([Id])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO

/****** Object:  Table [dbo].[Pedido_Drone]    Script Date: 22/08/2020 00:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido_Drone](
	[Pedido_Id] [uniqueidentifier] NOT NULL,
	[Drone_Id] [int] NOT NULL
 CONSTRAINT [PK_Pedido_Drone] PRIMARY KEY CLUSTERED 
(
	[Pedido_Id], [Drone_Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedido_Drone]  WITH CHECK ADD CONSTRAINT [FK_Pedido_Drone_Pedido] FOREIGN KEY([Pedido_Id])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Drone] CHECK CONSTRAINT [FK_Pedido_Drone_Pedido]
GO
ALTER TABLE [dbo].[Pedido_Drone]  WITH CHECK ADD CONSTRAINT [FK_Pedido_Drone_Drone] FOREIGN KEY([Drone_Id])
REFERENCES [dbo].[Drone] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Drone] CHECK CONSTRAINT [FK_Pedido_Drone_Drone]
GO

INSERT INTO [Drone] ([Id], [Capacidade], [Velocidade], [Autonomia],	[Carga], [Status])
VALUES
  -- ID, Capacidade KG, Velocidade KM/H, Autonomia min, Carga em %, Status
    (1,  12,            35,              15,            100,        1),
    (2,  7,             25,              35,            50,         1),
    (3,  5,             25,              35,            25,         1),
    (4,  10,            40,              20,            100,        1),
    (5,  8,             60,              25,            100,        1),
    (6,  7,             50,              30,            20,         1),
    (7,  12,            35,              15,            0,          0),
    (8,  7,             25,              35,            5,          0)
GO

--select NEWID()

INSERT INTO Usuario (ID, Nome ,Senha ,Papel)
VALUES
	('C3AD9FE4-9CA3-4EA1-A56B-00B168113ECC', 'Jefferson', '12345', 'admin'),
	('8DA33624-244A-44CD-9630-8D18B68E7315', 'Afonso', '12345', 'usuario'),
	('2A799C96-C391-4133-A8B1-31BA124A49FE', 'Eric', '12345', 'cliente'),
	('8001CB43-A741-4053-A7F8-FDDAFA3046B4', 'Allan', '12345', 'cliente')
GO

INSERT INTO Cliente (ID, Usuario_Id, Nome, email, telefone, Latitude, Longitude)
VALUES
    ('360A1388-1DC1-42F4-B214-B2E6022485DF', 'C3AD9FE4-9CA3-4EA1-A56B-00B168113ECC', 'Hulk', 'hulk@domain.com', '(11) 9999-9999', -23.5990684,-46.6784195),
    ('A848F95D-0A58-4512-8211-0BA08FAA7D05', '8DA33624-244A-44CD-9630-8D18B68E7315', 'Thor', 'thor@domain.com', '(11) 9999-9999', -23.6990684,-46.6684195),
    ('1CF28588-EDC6-48F9-8C22-5A91AED092B6', '2A799C96-C391-4133-A8B1-31BA124A49FE', 'Pantera Negra', 'pantera.negra@domain.com', '(11) 9999-9999', -23.5990684,-46.6684195),
    ('E5BDD63A-F233-480B-913C-CF54D4A98D5E', '8001CB43-A741-4053-A7F8-FDDAFA3046B4', 'Iron Man', 'iron.man@domain.com', '(11) 9999-9999', -23.5890684,-46.6584195)
GO

INSERT INTO [Pedido] (Id, Client_Id, Peso, DataHora, DistanciaParaOrigem, StatusPedido)
VALUES
    (NEWID(), '360A1388-1DC1-42F4-B214-B2E6022485DF', 5, CONVERT(DATETIME, '23/08/2020 09:06', 103), 2.55364638593945   , 2),
    (NEWID(), '360A1388-1DC1-42F4-B214-B2E6022485DF', 5, CONVERT(DATETIME, '23/08/2020 09:06', 103),12.4024182185119    , 2),
    (NEWID(), '360A1388-1DC1-42F4-B214-B2E6022485DF', 5, CONVERT(DATETIME, '23/08/2020 09:06', 103), 1.72945953901391   , 2),
    (NEWID(), 'A848F95D-0A58-4512-8211-0BA08FAA7D05', 5, CONVERT(DATETIME, '23/08/2020 09:05', 103), 0.23215649330868   , 2),
    (NEWID(), 'A848F95D-0A58-4512-8211-0BA08FAA7D05', 5, CONVERT(DATETIME, '23/08/2020 09:04', 103), 0                  , 2),
    (NEWID(), 'A848F95D-0A58-4512-8211-0BA08FAA7D05', 5, CONVERT(DATETIME, '23/08/2020 09:04', 103), 0.203488045541539  , 2),
    (NEWID(), '1CF28588-EDC6-48F9-8C22-5A91AED092B6', 5, CONVERT(DATETIME, '23/08/2020 09:04', 103), 0.16606820161035   , 2),
    (NEWID(), '1CF28588-EDC6-48F9-8C22-5A91AED092B6', 5, CONVERT(DATETIME, '23/08/2020 09:03', 103),10.1905556545044    , 2),
    (NEWID(), '1CF28588-EDC6-48F9-8C22-5A91AED092B6', 5, CONVERT(DATETIME, '23/08/2020 09:03', 103), 0.112312603076869  , 2),
    (NEWID(), 'E5BDD63A-F233-480B-913C-CF54D4A98D5E', 5, CONVERT(DATETIME, '23/08/2020 09:03', 103),10.4292864585278    , 2),
    (NEWID(), 'E5BDD63A-F233-480B-913C-CF54D4A98D5E', 5, CONVERT(DATETIME, '23/08/2020 09:02', 103), 0.00112323555155982, 2),
    (NEWID(), 'E5BDD63A-F233-480B-913C-CF54D4A98D5E', 5, CONVERT(DATETIME, '23/08/2020 09:02', 103), 0                  , 2)
GO
