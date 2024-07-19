using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;



namespace BAIPetRegMobileApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
        }

        private async Task<bool> CheckAndRequestPermissions()
        {
            var cameraPermission = ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera);
            var writePermission = ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage);
            var readPermission = ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage);

            if (cameraPermission == Permission.Granted && writePermission == Permission.Granted && readPermission == Permission.Granted)
            {
                return true;
            }

            ActivityCompat.RequestPermissions(this, new string[]
            {
            Manifest.Permission.Camera,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.ReadExternalStorage
            }, 0);

            return false;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            // Check if permissions were granted
            bool allPermissionsGranted = grantResults.All(result => result == Permission.Granted);

            if (!allPermissionsGranted)
            {
                // Handle the case where permissions are not granted
                Toast.MakeText(this, "Permissions are required for this functionality", ToastLength.Short).Show();
            }
        }

    }
}
