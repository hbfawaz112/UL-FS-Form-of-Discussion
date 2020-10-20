using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp.net_Project.Models;
using Asp.net_Project.Controllers;

namespace Asp.net_Project.Controllers
{
    public class QuestionController : Controller
    {

        //private QuestionDBContext db = new QuestionDBContext();

        // private UserDBContext dbusers = new UserDBContext();

        private ConfigDB db = new ConfigDB();


        public ActionResult show()
        {
            var LL = from q in db.Questions orderby q.id select q;
            return View(LL);

        }

        

        // GET: Question
        public ActionResult Index() // here we select * from table where categorie = public 
        {
            var L = from q in db.Questions where q.classedestination.Equals("Public Question") select q;
            return View(L);
        }


        public ActionResult Ask_Question()
        {
            if ((int)Session["userid"] == 0)
            {
                return RedirectToAction("Login", "User");
            }
            else {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Ask_Question(Question Qes)
        {
            

           

                Question question = new Question();

                try
                {
                    //HERE WE SELECT NAME FROM USER WHERE ID = ID (THIS ID FROM SESSION IJBERE !!)
                    //W HEDA L2ESEM B7OTTO BL question.asked_by_who. 


                    question.asked_by_who_id = (int)Session["userid"];
                    question.asked_by_who_name = Session["userfname"].ToString() + " " + Session["userlname"].ToString();
                    question.categorie = Qes.categorie;
                    question.classedestination = Qes.classedestination;
                    question.queston_title = Qes.queston_title;
                    question.question_detail = Qes.question_detail;
                    question.asking_date = DateTime.Now;

                    db.Questions.Add(question);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                catch
                {
                    return View();
                }
            
        }




        public ActionResult Direst_Question_For_Me()
        {

            int myid = (int)Session["userid"];
            var l = from qes in db.Questions where qes.classedestination.Equals(myid.ToString()) select qes;

            return View(l);
        }

        public ActionResult Direct_Question_Within_My_Promotion()
        {
            // get the id from session ymknnn :(  , we bs7ab lclass halle ele min user table.
            //brja3 b3ml list btsewe select from question where classdestination = halle s7bata abla 
            // w b3abbe hlist blview .

            if ((int)Session["userid"] == 0)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                string prom = Session["promotion"].ToString();
                var l = from qe in db.Questions where qe.classedestination.Equals(prom) select qe;
                return View(l);
            }

           // return View();
        }

        public ActionResult Academic_Question()
        {
            var L = from q in db.Questions where q.categorie.Equals("Academic Question") & q.classedestination.Equals("Public Question")  select q;
            return View(L);
            
        }

        public ActionResult Management_Question()
        {
            var L = from q in db.Questions where q.categorie.Equals("Management Question") & q.classedestination.Equals("Public Question") select q;
            return View(L);
            ;
        }

        public ActionResult Miscellaneous_Question()
        {
            var L = from q in db.Questions where q.categorie.Equals("Miscellaneous Question") & q.classedestination.Equals("Public Question") select q;
            return View(L);
            
        }

        public ActionResult list_of_my_question()
        {
            int myid = (int)Session["userid"];
            var list_of_question = from q in db.Questions where q.asked_by_who_id.Equals(myid) select q;
            return View(list_of_question);
        }




        
        public ActionResult Ask_Him_Question(int id)
        {
            if ((int)Session["userid"] == 0)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                Session["userid_foraskhim"] = id;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Ask_Him_Question(Question Qes)
        {




            Question question = new Question();

            try
            {
                int iddestination = (int)Session["userid_foraskhim"];

                //var fname = from fn in db.Users where fn.id.Equals(iddestination) select fn.fname;

               


                question.asked_by_who_id = (int)Session["userid"];
                question.asked_by_who_name = Session["userfname"].ToString() + " " + Session["userlname"].ToString();
                question.categorie = Qes.categorie;
                question.classedestination = iddestination.ToString();
                question.queston_title = Qes.queston_title;
                question.question_detail = Qes.question_detail;
                question.asking_date = DateTime.Now;

                db.Questions.Add(question);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }

        }
        

    }
}