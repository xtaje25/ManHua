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
    public class GongZhongHaoRepository : ConncetionHelper
    {
        public List<T> GetSomeList<T>(PageCriteria page, out int totalPage, out int totalRecord)
        {
            totalPage = 0;
            totalRecord = 0;
            var list = new List<T>();
            using (SqlConnection conn = new SqlConnection(MHConncetionString))
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

        public List<Tab_GongZhongHao> GetGZHList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            PageCriteria page = new PageCriteria();
            page.TableName = "[Tab_GongZhongHao]";
            page.Fields = "[F_Id], [F_GZHName], [F_WXName], [F_Logo], [F_About], [F_CreateDate]";
            page.Condition = "1 = 1";
            page.Sort = "[F_Id] DESC";
            page.PageSize = pageSize;
            page.CurrentPage = pageIndex;

            return GetSomeList<Tab_GongZhongHao>(page, out totalPage, out totalRecord);
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
            var sql = "SELECT F_Id, F_GZHName, F_WXName FROM dbo.Tab_GongZhongHao WHERE F_Id = @F_Id";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var list = conn.Query<Tab_GongZhongHao>(sql, new { F_Id = gid }).ToList();

                if (list != null && list.Count > 0)
                {
                    Tab_GongZhongHao g = new Tab_GongZhongHao();
                    g.F_Id = list[0].F_Id;
                    g.F_GZHName = list[0].F_GZHName;
                    g.F_WXName = list[0].F_WXName;

                    return g;
                }
            }

            return null;
        }
    }
}