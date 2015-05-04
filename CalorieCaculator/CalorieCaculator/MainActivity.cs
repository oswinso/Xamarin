using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;

namespace CalorieCaculator
{
	[Activity (Label = "CalorieCaculator", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/MyTheme")]
	public class MainActivity : ActionBarActivity
	{
		private SupportToolbar mToolbar;
		private MyActionBarToggle mDrawerToggle;
		private DrawerLayout mDrawerLayout;
		private ListView mLeftDrawer;
		private ArrayAdapter mLeftAdapter;

		private ListView bFood;
		private ArrayAdapter bFoodAdapter;

		private ListView lFood;
		private ArrayAdapter lFoodAdapter;

		private ListView dFood;
		private ArrayAdapter dFoodAdapter;

		private List<string> mLeftDataSet;
		private List<string> test;

		private Button bButton;
		private Button lButton;
		private Button dButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			mToolbar = FindViewById<SupportToolbar> (Resource.Id.toolbar);
			mDrawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			mLeftDrawer = FindViewById<ListView> (Resource.Id.left_drawer);
			bFood = FindViewById<ListView> (Resource.Id.breakfastFood);
			lFood = FindViewById<ListView> (Resource.Id.lunchFood);
			dFood = FindViewById<ListView> (Resource.Id.dinnerFood);

			bButton = FindViewById<Button> (Resource.Id.addBreakfast);
			lButton = FindViewById<Button> (Resource.Id.addLunch);
			dButton = FindViewById<Button> (Resource.Id.addDinner);

			SetSupportActionBar (mToolbar);
			mLeftDataSet = new List<string> ();
			mLeftDataSet.Add ("Calculate Calories");
			mLeftDataSet.Add ("Test");
			mLeftAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
			mLeftDrawer.Adapter = mLeftAdapter;

			test = new List<string> ();
			test.Add("Food");
			test.Add("Food 2");
			bFoodAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, test);
			lFoodAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, test);
			dFoodAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, test);

			bFood.Adapter = bFoodAdapter;
			lFood.Adapter = lFoodAdapter;
			dFood.Adapter = dFoodAdapter;

			mDrawerToggle = new MyActionBarToggle(
				this,							// Host Activity
				mDrawerLayout,					// DrawerLayout
				Resource.String.openDrawer,		// Opened Message
				Resource.String.closeDrawer		// Closed Message
			);

			mDrawerLayout.SetDrawerListener (mDrawerToggle);
			SupportActionBar.SetHomeButtonEnabled (true);
			SupportActionBar.SetDisplayShowTitleEnabled (true);
			mDrawerToggle.SyncState();

			if (bundle != null) {
				if (bundle.GetString ("DrawerState") == "Opened") {
					SupportActionBar.SetTitle (Resource.String.openDrawer);
				} else {
					SupportActionBar.SetTitle (Resource.String.closeDrawer);
				}

			} else {
				//This is the first time the activity is run
				SupportActionBar.SetTitle (Resource.String.closeDrawer);
			}
				
			CalorieCalculator.Utility.setListViewHeightBasedOnChildren (bFood);
			CalorieCalculator.Utility.setListViewHeightBasedOnChildren (lFood);
			CalorieCalculator.Utility.setListViewHeightBasedOnChildren (dFood);

			bButton.Click += delegate {
				StartActivity (typeof (SearchByActivity));
			};
			lButton.Click += delegate {
				StartActivity (typeof (SearchByActivity));
			};
			dButton.Click += delegate {
				StartActivity (typeof (SearchByActivity));
			};


		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			mDrawerToggle.OnOptionsItemSelected (item);
			return base.OnOptionsItemSelected (item);
		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			if (mDrawerLayout.IsDrawerOpen ((int)GravityFlags.Left)) {
				outState.PutString ("DrawerState", "Opened");
			} else {
				outState.PutString ("DrawerState", "Closed");
			}
			base.OnSaveInstanceState (outState);
		}
	}
}


