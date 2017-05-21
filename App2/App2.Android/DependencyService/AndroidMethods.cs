using Plugin.CurrentActivity;
using Android.App;
using Android.Widget;
using App2.Droid.DependencyService;
using App2.NativeInterface;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Content;
using System;
using App2.Models;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace App2.Droid.DependencyService
{
    public class AndroidMethods : IAndroidMethods
    {
        Dialog d;
        public string GetIdentifier()
        {
            var id = Android.OS.Build.Serial;
            return id;
        }

        public void ShowToast(string msg)
        {
            Toast.MakeText(Forms.Context, msg, ToastLength.Long).Show();
        }
        public void ShowSnakBar(string
		                        message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            Snackbar.Make(activityRootView, message, Snackbar.LengthLong).Show();
        }
		public void SaveLocalData(ResponseModel um)
        {
            try
            {
                //store

                var prefs = Android.App.Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
                var storage = prefs.Edit();
				storage.PutString("UserID", um.UserID);
				storage.PutString("UserName", um.UserName);
				storage.PutString("EmailID", um.EmailID);
				storage.PutString("Message", um.Message);
				storage.PutString("Location", um.Location);
				storage.PutString("Phone", um.Phone.ToString());
                //storage.PutString("LoginGUID", um.LoginGUID);
                //storage.PutString("LoginSessionKey", um.LoginSessionKey);
                //storage.PutString("redirect_back_url", um.redirect_back_url);
                //storage.PutString("IsSignup", um.IsSignup.ToString());
                storage.Commit();
            }
            catch (Exception e)
            {

            }
        }

        public void DeleteLocalData()
        {
            try
            {
                //store
                var prefs = Android.App.Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
                var storage = prefs.Edit();

                storage.PutString("UserID", "");
                storage.PutString("UserName", "");
                storage.PutString("EmailID", "");
                storage.PutString("Message", "");
                storage.PutString("Location", "");
                storage.PutString("Phone", "");
                //storage.PutString("LoginGUID", "");
                //storage.PutString("LoginSessionKey", "");
                //storage.PutString("redirect_back_url", "");
                //storage.PutString("IsSignup", "");
                storage.Commit();
            }
            catch (Exception)
            {

            }
        }

		public ResponseModel RetriveLocalData()
        {
			ResponseModel um = new ResponseModel();
            try
            {
                //retreive 
                var storage = Android.App.Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);

				um.UserID = Convert.ToString(storage.GetString("UserID", null));
				um.UserName = storage.GetString("UserName", null);
				um.EmailID = storage.GetString("EmailID", null);
				um.Location = storage.GetString("Location", null);
				um.Message = storage.GetString("Message", null);
                //um.UserTypeID = Convert.ToInt32(storage.GetString("UserTypeID", null));
                //um.LoginGUID = Convert.ToString(storage.GetString("LoginGUID", null));
                //um.LoginSessionKey = storage.GetString("LoginSessionKey", null);
                //um.redirect_back_url = storage.GetString("redirect_back_url", null);
                //um.IsSignup = Convert.ToBoolean(storage.GetString("IsSignup", "false"));

                return um;
            }
            catch (Exception ex)
            {
                return um;
            }

        }

        public void ShowLoader()
        {
            d = new Dialog(Forms.Context);
            //d.SetContentView(Resource.Layout.CustomProgressDialog);
            d.SetCancelable(false);
            d.Window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));
            d.Show();

        }
        public void DismissLoader()
        {
            if (d != null)
                d.Dismiss();
        }
    }
}
