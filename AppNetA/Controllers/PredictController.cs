using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AppNetA.Models;
using System.Data;

namespace AppNetA.Controllers
{
    public class PredictController : Controller
    {
        public PredictController()
        {
        }
        
        // GET: /PredictController/Regression
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Regression()
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /PredictController/Regression
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Regression(PredictModel model)
        {
            string response = RegressionCallOutPrediction.PredictCallOutRegression(model);
            // If we got this far, something failed, redisplay form
            if (response != "Error")
            {
                model.callOutActivity = float.Parse(response);
            }
            return View(model);
        }

        public ActionResult Classify()
        {
            //ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Classify(PredictModel model)
        {
            string response = ClassificationActivity.Classify(model);
            string[] values = response.Split('-');

            // If we got this far, something failed, redisplay form
            if (response != "Error")
            {
                model.category = values[0];
                model.probability = float.Parse(values[1]);
            }
            return View(model);
        }


        #region Helpers
        // Used for XSRF protection when adding external logins
        // private const string XsrfKey = "XsrfId";
        #endregion
    }
}
