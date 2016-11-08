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
using System.Windows;


namespace TestApplication
{
	[Activity (Label = "Kibic 2.0", MainLauncher = false, ScreenOrientation=Android.Content.PM.ScreenOrientation.SensorLandscape,Theme = "@android:style/Theme.Holo.DialogWhenLarge.NoActionBar")]
	public class OczekiwanieNaAkcje : Activity
	{

        public delegate void ShowMessage(string message);
        public ShowMessage myDelegate;
        Int32 port = 11000;
        UdpClient udpClient = new UdpClient(11000);
        Thread thread;
        public TextView text;
		int OrigTime = 10;
		bool Start = false;
		private Timer _dispatcherTimer;


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
            			
			SetContentView (Resource.Layout.OczekiwanieNaAkcje);
            text = FindViewById<TextView>(Resource.Id.textView1);

            thread = new Thread(new ThreadStart(ReceiveMessage));
            thread.IsBackground = true;
            thread.Start();

			TimerCallback timerDelegate = new TimerCallback (Tick);
			_dispatcherTimer = new Timer (timerDelegate, null, 0, 1000);

			/*System.Timers.Timer timeX = new System.Timers.Timer();
			timeX.Interval = 1000;
			timeX.Elapsed += OnTimedEvent;
			timeX.Enabled = true;
			timeX.Start ();*/

		}

		public void Tick(object state)
		{
			if (OrigTime > 0) {
				OrigTime--;
				RunOnUiThread (() => text.Text = "Kolejne spotkanie rozpocznie się za: \n\n                        " + (OrigTime / 60 + ":" + ((OrigTime % 60) >= 10 ? (OrigTime % 60).ToString () : "0" + OrigTime % 60)));
			} 
		}
		private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
		{
			
		/*	OrigTime--;
			RunOnUiThread (() => text.Text=(OrigTime/60 + ":" + ((OrigTime % 60) >= 10 ?  (OrigTime % 60).ToString() : "0" + OrigTime % 60)));
			text.Invalidate ();*/
		}
		void timeX_Tick(object sender, EventArgs e)
		{
			
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
						if (message == "100" || message=="200")
                        {
							
							Android.Content.Intent myIntent= new Android.Content.Intent (this, typeof(PierwszyEkran2));
							myIntent.PutExtra("key", message);

							StartActivity(myIntent);
							thread.Suspend();
                        }
						else if(message=="400")
						{
							message = "Ile możesz zaoszczędzić kupująć drugi produkt Polsatu Cyfrowego?\n    A) 10% \n    B) 20% "+
								"\n    C) 40% \n    D) 50% ";
						}
						
						{
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
           // text.Text = message;
        }
    }
}


