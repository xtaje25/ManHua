USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Auth_Menu_Relation]    Script Date: 2017/7/24 22:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_Auth_Menu_Relation](
	[F_AuthId] [int] NOT NULL,
	[F_MenuId] [int] NOT NULL,
 CONSTRAINT [PK_Tab_Auth_Menu_Relation] PRIMARY KEY CLUSTERED 
(
	[F_AuthId] ASC,
	[F_MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (1, 6)
INSERT [dbo].[Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (2, 7)
INSERT [dbo].[Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (3, 8)
INSERT [dbo].[Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (4, 9)
INSERT [dbo].[Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (5, 10)
INSERT [dbo].[Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (6, 11)
INSERT [dbo].[Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (7, 12)
