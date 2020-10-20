using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp.net_Project.Models;

namespace Asp.net_Project.Controllers
{
    public class AnswerController : Controller
    {

        private ConfigDB db = new ConfigDB();

        public ActionResult show()
        {
            var LL = from a in db.Answers orderby a.id select a;
            return View(LL);

        }


        public ActionResult answer_question(int id)
        {

            if ((int)Session["userid"] == 0)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                Session["question_id"] = id;


                return View();
            }
        }

        [HttpPost]
        public ActionResult answer_question(Answer ans)
        {

            Answer answer = new Answer();

            try
            {
                int question_id_to_answer = (int)Session["question_id"];

                answer.question_id = question_id_to_answer;
                answer.answer = ans.answer;
                answer.answerd_by_id = (int)Session["userid"];
                answer.answerd_by_name = Session["userfname"].ToString() + " " + Session["userlname"].ToString();
                answer.datatime_answering = DateTime.Now;

                db.Answers.Add(answer);
                db.SaveChanges();

                return RedirectToAction("Index" , "Question");


            }
            catch
            {

                return View();
            }
        }


        public ActionResult See_Other_Answers(int id)
        {
            var L1 = from answers in db.Answers where answers.question_id.Equals(id) select answers;
            return View(L1);
        }


    }
}