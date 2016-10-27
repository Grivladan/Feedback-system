using FeedbackSystem.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackSystem.WebHost.Controllers
{
    public class FeedBackController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}