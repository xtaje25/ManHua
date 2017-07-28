using Dapper;
using ManHuaAdmin.Models;
using System;
using System.Collections.Generic;
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
    }
}