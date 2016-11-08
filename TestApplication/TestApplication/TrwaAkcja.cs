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
	public class TrwaAkcja : Activity
	{

        public delegate void ShowMessage(string message);
        public ShowMessage myDelegate;
        Int32 port = 11000;
        UdpClient udpClient = new UdpClient(11000);
        Thread thread;
        public TextView text;
        //	int count = 1;

        private ShapeDrawable _shape;

		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
			return dp;
		}

	
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            			
			SetContentView (Resource.Layout.ProszeCzekac);
            text = FindViewById<TextView>(Resource.Id.textView1);

            thread = new Thread(new ThreadStart(ReceiveMessage));
            thread.IsBackground = true;
            thread.Start();

        }

        private void ReceiveMessage()
        {
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
						if (message != "100" && message!="200" && message!="300" && message!="400")
                        {
                            var lista = message.Split(';');

							message = "Podsumowanie akcji:      Dzisejsze punkty: 3\nZagrywka :" + lista[0].ToString() +"\nZagrywka strefa: " + lista[1].ToString()
								+ "\nBlok :" + lista[2].ToString() + "\nBlok strefa: " + lista[3].ToString() + "\nAtak: " + lista[4].ToString() +"         Aktualny ranking: 321"+ "\nAtak strefa: " + lista[5].ToString()
                                + "\nObrona: " + lista[6].ToString() + "\nObrona strefa: " + lista[7].ToString();
                        }
						else if(message=="300")
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
                        RunOnUiThread(() => zmienTekst(message));
                        //this.invo.Invoke(myDelegate, new object[] { message
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void zmienTekst(string message)
        {
            text.Text = message;
        }
    }
}


