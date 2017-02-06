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
    [Activity(Label = "Wie zijn wij", Theme = "@style/MyTheme")]
    public class WieZijnWijView : AppCompatActivity
    {
        //Initialize
        SupportToolbar mToolbar;
        MyActionBarDrawerToggle mDrawerToggle;
        DrawerLayout mDrawerLayout;
        ListView mLeftDrawer;
        ImageView mJan, mSjaak, mSlinger, mGarm;
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            GAService.GetGASInstance().Track_App_Page("Wie zijn Wij Pagina");

            //Basic initialization.
            SetContentView(Resource.Layout.WieZijnWij);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            mJan = FindViewById<ImageView>(Resource.Id.janid);
            mSjaak = FindViewById<ImageView>(Resource.Id.sjaakid);
            mSlinger = FindViewById<ImageView>(Resource.Id.slingerid);
            mGarm = FindViewById<ImageView>(Resource.Id.garmid);


            //Button initialization
            mJan.Click += MJan_Click;
            mSjaak.Click += MSjaak_Click;
            mSlinger.Click += MSlinger_Click;
            mGarm.Click += MGarm_Click;


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

            
        }

        private void MGarm_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_InformationGarm dialogInfo = new dialog_InformationGarm();
            dialogInfo.Show(transaction, "dialog fragment");
        }

        private void MSlinger_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_InformationSlinger dialogInfo = new dialog_InformationSlinger();
            dialogInfo.Show(transaction, "dialog fragment");
        }

        private void MSjaak_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_InformationSjaak dialogInfo = new dialog_InformationSjaak();
            dialogInfo.Show(transaction, "dialog fragment");
        }

        private void MJan_Click(object sender, EventArgs e)
        {        

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_InformationJan dialogInfo = new dialog_InformationJan();
            dialogInfo.Show(transaction, "dialog fragment");
            

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
                    mDrawerLayout.CloseDrawers();
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

        

        //For the hamburger
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            GAService.GetGASInstance().Track_App_Event(GAEventCategory.MenuOpen, "Menu is geopend");
            return base.OnOptionsItemSelected(item);
        }
    }
}