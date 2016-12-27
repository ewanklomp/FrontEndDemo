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
using static Android.Views.View;

namespace NISIApp
{
    [Activity(Label = "Cursus", Theme = "@style/MyTheme")]
    public class IndivCursusView : AppCompatActivity
    {
        //Initialize
        SupportToolbar mToolbar;
        MyActionBarDrawerToggle mDrawerToggle;
        DrawerLayout mDrawerLayout;
        ListView mLeftDrawer;
        TextView mTitel, mBeschrijving;
        ListView mProgramma;
        LinearLayout mTest;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Basic initialization.
            SetContentView(Resource.Layout.IndivCursus);
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            mTitel = FindViewById<TextView>(Resource.Id.txtTitel);
            mBeschrijving = FindViewById<TextView>(Resource.Id.txtBeschrijvingInv);
            mProgramma = FindViewById<ListView>(Resource.Id.IndivProgram);
            mTest = FindViewById<LinearLayout>(Resource.Id.testLL);



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



            //Setting the Right Cursus
            mTitel.Text = MainActivity.CursusArray[MainActivity.CursusInt].Naam;
            mBeschrijving.Text = MainActivity.CursusArray[MainActivity.CursusInt].Beschrijving;

            List<ProgrammaRij> Programma = MainActivity.CursusArray[MainActivity.CursusInt].Programma;
            ProgrammaListViewAdapter adapter = new ProgrammaListViewAdapter(this, Programma);
            mProgramma.Adapter = adapter;
            SetListViewHeightBasedOnChildren(mProgramma);
            mProgramma.Focusable = false;

        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int p = e.Position;
            switch (p)
            {

                case 0:
                    Intent i1 = new Intent(this, typeof(MainScreen));
                    this.StartActivity(i1);
                    break;
                case 1:
                    Intent i0 = new Intent(this, typeof(NieuwsView));
                    this.StartActivity(i0);
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

        

        //For the hamburger
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        public static void SetListViewHeightBasedOnChildren(ListView listView)
        {
            IListAdapter listAdapter = listView.Adapter;
            if (listAdapter == null)
            {
                return;
            }

            int totalHeight = listView.PaddingTop + listView.PaddingBottom;
            for (int i = 0; i < listAdapter.Count; i++)
            {
                View listItem = listAdapter.GetView(i, null, listView);
                if (listItem is ViewGroup)
                {
                    listItem.LayoutParameters = new global::Android.Views.ViewGroup.LayoutParams(global::Android.Views.ViewGroup.LayoutParams.WrapContent, global::Android.Views.ViewGroup.LayoutParams.WrapContent);
                }
                listItem.Measure(0, 0);
                totalHeight += listItem.MeasuredHeight;
            }

            global::Android.Views.ViewGroup.LayoutParams parameters = listView.LayoutParameters;
            parameters.Height = totalHeight + (listView.DividerHeight * (listAdapter.Count - 1));
            listView.LayoutParameters = parameters;
        }

    }
}