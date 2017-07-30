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
            var id = Request.Form["gid"];

            var pageIndex = 0;
            var pageSize = 0;
            var totalPage = 0;
            var totalRecord = 0;
            var gid = 0;

            int.TryParse(pageNum, out pageIndex);
            int.TryParse(numPerPage, out pageSize);

            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 50 : pageSize;
            int.TryParse(id, out gid);

            var list = _ss.GetMHPriceList(gid, pageIndex, pageSize, out totalPage, out totalRecord);

            VM_Page<Tab_MHSale> vm = new VM_Page<Tab_MHSale>();
            vm.pageNum = pageIndex;
            vm.numPerPage = pageSize;
            vm.totalcount = totalRecord;
            vm.option = option;
            vm.list = list;

            ViewBag.ca = vm;
            ViewBag.id = gid;
            ViewBag.glist = _gzhs.GetGZHList();

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
            var a = Request.Form["gid"];    // 公众号名称
            var b = Request.Form["mhid"];   // 漫画名称
            var c = Request.Form["st"];     // 收费类型
            var d = Request.Form["sid"];    // 收费方式
            var e = Request.Form["price"];  // 收费价格

            var gid = 0;
            var mhid = 0;
            var st = 0;
            var sid = 0;
            var price = 0;

            if (!int.TryParse(a, out gid) || gid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择公众号名称" });
            }

            if (!int.TryParse(b, out mhid) || mhid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择漫画" });
            }

            if (!int.TryParse(c, out st) || st == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择收费类型" });
            }

            if (!int.TryParse(d, out sid) || sid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择收费方式" });
            }

            if (!int.TryParse(e, out price) || price == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请填写收费价格" });
            }

            Tab_MHSale m = new Tab_MHSale();
            m.F_Id = mhid;
            m.F_SaleType = sid;
            m.F_Price = price;

            int i = _ss.AddMHSale(m);

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else if (i == 2)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "漫画和收费方式已经添加过" });
            }
            else
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
            }
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult EditView()
        {
            var a = Request.QueryString["id"]; // 漫画id
            var b = Request.QueryString["sid"]; // 售卖类型id

            var mhid = 0;
            var sid = 0;

            if (!int.TryParse(a, out mhid) || mhid == 0)
            {
                return View();
            }

            if (!int.TryParse(b, out sid) || sid == 0)
            {
                return View();
            }

            var m = _ss.GetMHGZH(mhid);

            var m2 = _ss.GetHMSale(mhid, sid);

            var list = _ss.GetSaleist();

            var sm = list.Find(x => x.F_Id == sid);

            var sl = list.FindAll(x => x.F_Type == sm.F_Type);

            ViewBag.m = m;
            ViewBag.m2 = m2;
            ViewBag.sm = sm;
            ViewBag.sl = sl;

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Edit()
        {
            var a = Request.Form["gid"];    // 公众号名称
            var b = Request.Form["mhid"];   // 漫画名称
            var c = Request.Form["st"];     // 收费类型
            var d = Request.Form["sid"];    // 收费方式
            var e = Request.Form["price"];  // 收费价格
            var f = Request.Form["sid2"];   // 原收费方式

            var gid = 0;
            var mhid = 0;
            var st = 0;
            var sid = 0;
            var price = 0;
            var sid2 = 0;

            if (!int.TryParse(a, out gid) || gid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择公众号名称" });
            }

            if (!int.TryParse(b, out mhid) || mhid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择漫画" });
            }

            if (!int.TryParse(c, out st) || st == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择收费类型" });
            }

            if (!int.TryParse(d, out sid) || sid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择收费方式" });
            }

            if (!int.TryParse(e, out price) || price == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请填写收费价格" });
            }

            if (!int.TryParse(f, out sid2) || sid2 == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "请选择收费方式" });
            }

            Tab_MHSale m = new Tab_MHSale();
            m.F_Id = mhid;
            m.F_SaleType = sid;
            m.F_Price = price;
            m.SaleType = sid2;

            int i = _ss.UpdateMHS(m);

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else if (i == 2)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "漫画和收费方式已经添加过" });
            }
            else
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
            }
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Delete()
        {
            var a = Request.QueryString["id"];     // 漫画id
            var b = Request.QueryString["sid"];    // 收费方式id

            var mhid = 0;
            var sid = 0;

            if (!int.TryParse(a, out mhid) || mhid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "漫画不存在" });
            }

            if (!int.TryParse(b, out sid) || sid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "收费方式不存在" });
            }

            Tab_MHSale m = new Tab_MHSale();
            m.F_Id = mhid;
            m.F_SaleType = sid;

            int i = _ss.DeleteMHS(m);

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
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