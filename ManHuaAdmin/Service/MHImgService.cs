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

        public VM_Tab_MHImg GetMH(int mhid, int sort)
        {
            return mr.GetMH(mhid, sort);
        }

        public List<VM_Tab_MHImg> GetMH2(int mhid, int sort)
        {
            return mr.GetMH2(mhid, sort);
        }

        public List<VM_Tab_MHImg> GetMHList(int mhid)
        {
            return mr.GetMHList(mhid);
        }

        public List<Tab_MHImg> GetMhCount()
        {
            return mr.GetMhCount();
        }
    }
}