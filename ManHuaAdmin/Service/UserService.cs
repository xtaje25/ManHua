using ManHuaAdmin.Models;
using ManHuaAdmin.Repository;
using ManHuaAdmin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Service
{
    public class UserService
    {
        UserRepository ur = new UserRepository();

        public List<Tab_User> GetUserList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            return ur.GetUserList(pageIndex, pageSize, out totalPage, out totalRecord);
        }

        public Tab_User GetUser(string name, string password)
        {
            return ur.GetUser(name, password);
        }

        public int UpdatePassword(int uid, string opwd, string npwd)
        {
            return ur.UpdatePassword(uid, opwd, npwd);
        }

        public int AddUser(Tab_User m)
        {
            return ur.AddUser(m);
        }

        public Tab_User_GZH_Relation GetUserGZH(int uid)
        {
            return ur.GetUserGZH(uid);
        }

        public int ResetPassword(int uid)
        {
            var pwd = Tools.MD5Encrypt32("123456");
            return ur.ResetPassword(uid, pwd);
        }

        public int DeleteUser(int uid)
        {
            return ur.DeleteUser(uid);
        }
    }
}