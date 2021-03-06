USE [MH]
GO
/****** Object:  StoredProcedure [dbo].[Module_Common_PagerNew]    Script Date: 2017/07/31 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Module_Common_PagerNew]
	@tableName   varchar(5000),        -- 表名 update by zhangm varchar长度从1000改到5000 2013/11/14
	@tableFields varchar(5000) = '*',  -- 字段名(全部字段为*)
	@sqlWhere    varchar(5000) = NULL, -- 条件语句(不加 where，可带 group by 分组条件，分组条件需要带 group by 关键字)
	@orderFields varchar(5000),        -- 排序字段(必须，支持多字段，不加 order by)
	@pageSize    int,                  -- 页大小(每页多少条记录)
	@pageIndex   int = 1 ,             -- 指定当前为第几页
	@totalPage   int output,           -- 返回总页数
    @totalRecord int output
AS
BEGIN
	Begin Tran -- 开始事务

	Declare @sql nvarchar(4000);
--	Declare @totalRecord int;

	-- 计算总记录数
	if (@sqlWhere = '' or @sqlWhere = NULL)
		set @sql = 'select @totalRecord = count(*) from ' + @tableName
	else
		BEGIN
			if(CHARINDEX('group by', LOWER(@sqlWhere)) > 0)
				set @sql = 'select @totalRecord = count(*) from (select ' + @tableFields + ' from ' + @tableName + ' where ' + @sqlWhere + ') as Tab_GroupTable'
			else
				set @sql = 'select @totalRecord = count(*) from ' + @tableName + ' where ' + @sqlWhere
		END

	print @Sql

	EXEC sp_executesql @sql,N'@totalRecord int OUTPUT',@totalRecord OUTPUT

	-- 计算总页数
	select @totalPage=CEILING((@totalRecord+0.0)/@pageSize)

	-- 处理页数超出范围情况
	if @pageIndex<=0
		Set @pageIndex = 1
	if @pageIndex>@totalPage
		Set @pageIndex = @totalPage

	-- 处理开始点和结束点
	Declare @startRecord int
	Declare @endRecord int
	set @startRecord = (@pageIndex-1)*@pageSize + 1
	set @endRecord = @startRecord + @pageSize - 1

	-- 合成sql语句
	if (@sqlWhere = '' or @sqlWhere = NULL)
		set @sql = 'Select * FROM (select ROW_NUMBER() Over(order by ' + @orderFields + ') as rowId,' + @tableFields + ' from ' + @tableName
	else
		set @sql = 'Select * FROM (select ROW_NUMBER() Over(order by ' + @orderFields + ') as rowId,' + @tableFields + ' from ' + @tableName + ' where ' + @sqlWhere

	set @Sql = @Sql + ') as Tab_TotalTable where rowId between ' + Convert(varchar(50),@startRecord) + ' and ' +  Convert(varchar(50),@endRecord)

	print @Sql
    
	Exec(@Sql)

	if @@Error <> 0
		BEGIN
			RollBack Tran
			Return -1
		END
	else
		BEGIN
			Commit Tran
			Return @totalRecord --- 返回记录总数
		END
END

GO
