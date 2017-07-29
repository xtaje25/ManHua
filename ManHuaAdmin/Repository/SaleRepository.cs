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
    public class SaleRepository : ConncetionHelper
    {
        public List<Tab_MHSale> GetMHPriceList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            PageCriteria page = new PageCriteria();
            page.TableName = "Tab_MHSale a JOIN Tab_SaleType b ON a.F_SaleType = b.F_Id JOIN Tab_MHCatalog c ON c.F_Id = a.F_Id JOIN Tab_GongZhongHao d ON d.F_Id = c.F_GZHId";
            page.Fields = "d.F_GZHName GZHName, c.F_Catalog Catalog, a.F_Id, a.F_SaleType, b.F_Type Type, b.F_TypeValue TypeValue, a.F_Price, a.F_CreateDate";
            page.Condition = "1 = 1";
            page.Sort = "a.F_Id DESC";
            page.PageSize = pageSize;
            page.CurrentPage = pageIndex;

            return CommonRepository.GetSomeList<Tab_MHSale>(page, out totalPage, out totalRecord);
        }

        public List<Tab_SaleType> GetSaleist(int type)
        {
            var sql = "SELECT F_Id, F_Type, F_TypeValue FROM Tab_SaleType WHERE F_Type = @F_Type";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<Tab_SaleType>(sql, new { F_Type = type }).ToList();
            }
        }

        public List<Tab_SaleType> GetSaleist()
        {
            var sql = "SELECT [F_Id], [F_Type], [F_TypeValue] FROM [Tab_SaleType]";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<Tab_SaleType>(sql).ToList();
            }
        }

        public int AddMHSale(Tab_MHSale m)
        {
            var sql = @"INSERT INTO [Tab_MHSale]
                                   ([F_Id]
                                   ,[F_SaleType]
                                   ,[F_Price]
                                   ,[F_CreateDate])
                             VALUES
                                   (@F_Id
                                   ,@F_SaleType
                                   ,@F_Price
                                   ,@F_CreateDate)";

            var sql1 = "SELECT COUNT(*) FROM [Tab_MHSale] WHERE [F_Id] = @F_Id AND [F_SaleType] = @F_SaleType";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    var a = conn.ExecuteScalar(sql1, new { F_Id = m.F_Id, F_SaleType = m.F_SaleType }, tran);

                    if (0 == Convert.ToInt32(a))
                    {
                        int r = conn.Execute(sql, new
                        {
                            F_Id = m.F_Id,
                            F_SaleType = m.F_SaleType,
                            F_Price = m.F_Price,
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

        public Tab_MHCatalog GetMHGZH(int mhid)
        {
            var sql = "SELECT a.F_Id, a.F_Catalog, a.F_GZHId, b.F_GZHName GZHName FROM dbo.Tab_MHCatalog a JOIN dbo.Tab_GongZhongHao b ON a.F_GZHId = b.F_Id WHERE a.F_Id = @F_Id";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var list = conn.Query<Tab_MHCatalog>(sql, new { F_Id = mhid }).ToList();

                if (list != null && list.Count > 0)
                {
                    Tab_MHCatalog g = new Tab_MHCatalog();
                    g.F_Id = list[0].F_Id;
                    g.F_Catalog = list[0].F_Catalog;
                    g.F_GZHId = list[0].F_GZHId;
                    g.GZHName = list[0].GZHName;

                    return g;
                }
            }

            return null;
        }

        public Tab_MHSale GetHMSale(int id, int sid)
        {
            var sql = "SELECT F_Id, F_SaleType, F_Price FROM dbo.Tab_MHSale WHERE F_Id = @F_Id AND F_SaleType = @F_SaleType";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var list = conn.Query<Tab_MHSale>(sql, new { F_Id = id, F_SaleType = sid }).ToList();

                if (list != null && list.Count > 0)
                {
                    Tab_MHSale g = new Tab_MHSale();
                    g.F_Id = list[0].F_Id;
                    g.F_SaleType = list[0].F_SaleType;
                    g.F_Price = list[0].F_Price;

                    return g;
                }
            }

            return null;
        }

        public int UpdateMHS(Tab_MHSale m)
        {
            var sql = @"UPDATE [Tab_MHSale]
                           SET [F_SaleType] = @F_SaleType
                              ,[F_Price] = @F_Price
                         WHERE [F_Id] = @F_Id
                           AND [F_SaleType] = @F_SaleType2";

            var sql1 = "SELECT COUNT(*) FROM [Tab_MHSale] WHERE [F_Id] = @F_Id AND [F_SaleType] = @F_SaleType";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                conn.Open();
                if (m.SaleType == m.F_SaleType)
                {
                    return conn.Execute(sql, new
                    {
                        F_SaleType = m.F_SaleType,
                        F_Price = m.F_Price,
                        F_Id = m.F_Id,
                        F_SaleType2 = m.SaleType,
                    });
                }
                else
                {
                    using (SqlTransaction tran = conn.BeginTransaction(IsolationLevel.RepeatableRead))
                    {
                        var a = conn.ExecuteScalar(sql1, new { F_Id = m.F_Id, F_SaleType = m.F_SaleType }, tran);

                        if (0 == Convert.ToInt32(a))
                        {
                            int r = conn.Execute(sql, new
                            {
                                F_SaleType = m.F_SaleType,
                                F_Price = m.F_Price,
                                F_Id = m.F_Id,
                                F_SaleType2 = m.SaleType,
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
            }

            return 0;
        }

        public int DeleteMHS(Tab_MHSale m)
        {
            var sql = "DELETE FROM [Tab_MHSale] WHERE [F_Id] = @F_Id AND [F_SaleType] = @F_SaleType";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Execute(sql, new
                {
                    F_Id = m.F_Id,
                    F_SaleType = m.F_SaleType,
                });
            }
        }
    }
}