using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Controllers
{
    public class QuestionController : Controller
    {
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

        public ActionResult UserQuestion()
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                List<Question> list_question = new List<Question>();
                foreach (var item in db.Questions)
                {
                    if(Int32.Parse(item.UserID.ToString()) == Int32.Parse(Session["ID"].ToString()))
                    {
                        list_question.Add(item);
                    }
                }
                return View(list_question);
            }
        }


        public ActionResult Delete(int id)
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                var question = db.Questions.Find(id);
                return View(question);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                var question = db.Questions.Find(id);
                db.Questions.Remove(question);
                db.SaveChanges();
            }
            return RedirectToAction("UserQuestion");
        }


    }
}