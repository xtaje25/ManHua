USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Role]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_Role](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tab_Role] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tab_Role] ON 

INSERT [dbo].[Tab_Role] ([F_Id], [F_Name]) VALUES (1, N'系统管理员')
INSERT [dbo].[Tab_Role] ([F_Id], [F_Name]) VALUES (2, N'公号管理员')
INSERT [dbo].[Tab_Role] ([F_Id], [F_Name]) VALUES (3, N'公号编辑')
INSERT [dbo].[Tab_Role] ([F_Id], [F_Name]) VALUES (4, N'财务')
SET IDENTITY_INSERT [dbo].[Tab_Role] OFF
