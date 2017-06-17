using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.Models
{
    public class ResponseModel
    {
        public string ERROR { get; set; }
        public string RCCODE { get; set; }
        public string SUCCESS { get; set; }
        public string MESSAGE { get; set; }
        public string LOCATION{ get; set; }
		public string UserID { get; set; }
		public string UserName { get; set; }
		public string EMAIL { get; set;}    
		public string PHONE {get;set;}
        public string NAME { get; set; }
        public string GENDER { get; set; }
        public string EXPERIENCE { get; set; }
        public string SKILL { get; set; }
        public string STRENGTH { get; set; }
        public string EXPECTED_SALARY { get; set; }
        public string ADDRESS { get; set; }
        public string PREFERED_LOCATION { get; set; }
        public string OBJECTIVE { get; set; }
        public string BRIEF_DESCRIPTION { get; set; }
        public string USER_TYPE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string CURRENT_REQUIRMENT { get; set; }
        public string JOB_ROLE { get; set; }
        

    }
}
