USE [MH]
GO
/****** Object:  StoredProcedure [dbo].[AddUrl]    Script Date: 2017/08/07 10:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[AddUrl]
	@F_MenuName NVARCHAR(50) = '',
	@F_URL NVARCHAR(500),
    @F_ParentId INT,
    @F_Site INT,
    @F_AuthName NVARCHAR(50) = '',
    @F_AuthType NVARCHAR(50),
    @OutMenuId INT OUTPUT,
    @OutAuthId INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

    BEGIN  TRANSACTION
    
    DECLARE @Error INT = 0;
    DECLARE @MenuId INT = 0;
    DECLARE @AuthId INT = 0;

    INSERT INTO [Tab_Menu] ([F_Name], [F_URL], [F_ParentId], [F_Site]) VALUES (@F_MenuName, @F_URL, @F_ParentId, @F_Site);
    SELECT @MenuId = SCOPE_IDENTITY(), @Error += @@ERROR;

    INSERT INTO [Tab_Authorization] ([F_Name], [F_AuthType], [F_CreateDate]) VALUES (@F_AuthName, @F_AuthType, GETDATE());
    SELECT @AuthId = SCOPE_IDENTITY(), @Error += @@ERROR;

    INSERT INTO [Tab_Auth_Menu_Relation] ([F_AuthId], [F_MenuId]) VALUES (@AuthId, @MenuId);
    SELECT @Error += SCOPE_IDENTITY();

    SET @OutMenuId = 0;
    SET @OutAuthId = 0;

    IF @Error <> 0
		BEGIN
			ROLLBACK TRANSACTION
		END
	ELSE
		BEGIN
			COMMIT TRANSACTION
            SET @OutMenuId = @MenuId;
            SET @OutAuthId = @AuthId;
		END
END
GO
