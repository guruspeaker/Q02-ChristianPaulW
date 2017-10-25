using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Q02_ChristianPaulW
{
	[Activity(Label = "Display Recipe Details")]
	public class recipeDetails : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			string incomingDish = Intent.GetStringExtra("SEND_DISH") ?? "No Dish Recieved";
			long incomingDishID = Intent.GetLongExtra("DISH_ID", 0);
			SetContentView(Resource.Layout.recipeDetails);
			TextView dishName = (TextView)FindViewById<TextView>(Resource.Id.dishTitle);
			TextView recipeDetail = (TextView)FindViewById<TextView>(Resource.Id.recipeDetails);
			recipeDetail.MovementMethod = new Android.Text.Method.ScrollingMovementMethod();
			dishName.Text = incomingDish;
			Button voteSMS = FindViewById<Button>(Resource.Id.btnVoteSMS);
			Button voteCall = FindViewById<Button>(Resource.Id.btnVoteCall);
			Button voteEmail = FindViewById<Button>(Resource.Id.btnVoteEmail);

			var dishPic = FindViewById<ImageView>(Resource.Id.imgDish);
						switch (incomingDishID)
			{
				case 1:
					dishPic.SetImageResource(Resource.Drawable.beandip);
					recipeDetail.Text = "1) In medium bowl, mix 1 can (16 oz) Old El Paso™ refried beans and 1 package (1 oz) Old El Paso™ taco seasoning mix. Spread mixture on large platter."
						 + "\n2) In another medium bowl, mix 1 package(8 oz) cream cheese, softened and 1 can(4.5 oz) Old El Paso™ chopped green chiles.Carefully spread over bean mixture."
						 + "\n3) Top with 1 cup Old El Paso™ Thick 'n Chunky salsa (any variety), 2 cups shredded lettuce, 2 cups shredded Cheddar or Mexican cheese blend (8 oz), 1 can (2.25 oz) sliced ripe olives, drained (1/2 cup) and 1 medium tomato, diced (3/4 cup)."
						 + "\n4) Refrigerate until serving time. Serve with tortilla chips.";
					break;

				case 2:
					dishPic.SetImageResource(Resource.Drawable.pulledpork);
					recipeDetail.Text =
						"1) Trim off excess fat from 3-1/2 lb boneless pork shoulder and cut into 2-inch pieces."
						+ "/n2) In small bowl, mix 3 tablespoons brown sugar, 3 tablespoons chili powder, 2 teaspoons salt and 1/2 teaspoon freshly ground pepper. Rub mixture all over pork. Place in 4 1/2- to 5-quart slow cooker."
						+ "/n3) Pour 3/4 cup Progresso™ chicken broth (from 32-oz carton) and 1/4 cup of apple cider vinegar over pork. Cover and cook on High heat setting 4 hours."
						+ "/n4) In medium bowl, beat 1/4 cup of mayonnaise, 3 tablespoons apple cider vinegar, 2 tablespoons brown sugar and 1/4 teaspoon salt. Stir in 4-cups of coleslaw mix. Cover and refrigerate at least 30 minutes but no longer than 4 hours."
						+ "/n5) Remove pork to cutting board, and shred using 2 forks. Reserve 1 cup of the cooking liquid. Discard remaining cooking liquid. In medium bowl, mix reserved cooking liquid with 1/2 cup barbecue sauce and 1/4 cup apple cider vinegar; return to slow cooker with shredded pork. Cover and cook on Low heat setting about 20 minutes or until warmed."
						+ "/n6) Using slotted spoon, spoon about 1/2 cup pork mixture on bottom half of each bun. Top each with about 1/4 cup coleslaw. Cover with top halves of buns. Pork mixture can be kept warm on Low heat setting up to 2 hours; stir occasionally.";
					break;

				default:
					dishPic.SetImageResource(Resource.Drawable.applepie);
					recipeDetail.Text = 
						"1) Heat oven to 425ºF.Prepare Crust Pastry."
						+ "/n2) Mix 1/3 to 1/2 cup sugar, 1/4 cup Gold Medal™ all-purpose flour, 1/2 teaspoon ground cinnamon, 1/2 teaspoon ground nutmeg and 1/8 teaspoon salt in large bowl. Stir in 8 cups thinly sliced peeled tart apples (8 medium). Turn into pastry-lined pie plate. Dot with butter. Trim overhanging edge of pastry 1/2 inch from rim of plate."
						+ "/n3) Roll other round of pastry. Fold into fourths and cut slits so steam can escape. Unfold top pastry over filling; trim overhanging edge 1 inch from rim of plate. Fold and roll top edge under lower edge, pressing on rim to seal; flute as desired. Cover edge with 3-inch strip of aluminum foil to prevent excessive browning. Remove foil during last 15 minutes of baking."
						+ "/n4) Bake 40 to 50 minutes or until crust is brown and juice begins to bubble through slits in crust. Serve warm if desired.";
					break;
			}

			voteCall.Click += delegate
			{
				var uri = Android.Net.Uri.Parse("tel:3055551212");
				Intent dialVote = new Intent(Intent.ActionDial, uri);
				StartActivity(dialVote);
			};
			voteSMS.Click += delegate
			{
				var uri = Android.Net.Uri.Parse("sms:3055551212");
				Intent smsVote = new Intent(Intent.ActionView, uri);
				StartActivity(smsVote);

			};
			voteEmail.Click += delegate
			{
				var email = new Intent(Android.Content.Intent.ActionSend);
				email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { "paul.christian001@mymdc.net" });
				email.PutExtra(Android.Content.Intent.ExtraSubject, string.Format("I'm voting for {0}", dishName));
				email.SetType("message/rfc822");
				StartActivity(email);
			};






		}

	}
}