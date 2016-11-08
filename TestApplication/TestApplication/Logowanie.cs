using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
	[Activity (Label = "Kibic 2.0", MainLauncher = false, ScreenOrientation=Android.Content.PM.ScreenOrientation.SensorLandscape,Theme = "@android:style/Theme.Holo.DialogWhenLarge.NoActionBar")]
	public class Logowanie : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            			
			SetContentView (Resource.Layout.Logowanie);

			var buttonImage = FindViewById<ImageButton> (Resource.Id.imageButton1);
			buttonImage.Click+= delegate {
				StartActivity(typeof(OczekiwanieNaAkcje));
			};
        }

     
    }
}


