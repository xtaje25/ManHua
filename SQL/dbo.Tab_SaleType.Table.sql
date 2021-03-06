USE [MH]
GO
/****** Object:  Table [dbo].[Tab_SaleType]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_SaleType](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Type] [int] NOT NULL,
	[F_TypeValue] [int] NOT NULL,
 CONSTRAINT [PK_Tab_SaleType] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tab_SaleType] ON 

INSERT [dbo].[Tab_SaleType] ([F_Id], [F_Type], [F_TypeValue]) VALUES (1, 1, 10)
INSERT [dbo].[Tab_SaleType] ([F_Id], [F_Type], [F_TypeValue]) VALUES (2, 1, 20)
INSERT [dbo].[Tab_SaleType] ([F_Id], [F_Type], [F_TypeValue]) VALUES (3, 1, 30)
INSERT [dbo].[Tab_SaleType] ([F_Id], [F_Type], [F_TypeValue]) VALUES (4, 2, 31)
INSERT [dbo].[Tab_SaleType] ([F_Id], [F_Type], [F_TypeValue]) VALUES (5, 2, 93)
INSERT [dbo].[Tab_SaleType] ([F_Id], [F_Type], [F_TypeValue]) VALUES (6, 2, 372)
SET IDENTITY_INSERT [dbo].[Tab_SaleType] OFF
