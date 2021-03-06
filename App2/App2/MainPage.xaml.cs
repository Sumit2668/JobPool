﻿using App2.API;
using App2.Menuitems;
using App2.Models;
using App2.StaticMethod;
using App2.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App2
{
	public partial class MainPage : MasterDetailPage
	{
		JobPoolAPI api = new JobPoolAPI();
		public List<MasterPageItem> menuList { get; set; }
		public MainPage()
		{
			InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            menuList = new List<MasterPageItem>();

			// Creating our pages for menu navigation
			// Here you can define title for item, 
			// icon on the left side, and page that you want to open after selection
			var page1 = new MasterPageItem() { Title = "Profie", Icon = "person_black.png", TargetType = typeof(EditProfile) };
			var page2 = new MasterPageItem() { Title = "Search Candidates", Icon = "search.png", TargetType = typeof(EmployeeRegister) };
            var page3 = new MasterPageItem() { Title = "Payment", Icon = "FPayBlack.png", TargetType = typeof(SelectPackages) };
            var page4 = new MasterPageItem() { Title = "Notification", Icon = "notifications.png", TargetType = typeof(FranchiseReg) };
			var page5 = new MasterPageItem() { Title = "About Us", Icon = "about_us.png", TargetType = typeof(AboutUs) };
			var page6 = new MasterPageItem() { Title = "Change Password", Icon = "password.png", TargetType = typeof(ChangePassword) };
			var page7 = new MasterPageItem() { Title = "Privacy Policy", Icon = "assignment.png", TargetType = typeof(CandidateReg) };
			var page8 = new MasterPageItem() { Title = "Terms & Conditions", Icon = "terms.png", TargetType = typeof(HomePage) };
			var page9 = new MasterPageItem() { Title = "Logout", Icon = "logout.png", TargetType = typeof(LoginPage) };

			// Adding menu items to menuList
			menuList.Add(page1);
			menuList.Add(page2);
			menuList.Add(page3);
			menuList.Add(page4);
			menuList.Add(page5);
			menuList.Add(page6);
			menuList.Add(page7);
			menuList.Add(page8);
            menuList.Add(page9);
            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

			// Initial navigation, this can be used for our home page
			Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(JobPool)));
		}

		// Event for Menu Item selection, here we are going to handle navigation based
		// on user selection in menu ListView
		private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
            
			var item = (MasterPageItem)e.SelectedItem;
			if (item.Title == "Logout")
			{
                JobPoolAPI api = new JobPoolAPI();
                ResponseModel user = StaticMethods.GetLocalSavedData();
                api.postLogout(user.EMAIL);
                Navigation.PushModalAsync(new LoginPage());
			}
            if (item.Title == "Change Password")
            {
            await PopupNavigation.PushAsync(new ChangePassword());
            }
            
            else
            {
                Type page = item.TargetType;
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }
		}
	}
}
