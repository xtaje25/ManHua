using ManHuaAdmin.Models;
using ManHuaAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Service
{
    public class SaleService
    {
        SaleRepository sr = new SaleRepository();

        public List<Tab_MHSale> GetMHPriceList(int gid, int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            return sr.GetMHPriceList(gid, pageIndex, pageSize, out totalPage, out totalRecord);
        }

        public List<Tab_SaleType> GetSaleist(int type)
        {
            return sr.GetSaleist(type);
        }

        public List<Tab_SaleType> GetSaleist()
        {
            return sr.GetSaleist();
        }

        public int AddMHSale(Tab_MHSale m)
        {
            return sr.AddMHSale(m);
        }

        public Tab_MHCatalog GetMHGZH(int mhid)
        {
            return sr.GetMHGZH(mhid);
        }

        public Tab_MHSale GetHMSale(int id, int sid)
        {
            return sr.GetHMSale(id, sid);
        }

        public int UpdateMHS(Tab_MHSale m)
        {
            return sr.UpdateMHS(m);
        }

        public int DeleteMHS(Tab_MHSale m)
        {
            return sr.DeleteMHS(m);
        }
    }
}