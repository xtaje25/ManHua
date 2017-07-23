USE [MH]
GO
/****** Object:  Table [dbo].[Tab_Menu]    Script Date: 2017/7/23 19:31:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_Menu](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Name] [nvarchar](50) NOT NULL,
	[F_URL] [nvarchar](500) NOT NULL,
	[F_ParentId] [int] NOT NULL,
 CONSTRAINT [PK_Tab_Menu] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Tab_Menu] ADD  CONSTRAINT [DF_Tab_Menu_F_ParentId]  DEFAULT ((0)) FOR [F_ParentId]
GO
