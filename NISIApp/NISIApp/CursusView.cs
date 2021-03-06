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
using Android.Graphics;

namespace NISIApp
{
    [Activity(Label = "Cursus", Theme = "@style/MyTheme")]
    public class CursusView : AppCompatActivity
    {
        //Initialize
        SupportToolbar mToolbar;
        MyActionBarDrawerToggle mDrawerToggle;
        DrawerLayout mDrawerLayout;
        ListView mLeftDrawer;

        private List<CursusRij> mItems;
        private ListView mCursusView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            GAService.GetGASInstance().Track_App_Page("Cursussen");

            //Basic initialization.
            SetContentView(Resource.Layout.Cursusview);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            mCursusView = FindViewById<ListView>(Resource.Id.CursusListView);

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
            
            //Sets listview (as CursusView)
            mItems = new List<CursusRij>();
            mItems.Add(new CursusRij(MainActivity.CursusArray[0].Foto, MainActivity.CursusArray[0].Naam, MainActivity.CursusArray[0].Samenvatting));
            mItems.Add(new CursusRij(MainActivity.CursusArray[1].Foto, MainActivity.CursusArray[1].Naam, MainActivity.CursusArray[1].Samenvatting));
            mItems.Add(new CursusRij(MainActivity.CursusArray[2].Foto, MainActivity.CursusArray[2].Naam, MainActivity.CursusArray[2].Samenvatting));
            mItems.Add(new CursusRij(MainActivity.CursusArray[3].Foto, MainActivity.CursusArray[3].Naam, MainActivity.CursusArray[3].Samenvatting));
            mItems.Add(new CursusRij(MainActivity.CursusArray[4].Foto, MainActivity.CursusArray[4].Naam, MainActivity.CursusArray[4].Samenvatting));
            mItems.Add(new CursusRij(MainActivity.CursusArray[5].Foto, MainActivity.CursusArray[5].Naam, MainActivity.CursusArray[5].Samenvatting));
            mItems.Add(new CursusRij(MainActivity.CursusArray[6].Foto, MainActivity.CursusArray[6].Naam, MainActivity.CursusArray[6].Samenvatting));

            CursusListViewAdapter cursusAdapter = new CursusListViewAdapter(this, mItems);
            mCursusView.Adapter = cursusAdapter;
            mCursusView.ItemClick += MCursusView_ItemClick;
        }

        private void MCursusView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int p = e.Position;
            MainActivity.CursusInt = p;
            Intent i0 = new Intent(this, typeof(IndivCursusView));
            this.StartActivity(i0);


        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int p = e.Position;
            switch (p)
            {

                case 0:
                    Intent i0 = new Intent(this, typeof(MainScreen));
                    this.StartActivity(i0);
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
                    mDrawerLayout.CloseDrawers();
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

        

        //For the hamburger
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            GAService.GetGASInstance().Track_App_Event(GAEventCategory.MenuOpen, "Menu is geopend");
            return base.OnOptionsItemSelected(item);
        }
    }
}