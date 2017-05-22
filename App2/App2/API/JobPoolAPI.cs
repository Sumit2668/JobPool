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
                j.Add("name", model.UserName);
                j.Add("user_name", model.UserID);
                j.Add("email", model.EmailID);
                j.Add("password", model.Password);
                j.Add("phone", model.PhoneNo);
                j.Add("gender", model.Gander);

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
                j.Add("company_name", model.CompanyName);
                j.Add("contact_person", model.ContactPerson);
                j.Add("email", model.EmailID);
                j.Add("password", model.Password);
                j.Add("phone", model.PhoneNo);
                j.Add("current_requirment", model.CurrentRequirement);
                j.Add("experience", model.Experience);
                j.Add("skill", model.Skill);
                j.Add("job_role", model.JobRoll);
                j.Add("location", model.Location);
                j.Add("address", model.Address);

                var json = JsonConvert.SerializeObject(j);
                content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(RestURL, content).Result; // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    response_model = new ResponseModel();
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JObject jObj = JObject.Parse(dataObjects);
                    response_model.Error = jObj["error"].ToString();
                    response_model.Message = jObj["message"].ToString();
                    response_model.RCCode = jObj["rccode"].ToString();
                    response_model.Success = jObj["success"].ToString();
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
					response_model.EmailID = jObj["data"]["email"].ToString();
                    response_model.Phone = jObj["data"]["phone"].ToString();
					response_model.Location = jObj["data"]["location"].ToString();
                    response_model.Error = jObj["error"].ToString();
                    response_model.Message = jObj["message"].ToString();
                    response_model.RCCode = jObj["rccode"].ToString();
                    response_model.Success = jObj["success"].ToString();
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
                    response_model.Error = jObj["error"].ToString();
                    response_model.Message = jObj["message"].ToString();
                    response_model.RCCode = jObj["rccode"].ToString();
                    response_model.Success = jObj["success"].ToString();
                 
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
                    response_model.Error = jObj["error"].ToString();
                    response_model.Message = jObj["message"].ToString();
                    response_model.RCCode = jObj["rccode"].ToString();
                    response_model.Success = jObj["success"].ToString();
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
                    response_model.Error = jObj["error"].ToString();
                    response_model.Message = jObj["message"].ToString();
                    response_model.RCCode = jObj["rccode"].ToString();
                    response_model.Success = jObj["success"].ToString();
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
    }
}
