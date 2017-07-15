using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Models
{
    public class ViewModels
    {
    }

    public class VM_Paging
    {
        public int pageNum { get; set; }
        public int numPerPage { get; set; }
        public int totalcount { get; set; }
        public int[] option { get; set; }
        public List<AC_Article> list { get; set; }
    }

}