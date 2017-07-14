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


        [HttpPost]
        public ActionResult Index(Question question)
        {
            if(ModelState.IsValid)
            {
                using (UserAccountEntities db = new UserAccountEntities())
                {
                    question.UserID = Int32.Parse(Session["ID"].ToString());
                    db.Questions.Add(question);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Your question has been successfully added";
            }
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