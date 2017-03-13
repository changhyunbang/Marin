using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Test.Droid
{
	[Activity(Label = "Test.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			//global::Xamarin.Forms.Forms.Init(this, bundle);

			//LoadApplication(new App());
			SetContentView(Resource.Layout.Main);

			Button button = FindViewById<Button>(Resource.Id.GetWeatherButton);
			button.Click += (object sender, EventArgs e) =>
			{
				EditText ZipCodeEditText = FindViewById<EditText>(Resource.Id.ZipCodeEdit);

				Weather weather = Core.GetWeather(ZipCodeEditText.Text).Result;
				if (weather != null)
				{
					FindViewById<TextView>(Resource.Id.ResultsTitle).Text = weather.Title;
					FindViewById<TextView>(Resource.Id.TempText).Text = weather.Temperature;
					FindViewById<TextView>(Resource.Id.WindText).Text = weather.Wind;
					FindViewById<TextView>(Resource.Id.VisibilityText).Text = weather.Visibility;
					FindViewById<TextView>(Resource.Id.HumidityText).Text = weather.Humidity;
					FindViewById<TextView>(Resource.Id.SunriseText).Text = weather.Sunrise;
					FindViewById<TextView>(Resource.Id.SunsetText).Text = weather.Sunset;

					button.Text = "Search Again";

				}
				else
				{
					FindViewById<TextView>(Resource.Id.ResultsTitle).Text = "Couldn't find any results";
				}			
			};
			//button.Click += delegate
			//{
				
				//EditText ZipCodeEditText = FindViewById<EditText>(Resource.Id.ZipCodeEdit);

				//Weather weather = Core.GetWeather(ZipCodeEditText.Text).Result;

				//if (weather != null)
				//{
				//	FindViewById<TextView>(Resource.Id.ResultsTitle).Text = weather.Title;
				//	FindViewById<TextView>(Resource.Id.TempText).Text = weather.Temperature;
				//	FindViewById<TextView>(Resource.Id.WindText).Text = weather.Wind;
				//	FindViewById<TextView>(Resource.Id.VisibilityText).Text = weather.Visibility;
				//	FindViewById<TextView>(Resource.Id.HumidityText).Text = weather.Humidity;
				//	FindViewById<TextView>(Resource.Id.SunriseText).Text = weather.Sunrise;
				//	FindViewById<TextView>(Resource.Id.SunsetText).Text = weather.Sunset;

				//	button.Text = "Search Again";
				//}
				//else
				//{
				//	FindViewById<TextView>(Resource.Id.ResultsTitle).Text = "Couldn't find any results";
				//}

			//};
		}
	}
}
