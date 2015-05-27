using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.ServiceModel;
using uCook_TimeLineHost;

namespace TimeLine.Android
{
    [Activity(Label = "uCook_TimeLineHost", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            InitializeTimeLineClient();

            // This button will invoke the GetHelloWorldData - the method that takes a C# object as a parameter.
            _getHelloWorldDataButton = FindViewById<Button>(Resource.Id.getHelloWorldDataButton);
            _getHelloWorldDataButton.Click += GetHelloWorldDataButtonOnClick;
            _getHelloWorldDataTextView = FindViewById<TextView>(Resource.Id.getHelloWorldDataTextView);

            // This button will invoke SayHelloWorld - this method takes a simple string as a parameter.
            _sayHelloWorldButton = FindViewById<Button>(Resource.Id.sayHelloWorldButton);
            _sayHelloWorldButton.Click += SayHelloWorldButtonOnClick;
            _sayHelloWorldTextView = FindViewById<TextView>(Resource.Id.sayHelloWorldTextView);
        }
        private void ClientOnGetHelloDataCompleted(object sender, GetHelloDataCompletedEventArgs getHelloDataCompletedEventArgs)
        {
            string msg = null;

            if (getHelloDataCompletedEventArgs.Error != null)
            {
                msg = getHelloDataCompletedEventArgs.Error.Message;
            }
            else if (getHelloDataCompletedEventArgs.Cancelled)
            {
                msg = "Request was cancelled.";
            }
            else
            {
                msg = getHelloDataCompletedEventArgs.Result.Name;
            }
            RunOnUiThread(() => _getHelloWorldDataTextView.Text = msg);
        }

        private void ClientOnSayHelloToCompleted(object sender, SayHelloToCompletedEventArgs sayHelloToCompletedEventArgs)
        {
            string msg = null;

            if (sayHelloToCompletedEventArgs.Error != null)
            {
                msg = sayHelloToCompletedEventArgs.Error.Message;
            }
            else if (sayHelloToCompletedEventArgs.Cancelled)
            {
                msg = "Request was cancelled.";
            }
            else
            {
                msg = sayHelloToCompletedEventArgs.Result;
            }
            RunOnUiThread(() => _sayHelloWorldTextView.Text = msg);
        }

        private void InitializeTimeLineClient()
        {
            BasicHttpBinding binding = CreateBasicHttp();

            _client = new TimeLineClient(binding, EndPoint);
            _client.SayHelloToCompleted += ClientOnSayHelloToCompleted;
            _client.GetHelloDataCompleted += ClientOnGetHelloDataCompleted;
        }

        private static BasicHttpBinding CreateBasicHttp()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }

        private void GetHelloWorldDataButtonOnClick(object sender, EventArgs eventArgs)
        {
            TimeLineData data = new TimeLineData { Name = "Mr. Chad", SayHello = true };
            _getHelloWorldDataTextView.Text = "Waiting for uCook client";
            _client.GetHelloDataAsync(data);
        }

        private void SayHelloWorldButtonOnClick(object sender, EventArgs eventArgs)
        {
            _sayHelloWorldTextView.Text = "Waiting for uCook client";
            _client.SayHelloToAsync("Kilroy");
        }

        public static readonly EndpointAddress EndPoint = new EndpointAddress("http://145.93.66.182:2161/TimeLineService.svc");

        private TimeLineClient _client;
        private Button _getHelloWorldDataButton;
        private TextView _getHelloWorldDataTextView;
        private Button _sayHelloWorldButton;
        private TextView _sayHelloWorldTextView;

    }
}

