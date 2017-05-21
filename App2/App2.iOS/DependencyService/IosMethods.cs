using App2.iOS.DependencyService;
using System;
using App2.Models;
using App2.NativeInterface;
using BigTed;
using PerpetualEngine.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(IosMethods))]
namespace App2.iOS.DependencyService
{
	public class IosMethods : IIosMethods
	{
		private string Key = "fazza_driver";
		public IosMethods()
		{
		}

		public string GetIdentifier()
		{
			var id = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			return id;
		}

		public void ShowToast(string msg, string str)
		{
			BTProgressHUD.ShowToast(msg, (ProgressHUD.ToastPosition)3, 2000);
		}

		public void ShowToast(string msg)
		{
			BTProgressHUD.ShowToast(msg, ProgressHUD.MaskType.Black, false, 2000);
		}
		public void ShowLoader()
		{
			BTProgressHUD.Show();
		}
		public void DismissLoader()
		{
			BTProgressHUD.Dismiss();
		}
		public void SaveLocalData(ResponseModel um)
		{
			try
			{
				var storage = SimpleStorage.EditGroup(Key);
				storage.Put("UserID", um.UserID);
				storage.Put("UserName", um.UserName);
				storage.Put("EmailID", um.EmailID);
				storage.Put("Location", um.Location);
				storage.Put("Message", um.Message);
				storage.Put("Phone", um.Phone);
				//storage.Put("LoginGUID", um.LoginGUID);
				//storage.Put("LoginSessionKey", um.LoginSessionKey);
				//storage.Put("redirect_back_url", um.redirect_back_url);
				//storage.Put("IsSignup", um.IsSignup);
				//storage.Put("DeviceToken", um.DeviceToken);
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
				var storage = SimpleStorage.EditGroup(Key);
				um.UserID = storage.Get("UserID", null);
				um.UserName = storage.Get("UserName", null);
				um.EmailID = storage.Get("EmailID", null);
				um.Location = storage.Get("Location", null);
				um.Message = storage.Get("Message", null);
				um.Phone = Convert.ToString(storage.Get("JsonPhone", null));
				//um.LoginSessionKey = storage.Get("LoginSessionKey", null);
				//um.redirect_back_url = storage.Get("redirect_back_url", null);
				//um.IsSignup = storage.Get("IsSignup", false);
				//um.DeviceToken = storage.Get("DeviceToken", "");

				return um;
			}
			catch (Exception)
			{
				return um;
			}
		}
		public void DeleteLocalData()
		{
			string values = string.Empty;
			try
			{
                //var storage = SimpleStorage.EditGroup(Key);
				//storage.Delete(Key);

			}
			catch (Exception)
			{

			}
		}

		ResponseModel IIosMethods.RetriveLocalData()
		{
			throw new NotImplementedException();
		}
	}
}
