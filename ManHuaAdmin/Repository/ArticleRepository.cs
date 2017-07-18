using Dapper;
using ManHuaAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Repository
{
    public class ArticleRepository : ConncetionHelper
    {
        public List<T> GetSomeList<T>(PageCriteria page, out int totalPage, out int totalRecord)
        {
            totalPage = 0;
            totalRecord = 0;
            var list = new List<T>();
            using (SqlConnection conn = new SqlConnection(TruckhomeConncetionString))
            {
                var p = new DynamicParameters();
                p.Add("@tableName", page.TableName);
                p.Add("@tableFields", page.Fields);
                p.Add("@sqlWhere", page.Condition);
                p.Add("@orderFields", page.Sort);
                p.Add("@pageSize", page.PageSize);
                p.Add("@pageIndex", page.CurrentPage);
                p.Add("@totalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@totalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);

                list = conn.Query<T>("Module_Common_PagerNew", p, commandType: CommandType.StoredProcedure).ToList();

                totalPage = p.Get<int>("@totalPage");
                totalRecord = p.Get<int>("@totalRecord");
            }
            return list;
        }

        public List<AC_Article> GetArticleList(string title, int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            PageCriteria page = new PageCriteria();
            page.TableName = "[AC_Article]";
            page.Fields = "[ArticleId], [Title], [Editor], [PublishDateTime], [IsEnable], [SourceType], [CreateDateTime]";
            if (string.IsNullOrWhiteSpace(title))
                page.Condition = "1 = 1";
            else
                page.Condition = "[Title] like '%" + title + "%'";
            page.Sort = "[ArticleId] DESC";
            page.PageSize = pageSize;
            page.CurrentPage = pageIndex;

            return GetSomeList<AC_Article>(page, out totalPage, out totalRecord);
        }

        public int AddArticle(AC_Article m)
        {
            var sql = @"INSERT INTO [AC_Article]
                                   ([Title]
                                   ,[SourceType]
                                   ,[Editor]
                                   ,[PublishDateTime]
                                   ,[IsEableComment]
                                   ,[IsPublish]
                                   ,[IsEnable]
                                   ,[CreateDateTime]
                                   ,[LastUpdateDateTime]
                                   ,[LastUpdateEditor]
                                   ,[ImageId]
                                   ,[EditorId]
                                   ,[ArticleType])
                             VALUES
                                   (@Title
                                   ,@SourceType
                                   ,@Editor
                                   ,@PublishDateTime
                                   ,@IsEableComment
                                   ,@IsPublish
                                   ,@IsEnable
                                   ,@CreateDateTime
                                   ,@LastUpdateDateTime
                                   ,@LastUpdateEditor
                                   ,@ImageId
                                   ,@EditorId
                                   ,@ArticleType)";

            using (SqlConnection conn = new SqlConnection(TruckhomeConncetionString))
            {
                var r = conn.Execute(sql, new
                {
                    Title = m.Title,
                    SourceType = m.SourceType,
                    Editor = m.Editor,
                    PublishDateTime = m.PublishDateTime,
                    IsEableComment = m.IsEableComment,
                    IsPublish = m.IsPublish,
                    IsEnable = m.IsEnable,
                    CreateDateTime = m.CreateDateTime,
                    LastUpdateDateTime = m.LastUpdateDateTime,
                    LastUpdateEditor = m.LastUpdateEditor,
                    ImageId = m.ImageId,
                    EditorId = m.EditorId,
                    ArticleType = m.ArticleType
                });
                return r;
            }
        }
    }
}