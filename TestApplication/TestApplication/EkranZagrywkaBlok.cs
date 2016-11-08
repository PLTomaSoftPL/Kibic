using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
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
	[Activity (Label = "Kibic 2.0", MainLauncher = false,ScreenOrientation=Android.Content.PM.ScreenOrientation.SensorLandscape,Theme = "@android:style/Theme.Holo.DialogWhenLarge.NoActionBar")]
	public class EkranZagrywkaBlok : Activity
	{
		//	int count = 1;

		public delegate void ShowMessage(string message);
		public ShowMessage myDelegate;
		Int32 port = 11000;
		UdpClient udpClient = new UdpClient(11000);
		Thread thread;

		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
			return dp;
		}



		protected override void OnCreate (Bundle savedInstanceState)
		{
			try
			{
			base.OnCreate (savedInstanceState);

			myDelegate = new ShowMessage(ShowMessageMethod);
			thread = new Thread(new ThreadStart(ReceiveMessage));
			thread.IsBackground = true;
			thread.Start();

			var metrics = Resources.DisplayMetrics;
			float widthInDp =  ConvertPixelsToDp(metrics.WidthPixels);
			float heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

			float zmianaWartosciX = 0;
		//	float zmianaWartosciY = 1;blue

			if (widthInDp != 640 && heightInDp!= 360) {
                zmianaWartosciX = 400 - metrics.Xdpi;
                zmianaWartosciX = zmianaWartosciX*1.5F;
		//		zmianaWartosciY = ((360/heightInDp)-1);
		//		if (zmianaWartosciY < 0) {
		//			zmianaWartosciY = zmianaWartosciY * (-1);
		//		}
			}
            


			byte typButton1 = 1;
			byte typButton2 = 0;
			byte czyZagrywka = 1;
			byte czyBlok = 0;
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.EkranZagrywkaBlok);
			var buttonOpcje1 = FindViewById<Button> (Resource.Id.buttonOpcje1);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Visible;

			var linerauLayout = FindViewById<LinearLayout> (Resource.Id.linearLayout3);
			linerauLayout.Visibility = ViewStates.Visible;

			var buttonGoraPierwszy = FindViewById<Button> (Resource.Id.ButtonGoraPierwszy);
			var buttonGoraDrugi = FindViewById<Button> (Resource.Id.ButtonGoraDrugi);

			//var videoView = FindViewById<VideoView> (Resource.Id.videoView1);
			//videoView.SetVideoPath (Resource.Drawable.plusVideo);

			var buttonOpcje2 = FindViewById<Button> (Resource.Id.ButtonOpcje2);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Visible;
			var buttonOpcje3 = FindViewById<Button> (Resource.Id.ButtonOpcje3);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Visible;
			var buttonOpcje4 = FindViewById<Button> (Resource.Id.ButtonOpcje4);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Visible;
			var buttonOpcje5 = FindViewById<Button> (Resource.Id.ButtonOpcje5);
			buttonOpcje1.Visibility = Android.Views.ViewStates.Visible;
			var imageView =
				FindViewById<ImageView> (Resource.Id.imageView1);
			imageView.SetImageResource (Resource.Drawable.EkranZPodzialem);

            var heiht = imageView.MeasuredHeight;
            var width = imageView.MeasuredWidth;

			buttonOpcje1.Text = "AS";
			buttonOpcje2.Visibility = Android.Views.ViewStates.Visible;
			buttonOpcje2.Text = "Odbiór";
			buttonOpcje3.Visibility=Android.Views.ViewStates.Visible;
			buttonOpcje3.Text = "Błąd";
			buttonOpcje4.Visibility=Android.Views.ViewStates.Invisible;
			buttonOpcje4.Text="Aut";

			var imageView2 = FindViewById<ImageView> (Resource.Id.imageView2);
			imageView2.SetImageResource (Resource.Drawable.Reklamy);

			buttonOpcje5.Click += (object sender, System.EventArgs e) => {

					if(buttonOpcje1.Text=="AS")
				{
					StartActivity(typeof(PierwszyEkran2));
				}
				else
				{
					linerauLayout.Visibility = ViewStates.Visible;
					buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
					buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
					buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
					buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
					buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
					if (typButton1==0 || (typButton1==1 && czyZagrywka==1)) {
						buttonGoraPierwszy.SetBackgroundResource(Resource.Drawable.red_button);
						buttonGoraDrugi.SetBackgroundResource(Resource.Drawable.button_glowny);
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialem);
						buttonOpcje1.Visibility=Android.Views.ViewStates.Visible;
						buttonOpcje1.Text = "AS";
						buttonOpcje2.Visibility = Android.Views.ViewStates.Visible;
						buttonOpcje2.Text = "Odbiór";
						buttonOpcje3.Visibility=Android.Views.ViewStates.Visible;
						buttonOpcje3.Text = "Błąd";
						buttonOpcje4.Visibility=Android.Views.ViewStates.Invisible;
						buttonOpcje4.Text="Aut";
						typButton1 = 1;
						typButton2=0;
						czyZagrywka=1;
						czyBlok=0;
					}
				}
				
			};
			buttonOpcje1.Click+= (object sender, System.EventArgs e) => {
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.red_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
				if(typButton1==1)
				{
					czyZagrywka=1;
					czyBlok=0;
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialem);
				}
				else if(typButton2==1)
				{
					czyZagrywka=0;
					czyBlok=1;
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialemBlok);
				}
				else
				{
					czyZagrywka=0;
					czyBlok=1;
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialem);
				}
			};
			buttonOpcje2.Click+= (object sender, System.EventArgs e) => {
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.red_button);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
				if(typButton1==1)
				{
					czyZagrywka=1;
					czyBlok=0;
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialem);
				}
				else
				{
					czyZagrywka=0;
					czyBlok=1;
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialemBlok);
				}
			};
			buttonOpcje3.Click+= (object sender, System.	EventArgs e) => 
			{
				if(buttonOpcje3.Text!="Błąd")
				{
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.red_button);
				}
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
				czyZagrywka=0;
				czyBlok=1;
				if(typButton1==1 && buttonOpcje3.Text!="Błąd")
				{
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialem);
				}
				else if(typButton1==1 && buttonOpcje3.Text=="Błąd")
				{
					buttonOpcje3.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje3.Text = "Siatka";
					buttonOpcje4.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje4.Text="Aut";
				}
				else
				{
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialemBlok);
				}
			};
			buttonOpcje4.Click += (object sender, System.EventArgs e) => 
			{
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.red_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
				if(typButton1==1)
				{
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialem);
				}
				else
				{
					imageView.SetImageResource (Resource.Drawable.EkranZPodzialemBlok);
				}
				czyZagrywka=0;
				czyBlok=1;
			};
			buttonGoraPierwszy.SetBackgroundResource(Resource.Drawable.red_button);
			buttonGoraDrugi.SetBackgroundResource(Resource.Drawable.button_glowny);

			imageView.Touch += (object sender, Android.Views.View.TouchEventArgs e) => {
				if(typButton1==1 && czyZagrywka==1)
				{
                   
				switch(e.Event.Action)
				{

					case MotionEventActions.Down:
					var x = e.Event.GetX();
					var y =e.Event.GetY();
						//Android.Util.Log.Info("Kibic2.0","x = "+x+" y = "+y);

						if(x > 30 - zmianaWartosciX && x < 350 - zmianaWartosciX && y<305 - zmianaWartosciX && y>55-zmianaWartosciX)
					{
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialem1);
					}
						else if(x > 30 - zmianaWartosciX && x < 350 - zmianaWartosciX && y>305-zmianaWartosciX&& y<492-zmianaWartosciX*2)
					{
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialem2);
					}
						else if(x > 30 - zmianaWartosciX && x < 350 - zmianaWartosciX && y<708-zmianaWartosciX && y>492-zmianaWartosciX*2)
					{
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialem3);
					}
						else if(x > 350 - zmianaWartosciX && x < 657 - zmianaWartosciX && y<305-zmianaWartosciX && y>55-zmianaWartosciX)
					{
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialem4);
					}
						else if(x  > 350 - zmianaWartosciX && x < 657 - zmianaWartosciX && y>305-zmianaWartosciX && y<492-zmianaWartosciX*2)
					{
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialem5);
					}
						else if(x > 350 - zmianaWartosciX && x < 657 - zmianaWartosciX && y<708 -zmianaWartosciX && y>492-zmianaWartosciX*2)
					{
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialem6);
					}
					break;


					}
				/*	linerauLayout.Visibility = ViewStates.Visible;
					buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
					buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
					buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
					buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
					buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
					if (typButton2 == 0) {
						buttonGoraPierwszy.SetBackgroundResource(Resource.Drawable.button_glowny);
						buttonGoraDrugi.SetBackgroundResource(Resource.Drawable.red_button);
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialemBlok);
						typButton2 = 1;
						typButton1=0;
						buttonOpcje1.Visibility=Android.Views.ViewStates.Visible;
						buttonOpcje1.Text = "Blok punktowy";
						buttonOpcje2.Visibility = Android.Views.ViewStates.Visible;
						buttonOpcje2.Text = "Blok / aut";
						buttonOpcje3.Visibility=Android.Views.ViewStates.Visible;
						buttonOpcje3.Text = "Bez bloku";
						buttonOpcje4.Visibility=Android.Views.ViewStates.Visible;
						buttonOpcje4.Text="Wyblok";
						czyBlok=1; 
					}*/
				}
				if(typButton2==1 && czyBlok==1)
				{
					switch(e.Event.Action)
					{

					case MotionEventActions.Down:
						var x = e.Event.GetX();
						var y =e.Event.GetY();

						if(x>350 - zmianaWartosciX && x<657 && y<305 - zmianaWartosciX&& y>55-zmianaWartosciX)
						{
							imageView.SetImageResource(Resource.Drawable.EkranZPodzialemBlok1);
						}
						else if(x>350 -zmianaWartosciX && x<657 && y>305-zmianaWartosciX && y<492-zmianaWartosciX*2)
						{
							imageView.SetImageResource(Resource.Drawable.EkranZPodzialemBlok2);
						}
						else if(x>350 - zmianaWartosciX && x<657&& y<708-zmianaWartosciX && y>492-zmianaWartosciX*2)
						{
							imageView.SetImageResource(Resource.Drawable.EkranZPodzialemBlok3);
						}
						else if(x>30 -zmianaWartosciX && x<350&& y>305-zmianaWartosciX && y<492-zmianaWartosciX*2)
						{
							imageView.SetImageResource(Resource.Drawable.EkranZPodzialemBlok4);
						}
						break;
					}
				}
			};
            


			//buttonGoraPierwszy.SetBackgroundColor (Android.Graphics.Color.Black);
			buttonGoraPierwszy.Text = "Zagrywka";

		//	buttonGoraDrugi.SetBackgroundColor (Android.Graphics.Color.Black);
			buttonGoraDrugi.Text = "Blok";
			buttonGoraPierwszy.Click += delegate {
				linerauLayout.Visibility = ViewStates.Visible;
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
				if (typButton1==0 || (typButton1==1 && czyZagrywka==1)) {
					buttonGoraPierwszy.SetBackgroundResource(Resource.Drawable.red_button);
					buttonGoraDrugi.SetBackgroundResource(Resource.Drawable.button_glowny);
					imageView.SetImageResource(Resource.Drawable.EkranZPodzialem);
					buttonOpcje1.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje1.Text = "AS";
					buttonOpcje2.Visibility = Android.Views.ViewStates.Visible;
					buttonOpcje2.Text = "Odbiór";
					buttonOpcje3.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje3.Text = "Siatka";
					buttonOpcje4.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje4.Text="Aut";
					typButton1 = 1;
					typButton2=0;
				} else {
					buttonGoraPierwszy.SetBackgroundResource(Resource.Drawable.button_glowny);
					buttonGoraDrugi.SetBackgroundResource(Resource.Drawable.button_glowny);
					imageView.SetImageResource(Resource.Drawable.EkranZPodzialem);
					typButton1 = 0;
					buttonOpcje1.Visibility=Android.Views.ViewStates.Invisible;
					buttonOpcje2.Visibility=Android.Views.ViewStates.Invisible;
					//buttonOpcje2.Text = "AS";
					buttonOpcje3.Visibility = Android.Views.ViewStates.Invisible;
					//buttonOpcje3.Text = "Odbiór";
					buttonOpcje4.Visibility=Android.Views.ViewStates.Invisible;
					//buttonOpcje4.Text = "Siatka";
					buttonOpcje5.Visibility=Android.Views.ViewStates.Invisible;
					//buttonOpcje5.Text="Aut";
				}
			};

			buttonGoraDrugi.Click += delegate {
				linerauLayout.Visibility = ViewStates.Visible;
				buttonOpcje5.SetBackgroundResource (Resource.Drawable.szary_button);
				buttonOpcje2.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje3.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje1.SetBackgroundResource (Resource.Drawable.button_wyboru);
				buttonOpcje4.SetBackgroundResource (Resource.Drawable.button_wyboru);
				if (typButton2 == 0) {
					buttonGoraPierwszy.SetBackgroundResource(Resource.Drawable.button_glowny);
					buttonGoraDrugi.SetBackgroundResource(Resource.Drawable.red_button);
					imageView.SetImageResource(Resource.Drawable.EkranZPodzialemBlok);
					typButton2 = 1;
					typButton1=0;
					buttonOpcje1.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje1.Text = "Blok punktowy";
					buttonOpcje2.Visibility = Android.Views.ViewStates.Visible;
					buttonOpcje2.Text = "Blok / aut";
					buttonOpcje3.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje3.Text = "Bez bloku";
					buttonOpcje4.Visibility=Android.Views.ViewStates.Visible;
					buttonOpcje4.Text="Wyblok";
					czyBlok=1;
				}
				else
				{		buttonGoraPierwszy.SetBackgroundResource(Resource.Drawable.button_glowny);
						buttonGoraDrugi.SetBackgroundResource(Resource.Drawable.button_glowny);
						imageView.SetImageResource(Resource.Drawable.EkranZPodzialemBlok);
						typButton2 = 0;
					buttonOpcje1.Visibility=Android.Views.ViewStates.Invisible;
					buttonOpcje2.Visibility=Android.Views.ViewStates.Invisible;
					//buttonOpcje2.Text = "AS";
					buttonOpcje3.Visibility = Android.Views.ViewStates.Invisible;
					//buttonOpcje3.Text = "Odbiór";
					buttonOpcje4.Visibility=Android.Views.ViewStates.Invisible;
					//buttonOpcje4.Text = "Siatka";
					buttonOpcje5.Visibility=Android.Views.ViewStates.Invisible;
					//buttonOpcje5.Text="Aut";
				}
				
			};
            

			// Get our button from the layout resource,
			// and attach an event to it
			}
			catch (Exception ex) {
			}
		}
		public void UstawieniaBlok()
		{
			
		}
		private void ShowMessageMethod(string message)
		{
			string wiadomosc= message;
		}
		private void ReceiveMessage()
		{                   

			IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
			string ipAddress = string.Empty;
			if (addresses != null && addresses[0] != null)
			{
				ipAddress = addresses[0].ToString();
			}
			else
			{
				ipAddress = null;
			}

			try
			{
			while (true)
			{
					string hostName = Dns.GetHostName(); // Retrive the Name of HOST
					IPAddress ip = IPAddress.Parse(Dns.GetHostByName(hostName).AddressList[0].ToString());
					IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
				byte[] content = udpClient.Receive(ref remoteIPEndPoint);

				if (content.Length > 0)
				{
					string message = Encoding.ASCII.GetString(content);

                    if(message=="300")
                        {
                           // udpClient.Close();
                            StartActivity(typeof(TrwaAkcja));
                            
                        }
						else if(message=="100" || message=="200")
						{
							Android.Content.Intent myIntent= new Android.Content.Intent (this, typeof(PierwszyEkran2));
							myIntent.PutExtra("key", message);

							StartActivity(myIntent);
						}
						else if(message=="400")
						{
							message = "Ile możesz zaoszczędzić kupująć drugi produkt Polsatu Cyfrowego?\n    A) 10% \n    B) 20% "+
								"\n    C) 40% \n    D) 50% ";
						}

					//this.invo.Invoke(myDelegate, new object[] { message
				}
					}
				}
				catch {
			}
			

		}
	}

}


