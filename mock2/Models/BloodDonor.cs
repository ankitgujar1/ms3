using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mock2.Models
{
    public class BloodDonor
    {
        public int ID{get;set;}
        public string? Name{get;set;}
        public DateTime DOB{get;set;}
        public string Gender{get;set;}
        public string BloodGroup{get;set;}
        public string MobileNumber{get;set;}
        public string Email{get;set;}
        public string Location{get;set;}
        
    }
}