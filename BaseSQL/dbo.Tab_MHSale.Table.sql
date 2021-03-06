USE [MH]
GO
/****** Object:  Table [dbo].[Tab_MHSale]    Script Date: 2017/08/07 10:59:09 ******/
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
ALTER TABLE [dbo].[Tab_MHSale] ADD  CONSTRAINT [DF_Tab_MHSale_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
