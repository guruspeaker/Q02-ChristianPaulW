using Android.App;
using Android.Widget;
using Android.OS;

namespace Q02_ChristianPaulW
{
	[Activity(Label = "Q02_ChristianPaulW", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
		}
	}
}

