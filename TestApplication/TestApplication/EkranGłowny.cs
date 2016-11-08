using Android.App;
using Android.Widget;
using Android.OS;

namespace TestApplication
{
	[Activity (Label = "Kibic 2.0", MainLauncher = false, ScreenOrientation=Android.Content.PM.ScreenOrientation.SensorLandscape,Theme = "@android:style/Theme.Holo.DialogWhenLarge.NoActionBar")]
	public class PierwszyEkran : Activity
	{
		//	int count = 1;

	
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			//byte typButton1 = 0;
		///	byte typButton2 = 0;
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.EkranGlowny);

		/*	var imageView =
				FindViewById<ImageView> (Resource.Id.imageView1);
			imageView.SetImageResource (Resource.Drawable.Boisko1);
			imageView.Click+= delegate {
				//var PierwszyEkranActivity = new Intent (this, typeof(PierwszyEkran));

				StartActivity (typeof(EkranSklady));
			};

			imageView.SetScaleType(ImageView.ScaleType.FitCenter); */

			var imageView2 = FindViewById<ImageView> (Resource.Id.imageView2);
			imageView2.SetImageResource (Resource.Drawable.Reklamy);

            var buttonOpcje3 = FindViewById<Button>(Resource.Id.button3);
            buttonOpcje3.Click += delegate
             {
                 StartActivity(typeof(Logowanie));
             };

			/*
			var buttonGoraPierwszy = FindViewById<Button> (Resource.Id.ButtonGoraPierwszy);
		//	buttonGoraPierwszy.SetBackgroundColor (Android.Graphics.Color.Black);
			var buttonGoraDrugi = FindViewById<Button> (Resource.Id.ButtonGoraDrugi);

			var buttonOpcje1 = FindViewById<Button> (Resource.Id.button5);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Invisible;

			var buttonOpcje2 = FindViewById<Button> (Resource.Id.button1);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Invisible;
			var buttonOpcje3 = FindViewById<Button> (Resource.Id.button2);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Invisible;
			var buttonOpcje4 = FindViewById<Button> (Resource.Id.button3);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Invisible;
			var buttonOpcje5 = FindViewById<Button> (Resource.Id.button4);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Invisible;

			buttonOpcje1.Click += (object sender, System.EventArgs e) => {
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.red_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_glowny);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_glowny);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_glowny);
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.button_glowny);
			};
			buttonOpcje2.Click+= (object sender, System.EventArgs e) => {
			//	buttonOpcje2.SetBackgroundResource (Resource.Drawable.red_button);
			//	buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
			//	buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
			//	buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
			//	buttonOpcje5.SetBackgroundResource (Resource.Drawable.button_wyboru);
				StartActivity(typeof(EkranSklady));

			};
			buttonOpcje3.Click+= (object sender, System.EventArgs e) => {
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.red_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.button_wyboru);
			};
			buttonOpcje4.Click+= (object sender, System.EventArgs e) => 
			{
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.red_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.button_wyboru);
			};
			buttonOpcje5.Click += (object sender, System.EventArgs e) => 
			{
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.red_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
			};

		//	buttonGoraDrugi.SetBackgroundColor (Android.Graphics.Color.Black);
			buttonGoraPierwszy.Click += delegate {
				if (typButton1==0) {
					typButton1 = 1;
					typButton2=0;
					StartActivity(typeof(EkranZagrywkaBlok));
				} else {
					typButton1 = 0;

				}
			};

			buttonGoraDrugi.Click += delegate {
				if (typButton2 == 0) {
					typButton2 = 1;
					typButton1=0;
					StartActivity(typeof(EkranAtakObrona));
				} else {
					typButton2 = 0;
				}
			};
			*/

			// Get our button from the layout resource,
			// and attach an event to it

		}
	}
}


