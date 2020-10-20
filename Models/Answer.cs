using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Asp.net_Project.Models;

namespace Asp.net_Project.Models
{
    public class Answer
    {
        
        public int id { get; set; }

        public int question_id { get; set; }

        [Required]
        public string answer { get; set; }


        public int answerd_by_id { get; set; }

        public string answerd_by_name { get; set; }

        public DateTime datatime_answering { get; set; }



    }

   


}