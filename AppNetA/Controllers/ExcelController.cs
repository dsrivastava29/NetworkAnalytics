using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppNetA.Controllers
{
    public class ExcelController : Controller
    {
            public ActionResult ExcelResult() {
            String pth = Server.MapPath("~");
            DataTable dt = Helper.ReadExcelFile("DecemberFilteredMonthlyNetworkD", pth+"/Content/Excel/DecemberFilteredMonthlyNetworkData.csv");
            dt = dt.AsEnumerable().Take(100).CopyToDataTable();
            return PartialView(dt); //passing the DataTable as my Model
        }
    }
}