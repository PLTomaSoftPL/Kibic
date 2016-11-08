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
	public class AkcjaZakonczona : Activity
	{

        public delegate void ShowMessage(string message);
        public ShowMessage myDelegate;
        Int32 port = 11000;
        UdpClient udpClient = new UdpClient(11000);
        Thread thread;
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

            
            thread = new Thread(new ThreadStart(ReceiveMessage));
            thread.IsBackground = true;
            thread.Start();

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
                    IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, port);
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
                        //this.invo.Invoke(myDelegate, new object[] { message
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}


