create database [Kutuphane1]
GO
/****** Object:  Table [dbo].[Kitap_Turleri]    Script Date: 14.03.2024 15:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitap_Turleri](
	[Tur_ID] [int] IDENTITY(1,1) NOT NULL,
	[Tur_Ad] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Tur_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KitaPlar]    Script Date: 14.03.2024 15:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitaPlar](
	[Kitap_ID] [int] IDENTITY(1,1) NOT NULL,
	[Tur_ID] [int] NOT NULL,
	[Kitap_Adi] [varchar](40) NOT NULL,
	[Yazar] [varchar](40) NOT NULL,
	[YayinEvi] [varchar](40) NOT NULL,
	[Sayfa_Sayisi] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Kitap_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odunc_Kitaplar]    Script Date: 14.03.2024 15:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odunc_Kitaplar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ogrenci_No] [int] NOT NULL,
	[Kitap_ID] [int] NOT NULL,
	[Verilis_Tarih] [date] NOT NULL,
	[Teslim_Tarih] [date] NULL,
	[Aciklama] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ogrenci]    Script Date: 14.03.2024 15:57:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ogrenci](
	[Ogrenci_No] [int] NOT NULL,
	[OGR_Ad] [varchar](40) NOT NULL,
	[OGR_Soyad] [varchar](40) NOT NULL,
	[OGR_Sinif] [tinyint] NOT NULL,
	[OGR_Cinsiyet] [varchar](7) NOT NULL,
	[OGR_Tel] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Ogrenci_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kitap_Turleri] ON 

INSERT [dbo].[Kitap_Turleri] ([Tur_ID], [Tur_Ad]) VALUES (1, N'ROMAN')
INSERT [dbo].[Kitap_Turleri] ([Tur_ID], [Tur_Ad]) VALUES (2, N'HİKAYE')
INSERT [dbo].[Kitap_Turleri] ([Tur_ID], [Tur_Ad]) VALUES (3, N'SİİR')
INSERT [dbo].[Kitap_Turleri] ([Tur_ID], [Tur_Ad]) VALUES (4, N'GEZİ')
INSERT [dbo].[Kitap_Turleri] ([Tur_ID], [Tur_Ad]) VALUES (5, N'COCUK')
INSERT [dbo].[Kitap_Turleri] ([Tur_ID], [Tur_Ad]) VALUES (6, N'KİSİSEL BAKIM')
INSERT [dbo].[Kitap_Turleri] ([Tur_ID], [Tur_Ad]) VALUES (7, N'SAGLİK')
SET IDENTITY_INSERT [dbo].[Kitap_Turleri] OFF
GO
SET IDENTITY_INSERT [dbo].[KitaPlar] ON 

INSERT [dbo].[KitaPlar] ([Kitap_ID], [Tur_ID], [Kitap_Adi], [Yazar], [YayinEvi], [Sayfa_Sayisi]) VALUES (1, 1, N'bisey', N'ikisey', N'birseyler', 225)
INSERT [dbo].[KitaPlar] ([Kitap_ID], [Tur_ID], [Kitap_Adi], [Yazar], [YayinEvi], [Sayfa_Sayisi]) VALUES (2, 1, N'a', N'ab', N'abc', 220)
INSERT [dbo].[KitaPlar] ([Kitap_ID], [Tur_ID], [Kitap_Adi], [Yazar], [YayinEvi], [Sayfa_Sayisi]) VALUES (3, 1, N'1', N'12', N'123', 225)
INSERT [dbo].[KitaPlar] ([Kitap_ID], [Tur_ID], [Kitap_Adi], [Yazar], [YayinEvi], [Sayfa_Sayisi]) VALUES (4, 2, N'bisey', N'ikisey', N'birseyler', 225)
INSERT [dbo].[KitaPlar] ([Kitap_ID], [Tur_ID], [Kitap_Adi], [Yazar], [YayinEvi], [Sayfa_Sayisi]) VALUES (5, 3, N'a', N'ab', N'abc', 220)
SET IDENTITY_INSERT [dbo].[KitaPlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Odunc_Kitaplar] ON 

INSERT [dbo].[Odunc_Kitaplar] ([ID], [Ogrenci_No], [Kitap_ID], [Verilis_Tarih], [Teslim_Tarih], [Aciklama]) VALUES (1, 210, 3, CAST(N'2020-02-12' AS Date), NULL, NULL)
INSERT [dbo].[Odunc_Kitaplar] ([ID], [Ogrenci_No], [Kitap_ID], [Verilis_Tarih], [Teslim_Tarih], [Aciklama]) VALUES (2, 256, 2, CAST(N'2024-03-12' AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Odunc_Kitaplar] OFF
GO
INSERT [dbo].[Ogrenci] ([Ogrenci_No], [OGR_Ad], [OGR_Soyad], [OGR_Sinif], [OGR_Cinsiyet], [OGR_Tel]) VALUES (210, N'Berkay', N'Gürsoy', 10, N'Erkek', N'0736745')
INSERT [dbo].[Ogrenci] ([Ogrenci_No], [OGR_Ad], [OGR_Soyad], [OGR_Sinif], [OGR_Cinsiyet], [OGR_Tel]) VALUES (256, N'Berkay1', N'Gürsoy1', 11, N'Erkek', N'036575')
INSERT [dbo].[Ogrenci] ([Ogrenci_No], [OGR_Ad], [OGR_Soyad], [OGR_Sinif], [OGR_Cinsiyet], [OGR_Tel]) VALUES (357, N'Berkay2', N'Gürsoy3', 9, N'Erkek', N'0787645')
INSERT [dbo].[Ogrenci] ([Ogrenci_No], [OGR_Ad], [OGR_Soyad], [OGR_Sinif], [OGR_Cinsiyet], [OGR_Tel]) VALUES (448, N'Berkay4', N'Gürsoy6', 12, N'Erkek', N'7543745')
INSERT [dbo].[Ogrenci] ([Ogrenci_No], [OGR_Ad], [OGR_Soyad], [OGR_Sinif], [OGR_Cinsiyet], [OGR_Tel]) VALUES (586, N'Berkay2', N'Gürsoy8', 8, N'Erkek', N'0736745')
INSERT [dbo].[Ogrenci] ([Ogrenci_No], [OGR_Ad], [OGR_Soyad], [OGR_Sinif], [OGR_Cinsiyet], [OGR_Tel]) VALUES (653, N'hggfhxf', N'xfthnfnxc', 11, N'ERKEK', N'34567890')
GO
ALTER TABLE [dbo].[KitaPlar]  WITH CHECK ADD  CONSTRAINT [FK_KitaPlar_Kitap_Turleri] FOREIGN KEY([Tur_ID])
REFERENCES [dbo].[Kitap_Turleri] ([Tur_ID])
GO
ALTER TABLE [dbo].[KitaPlar] CHECK CONSTRAINT [FK_KitaPlar_Kitap_Turleri]
GO
ALTER TABLE [dbo].[Odunc_Kitaplar]  WITH CHECK ADD  CONSTRAINT [FK_Odunc_Kitaplar_KitaPlar] FOREIGN KEY([Kitap_ID])
REFERENCES [dbo].[KitaPlar] ([Kitap_ID])
GO
ALTER TABLE [dbo].[Odunc_Kitaplar] CHECK CONSTRAINT [FK_Odunc_Kitaplar_KitaPlar]
GO
ALTER TABLE [dbo].[Odunc_Kitaplar]  WITH CHECK ADD  CONSTRAINT [FK_Odunc_Kitaplar_Ogrenci] FOREIGN KEY([Ogrenci_No])
REFERENCES [dbo].[Ogrenci] ([Ogrenci_No])
GO
ALTER TABLE [dbo].[Odunc_Kitaplar] CHECK CONSTRAINT [FK_Odunc_Kitaplar_Ogrenci]
GO
