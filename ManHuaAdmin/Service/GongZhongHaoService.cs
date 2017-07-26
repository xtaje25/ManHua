using ManHuaAdmin.Models;
using ManHuaAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Service
{
    public class GongZhongHaoService
    {
        GongZhongHaoRepository gzhr = new GongZhongHaoRepository();

        public List<Tab_GongZhongHao> GetGZHList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            return gzhr.GetGZHList(pageIndex, pageSize, out totalPage, out totalRecord);
        }

        /// <summary>
        /// 0：没执行；1：执行成功；2：公号名称重复；3：关联微信号重复；
        /// </summary>
        public int AddGZH(Tab_GongZhongHao m)
        {
            return gzhr.AddGZH(m);
        }

        public int UpdateGZH(Tab_GongZhongHao m)
        {
            return gzhr.UpdateGZH(m);
        }

        public Tab_GongZhongHao GetGZH(int gid)
        {
            return gzhr.GetGZH(gid);
        }
    }
}