using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Q02_ChristianPaulW
{
	[Activity(Label = "Select a Recipe", MainLauncher = true)]
	public class MainActivity : Activity
	{
		public string dish { get; private set; }
		public long dishRefNum { get; private set; }

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Set-up the Spinner
			Spinner spinner = FindViewById<Spinner>(Resource.Id.spnRecipe);

			// spinner 
			spinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource(
				this, Resource.Array.recipe_list, Android.Resource.Layout.SimpleSpinnerItem);
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;

			// Set-Up the Button
			Button mainButton = (Button)FindViewById<Button>(Resource.Id.btnGetRecipe);


			mainButton.Click += delegate
			{
				if (dish == "Pick a Recipe")
				{
					string toast = string.Format("Please Select a Recipe first.");
					Toast.MakeText(this, toast, ToastLength.Long).Show();
				}
				else
				{

					var goRecipeDetails = new Intent(this, typeof(recipeDetails));
					Bundle extras = new Bundle();
					extras.PutString("SEND_DISH", dish);
					extras.PutLong("DISH_ID", dishRefNum);
					goRecipeDetails.PutExtras(extras);
					StartActivity(goRecipeDetails);

				}
			};




		}

		public void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)

		{
			Spinner spinner = (Spinner)sender;
			dish = string.Format("{0}", spinner.GetItemAtPosition(e.Position));
			dishRefNum = spinner.GetItemIdAtPosition(e.Position);


		}
	}
}