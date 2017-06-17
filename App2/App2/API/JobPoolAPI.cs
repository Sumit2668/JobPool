using App2.Models;
using App2.StaticMethod;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace App2.API
{
    public  class JobPoolAPI
    {
        public readonly string BaseURL = "http://smtgroup.in/jobpools/wdiapi/index.php/";
     
        #region CandidateReg
        public ResponseModel postCandidateReg(CandidateRegMdl model)
        {
            ResponseModel response_model = null;
            StringContent content;
            try
            {
                var RestURL = BaseURL + "candidate_register";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("name", model.EMAIL);
                j.Add("user_name", model.UserID);
                j.Add("email", model.NAME);
                j.Add("password", model.Password);
                j.Add("phone", model.PHONE);
                j.Add("gender", model.GENDER);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ResponseModel();
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                }

            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region EployeeReg
        public ResponseModel postEmployerReg(EmployerRegMdl model)
        {
            ResponseModel response_model = null;
            StringContent content;
            try
            {
                var RestURL = BaseURL + "employer_register";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("company_name", model.COMPANY_NAME);
                j.Add("contact_person", model.CONTACT_PERSON);
                j.Add("email", model.EMAIL);
                j.Add("password", model.Password);
                j.Add("phone", model.PHONE);
                j.Add("current_requirment", model.CURRENT_REQUIRMENT);
                j.Add("experience", model.EXPERIENCE);
                j.Add("skill", model.SKILL);
                j.Add("job_role", model.JOBROLL);
                j.Add("location", model.LOCATION);
                j.Add("address", model.ADDRESS);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ResponseModel();
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.ERROR = jObj["error"].ToString();
                    response_model.MESSAGE = jObj["message"].ToString();
                    response_model.RCCODE = jObj["rccode"].ToString();
                    response_model.SUCCESS = jObj["success"].ToString();
                }
            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region Login
        public ResponseModel postLogin(string Email,string Pass)
        {
            ResponseModel response_model = new ResponseModel();
            StringContent content;
            try
            {
                var RestURL = BaseURL + "user_login";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("email", Email);
                j.Add("password", Pass);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
					response_model.UserID = jObj["data"]["user_id"].ToString();
					response_model.UserName = jObj["data"]["username"].ToString();
					response_model.EMAIL = jObj["data"]["email"].ToString();
                    response_model.PHONE = jObj["data"]["phone"].ToString();
					response_model.LOCATION = jObj["data"]["location"].ToString();
                    response_model.ERROR = jObj["error"].ToString();
                    response_model.MESSAGE = jObj["message"].ToString();
                    response_model.RCCODE = jObj["rccode"].ToString();
                    response_model.SUCCESS = jObj["success"].ToString();
                }

            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region ForgatPassword
        public ResponseModel postForgetPass(string ForgatePass)
        {
            ResponseModel response_model = null;
            StringContent content;
            try
            {
                var RestURL = BaseURL + "candidate_forgot_password";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("email", ForgatePass);
                
                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ResponseModel();
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.ERROR = jObj["error"].ToString();
                    response_model.MESSAGE = jObj["message"].ToString();
                    response_model.RCCODE = jObj["rccode"].ToString();
                    response_model.SUCCESS = jObj["success"].ToString();
                 
                }

            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region Logout
        public ResponseModel postLogout(string ForgatePass)
        {
            ResponseModel response_model = null;
            StringContent content;
            try
            {
                var RestURL = BaseURL + "candidate_logout";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("email", ForgatePass);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ResponseModel();
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.ERROR = jObj["error"].ToString();
                    response_model.MESSAGE = jObj["message"].ToString();
                    response_model.RCCODE = jObj["rccode"].ToString();
                    response_model.SUCCESS = jObj["success"].ToString();
                }

            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region Change Password
        public ResponseModel postChangePassword(string Email, string OldPass, string NewPass)
        {
            ResponseModel response_model = new ResponseModel();
            StringContent content;
            try
            {
                var RestURL = BaseURL + "candidate_changed_password";
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("email", Email);
                j.Add("old_password", OldPass);
                j.Add("new_password", NewPass);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {

                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.ERROR = jObj["error"].ToString();
                    response_model.MESSAGE = jObj["message"].ToString();
                    response_model.RCCODE = jObj["rccode"].ToString();
                    response_model.SUCCESS = jObj["success"].ToString();
                }

            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region Get Profile Details
        public ProfileDetails postgetProfileDetails(string Email)
        {
            ProfileDetails response_model = null;
            StringContent content;
            try
            {
                var RestURL = BaseURL + "get_profile";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("email", Email);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ProfileDetails();
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.EMPLOYER_ID = jObj["data"]["employer_id"].ToString();
                    response_model.COMPANY_NAME = jObj["data"]["company_name"].ToString();
                    response_model.CONTACT_PERSON = jObj["data"]["contact_person"].ToString();
                    response_model.EMAIL = jObj["data"]["email"].ToString();
                    response_model.PHONE = jObj["data"]["phone"].ToString();
                    response_model.CURRENT_REQUIRMENT = jObj["data"]["current_requirment"].ToString();
                    response_model.EXPERIENCE = jObj["data"]["experience"].ToString();
                    response_model.SKILL = jObj["data"]["skill"].ToString();
                    response_model.JOB_ROLE = jObj["data"]["job_role"].ToString();
                    response_model.LOCATION = jObj["data"]["location"].ToString();
                    response_model.ADDRESS = jObj["data"]["address"].ToString();
                    response_model.EXP_DATE = jObj["data"]["exp_date"].ToString();
                    response_model.PACKAGE = jObj["data"]["package"].ToString();
                    response_model.AMOUNT = jObj["data"]["amount "].ToString();
                    response_model.USER_TYPE = jObj["data"]["user_type"].ToString();

                }

            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region Update Candidate
        public ResponseModel postUpdateCandidateProfile(CandidateRegMdl model)
        {
            ResponseModel response_model = null;
            StringContent content;
            try
            {
                var RestURL = BaseURL + "candidate_register";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("name", model.NAME);
                j.Add("phone", model.PHONE);
                j.Add("gender", model.GENDER);
                j.Add("location", model.LOCATION);
                j.Add("experience", model.EXPERIENCE);
                j.Add("skill", model.SKILL);
                j.Add("email", model.EMAIL);
                j.Add("strength", model.STRENGTH);
                j.Add("expected_salary", model.EXPECTED_SALARY);
                j.Add("address", model.ADDRESS);
                j.Add("prefered_location", model.PREFERED_LOCATION);
                j.Add("objective", model.OBJECTIVE);
                j.Add("brief_description", model.BRIEF_DESCRIPTION);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ResponseModel();
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.NAME = jObj["data"]["name"].ToString();
                    response_model.GENDER= jObj["data"]["gender"].ToString();
                    response_model.LOCATION= jObj["data"]["location"].ToString();
                    response_model.EMAIL = jObj["data"]["email"].ToString();
                    response_model.PHONE = jObj["data"]["phone"].ToString();
                    response_model.EXPECTED_SALARY= jObj["data"]["expected_salary"].ToString();
                    response_model.EXPERIENCE = jObj["data"]["experience"].ToString();
                    response_model.SKILL = jObj["data"]["skill"].ToString();
                    response_model.STRENGTH = jObj["data"]["strength"].ToString();
                    response_model.ADDRESS = jObj["data"]["address"].ToString();
                    response_model.PREFERED_LOCATION = jObj["data"]["prefered_location"].ToString();
                    response_model.OBJECTIVE = jObj["data"]["objective"].ToString();
                    response_model.BRIEF_DESCRIPTION = jObj["data"]["brief_description"].ToString();
                    response_model.USER_TYPE = jObj["data"]["user_type"].ToString();
                    response_model.ERROR = jObj["error"].ToString();
                    response_model.MESSAGE = jObj["message"].ToString();
                    response_model.RCCODE = jObj["rccode"].ToString();
                    response_model.SUCCESS = jObj["success"].ToString();
                }

            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
        #region Employer Update Profile
        public ResponseModel postEmployerUpdateProfile(ResponseModel model)
        {
            ResponseModel response_model = null;
            StringContent content;
            try
            {
                var RestURL = BaseURL + "employer_update";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);

                JObject j = new JObject();
                j.Add("company_name", model.COMPANY_NAME);
                j.Add("phone", model.PHONE);
                j.Add("contact_person", model.CONTACT_PERSON);
                j.Add("current_requirment", model.CURRENT_REQUIRMENT);
                j.Add("experience", model.EXPERIENCE);
                j.Add("skill", model.SKILL);
                j.Add("email", model.EMAIL);
                j.Add("job_role", model.JOB_ROLE);
                j.Add("location", model.LOCATION);
                j.Add("address", model.ADDRESS);
               
                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ResponseModel();
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.COMPANY_NAME = jObj["data"]["company_name"].ToString();
                    response_model.CONTACT_PERSON= jObj["data"]["contact_person"].ToString();
                    response_model.PHONE = jObj["data"]["phone"].ToString();
                    response_model.CURRENT_REQUIRMENT = jObj["data"]["current_requirment"].ToString();
                    response_model.EXPERIENCE = jObj["data"]["experience"].ToString();
                    response_model.SKILL= jObj["data"]["skill"].ToString();
                    response_model.JOB_ROLE= jObj["data"]["job_role"].ToString();
                    response_model.LOCATION = jObj["data"]["location"].ToString();
                    response_model.ADDRESS= jObj["data"]["address"].ToString();
                    response_model.EMAIL = jObj["data"]["email"].ToString();
                    response_model.USER_TYPE = jObj["data"]["user_type"].ToString();
                    response_model.ERROR = jObj["error"].ToString();
                    response_model.MESSAGE = jObj["message"].ToString();
                    response_model.RCCODE = jObj["rccode"].ToString();
                    response_model.SUCCESS = jObj["success"].ToString();
                }
            }
            catch (Exception e)
            {
                StaticMethods.AndroidSnackBar(e.Message);
            }
            finally
            {
                content = null;
            }
            return response_model;
        }
        #endregion
    }
}
