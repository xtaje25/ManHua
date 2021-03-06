USE [MH]
GO
/****** Object:  Table [dbo].[Tab_MHImg]    Script Date: 2017/08/07 10:59:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tab_MHImg](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Name] [nvarchar](50) NOT NULL,
	[F_Img] [nvarchar](200) NOT NULL,
	[F_MHId] [int] NOT NULL,
	[F_Sort] [int] NOT NULL,
	[F_IsEnable] [bit] NOT NULL,
	[F_UserId] [int] NOT NULL,
	[F_CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tab_MHImg] PRIMARY KEY CLUSTERED 
(
	[F_MHId] ASC,
	[F_Sort] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tab_MHImg] ADD  CONSTRAINT [DF_Tab_MHImg_F_IsEnable]  DEFAULT ((1)) FOR [F_IsEnable]
GO
ALTER TABLE [dbo].[Tab_MHImg] ADD  CONSTRAINT [DF_Tab_MHImg_F_CreateDate]  DEFAULT (getdate()) FOR [F_CreateDate]
GO
