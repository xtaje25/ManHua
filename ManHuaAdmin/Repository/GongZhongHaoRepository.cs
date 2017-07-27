using Dapper;
using ManHuaAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ManHuaAdmin.Repository
{
    public class GongZhongHaoRepository : ConncetionHelper
    {
        public List<Tab_GongZhongHao> GetGZHList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            PageCriteria page = new PageCriteria();
            page.TableName = "[Tab_GongZhongHao]";
            page.Fields = "[F_Id], [F_GZHName], [F_WXName], [F_Logo], [F_About], [F_CreateDate]";
            page.Condition = "1 = 1";
            page.Sort = "[F_Id] DESC";
            page.PageSize = pageSize;
            page.CurrentPage = pageIndex;

            return CommonRepository.GetSomeList<Tab_GongZhongHao>(page, out totalPage, out totalRecord);
        }

        public int AddGZH(Tab_GongZhongHao m)
        {
            var sql = @"INSERT INTO [Tab_GongZhongHao]
                                   ([F_GZHName]
                                   ,[F_WXName]
                                   ,[F_CreateDate])
                             VALUES
                                   (@F_GZHName
                                   ,@F_WXName
                                   ,@F_CreateDate)";

            var sql1 = "SELECT COUNT(*) FROM[Tab_GongZhongHao] WHERE[F_GZHName] = @F_GZHName";

            var sql2 = "SELECT COUNT(*) FROM[Tab_GongZhongHao] WHERE[F_WXName] = @F_WXName";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    var a = conn.ExecuteScalar(sql1, new { F_GZHName = m.F_GZHName }, tran);

                    var b = conn.ExecuteScalar(sql2, new { F_WXName = m.F_WXName }, tran);

                    if (0 == Convert.ToInt32(a) && 0 == Convert.ToInt32(b))
                    {
                        int r = conn.Execute(sql, new
                        {
                            F_GZHName = m.F_GZHName,
                            F_WXName = m.F_WXName,
                            F_CreateDate = DateTime.Now,
                        }, tran);

                        if (r == 1)
                        {
                            tran.Commit();
                            return 1;
                        }
                    }

                    if (Convert.ToInt32(a) > 0)
                    {
                        tran.Rollback();
                        return 2;
                    }

                    if (Convert.ToInt32(b) > 0)
                    {
                        tran.Rollback();
                        return 3;
                    }
                }
            }

            return 0;
        }

        public int UpdateGZH(Tab_GongZhongHao m)
        {
            var sql = @"UPDATE [Tab_GongZhongHao]
                           SET [F_GZHName] = @F_GZHName
                              ,[F_WXName] = @F_WXName
                         WHERE [F_Id] = @F_Id";

            var sql1 = "SELECT COUNT(*) FROM[Tab_GongZhongHao] WHERE[F_GZHName] = @F_GZHName";

            var sql2 = "SELECT COUNT(*) FROM[Tab_GongZhongHao] WHERE[F_WXName] = @F_WXName";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    var a = conn.ExecuteScalar(sql1, new { F_GZHName = m.F_GZHName }, tran);

                    var b = conn.ExecuteScalar(sql2, new { F_WXName = m.F_WXName }, tran);

                    if (0 == Convert.ToInt32(a) && 0 == Convert.ToInt32(b))
                    {
                        int r = conn.Execute(sql, new
                        {
                            F_GZHName = m.F_GZHName,
                            F_WXName = m.F_WXName,
                            F_Id = m.F_Id,
                        }, tran);

                        if (r == 1)
                        {
                            tran.Commit();
                            return 1;
                        }
                    }

                    if (Convert.ToInt32(a) > 0)
                    {
                        tran.Rollback();
                        return 2;
                    }

                    if (Convert.ToInt32(b) > 0)
                    {
                        tran.Rollback();
                        return 3;
                    }
                }
            }

            return 0;
        }

        public Tab_GongZhongHao GetGZH(int gid)
        {
            var sql = "SELECT F_Id, F_GZHName, F_WXName, F_About, F_Logo FROM dbo.Tab_GongZhongHao WHERE F_Id = @F_Id";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var list = conn.Query<Tab_GongZhongHao>(sql, new { F_Id = gid }).ToList();

                if (list != null && list.Count > 0)
                {
                    Tab_GongZhongHao g = new Tab_GongZhongHao();
                    g.F_Id = list[0].F_Id;
                    g.F_GZHName = list[0].F_GZHName;
                    g.F_WXName = list[0].F_WXName;
                    g.F_About = list[0].F_About;
                    g.F_Logo = list[0].F_Logo;

                    return g;
                }
            }

            return null;
        }

        public int DeleteGZH(int gid)
        {
            var sql = "DELETE FROM dbo.Tab_GongZhongHao WHERE F_Id = @F_Id";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Execute(sql, new { F_Id = gid });
            }
        }

        public int UpdateGZHInfo(Tab_GongZhongHao m)
        {
            if (m.F_Logo == null && m.F_About == null)
                return 1;

            var sql = new StringBuilder();
            sql.Append("UPDATE [Tab_GongZhongHao]");
            if (m.F_About != null)
            {
                sql.Append(" SET [F_About] = @F_About");
            }
            if (m.F_Logo != null)
            {
                if (m.F_About != null)
                    sql.Append(",[F_Logo] = @F_Logo");
                else
                    sql.Append(" SET [F_Logo] = @F_Logo");
            }
            sql.Append(" WHERE [F_Id] = @F_Id");

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Execute(sql.ToString(), new { F_Id = m.F_Id, F_About = m.F_About, F_Logo = m.F_Logo });
            }
        }

        public List<Tab_GongZhongHao> GetGZHList()
        {
            var sql = @"SELECT [F_Id]
                              ,[F_GZHName]
                              ,[F_WXName]
                              ,[F_Logo]
                              ,[F_About]
                              ,[F_CreateDate]
                          FROM [Tab_GongZhongHao]
                      ORDER BY [F_Id] DESC";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<Tab_GongZhongHao>(sql).ToList();
            }
        }
    }
}