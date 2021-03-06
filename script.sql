USE [EsatCelikBlog]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleCategories]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleCategories](
	[ArticleId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[InsertedBy] [int] NOT NULL,
 CONSTRAINT [PK_ArticleCategories] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](160) NOT NULL,
	[ArticleAddress] [nvarchar](120) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[MainPictureResourceId] [int] NOT NULL,
	[AllowComment] [bit] NOT NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[InsertedBy] [int] NOT NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[InsertedBy] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[ArticleId] [int] NOT NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[InsertedBy] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Url] [nvarchar](120) NOT NULL,
	[Thumbnail] [nvarchar](max) NULL,
	[ContentType] [nvarchar](max) NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[InsertedBy] [int] NOT NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInformations]    Script Date: 14.02.2021 19:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInformations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[InsertedBy] [int] NOT NULL,
 CONSTRAINT [PK_UserInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210212183324_202102122133', N'5.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210213094855_202102131248', N'5.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210213110151_202102131359', N'5.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210213120255_202102131502', N'5.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210214112904_202102141428', N'5.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210214115109_202102141446', N'5.0.3')
GO
INSERT [dbo].[ArticleCategories] ([ArticleId], [CategoryId], [Id], [InsertDate], [InsertedBy]) VALUES (4, 10, 0, CAST(N'2021-02-13T14:34:01.4427106' AS DateTime2), 0)
INSERT [dbo].[ArticleCategories] ([ArticleId], [CategoryId], [Id], [InsertDate], [InsertedBy]) VALUES (4, 11, 0, CAST(N'2021-02-13T14:34:01.4428514' AS DateTime2), 0)
INSERT [dbo].[ArticleCategories] ([ArticleId], [CategoryId], [Id], [InsertDate], [InsertedBy]) VALUES (5, 1, 0, CAST(N'2021-02-13T15:29:06.7582230' AS DateTime2), 0)
INSERT [dbo].[ArticleCategories] ([ArticleId], [CategoryId], [Id], [InsertDate], [InsertedBy]) VALUES (5, 2, 0, CAST(N'2021-02-13T15:53:02.0590079' AS DateTime2), 0)
INSERT [dbo].[ArticleCategories] ([ArticleId], [CategoryId], [Id], [InsertDate], [InsertedBy]) VALUES (5, 10, 0, CAST(N'2021-02-13T15:29:06.7583279' AS DateTime2), 0)
INSERT [dbo].[ArticleCategories] ([ArticleId], [CategoryId], [Id], [InsertDate], [InsertedBy]) VALUES (6, 1, 0, CAST(N'2021-02-14T10:43:55.3486138' AS DateTime2), 0)
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Title], [ArticleAddress], [Content], [MainPictureResourceId], [AllowComment], [InsertDate], [InsertedBy]) VALUES (4, N'Lorem ipsum', N'lorem-ipsum', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae hendrerit sapien, sit amet tristique tortor. Integer non arcu ac enim scelerisque molestie posuere in metus. Donec pharetra arcu sed molestie hendrerit. In faucibus convallis purus, faucibus rhoncus mauris elementum volutpat. Nullam maximus quis mauris sed facilisis. Nam mollis turpis hendrerit sem ullamcorper, non placerat justo tempus. Sed odio sem, pretium et nibh id, iaculis varius sapien. Quisque at euismod lacus.', 1, 1, CAST(N'2021-02-13T14:34:01.4422375' AS DateTime2), 0)
INSERT [dbo].[Articles] ([Id], [Title], [ArticleAddress], [Content], [MainPictureResourceId], [AllowComment], [InsertDate], [InsertedBy]) VALUES (5, N'string', N'string', N'string', 5, 1, CAST(N'2021-02-13T15:53:02.0589730' AS DateTime2), 0)
INSERT [dbo].[Articles] ([Id], [Title], [ArticleAddress], [Content], [MainPictureResourceId], [AllowComment], [InsertDate], [InsertedBy]) VALUES (6, N'esat', N'string', N'string', 6, 1, CAST(N'2021-02-14T10:42:12.6576264' AS DateTime2), 0)
INSERT [dbo].[Articles] ([Id], [Title], [ArticleAddress], [Content], [MainPictureResourceId], [AllowComment], [InsertDate], [InsertedBy]) VALUES (9, N'string', N'string', N'string', 10, 1, CAST(N'2021-02-14T13:36:19.8558686' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'393aafe4-0eb2-4e23-9717-26fa9c5ef3b4', N'Owner', N'OWNER', N'1a44ef88-6a1c-4f01-a47c-f33ad35fbc83')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4077ffbe-490b-4e8c-99d0-43d819d8b664', N'393aafe4-0eb2-4e23-9717-26fa9c5ef3b4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4077ffbe-490b-4e8c-99d0-43d819d8b664', N'Owner', N'OWNER', N'owner@example.com', N'OWNER@EXAMPLE.COM', 1, N'AQAAAAEAACcQAAAAEAcEZb0B0gjYSNpo/r+/rVGE0dlvoepEABA4nWzS89LmvlZNGmAVT6N5peI60o6v+g==', N'd8d68aab-570c-47ac-971f-839cd5bb49c5', N'449398c1-ee42-406d-a81b-07cad55d104c', N'+111111111111', 1, 0, NULL, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CategoryName], [InsertDate], [InsertedBy]) VALUES (1, N'Game', CAST(N'2021-02-13T15:02:55.6246391' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [CategoryName], [InsertDate], [InsertedBy]) VALUES (2, N'Travel', CAST(N'2021-02-13T15:02:55.6246825' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [CategoryName], [InsertDate], [InsertedBy]) VALUES (3, N'Photography', CAST(N'2021-02-13T15:02:55.6246827' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [CategoryName], [InsertDate], [InsertedBy]) VALUES (10, N'sample category', CAST(N'2021-02-13T14:34:00.7490473' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [CategoryName], [InsertDate], [InsertedBy]) VALUES (11, N'sample category 2', CAST(N'2021-02-13T14:34:00.7490504' AS DateTime2), 0)
INSERT [dbo].[Categories] ([Id], [CategoryName], [InsertDate], [InsertedBy]) VALUES (13, N'string', CAST(N'2021-02-14T18:37:55.7923876' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [Title], [Message], [ArticleId], [InsertDate], [InsertedBy]) VALUES (3, N'string', N'string', 9, CAST(N'2021-02-14T13:36:36.3698531' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Resources] ON 

INSERT [dbo].[Resources] ([Id], [Name], [Url], [Thumbnail], [ContentType], [InsertDate], [InsertedBy]) VALUES (1, N'Mauris quis mauris', N'string', N'string', N'string', CAST(N'2021-02-13T11:03:25.8880000' AS DateTime2), 0)
INSERT [dbo].[Resources] ([Id], [Name], [Url], [Thumbnail], [ContentType], [InsertDate], [InsertedBy]) VALUES (5, N'string', N'string', N'string', N'string', CAST(N'2021-02-13T12:42:59.6890000' AS DateTime2), 0)
INSERT [dbo].[Resources] ([Id], [Name], [Url], [Thumbnail], [ContentType], [InsertDate], [InsertedBy]) VALUES (6, N'string', N'string', N'string', N'string', CAST(N'2021-02-14T07:42:03.9270000' AS DateTime2), 0)
INSERT [dbo].[Resources] ([Id], [Name], [Url], [Thumbnail], [ContentType], [InsertDate], [InsertedBy]) VALUES (7, N'string', N'string', N'string', N'string', CAST(N'2021-02-14T09:32:27.8460000' AS DateTime2), 0)
INSERT [dbo].[Resources] ([Id], [Name], [Url], [Thumbnail], [ContentType], [InsertDate], [InsertedBy]) VALUES (8, N'string', N'string', N'string', N'string', CAST(N'2021-02-14T09:43:51.0190000' AS DateTime2), 0)
INSERT [dbo].[Resources] ([Id], [Name], [Url], [Thumbnail], [ContentType], [InsertDate], [InsertedBy]) VALUES (9, N'string', N'string', N'string', N'string', CAST(N'2021-02-14T09:43:51.0190000' AS DateTime2), 0)
INSERT [dbo].[Resources] ([Id], [Name], [Url], [Thumbnail], [ContentType], [InsertDate], [InsertedBy]) VALUES (10, N'string', N'string', N'string', N'string', CAST(N'2021-02-14T09:43:51.0190000' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Resources] OFF
GO
ALTER TABLE [dbo].[ArticleCategories]  WITH CHECK ADD  CONSTRAINT [FK_ArticleCategories_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([Id])
GO
ALTER TABLE [dbo].[ArticleCategories] CHECK CONSTRAINT [FK_ArticleCategories_Articles_ArticleId]
GO
ALTER TABLE [dbo].[ArticleCategories]  WITH CHECK ADD  CONSTRAINT [FK_ArticleCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ArticleCategories] CHECK CONSTRAINT [FK_ArticleCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Resources_MainPictureResourceId] FOREIGN KEY([MainPictureResourceId])
REFERENCES [dbo].[Resources] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Resources_MainPictureResourceId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Articles_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Articles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Articles_ArticleId]
GO
