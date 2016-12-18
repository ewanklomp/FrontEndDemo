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
using Android.Support.V7.App;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;

namespace NISIApp
{
    [Activity(Label = "NISI", Theme = "@style/MyTheme")]
    public class MainScreen : AppCompatActivity
    {
        //Initialize
        SupportToolbar mToolbar;
        MyActionBarDrawerToggle mDrawerToggle;
        DrawerLayout mDrawerLayout;
        ListView mLeftDrawer;

        private List<ProgrammaRij> mItems;
        private ListView mProgrammaView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Basic initialization.
            SetContentView(Resource.Layout.MainScreen);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            mProgrammaView = FindViewById<ListView>(Resource.Id.ProgrammaFront);

            //set Top bar
            SetSupportActionBar(mToolbar);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //Sets the Drawer toggle, the hamburger to arrow
            mDrawerToggle = new MyActionBarDrawerToggle(this, mDrawerLayout, Resource.String.openDrawer, Resource.String.closeDrawer);
            mDrawerLayout.AddDrawerListener(mDrawerToggle);
            mDrawerToggle.SyncState();

            //Sets listview in navigation
            List<string> mLeftDataSet = new List<string>();
            mLeftDataSet.Add(MainActivity.KopjesArray[0].Kopjes);
            mLeftDataSet.Add(MainActivity.KopjesArray[1].Kopjes);
            mLeftDataSet.Add(MainActivity.KopjesArray[2].Kopjes);
            mLeftDataSet.Add(MainActivity.KopjesArray[3].Kopjes);
            mLeftDataSet.Add(MainActivity.KopjesArray[4].Kopjes);
            mLeftDataSet.Add(MainActivity.KopjesArray[5].Kopjes);
            mLeftDataSet.Add(MainActivity.KopjesArray[6].Kopjes);
            ArrayAdapter mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
            mLeftDrawer.Adapter = mLeftAdapter;


            //Create Programm Frontpage
            mItems = new List<ProgrammaRij>();
            mItems.Add(new ProgrammaRij("Data", "Cursustitel", "Locatie"));
            mItems.Add(new ProgrammaRij("12 jan - 09 mrt", "Software Business Development", "de Uithof"));
            mItems.Add(new ProgrammaRij("12 jan - 09 mrt", "Advanced Model Driven Engineering", "de Uithof"));
            mItems.Add(new ProgrammaRij("12 jan - 09 mrt", "Continuous Delivery 3.0", "de Uithof"));
            mItems.Add(new ProgrammaRij("07 mrt - 16 mei", "Software Product Management", "de Uithof"));
            mItems.Add(new ProgrammaRij("14 mrt - 11 apr", "Agile Product Ownership & Product Management", "de Uithof"));
            mItems.Add(new ProgrammaRij("19 apr - 07 jun", "Ontwikkelen van Agile organisaties in de praktijk", "de Uithof"));

            ProgrammaListViewAdapter adapter = new ProgrammaListViewAdapter(this, mItems);

            mProgrammaView.Adapter = adapter;
        }


        //For the hamburger
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}