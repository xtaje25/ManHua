USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Role_Auth_Relation]    Script Date: 2017/07/24 18:23:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_Role_Auth_Relation](
	[F_RoleId] [int] NOT NULL,
	[F_AuthId] [int] NOT NULL,
 CONSTRAINT [PK_Tab_Role_Auth_Relation] PRIMARY KEY CLUSTERED 
(
	[F_RoleId] ASC,
	[F_AuthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
