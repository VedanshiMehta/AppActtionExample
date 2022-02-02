using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace AppActtionExample
{

    [IntentFilter(new[]{Xamarin.Essentials.Platform.Intent.ActionAppAction}, Categories = new[] { Android.Content.Intent.CategoryDefault })]
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            try
            {
                AppActions.SetAsync(

                    new AppAction("app_info", "AppAction", icon: "ic_launcher"),
                    new AppAction("home_info", "Home", icon: "ic_home"),
                    new AppAction("fav_info", "Favourites", icon: "ic_fav"),
                    new AppAction("notifi_info", "Notification", icon: "ic_notification"));


            }
            catch (FeatureNotSupportedException e)
            { 
                Console.WriteLine("App Action Not Supported");
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}