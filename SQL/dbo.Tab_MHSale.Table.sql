USE [MH]
GO
/****** Object:  Table [dbo].[Tab_MHSale]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_MHSale](
	[F_Id] [int] NOT NULL,
	[F_SaleType] [int] NOT NULL,
	[F_Price] [int] NOT NULL,
	[F_CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tab_MHSale] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC,
	[F_SaleType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tab_MHSale] ([F_Id], [F_SaleType], [F_Price], [F_CreateDate]) VALUES (1, 1, 2, CAST(N'2017-07-30T00:28:00.780' AS DateTime))
INSERT [dbo].[Tab_MHSale] ([F_Id], [F_SaleType], [F_Price], [F_CreateDate]) VALUES (2, 2, 6, CAST(N'2017-07-29T17:05:10.833' AS DateTime))
INSERT [dbo].[Tab_MHSale] ([F_Id], [F_SaleType], [F_Price], [F_CreateDate]) VALUES (3, 4, 3, CAST(N'2017-07-29T17:05:23.007' AS DateTime))
ALTER TABLE [dbo].[Tab_MHSale] ADD  CONSTRAINT [DF_Tab_MHSale_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
