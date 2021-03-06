USE [MH]
GO
/****** Object:  Table [dbo].[Tab_MHCatalog]    Script Date: 2017/07/31 15:21:48 ******/
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
 CONSTRAINT [PK_Tab_MHCatalog] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tab_MHCatalog] ON 

INSERT [dbo].[Tab_MHCatalog] ([F_Id], [F_Catalog], [F_Logo], [F_GZHId], [F_CreateUser], [F_CreateDate]) VALUES (1, N'漫画1', N'http://7xiyf4.com1.z0.glb.clouddn.com/MH/1/1/1501485075962.jpg', 1, 1, CAST(N'2017-07-27T18:15:15.030' AS DateTime))
INSERT [dbo].[Tab_MHCatalog] ([F_Id], [F_Catalog], [F_Logo], [F_GZHId], [F_CreateUser], [F_CreateDate]) VALUES (2, N'漫画2', NULL, 3, 2, CAST(N'2017-07-27T18:37:22.353' AS DateTime))
INSERT [dbo].[Tab_MHCatalog] ([F_Id], [F_Catalog], [F_Logo], [F_GZHId], [F_CreateUser], [F_CreateDate]) VALUES (3, N'漫画3', NULL, 3, 1, CAST(N'2017-07-29T16:53:10.227' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tab_MHCatalog] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tab_MHCatalog]    Script Date: 2017/07/31 15:21:48 ******/
ALTER TABLE [dbo].[Tab_MHCatalog] ADD  CONSTRAINT [IX_Tab_MHCatalog] UNIQUE NONCLUSTERED 
(
	[F_Catalog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tab_MHCatalog] ADD  CONSTRAINT [DF_Tab_MHCatalog_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
