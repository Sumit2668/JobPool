using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App2.Droid.CustomRenderer;
using App2.CustomRenderer;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace App2.Droid.CustomRenderer
{
    class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                //if (ForgotPasswordPage.flag == 1)
                //    Control.Gravity = Android.Views.GravityFlags.Center;
            }
        }
    }
}