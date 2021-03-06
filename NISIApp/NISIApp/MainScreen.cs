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
        Button mDemobtn;
        private List<ProgrammaRij> mItems;
        private ListView mProgrammaView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            GAService.GetGASInstance().Track_App_Page("Main Screen");
            //Basic initialization.
            SetContentView(Resource.Layout.MainScreen);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            mProgrammaView = FindViewById<ListView>(Resource.Id.ProgrammaFront);
            mDemobtn = FindViewById<Button>(Resource.Id.button1);

            mDemobtn.Click += MDemobtn_Click;

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
            mLeftDrawer.ItemClick += MLeftDrawer_ItemClick;

            //Create Programm Frontpage
            mItems = new List<ProgrammaRij>();
            mItems.Add(new ProgrammaRij("Data", "Cursustitel", "Locatie"));
            mItems.Add(new ProgrammaRij("12 jan - 09 mrt", "Advanced Model Driven Engineering", "de Uithof"));
            mItems.Add(new ProgrammaRij("22 feb - 12 apr", MainActivity.CursusArray[0].Naam, "de Uithof"));
            mItems.Add(new ProgrammaRij("07 mrt - 16 mei", "Software Product Management", "de Uithof"));
            mItems.Add(new ProgrammaRij("09 mrt - 18 mei", "Software Business Development", "de Uithof"));
            mItems.Add(new ProgrammaRij("14 mrt - 11 apr", "Agile Product Ownership & Product Management", "de Uithof"));
            mItems.Add(new ProgrammaRij("19 apr - 07 jun", "Ontwikkelen van Agile organisaties in de praktijk", "de Uithof"));

            ProgrammaListViewAdapter adapter = new ProgrammaListViewAdapter(this, mItems);

            mProgrammaView.Adapter = adapter;
            mProgrammaView.ItemClick += MProgrammaView_ItemClick;

        }

        private void MDemobtn_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_CDDemo dialogInfo = new dialog_CDDemo();
            dialogInfo.Show(transaction, "dialog fragment");
        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int p = e.Position;
            switch (p)
            {

                case 0:
                    mDrawerLayout.CloseDrawers();
                    break;
                case 1:
                    Intent i1 = new Intent(this, typeof(NieuwsView));
                    this.StartActivity(i1);
                    break;
                case 2:
                    Intent i2 = new Intent(this, typeof(WieZijnWijView));
                    this.StartActivity(i2);
                    break;
                case 3:
                    Intent i3 = new Intent(this, typeof(CursusView));
                    this.StartActivity(i3);
                    break;
                case 4:
                    Intent i4 = new Intent(this, typeof(ConsultancyView));
                    this.StartActivity(i4);
                    break;
                case 5:
                    Intent i5 = new Intent(this, typeof(WerkgroepView));
                    this.StartActivity(i5);
                    break;
                case 6:
                    Intent i6 = new Intent(this, typeof(ContactView));
                    this.StartActivity(i6);
                    break;



                default:
                    break;

            }
        }

        private void MProgrammaView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            int p = e.Position;
            switch (p)
            {
                case 0:
                    break;
                case 1:
                    MainActivity.CursusInt = 2;
                    break;
                case 2:
                    MainActivity.CursusInt = 4;
                    break;
                case 3:
                    MainActivity.CursusInt = 0;
                    break;
                case 4:
                    MainActivity.CursusInt = 1;
                    break;
                case 5:
                    MainActivity.CursusInt = 5;
                    break;
                case 6:
                    MainActivity.CursusInt = 6;
                    break;



                default:
                    break;
            }

            Intent i0 = new Intent(this, typeof(IndivCursusView));
            this.StartActivity(i0);
        }


        //For the hamburger
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            GAService.GetGASInstance().Track_App_Event(GAEventCategory.MenuOpen, "Menu is geopend");
            return base.OnOptionsItemSelected(item);
            
        }
    }
}