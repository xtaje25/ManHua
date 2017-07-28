using ManHuaAdmin.Models;
using ManHuaAdmin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManHuaAdmin.Controllers
{
    public class SaleController : Controller
    {
        private SaleService _ss = new SaleService();
        private GongZhongHaoService _gzhs = new GongZhongHaoService();
        private MHCatalogService _mhs = new MHCatalogService();

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult PriceView()
        {
            var option = new int[] { 20, 50, 100, 200 };

            var pageNum = Request.Form["pageNum"];
            var numPerPage = Request.Form["numPerPage"];

            var pageIndex = 0;
            var pageSize = 0;
            var totalPage = 0;
            var totalRecord = 0;

            int.TryParse(pageNum, out pageIndex);
            int.TryParse(numPerPage, out pageSize);

            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 50 : pageSize;

            var list = _ss.GetMHPriceList(pageIndex, pageSize, out totalPage, out totalRecord);

            VM_Page<Tab_MHSale> vm = new VM_Page<Tab_MHSale>();
            vm.pageNum = pageIndex;
            vm.numPerPage = pageSize;
            vm.totalcount = totalRecord;
            vm.option = option;
            vm.list = list;

            ViewBag.ca = vm;

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult AddView()
        {
            var glist = _gzhs.GetGZHList();

            ViewBag.glist = glist;

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Add()
        {
            var name = Request.Form["name"];
            var wxin = Request.Form["wxin"];

            if (name == null || name.Length < 1 || name.Length > 200)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "长度必须大于1个字符小于200字符" });
            }

            if (wxin == null || wxin.Length < 1 || wxin.Length > 200)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "长度必须大于1个字符小于200字符" });
            }

            Tab_GongZhongHao m = new Tab_GongZhongHao();
            m.F_GZHName = name;
            m.F_WXName = wxin;

            int i = 9; // 0：没执行；1：执行成功；2：公号名称重复；3：关联微信号重复；

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else if (i == 2)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "公号名称重复" });
            }
            else if (i == 3)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "关联微信号重复" });
            }
            else
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
            }
        }

        /// <summary>
        /// //[{"key", "value"},{"key", "value"}]
        /// </summary>        
        public ActionResult Get()
        {
            var t = Request.QueryString["t"]; // 1:漫画名称; 2:收费方式;
            var i = Request.QueryString["i"]; // 公众号名称id/收费类型id

            if (t != null && i != null)
            {
                int type = 0;
                int id = 0;
                if (int.TryParse(t, out type) && int.TryParse(i, out id) && new int[] { 1, 2 }.Contains(type) && id > 0)
                {
                    var arr = new object();
                    switch (type)
                    {
                        case 1:
                            #region MyRegion
                            var mlist = _mhs.GetMHList(id);

                            object[] array = new object[mlist.Count];
                            for (int j = 0; j < mlist.Count; j++)
                            {
                                array[j] = new { id = mlist[j].F_Id, val = mlist[j].F_Catalog };
                            }
                            arr = array;
                            #endregion
                            break;

                        case 2:
                            #region MyRegion
                            var slist = _ss.GetSaleist(id);

                            object[] array2 = new object[slist.Count];
                            for (int j = 0; j < slist.Count; j++)
                            {
                                var value = "";
                                switch (slist[j].F_Id)
                                {
                                    case 1:
                                        value = "每次10章";
                                        break;

                                    case 2:
                                        value = "每次20章";
                                        break;

                                    case 3:
                                        value = "每次30章";
                                        break;

                                    case 4:
                                        value = "月度(31天x1)";
                                        break;

                                    case 5:
                                        value = "季度(31天x3)";
                                        break;

                                    case 6:
                                        value = "年度(31天x12)";
                                        break;
                                }
                                array2[j] = new { id = slist[j].F_Id, val = value };
                            }
                            arr = array2;
                            #endregion
                            break;
                    }

                    return Json(arr);
                }
                else
                {
                    return Json(new object[] { });
                }
            }
            else
            {
                return Json(new object[] { });
            }
        }
    }
}