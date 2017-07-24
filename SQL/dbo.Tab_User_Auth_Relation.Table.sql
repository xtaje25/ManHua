USE [MH]
GO
/****** Object:  Table [dbo].[Tab_User_Auth_Relation]    Script Date: 2017/07/24 18:23:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_User_Auth_Relation](
	[F_UserId] [int] NOT NULL,
	[F_RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Tab_User_Auth_Relation] PRIMARY KEY CLUSTERED 
(
	[F_UserId] ASC,
	[F_RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
