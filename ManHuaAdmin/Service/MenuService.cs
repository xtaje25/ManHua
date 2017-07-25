using ManHuaAdmin.Models;
using ManHuaAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Service
{
    public class MenuService
    {
        MenuRepository mr = new MenuRepository();

        public List<Tab_Menu> GetMenuList(int userId)
        {
            return mr.GetMenuList(userId);
        }

        public List<Tab_Menu> GetMenuCatalog()
        {
            return mr.GetMenuCatalog();
        }
    }
}