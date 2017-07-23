USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Auth_Menu_Relation]    Script Date: 2017/7/23 19:31:54 ******/
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
