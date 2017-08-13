using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Models
{
    public class VM_Paging
    {
        public int pageNum { get; set; }
        public int numPerPage { get; set; }
        public int totalcount { get; set; }
        public int[] option { get; set; }
        public string title { get; set; }
        public List<AC_Article> list { get; set; }
    }

    public class VM_Page<T>
    {
        public int pageNum { get; set; }
        public int numPerPage { get; set; }
        public int totalcount { get; set; }
        public int[] option { get; set; }
        public List<T> list { get; set; }
    }

    public class ViewModels
    {
        public int status { get; set; }
        public string msg { get; set; } = string.Empty;
        public string data { get; set; } = string.Empty;
    }

    public class ViewModels<T>
    {
        public int status { get; set; }
        public string msg { get; set; } = string.Empty;
        public List<T> data = new List<T>();
    }

    public class ViewModels_obj
    {
        public int status { get; set; }
        public string msg { get; set; } = string.Empty;
        public object data = new { };
    }

    public class VM_Tab_MHCatalog
    {
        public int f_id { get; set; }

        public string f_catalog { get; set; }

        public string f_logo { get; set; }

        public int f_gzhid { get; set; }

        public string f_about { get; set; } = string.Empty;

        public int sort { get; set; }
    }

    public class VM_Tab_MHImg
    {
        public string f_name { get; set; }

        public string f_img { get; set; }

        public int f_mhid { get; set; }

        public int f_sort { get; set; }

        public int sort { get; set; }

        public int previous { get; set; }

        public int next { get; set; }        
    }

}