using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp.net_Project.Models;

namespace Asp.net_Project.Controllers
{
    public class AdminController : Controller
    {
        private ConfigDB db = new ConfigDB();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin_LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin_LogIn(Admin admin)
        {
            var L1 = from adm in db.Admins orderby adm.id select adm;


            foreach (Admin adminlist in L1)
            {
                if (adminlist.username == admin.username && adminlist.password == admin.password)
                {
                    this.Session["loggedin_admin"] = 1;
                  
                    return RedirectToAction("Index", "Admin");
                }

            }



            return RedirectToAction("Admin_LogIn", "Admin", new { val = "ERR" });

        }

        public ActionResult Admin_Logout()
        {
            this.Session["loggedin_admin"] = 0;

            /*this.Session["loggedIn"] = 0;
            this.Session["userfname"] = null;
            this.Session["userlname"] = null;
            this.Session["userid"] = 0;
            this.Session["promotion"] = null;
            */


            return RedirectToAction("Login", "User");
        }

        public ActionResult List_Of_All_User()
        {
            var L = from users in db.Users orderby users.fname select users;

            return View(L);
        }



        // GET: Employee/Delete/5
        public ActionResult Delete(int id) //Delete User
        {
            var user_to_delete = db.Users.Single(m => m.id == id);
            return View(user_to_delete);
        }

        // POST: Employee/Delete/5
        [HttpPost]  //DELETE USER
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var user_to_delete = db.Users.Single(m => m.id == id);
                db.Users.Remove(user_to_delete);
                db.SaveChanges();
                return RedirectToAction("Index","Admin");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult List_Public_All_Quesion()
        {
            // var LL = from q in db.Questions orderby q.id where q.classedestination.Equals("Public Question") select q;

            var LL = from q in db.Questions orderby q.id  select q;
            //OR ORDER BY DATE .
            return View(LL);
        }
        public ActionResult List_Academic_Question()
        {
            var L = from q in db.Questions where q.categorie.Equals("Academic Question")  select q;
            return View(L);

        }

        public ActionResult List_Management_Question()
        {
            var L = from q in db.Questions where q.categorie.Equals("Management Question")  select q;
            return View(L);
            ;
        }

        public ActionResult List_Miscellaneous_Question()
        {
            var L = from q in db.Questions where q.categorie.Equals("Miscellaneous Question")  select q;
            return View(L);

        }




        // GET: Employee/Delete/5
        public ActionResult Delete_Question(int id) //Delete Question
        {
            var question_to_delete = db.Questions.Single(m => m.id == id);
            return View(question_to_delete);
        }

        // POST: Employee/Delete/5
        [HttpPost]  //DELETE Question
        public ActionResult Delete_Qestion(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var question_to_delete = db.Questions.Single(m => m.id == id);
                db.Questions.Remove(question_to_delete);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details_Question(int id)
        {
            var quest = db.Questions.Single(m => m.id == id);

            return View(quest);
        }


        public ActionResult Add_User()
        {

            return View();
        }
        //POST  
        [HttpPost]
        public ActionResult Add_User(User u)
        {
            try
            {

                db.Users.Add(u);
                db.SaveChanges();

                return RedirectToAction("Index","Admin");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Add_Admin()
        {

            return View();
        }
        //POST  
        [HttpPost]
        public ActionResult Add_Admin(Admin u)
        {
            try
            {

                db.Admins.Add(u);
                db.SaveChanges();

                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult See_Answers(int id)
        {
            var L1 = from answers in db.Answers where answers.question_id.Equals(id) select answers;
            return View(L1);

           
        }


        // GET: Employee/Delete/5
        public ActionResult Delete_Answer(int id) //Delete Question
        {
            var answer_to_delete = db.Answers.Single(m => m.id == id);
            return View(answer_to_delete);
        }

        // POST: Employee/Delete/5
        [HttpPost]  //DELETE Question
        public ActionResult Delete_Answer(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var answer_to_delete = db.Answers.Single(m => m.id == id);
                db.Answers.Remove(answer_to_delete);
                db.SaveChanges();
                return RedirectToAction("List_Public_All_Quesion", "Admin");
            }
            catch
            {
                return View();
            }
        }




    }



}