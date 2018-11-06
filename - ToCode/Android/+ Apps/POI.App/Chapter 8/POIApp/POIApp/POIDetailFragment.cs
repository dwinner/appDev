﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace POIApp
{
	public class POIDetailFragment : Fragment
	{

		PointOfInterest _poi;

		EditText _nameEditText;
		EditText _descrEditText;
		EditText _addrEditText;
		EditText _latEditText;
		EditText _longEditText;
		private Activity activity;

		public override void OnAttach (Activity activity)
		{
			base.OnAttach (activity);
			this.activity = activity;
		}


		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			if (Arguments!=null && Arguments.ContainsKey("poi")) {
				string poiJson = Arguments.GetString ("poi");
				_poi = JsonConvert.DeserializeObject<PointOfInterest>(poiJson);
			} else {
				_poi = new PointOfInterest ();
			}
		}


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.POIDetailFragment, container, false);

			_nameEditText = view.FindViewById<EditText>(Resource.Id.nameEditText);
			_descrEditText = view.FindViewById<EditText> (Resource.Id.descrEditText);
			_addrEditText = view.FindViewById<EditText> (Resource.Id.addrEditText);
			_latEditText = view.FindViewById<EditText> (Resource.Id.latEditText);
			_longEditText = view.FindViewById<EditText> (Resource.Id.longEditText);

			SetHasOptionsMenu (true);

			if (Arguments!=null && Arguments.ContainsKey("poi")) {
				string poiJson = Arguments.GetString ("poi");
				_poi = JsonConvert.DeserializeObject<PointOfInterest>(poiJson);
			} else {
				_poi = new PointOfInterest ();
			}

			UpdateUI ();

			return view;
		}

		protected void UpdateUI()
		{
			_nameEditText.Text = _poi.Name;
			_descrEditText.Text = _poi.Description;
			_addrEditText.Text = _poi.Address;
			_latEditText.Text = _poi.Latitude.ToString ();
			_longEditText.Text = _poi.Longitude.ToString ();
		}

		protected void SavePOI()
		{
			bool errors = false;
			if (String.IsNullOrEmpty (_nameEditText.Text)) {
				_nameEditText.Error = "Name cannot be empty";
				errors = true;
			} else {
				_nameEditText.Error = null;
			}


			double? tempLatitude = null;
			if (!String.IsNullOrEmpty(_latEditText.Text)) {
				try {
					tempLatitude = Double.Parse(_latEditText.Text);
					if ((tempLatitude > 90) | (tempLatitude < -90)) {
						_latEditText.Error = "Latitude must be a decimal value between -90 and 90";
						errors = true;
					} else{
						_latEditText.Error = null;
					}
				}
				catch {
					_latEditText.Error = "Latitude must be valid decimal number";
					errors = true;
				}
			}

			double? tempLongitude = null;
			if (!String.IsNullOrEmpty (_longEditText.Text)) {
				try {
					tempLongitude = Double.Parse(_longEditText.Text);
					if ((tempLongitude > 180) | (tempLongitude < -180)) {
						_longEditText.Error = "Longitude must be a decimal value between -180 and 180";
						errors = true;
					} else {
						_longEditText.Error = null;
					}
				} catch {
					_longEditText.Error = "Longitude must be valid decimal number";
					errors = true;
				}
			}

			if (errors) {
				return;
			}

			_poi.Name = _nameEditText.Text;
			_poi.Description = _descrEditText.Text;
			_poi.Address = _addrEditText.Text;
			_poi.Latitude = tempLatitude;
			_poi.Longitude = tempLongitude;

			CreateOrUpdatePOIAsync (_poi);
		}

		private async void CreateOrUpdatePOIAsync(PointOfInterest poi){
			POIService service = new POIService ();
			if (!service.isConnected(activity)) {
				Toast toast = Toast.MakeText (activity, "Not conntected to internet. Please check your device network settings.", ToastLength.Short);
				toast.Show ();
				return;
			}

			string response = await service.CreateOrUpdatePOIAsync (_poi);
			if (!string.IsNullOrEmpty (response)) {
				Toast toast = Toast.MakeText (activity, String.Format ("{0} saved.", _poi.Name), ToastLength.Short);
				toast.Show();

				DBManager.Instance.SavePOI (poi);

				if(!POIListActivity.isDualMode)
					activity.Finish ();
			} else {
				Toast toast = Toast.MakeText (activity, "Something went Wrong!", ToastLength.Short);
				toast.Show();
			}
		}

		protected void DeletePOI()
		{
			FragmentTransaction ft = FragmentManager.BeginTransaction();

			// Create and show the dialog.
			DeleteDialogFragment dialogFragment = new DeleteDialogFragment();
			dialogFragment.SetTargetFragment (this, 0);

			Bundle bundle = new Bundle();
			bundle.PutString("name", _poi.Name);
			dialogFragment.Arguments = bundle;

			//Add fragment
			dialogFragment.Show(ft, "dialog");
		}

		public async void DeletePOIAsync(){
			POIService service = new POIService ();
			if (!service.isConnected(activity)) {
				Toast toast = Toast.MakeText (activity, "Not conntected to internet. Please check your device network settings.", ToastLength.Short);
				toast.Show ();
				return;
			}

			string response = await service.DeletePOIAsync (_poi.Id);
			if (!string.IsNullOrEmpty	(response)) {
				Toast toast = Toast.MakeText (activity, String.Format ("{0} deleted.", _poi.Name), ToastLength.Short);
				toast.Show();

				DBManager.Instance.DeletePOI (poi);

				if(!POIListActivity.isDualMode)
					activity.Finish ();
			} else {
				Toast toast = Toast.MakeText (activity, "Something went Wrong!", ToastLength.Short);
				toast.Show();
			}
		}

		public override void OnCreateOptionsMenu (IMenu menu, MenuInflater inflater)
		{
			inflater.Inflate(Resource.Menu.POIDetailMenu, menu);
			base.OnCreateOptionsMenu (menu, inflater);
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			switch (item.ItemId)
			{
			case Resource.Id.actionSave:
				SavePOI ();
				return true;
			case Resource.Id.actionDelete: 
				DeletePOI ();
				return true;
			default:
				return base.OnOptionsItemSelected(item);
			}
		}

		public override void OnPrepareOptionsMenu (IMenu menu)
		{
			base.OnPrepareOptionsMenu (menu);
			if (_poi.Id <= 0) {
				IMenuItem item = menu.FindItem (Resource.Id.actionDelete);
				item.SetEnabled (false);
				item.SetVisible(false);
			}
		}


	}
}
