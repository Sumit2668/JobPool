using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Models
{
    public class EmployerRegMdl
    {
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
       
        public string CurrentRequirement { get; set; }
        public string Experience { get; set; }
        public string Skill { get; set; }
        public string JobRoll { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
    }
}
