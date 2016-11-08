using Android.App;
using Android.Widget;
using Android.OS;

namespace TestApplication
{
	[Activity (Label = "Kibic 2.0", MainLauncher = true, ScreenOrientation=Android.Content.PM.ScreenOrientation.SensorPortrait)]
	public class MainActivity : Activity
	{
	//	int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var imageView1 = FindViewById<ImageView> (Resource.Id.imageView);
			imageView1.SetBackgroundResource (Resource.Drawable.Mariusz);

            imageView1.Click += delegate
             {
                 StartActivity(typeof(PierwszyEkran));
             };

		/*	var button = FindViewById<Button> (Resource.Id.button1);
			button.Click += delegate {
				//var PierwszyEkranActivity = new Intent (this, typeof(PierwszyEkran));

				StartActivity (typeof(PierwszyEkran));
			};*/
			}

			// Get our button from the layout resource,
			// and attach an event to it

		}
	}



