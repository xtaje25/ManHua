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

        public int GetLastSort(int mhid)
        {
            var sql = @"SELECT MAX(F_Sort) F_Sort FROM dbo.Tab_MHImg WHERE F_MHId = @F_MHId";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var s = conn.ExecuteScalar(sql, new { F_MHId = mhid });
                return Convert.ToInt32(s);
            }
        }

        public VM_Tab_MHImg GetMH(int mhid, int sort)
        {
            var sql = "SELECT F_Id, F_Name, F_Img, F_MHId, F_Sort FROM Tab_MHImg WHERE F_MHId = @F_MHId AND F_Sort = @F_Sort";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                var i = conn.Query<VM_Tab_MHImg>(sql, new { F_MHId = mhid, F_Sort = sort }).ToList();

                if (i.Count > 0)
                {
                    VM_Tab_MHImg m = new VM_Tab_MHImg();
                    m.f_name = i[0].f_name;
                    m.f_img = i[0].f_img;
                    m.f_mhid = i[0].f_mhid;
                    m.f_sort = i[0].f_sort;

                    return m;
                }
            }

            return null;
        }

        public List<VM_Tab_MHImg> GetMH2(int mhid, int sort)
        {
            var sql = "SELECT TOP(2) F_Id, F_Name, F_Img, F_MHId, F_Sort FROM Tab_MHImg WHERE F_MHId = @F_MHId AND F_Sort >= @F_Sort ORDER BY F_Sort";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<VM_Tab_MHImg>(sql, new { F_MHId = mhid, F_Sort = sort }).ToList();
            }
        }

        public List<VM_Tab_MHImg> GetMHList(int mhid)
        {
            var sql = @"SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY F_Sort) sort, F_Id, F_Name, F_Img, F_MHId, F_Sort FROM Tab_MHImg WHERE F_MHId = @F_MHId) AS t";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<VM_Tab_MHImg>(sql, new { F_MHId = mhid }).ToList();
            }
        }

        public List<Tab_MHImg> GetMhCount()
        {
            var sql = "SELECT F_MHId, COUNT(*) F_Count FROM dbo.Tab_MHImg GROUP BY F_MHId";

            using (SqlConnection conn = new SqlConnection(MHConncetionString))
            {
                return conn.Query<Tab_MHImg>(sql).ToList();
            }
        }
    }
}