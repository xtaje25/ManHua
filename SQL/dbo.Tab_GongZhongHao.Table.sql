USE [MH]
GO
/****** Object:  Table [dbo].[Tab_GongZhongHao]    Script Date: 2017/07/26 18:17:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_GongZhongHao](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_GZHName] [nvarchar](200) NOT NULL,
	[F_WXName] [nvarchar](200) NOT NULL,
	[F_Logo] [nvarchar](1000) NULL,
	[F_About] [nvarchar](4000) NULL,
	[F_CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tab_GongZhongHao] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tab_GongZhongHao] ON 

INSERT [dbo].[Tab_GongZhongHao] ([F_Id], [F_GZHName], [F_WXName], [F_Logo], [F_About], [F_CreateDate]) VALUES (1, N'123123', N'123123', NULL, NULL, CAST(N'2017-07-26T16:36:19.617' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tab_GongZhongHao] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tab_GongZhongHao]    Script Date: 2017/07/26 18:17:45 ******/
ALTER TABLE [dbo].[Tab_GongZhongHao] ADD  CONSTRAINT [IX_Tab_GongZhongHao] UNIQUE NONCLUSTERED 
(
	[F_GZHName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tab_GongZhongHao_1]    Script Date: 2017/07/26 18:17:45 ******/
ALTER TABLE [dbo].[Tab_GongZhongHao] ADD  CONSTRAINT [IX_Tab_GongZhongHao_1] UNIQUE NONCLUSTERED 
(
	[F_WXName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tab_GongZhongHao] ADD  CONSTRAINT [DF_Tab_GongZhongHao_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
