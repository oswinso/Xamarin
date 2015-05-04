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
	[Activity (Label = "CalorieCaculator", Icon = "@drawable/icon", Theme="@style/MyTheme")]
	public class SearchByNameActivity : ActionBarActivity
	{
		private SupportToolbar mToolbar;
		private MyActionBarToggle mDrawerToggle;
		private DrawerLayout mDrawerLayout;
		private ListView mLeftDrawer;
		private ArrayAdapter mLeftAdapter;

		private List<string> mLeftDataSet;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.SearchByName);

			mToolbar = FindViewById<SupportToolbar> (Resource.Id.toolbar);
			mDrawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			mLeftDrawer = FindViewById<ListView> (Resource.Id.left_drawer);

			SetSupportActionBar (mToolbar);
			mLeftDataSet = new List<string> ();
			mLeftDataSet.Add ("Calculate Calories");
			mLeftDataSet.Add ("Test");
			mLeftAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
			mLeftDrawer.Adapter = mLeftAdapter;

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


