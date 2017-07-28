using ManHuaAdmin.Models;
using ManHuaAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Service
{
    public class MHCatalogService
    {
        MHCatalogRepository mr = new MHCatalogRepository();

        public List<Tab_MHCatalog> GetMHList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            return mr.GetMHList(pageIndex, pageSize, out totalPage, out totalRecord);
        }

        /// <summary>
        /// 0：没执行；1：执行成功；2：目录名称重复；
        /// </summary>
        public int AddMH(Tab_MHCatalog m)
        {
            return mr.AddMH(m);
        }

        public Tab_MHCatalog GetMH(int mhid)
        {
            return mr.GetMH(mhid);
        }

        public int UpdateMH(Tab_MHCatalog m)
        {
            return mr.UpdateMH(m);
        }

        public List<Tab_MHCatalog> GetMHList(int gid)
        {
            return mr.GetMHList(gid);
        }
    }
}