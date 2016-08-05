using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace AppNetA.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public FileStreamResult GetPDF()
        {
            String pth = Server.MapPath("~");
            FileStream fs = new FileStream(pth+"/Content/Report.pdf", FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");
        }
        public ActionResult Visualize()
        {
            return View();
        }
    }
}
