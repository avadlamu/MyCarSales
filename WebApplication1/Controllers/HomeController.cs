using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
//using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                using (AnilEntities2 db = new AnilEntities2())
                {
                    var obj = db.Signups.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).FirstOrDefault();
                    if(obj!=null)
                    {
                        Session["Name"] = obj.FirstName.ToString();
                        Session["Email"] = obj.Email.ToString();
                        return RedirectToAction("ConfirmationLogin", "Home");
                    }
                }
            }
            return View(model);
        }
        public ActionResult ConfirmationLogin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Signup obj)
        {
            if (ModelState.IsValid)
            {
                AnilEntities2 db = new AnilEntities2();
                db.Signups.Add(obj);
                db.SaveChanges();
                return RedirectToAction("ConfirmationPage", "Home");
            }
            
            return View(obj);           
        }
        public ActionResult ConfirmationPage()
        {
            return View();
        }
        public ActionResult Dealers()
        {
            return View();
        }
        public ActionResult Sell()
        {
            //return RedirectToAction("ConfirmationPage", "Home");
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}