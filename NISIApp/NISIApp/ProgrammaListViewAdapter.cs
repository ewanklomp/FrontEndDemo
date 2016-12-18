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

namespace NISIApp
{
    class ProgrammaListViewAdapter : BaseAdapter<ProgrammaRij>
        
    {
        public List<ProgrammaRij> mItems;
        private Context mContext;

        public ProgrammaListViewAdapter (Context context, List<ProgrammaRij> items)
        {
            mItems = items;
            mContext = context;
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ProgrammaRij this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listviewRow, null, false);   
                   
                    }
            TextView txtDatum = row.FindViewById<TextView>(Resource.Id.datum);
            txtDatum.Text = mItems[position].Datum;

            TextView txtOnderwerp = row.FindViewById<TextView>(Resource.Id.onderwerp);
            txtOnderwerp.Text = mItems[position].Onderwerp;

            TextView txtSpreker = row.FindViewById<TextView>(Resource.Id.sprekers);
            txtSpreker.Text = mItems[position].Spreker;

            return row;
        }


    }
}