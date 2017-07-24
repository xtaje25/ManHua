USE [MH]
GO
/****** Object:  Table [dbo].[Tab_User_Auth_Relation]    Script Date: 2017/7/24 22:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_User_Auth_Relation](
	[F_UserId] [int] NOT NULL,
	[F_AuthId] [int] NOT NULL,
 CONSTRAINT [PK_Tab_User_Auth_Relation] PRIMARY KEY CLUSTERED 
(
	[F_UserId] ASC,
	[F_AuthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tab_User_Auth_Relation] ([F_UserId], [F_AuthId]) VALUES (1, 1)
INSERT [dbo].[Tab_User_Auth_Relation] ([F_UserId], [F_AuthId]) VALUES (1, 2)
INSERT [dbo].[Tab_User_Auth_Relation] ([F_UserId], [F_AuthId]) VALUES (1, 3)
INSERT [dbo].[Tab_User_Auth_Relation] ([F_UserId], [F_AuthId]) VALUES (1, 4)
INSERT [dbo].[Tab_User_Auth_Relation] ([F_UserId], [F_AuthId]) VALUES (1, 5)
INSERT [dbo].[Tab_User_Auth_Relation] ([F_UserId], [F_AuthId]) VALUES (1, 6)
INSERT [dbo].[Tab_User_Auth_Relation] ([F_UserId], [F_AuthId]) VALUES (1, 7)
