USE [Dictionary]
GO
/****** Object:  Table [dbo].[DictionaryENVN]    Script Date: 11/24/2022 8:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DictionaryENVN](
	[wordID] [int] IDENTITY(1,1) NOT NULL,
	[word] [nvarchar](50) NOT NULL,
	[meaning] [nvarchar](max) NOT NULL,
	[type] [int] NOT NULL,
 CONSTRAINT [PK_DictionaryENVN] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DictionaryVNEN]    Script Date: 11/24/2022 8:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DictionaryVNEN](
	[wordID] [int] NOT NULL,
	[word] [nvarchar](50) NOT NULL,
	[meaning] [nvarchar](max) NOT NULL,
	[type] [int] NOT NULL,
 CONSTRAINT [PK_DictionaryVNEN] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[workTypeENVN]    Script Date: 11/24/2022 8:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[workTypeENVN](
	[ID] [int] NOT NULL,
	[wordType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_workTypeENVN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[workTypeVNEN]    Script Date: 11/24/2022 8:33:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[workTypeVNEN](
	[ID] [int] NOT NULL,
	[wordType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_workTypeVNEN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DictionaryENVN] ON 

INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (1, N'account', N'tài khoản', 1)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (2, N'action', N'hành động', 1)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (3, N'academic', N'học thuật', 3)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (4, N'baby', N'em bé', 1)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (5, N'buy', N'mua', 2)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (6, N'bubble', N'bong bóng', 1)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (7, N'cat', N'con mèo', 1)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (8, N'now', N'hiện tại', 4)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (9, N'opposite', N'đối diện', 5)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (10, N'cry', N'khóc', 2)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (11, N'kitchen', N'nhà bếp', 1)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (12, N'school', N'trường học', 1)
INSERT [dbo].[DictionaryENVN] ([wordID], [word], [meaning], [type]) VALUES (13, N'sun', N'mặt trời', 1)
SET IDENTITY_INSERT [dbo].[DictionaryENVN] OFF
GO
INSERT [dbo].[DictionaryVNEN] ([wordID], [word], [meaning], [type]) VALUES (2, N'Bằng cấp', N'Degree', 2)
INSERT [dbo].[DictionaryVNEN] ([wordID], [word], [meaning], [type]) VALUES (3, N'Chơi game', N'Playing game', 1)
INSERT [dbo].[DictionaryVNEN] ([wordID], [word], [meaning], [type]) VALUES (4, N'Thú vị', N'Interesting', 3)
INSERT [dbo].[DictionaryVNEN] ([wordID], [word], [meaning], [type]) VALUES (5, N'Vui vẻ', N'Happy', 3)
INSERT [dbo].[DictionaryVNEN] ([wordID], [word], [meaning], [type]) VALUES (6, N'Bên trên', N'Above', 5)
INSERT [dbo].[DictionaryVNEN] ([wordID], [word], [meaning], [type]) VALUES (7, N'Bên trái', N'Left', 5)
INSERT [dbo].[DictionaryVNEN] ([wordID], [word], [meaning], [type]) VALUES (8, N'Tốt', N'Well', 4)
GO
INSERT [dbo].[workTypeENVN] ([ID], [wordType]) VALUES (1, N'Noun')
INSERT [dbo].[workTypeENVN] ([ID], [wordType]) VALUES (2, N'Verb')
INSERT [dbo].[workTypeENVN] ([ID], [wordType]) VALUES (3, N'Adjective')
INSERT [dbo].[workTypeENVN] ([ID], [wordType]) VALUES (4, N'Adverb')
INSERT [dbo].[workTypeENVN] ([ID], [wordType]) VALUES (5, N'Preposition')
GO
INSERT [dbo].[workTypeVNEN] ([ID], [wordType]) VALUES (1, N'Động từ')
INSERT [dbo].[workTypeVNEN] ([ID], [wordType]) VALUES (2, N'Danh từ')
INSERT [dbo].[workTypeVNEN] ([ID], [wordType]) VALUES (3, N'Tính từ')
INSERT [dbo].[workTypeVNEN] ([ID], [wordType]) VALUES (4, N'Trạng từ')
INSERT [dbo].[workTypeVNEN] ([ID], [wordType]) VALUES (5, N'Giới từ')
GO
ALTER TABLE [dbo].[DictionaryENVN]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryENVN_workTypeENVN] FOREIGN KEY([type])
REFERENCES [dbo].[workTypeENVN] ([ID])
GO
ALTER TABLE [dbo].[DictionaryENVN] CHECK CONSTRAINT [FK_DictionaryENVN_workTypeENVN]
GO
ALTER TABLE [dbo].[DictionaryVNEN]  WITH CHECK ADD  CONSTRAINT [FK_DictionaryVNEN_workTypeVNEN] FOREIGN KEY([type])
REFERENCES [dbo].[workTypeVNEN] ([ID])
GO
ALTER TABLE [dbo].[DictionaryVNEN] CHECK CONSTRAINT [FK_DictionaryVNEN_workTypeVNEN]
GO
