using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;

namespace TestApplication
{
	[Activity (Label = "Kibic 2.0", MainLauncher = false, ScreenOrientation=Android.Content.PM.ScreenOrientation.SensorLandscape,Theme = "@android:style/Theme.Holo.DialogWhenLarge.NoActionBar")]
	public class PierwszyEkran2 : Activity
	{
		//	int count = 1;

		private ShapeDrawable _shape;
		string extraData="";

		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
			return dp;
		}

	
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			byte zaznaczonaDruzyna = 0;
			var paint = new Paint();
			paint.SetARGB(255, 200, 255, 0);
			paint.SetStyle(Paint.Style.Stroke);
			paint.StrokeWidth = 4;

			_shape = new ShapeDrawable(new OvalShape());
			_shape.Paint.Set(paint);

			_shape.SetBounds(20, 20, 300, 200);

			var metrics = Resources.DisplayMetrics;
			float widthInDp =  ConvertPixelsToDp(metrics.WidthPixels);
			float heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

			float zmianaWartosciX = 1;
			float zmianaWartosciY = 1;

			if (widthInDp != 640 || heightInDp!= 360) {
				zmianaWartosciX =((640/widthInDp)-1)*10;
				zmianaWartosciY = (360 / heightInDp) - 1;
				if (zmianaWartosciY < 0) {
					zmianaWartosciY = zmianaWartosciY * (-1);
				}
			}
			//byte typButton1 = 0;
		///	byte typButton2 = 0;
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.EkranGlowny2);

			var imageView =
				FindViewById<ImageView> (Resource.Id.imageView1);
			imageView.SetImageResource (Resource.Drawable.Boisko2);

			var imageView2 = FindViewById<ImageView> (Resource.Id.imageView2);

			var imageButton1 = FindViewById<ImageButton> (Resource.Id.buttonGospodarze);
			imageButton1.Visibility = ViewStates.Invisible;

			var imageButton2 = FindViewById<ImageButton> (Resource.Id.buttonGospodarze);
			imageButton2.Visibility = ViewStates.Invisible;


			imageView2.SetImageResource (Resource.Drawable.Reklamy);
			//var videoView = FindViewById<VideoView> (Resource.Id.videoView1);
			//videoView.SetVideoPath (Resource.Drawable.plusVideo);
			imageView.Touch+= (object sender, Android.Views.View.TouchEventArgs e) => {
				switch(e.Event.Action)
				{
				case MotionEventActions.Down:
					var x = e.Event.GetX();
					var y =e.Event.GetY();

					if(x>370 *zmianaWartosciX && x<980*zmianaWartosciX && y<602*zmianaWartosciX && y>10*zmianaWartosciX)
					{
						imageView.SetImageResource(Resource.Drawable.Boisko21);
						zaznaczonaDruzyna=1;
						if(extraData=="100") StartActivity(typeof(EkranZagrywkaBlok));
						else StartActivity(typeof(EkranAtakObrona));
					}
					else if(x>981*zmianaWartosciX && x<1540*zmianaWartosciX && y<602 *zmianaWartosciX&& y>10*zmianaWartosciX)
					{
						imageView.SetImageResource(Resource.Drawable.Boisko22);
						zaznaczonaDruzyna=1;
						if(extraData=="100") StartActivity(typeof(EkranAtakObrona));
						else StartActivity(typeof(EkranZagrywkaBlok));
					}
					break;
				}
			};
		
	//		var linerauLayout = FindViewById<LinearLayout> (Resource.Id.linearLayout3);
	//		linerauLayout.Visibility = Android.Views.ViewStates.Invisible;


			var buttonGoraPierwszy = FindViewById<Button> (Resource.Id.ButtonGoraPierwszy);
		//	buttonGoraPierwszy.SetBackgroundColor (Android.Graphics.Color.Black);

			buttonGoraPierwszy.Click+= (object sender, System.EventArgs e) => {

				StartActivity(typeof(EkranSklady2));
			};


			extraData = Intent.GetStringExtra("key");
			if (extraData == "100") {
				var imageButton = FindViewById<ImageButton> (Resource.Id.buttonGospodarze);
				imageButton.Visibility = ViewStates.Visible;
				var imageButton3 = FindViewById<ImageButton> (Resource.Id.buttonGoscie);
				imageButton3.Visibility = ViewStates.Invisible;
			}
			else
			{
				var imageButton = FindViewById<ImageButton> (Resource.Id.buttonGoscie);
				imageButton.Visibility = ViewStates.Visible;
			}

/*			var buttonOpcje1 = FindViewById<Button> (Resource.Id.button5);
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
*/
		//	buttonGoraDrugi.SetBackgroundColor (Android.Graphics.Color.Black);
			buttonGoraPierwszy.Click += delegate {
				

			};


			// Get our button from the layout resource,
			// and attach an event to it

		}
	}
}


