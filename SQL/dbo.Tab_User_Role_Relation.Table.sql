USE [MH]
GO
/****** Object:  Table [dbo].[Tab_User_Role_Relation]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_User_Role_Relation](
	[F_UserId] [int] NOT NULL,
	[F_RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Tab_User_Role_Relation] PRIMARY KEY CLUSTERED 
(
	[F_UserId] ASC,
	[F_RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tab_User_Role_Relation] ([F_UserId], [F_RoleId]) VALUES (1, 1)
INSERT [dbo].[Tab_User_Role_Relation] ([F_UserId], [F_RoleId]) VALUES (2, 2)
INSERT [dbo].[Tab_User_Role_Relation] ([F_UserId], [F_RoleId]) VALUES (3, 2)
INSERT [dbo].[Tab_User_Role_Relation] ([F_UserId], [F_RoleId]) VALUES (4, 2)
