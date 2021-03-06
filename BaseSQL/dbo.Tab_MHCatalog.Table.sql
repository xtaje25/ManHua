USE [MH]
GO
/****** Object:  Table [dbo].[Tab_MHCatalog]    Script Date: 2017/08/07 10:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_MHCatalog](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Catalog] [nvarchar](50) NOT NULL,
	[F_Logo] [nvarchar](1000) NULL,
	[F_GZHId] [int] NOT NULL,
	[F_CreateUser] [int] NOT NULL,
	[F_CreateDate] [datetime] NOT NULL,
	[F_About] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Tab_MHCatalog] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Tab_MHCatalog] UNIQUE NONCLUSTERED 
(
	[F_Catalog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tab_MHCatalog] ADD  CONSTRAINT [DF_Tab_MHCatalog_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
