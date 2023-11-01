using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace mvcefwithdb.Models
{
    public class RegisterViewModel
    {
        [Display(Name="Enter Name")]
        [Required(ErrorMessage="Enter Username")]
        [RegularExpression("[a-zA-Z\\s.]{1,10}",ErrorMessage="Enter Username in proper format")]
        public string? Username{get;set;}
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Enter Password")]
        public string? Password{get;set;}

        [DataType(DataType.Password)]
        [Required(ErrorMessage="Enter Password")]
        [Compare("Password",ErrorMessage ="Password do not match")]
        public string? ConfirmPassword{get;set;}

        [DataType(DataType.MultilineText)]

        public string?Address{get;set;}

        [Range(10,16,ErrorMessage ="Invalid age")]
        public int Age{get;set;}

        [RegularExpression("\\d{10}",ErrorMessage = "Invalid Date Format")]
        public long Mobile{set;get;}
       
        [DataType(DataType.EmailAddress)]
        public string? Email {set;get;}
 
        [DataType(DataType.Date)]
        public string? JoinDate {set;get;}


    }
}