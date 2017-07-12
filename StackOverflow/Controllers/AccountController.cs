using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult Delete(int id)
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                User user = db.Users.Find(id);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User account)
        {
            if(ModelState.IsValid)
            {
                using (UserAccountEntities db = new UserAccountEntities())
                {
                    db.Users.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully added.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                var usr = db.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if(usr != null)
                {
                    Session["ID"] = usr.ID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
            }
            return View();
        } 

        public ActionResult Edit(int id)
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                User user = db.Users.Find(id);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            using (UserAccountEntities db = new UserAccountEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
        }

        public ActionResult Log_out()
        {
            Session["ID"] = null;
            Session["Username"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}