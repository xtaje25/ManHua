using Dapper;
using ManHuaAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Repository
{
    public class MHImgRepository : ConncetionHelper
    {
        public List<VM_Tab_MHImg> GetImgList(int mhid)
        {
            var sql = @"SELECT [F_Name]
                              ,[F_Img]
                              ,[F_MHId]
                              ,[F_Sort]
                          FROM [Tab_MHImg]
                          WHERE [F_MHId] = @F_MHId";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<VM_Tab_MHImg>(sql, new { F_MHId = mhid }).ToList();
            }
        }
    }
}