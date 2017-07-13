using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                return View(db.Questions.ToList());
            }
        }

    }
}