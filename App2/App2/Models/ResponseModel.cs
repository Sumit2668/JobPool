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
        public string Error { get; set; }
        public string RCCode { get; set; }
        public string Success { get; set; }
        public string Message { get; set; }
        public string Location{ get; set; }
		public string UserID { get; set; }
		public string UserName { get; set; }
		public string EmailID { get; set;}    
		public string Phone{get;set;}
        
	}
}
