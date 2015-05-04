// You will need to put this Utility class into a code file including various
// libraries, I found that I needed at least System, Linq, Android.Views and 
// Android.Widget.
using System;
using System.Linq;
using Android.Views;
using Android.Widget;

namespace CalorieCalculator  // whatever you like, obviously!
{
	public class Utility
	{
		public static void setListViewHeightBasedOnChildren (ListView listView)
		{
			if (listView.Adapter == null) {
				// pre-condition
				return;
			}

			int totalHeight = listView.PaddingTop + listView.PaddingBottom;
			for (int i = 0; i < listView.Count; i++) {
				View listItem = listView.Adapter.GetView (i, null, listView);
				if (listItem.GetType () == typeof(ViewGroup)) {
					listItem.LayoutParameters = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
				}
				listItem.Measure (0, 0);
				totalHeight += listItem.MeasuredHeight;
			}

			listView.LayoutParameters.Height = totalHeight + (listView.DividerHeight * (listView.Count - 1));
		}
	}
}