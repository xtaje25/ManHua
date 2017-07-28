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

        public List<Tab_MHSale> GetMHPriceList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            return sr.GetMHPriceList(pageIndex, pageSize, out totalPage, out totalRecord);
        }

        public List<Tab_SaleType> GetSaleist(int type)
        {
            return sr.GetSaleist(type);
        }
    }
}