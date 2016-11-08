using Android.App;
using Android.Widget;
using Android.OS;

namespace TestApplication
{
	[Activity (Label = "Kibic 2.0", MainLauncher = false,ScreenOrientation=Android.Content.PM.ScreenOrientation.SensorLandscape,Theme = "@android:style/Theme.Holo.DialogWhenLarge.NoActionBar")]			
	public class EkranSklady : Activity
	{
	//	int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.EkranSklady);

			var imageView1 = FindViewById<ImageView>(Resource.Id.imageView1);
			imageView1.SetBackgroundResource (Resource.Drawable.SKLADY);
			imageView1.Click+= (object sender, System.EventArgs e) => {
				StartActivity(typeof(PierwszyEkran2));
			};
		}

			// Get our button from the layout resource,
			// and attach an event to it

	}
}



