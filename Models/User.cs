using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp.net_Project.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required] 
        public string fname { get; set; }

        [Required]
        public string lname { get; set; }

        [Required] 
        public string email { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string  college { get; set; }

        [Required]
        public string major { get; set; }

         [Required]
         public string language { get; set; } 

        [Required]
        public string classe{ get; set; }

        [Required]
        public string bio { get; set; }

    }



   
      

}