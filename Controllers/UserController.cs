using Asp.net_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.net_Project.Controllers
{
    
    public class UserController : Controller
    {

        private ConfigDB db = new ConfigDB();


        public ActionResult show()
        {

            
            
                var L2 = from u in db.Users orderby u.id select u;
                return View(L2);
            
        }
        // GET: User
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            
            var L1 = from us in db.Users orderby us.id select us;


            foreach (User userinlist  in L1)
            {
                 if(userinlist.username == user.username && userinlist.password == user.password)
                {
                    this.Session["loggedIn"] =1;
                    //HttpContext.Session.Add("UserID", user.id);
                    this.Session["userid"] = userinlist.id;
                    this.Session["userfname"] = userinlist.fname;
                    this.Session["userlname"] = userinlist.lname;
                    this.Session["promotion"] = userinlist.classe;

                    return RedirectToAction("Index", "Question");
                }
                
            }
            
            

                return RedirectToAction("Login","User", new { val = "ERR" });
            

            
        }

        public ActionResult Logout()
        {
            this.Session["loggedIn"] = 0;
            this.Session["userfname"] = null;
            this.Session["userlname"] = null;
            this.Session["userid"] = 0;
            this.Session["promotion"] = null;



            return RedirectToAction("Login", "User");
        }

        public ActionResult SignUp()
        {

            return View();
        }
        //POST  
        [HttpPost]
        public ActionResult SignUp(User u)
        {
            try
            {

                db.Users.Add(u);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SeeProfile(int id)
        {
            
            var userprofile = db.Users.FirstOrDefault(m => m.id == id);
            return View(userprofile);
        }

        public ActionResult UpdateProfile()
        {
            int useridd = (Int32)Session["userid"];

            var usertoupdate = db.Users.Single(m => m.id == useridd);
            return View(usertoupdate);
           
        }
        [HttpPost]
        public ActionResult UpdateProfile(User u)
        {
            try
            {
                int useridd = (Int32)Session["userid"];
                var usertoupdate = db.Users.Single(m => m.id == useridd);

                if (TryUpdateModel(usertoupdate))
                {
                    db.SaveChanges();


                    //UPDATR THE SESSION LEZM :(.
                    return RedirectToAction("Logout", "User");

                }
                return View(usertoupdate);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult List_Of_User()
        {
            var list_of_user = from lu in db.Users orderby lu.fname select lu;
            return View(list_of_user);
        }




    }
}