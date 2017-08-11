using ManHuaAdmin.Models;
using ManHuaAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Service
{
    public class MHImgService
    {
        MHImgRepository mr = new MHImgRepository();

        public List<VM_Tab_MHImg> GetImgList(int mhid)
        {
            return mr.GetImgList(mhid);
        }

        public int GetLastSort(int mhid)
        {
            return mr.GetLastSort(mhid);
        }
    }
}