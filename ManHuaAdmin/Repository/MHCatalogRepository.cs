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
    public class MHCatalogRepository : ConncetionHelper
    {
        public List<Tab_MHCatalog> GetMHList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            PageCriteria page = new PageCriteria();
            page.TableName = "[Tab_MHCatalog] a JOIN [Tab_GongZhongHao] b ON a.[F_GZHId] = b.[F_Id] JOIN [dbo].[Tab_User] c ON c.F_Id = a.[F_CreateUser]";
            page.Fields = "a.[F_Id], a.[F_Catalog], a.[F_Logo], a.[F_About], a.[F_GZHId], c.[F_Name] [userName], a.[F_CreateUser], a.[F_CreateDate], b.[F_GZHName] [GZHName]";
            page.Condition = "1 = 1";
            page.Sort = "a.[F_Id] DESC";
            page.PageSize = pageSize;
            page.CurrentPage = pageIndex;

            return CommonRepository.GetSomeList<Tab_MHCatalog>(page, out totalPage, out totalRecord);
        }

        public int AddMH(Tab_MHCatalog m)
        {
            var sql = @"INSERT INTO [Tab_MHCatalog]
                                   ([F_Catalog]
                                   ,[F_GZHId]
                                   ,[F_CreateUser]
                                   ,[F_CreateDate])
                             VALUES
                                   (@F_Catalog
                                   ,@F_GZHId
                                   ,@F_CreateUser
                                   ,@F_CreateDate)";

            var sql1 = "SELECT COUNT(*) FROM[Tab_MHCatalog] WHERE[F_Catalog] = @F_Catalog";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    var a = conn.ExecuteScalar(sql1, new { F_Catalog = m.F_Catalog }, tran);

                    if (0 == Convert.ToInt32(a))
                    {
                        int r = conn.Execute(sql, new
                        {
                            F_Catalog = m.F_Catalog,
                            F_GZHId = m.F_GZHId,
                            F_CreateUser = m.F_CreateUser,
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
                }
            }

            return 0;
        }

        public Tab_MHCatalog GetMH(int mhid)
        {
            var sql = "SELECT [F_Id], [F_Catalog], [F_GZHId], [F_CreateUser], [F_CreateDate], [F_About] FROM [Tab_MHCatalog]  WHERE [F_Id] = @F_Id";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var list = conn.Query<Tab_MHCatalog>(sql, new { F_Id = mhid }).ToList();

                if (list != null && list.Count > 0)
                {
                    Tab_MHCatalog g = new Tab_MHCatalog();
                    g.F_Id = list[0].F_Id;
                    g.F_Catalog = list[0].F_Catalog;
                    g.F_GZHId = list[0].F_GZHId;
                    g.F_CreateUser = list[0].F_CreateUser;
                    g.F_CreateDate = list[0].F_CreateDate;

                    return g;
                }
            }

            return null;
        }

        public int UpdateMH(Tab_MHCatalog m)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE [Tab_MHCatalog]");
            sql.Append("   SET [F_Catalog] = @F_Catalog");
            sql.Append("      ,[F_GZHId] = @F_GZHId");
            if (m.F_Logo != null)
            {
                sql.Append("  ,[F_Logo] = @F_Logo");
            }
            if (m.F_About != null)
            {
                sql.Append("  ,[F_About] = @F_About");
            }
            sql.Append(" WHERE [F_Id] = @F_Id");

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Execute(sql.ToString(), new { F_Catalog = m.F_Catalog, F_GZHId = m.F_GZHId, F_Id = m.F_Id, F_Logo = m.F_Logo, F_About = m.F_About });
            }
        }

        public List<Tab_MHCatalog> GetMHList(int gid)
        {
            var sql = "SELECT F_Id, F_Catalog FROM Tab_MHCatalog WHERE F_GZHId = @F_GZHId";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<Tab_MHCatalog>(sql, new { F_GZHId = gid }).ToList();
            }
        }

        public List<VM_Tab_MHCatalog> GetMHList()
        {
            var sql = @"SELECT [F_Id]
                              ,[F_Catalog]
                              ,[F_Logo]
                              ,[F_GZHId]
                              ,[F_About]
                          FROM [Tab_MHCatalog]
                          ORDER BY [F_Id]";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<VM_Tab_MHCatalog>(sql).ToList();
            }
        }

        public VM_Tab_MHCatalog GetAPIMH(int mhid)
        {
            var sql = "SELECT F_Id, F_Catalog, F_Logo, F_GZHId, F_About FROM dbo.Tab_MHCatalog WHERE F_Id = @F_Id";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var list = conn.Query<VM_Tab_MHCatalog>(sql, new { F_Id = mhid }).ToList();

                if (list != null && list.Count > 0)
                {
                    VM_Tab_MHCatalog g = new VM_Tab_MHCatalog();
                    g.f_id = list[0].f_id;
                    g.f_catalog = list[0].f_catalog;
                    g.f_logo = list[0].f_logo;
                    g.f_gzhid = list[0].f_gzhid;
                    g.f_about = list[0].f_about;

                    return g;
                }
            }

            return null;
        }
    }
}