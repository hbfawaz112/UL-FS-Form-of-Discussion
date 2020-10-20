using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp.net_Project.Models
{
    public class Question
    {
        
        public int id { get; set; }

        [Required] // Foreign key
        public int asked_by_who_id { get; set; }

        [Required] // Foreign Key
        public string asked_by_who_name { get; set; }

        [Required]
        public string categorie { get; set; }

        [Required]
        public string classedestination { get; set; }

        [Required]
        public string queston_title { get; set; }

        [Required]
        public string question_detail { get; set; }

        public DateTime asking_date { get; set; }

    }

   
}