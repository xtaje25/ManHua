﻿using ManHuaAdmin.Models;
using ManHuaAdmin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManHuaAdmin.Service
{
    public class ArticleService
    {
        ArticleRepository ar = new ArticleRepository();

        public List<AC_Article> GetArticleList(int pageIndex, int pageSize, out int totalPage, out int totalRecord)
        {
            return ar.GetArticleList(pageIndex, pageSize, out totalPage, out totalRecord);
        }
    }
}