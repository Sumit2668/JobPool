﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2.Droid
{
    [Activity(Theme = "@style/Theme.Splash"
                     , MainLauncher =true,
                       NoHistory =true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(1000); //Let's wait awhile...

            this.StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}