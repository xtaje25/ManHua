using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ManHuaAdmin.Repository
{
    public class ConncetionHelper
    {
        protected static readonly string TruckhomeConncetionString = ""; // WebConfigurationManager.ConnectionStrings["TruckhomeConncetionString"].ConnectionString;
        protected static readonly string MHConncetionString = WebConfigurationManager.ConnectionStrings["MHConncetionString"].ConnectionString;
    }
}