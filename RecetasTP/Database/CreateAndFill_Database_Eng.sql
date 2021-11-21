CREATE DATABASE [20212C_TP]
GO

USE [20212C_TP]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 11/21/2021 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[DinerId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[DinersAmount] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 11/21/2021 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[ChefId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Date] [datetime] NOT NULL,
	[DinersAmount] [int] NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[Picture] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[State] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventsRecipes]    Script Date: 11/21/2021 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventsRecipes](
	[EventRecipeId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
 CONSTRAINT [PK_EventsRecipes] PRIMARY KEY CLUSTERED 
(
	[EventRecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 11/21/2021 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[DinerId] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 11/21/2021 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[RecipeId] [int] IDENTITY(1,1) NOT NULL,
	[ChefId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CookingTime] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Ingredients] [nvarchar](max) NOT NULL,
	[RecipeTypeId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[DeletedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipesType]    Script Date: 11/21/2021 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipesType](
	[RecipeTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RecipeType] PRIMARY KEY CLUSTERED 
(
	[RecipeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/21/2021 6:15:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Rol] [int] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (1, 4, 2, 4, 15, CAST(N'2021-11-21T17:38:18.850' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (2, 5, 2, 6, 50, CAST(N'2021-11-21T17:38:39.527' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (3, 3, 2, 2, 10, CAST(N'2021-11-21T17:38:46.357' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (4, 3, 2, 4, 15, CAST(N'2021-11-21T17:38:58.747' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (5, 1, 2, 5, 30, CAST(N'2021-11-21T17:39:15.467' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (6, 6, 2, 3, 25, CAST(N'2021-11-21T17:49:24.373' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (7, 2, 2, 3, 50, CAST(N'2021-11-21T17:49:33.530' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (8, 7, 2, 1, 50, CAST(N'2021-11-21T17:54:23.750' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (9, 7, 2, 1, 10, CAST(N'2021-11-21T17:54:31.627' AS DateTime))
GO
INSERT [dbo].[Bookings] ([BookId], [EventId], [DinerId], [RecipeId], [DinersAmount], [CreationDate]) VALUES (10, 8, 2, 4, 20, CAST(N'2021-11-21T18:07:16.193' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (1, 1, N'Costa Salguero #20', N'El evento se llevará a cabo en Costa Salguero Pabellón 3. Está reservado para el día 21 del corriente més y se degustarán varias recetas de los mejores chefs', CAST(N'2021-10-21T20:00:00.000' AS DateTime), 500, N'Costa Salguero', N'85538705-cc6a-4b74-8a1b-f1857edc7d1d.jpg', CAST(2399.00 AS Decimal(18, 2)), 2, NULL, NULL, CAST(N'2021-11-21T17:40:42.327' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (2, 1, N'Costa Salguero #21', N'El evento se llevará a cabo en Costa Salguero Pabellón 7. Está reservado para el día 20 del corriente més y se degustarán varias recetas de los mejores chefs. Platos orientales', CAST(N'2020-11-21T19:00:00.000' AS DateTime), 250, N'Costa Salguero Pabellón 7', N'660eae95-9bd5-40aa-8bee-e1b3d016b911.jpg', CAST(1500.00 AS Decimal(18, 2)), 2, NULL, NULL, CAST(N'2021-11-21T17:50:43.093' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (3, 1, N'Costa Salguero #22', N'El evento se llevará a cabo en Costa Salguero Pabellón 3. Está reservado para el día 25 del corriente més y se degustarán varias recetas de los mejores chefs. Diet', CAST(N'2021-10-25T20:00:00.000' AS DateTime), 300, N'Costa Salguero Pabellón 3', N'9e06edea-52f2-474d-9163-3e86d4df922e.jpg', CAST(999.00 AS Decimal(18, 2)), 2, NULL, NULL, CAST(N'2021-11-21T17:40:48.343' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (4, 1, N'La Rural #33', N'El evento se llevará a cabo en La Rural Escenario 2. Está reservado para el día 19 del corriente més y se degustarán varias recetas de los mejores chefs', CAST(N'2020-11-19T20:00:00.000' AS DateTime), 50, N'La Rural Escenario 2', N'64ccd767-e291-4dd5-a6d6-27077f9dae22.jpg', CAST(1500.00 AS Decimal(18, 2)), 2, NULL, NULL, CAST(N'2021-11-21T17:40:33.880' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (5, 1, N'La Rural #34', N'El evento se llevará a cabo en La Rural Escenario 4. Está reservado para el día 19 del corriente més y se degustarán varias recetas de los mejores chefs', CAST(N'2020-11-21T19:00:00.000' AS DateTime), 200, N'La Rural Escenario 4', N'783a5d73-f6d0-48de-acfe-58fcf4cc18ac.jpg', CAST(999.00 AS Decimal(18, 2)), 2, NULL, NULL, CAST(N'2021-11-21T17:40:24.037' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (6, 1, N'La Rural #35', N'El evento se llevará a cabo en La Rural Escenario 1. Está reservado para el día 19 del corriente més y se degustarán varias recetas de los mejores chefs', CAST(N'2020-11-19T18:00:00.000' AS DateTime), 500, N'La Rural Escenario 1', N'1d91256b-2906-4f30-afbf-a7a1fb59b36c.png', CAST(700.00 AS Decimal(18, 2)), 2, NULL, NULL, CAST(N'2021-11-21T17:50:49.037' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (7, 1, N'Evento de Prueba #1', N'Esto es un evento de prueba', CAST(N'2021-11-21T20:00:00.000' AS DateTime), 500, N'Unlam', N'b97c65d3-dc70-4e6b-8656-93163bf63270.jpg', CAST(200.00 AS Decimal(18, 2)), 1, CAST(N'2021-11-21T17:52:54.723' AS DateTime), N'1', CAST(N'2021-11-21T17:52:54.723' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (8, 1, N'Evento de Prueba #2', N'Esto es un evento de prueba', CAST(N'2021-11-20T22:00:00.000' AS DateTime), 200, N'Unlam', N'79678281-1197-45f6-98a8-eabdc993e2a1.jpg', CAST(1000.00 AS Decimal(18, 2)), 3, NULL, NULL, CAST(N'2021-11-21T18:08:38.163' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Events] ([EventId], [ChefId], [Name], [Description], [Date], [DinersAmount], [Location], [Picture], [Price], [State], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (9, 1, N'Evento de Prueba #3', N'Esto es un evento de prueba', CAST(N'2021-12-04T22:12:00.000' AS DateTime), 500, N'Unlam', N'cd63b5bc-233a-4505-ad14-f7212df7a17c.jpg', CAST(500.00 AS Decimal(18, 2)), 1, CAST(N'2021-11-21T18:11:35.863' AS DateTime), N'1', CAST(N'2021-11-21T18:11:35.863' AS DateTime), N'1', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[EventsRecipes] ON 
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (1, 1, 6)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (2, 1, 5)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (3, 1, 1)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (4, 2, 2)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (5, 2, 1)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (6, 2, 3)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (7, 3, 2)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (8, 3, 4)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (9, 4, 6)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (10, 4, 4)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (11, 4, 5)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (12, 5, 6)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (13, 5, 2)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (14, 5, 4)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (15, 5, 5)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (16, 6, 1)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (17, 6, 3)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (18, 6, 4)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (19, 6, 5)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (20, 7, 2)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (21, 7, 1)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (22, 7, 3)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (23, 8, 6)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (24, 8, 4)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (25, 8, 5)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (26, 9, 6)
GO
INSERT [dbo].[EventsRecipes] ([EventRecipeId], [EventId], [RecipeId]) VALUES (27, 9, 5)
GO
SET IDENTITY_INSERT [dbo].[EventsRecipes] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (1, 1, 2, 5, N'Excelente atención, todo 10 puntos.')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (2, 1, 2, 3, N'La comida bien pero se tardo mucho.')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (3, 3, 2, 5, N'Todo excelente.')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (4, 3, 2, 3, N'Demasiado caro por lo que es, se consiguen cosas mejores y mas baratas en otros eventos.')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (5, 4, 2, 5, N'Todo fantastico.')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (6, 5, 2, 4, N'Todo normal sin complicaciones.')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (7, 5, 2, 5, N'El mejor de los mejores, muchas gracias @tastyevents')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (8, 2, 2, 4, N'Todo normal, sin complicaciones.')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (9, 6, 2, 5, N'Excelente recomendación y excelente la comida. Felicitaciones al equipo')
GO
INSERT [dbo].[Ratings] ([RatingId], [EventId], [DinerId], [Rating], [Comments]) VALUES (10, 8, 2, 5, N'Todo super bien.')
GO
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipes] ON 
GO
INSERT [dbo].[Recipes] ([RecipeId], [ChefId], [Name], [CookingTime], [Description], [Ingredients], [RecipeTypeId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (1, 1, N'Crispy Wrap', 45, N'Bañado en los exóticos sabores del curry y coco tailandés, este bollito crujiente, relleno de pollo y camarones, se sirve en un consomé de bonito, acompañado de col lombarda', N'Cocina Mexicana Avant, Garde', 1, NULL, NULL, CAST(N'2021-11-21T17:24:55.470' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Recipes] ([RecipeId], [ChefId], [Name], [CookingTime], [Description], [Ingredients], [RecipeTypeId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (2, 1, N'Sopa De Flor De Calabaza', 120, N'Servido con una ronda de queso de cabra y chile ancho, esta sabrosa sopa de flor de calabaza se sirve con maíz y calabacín.', N'Cocina Mexicana Avant, Garde', 1, NULL, NULL, CAST(N'2021-11-21T17:25:08.523' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Recipes] ([RecipeId], [ChefId], [Name], [CookingTime], [Description], [Ingredients], [RecipeTypeId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (3, 1, N'Aguachile Rojo', 20, N'Acompañado de cebolla roja y pepino, este camarón cocido con limón se sirve bañado en una salsa de chile guajillo.', N'Rooftop del hotel Mousai', 1, NULL, NULL, CAST(N'2021-11-21T17:18:24.743' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Recipes] ([RecipeId], [ChefId], [Name], [CookingTime], [Description], [Ingredients], [RecipeTypeId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (4, 1, N'Wrap De Jícama', 50, N'Servidas con aderezo de chipotle, estas envolturas ingeniosamente hechas de jícama en finas rodajas contienen una mezcla de rúcula y camarones.', N'BocaDos STK', 2, NULL, NULL, CAST(N'2021-11-21T17:18:15.247' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Recipes] ([RecipeId], [ChefId], [Name], [CookingTime], [Description], [Ingredients], [RecipeTypeId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (5, 1, N'Milanesa con papas fritas', 60, N'Clásica milanesa con papas fritas a la industria Argentina.', N'Carne de ternera - Papas', 3, CAST(N'2021-11-21T17:11:56.423' AS DateTime), N'1', CAST(N'2021-11-21T17:11:56.423' AS DateTime), N'1', NULL, NULL)
GO
INSERT [dbo].[Recipes] ([RecipeId], [ChefId], [Name], [CookingTime], [Description], [Ingredients], [RecipeTypeId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [DeletedDate], [DeletedBy]) VALUES (6, 1, N'Pizza a los 4 quesos', 120, N'Degustadora pizza a los 4 quesos proveniente de la provincia de Cordoba', N'Mozarela, Gorgonzola, Fontina, Parmesano', 3, NULL, NULL, CAST(N'2021-11-21T17:25:31.500' AS DateTime), N'1', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Recipes] OFF
GO
SET IDENTITY_INSERT [dbo].[RecipesType] ON 
GO
INSERT [dbo].[RecipesType] ([RecipeTypeId], [Name]) VALUES (1, N'Gourmet')
GO
INSERT [dbo].[RecipesType] ([RecipeTypeId], [Name]) VALUES (2, N'Diet')
GO
INSERT [dbo].[RecipesType] ([RecipeTypeId], [Name]) VALUES (3, N'Casera')
GO
SET IDENTITY_INSERT [dbo].[RecipesType] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Name], [Email], [Password], [Rol], [RegistrationDate]) VALUES (1, N'Chef', N'chef@tasty.com', N'83EBF1AB924108B2B8730B04BEDC4A', 2, CAST(N'2021-11-21T16:13:15.367' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [Name], [Email], [Password], [Rol], [RegistrationDate]) VALUES (2, N'Diner', N'diner@tasty.com', N'83EBF1AB924108B2B8730B04BEDC4A', 1, CAST(N'2021-11-21T16:13:36.967' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Events]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([RecipeId])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Recipes]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Users] FOREIGN KEY([DinerId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Users]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([ChefId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Users]
GO
ALTER TABLE [dbo].[EventsRecipes]  WITH CHECK ADD  CONSTRAINT [FK_EventsRecipes_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[EventsRecipes] CHECK CONSTRAINT [FK_EventsRecipes_Events]
GO
ALTER TABLE [dbo].[EventsRecipes]  WITH CHECK ADD  CONSTRAINT [FK_EventsRecipes_Recipes] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([RecipeId])
GO
ALTER TABLE [dbo].[EventsRecipes] CHECK CONSTRAINT [FK_EventsRecipes_Recipes]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Events]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Users] FOREIGN KEY([DinerId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Users]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_RecipesType] FOREIGN KEY([RecipeTypeId])
REFERENCES [dbo].[RecipesType] ([RecipeTypeId])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_RecipesType]
GO
