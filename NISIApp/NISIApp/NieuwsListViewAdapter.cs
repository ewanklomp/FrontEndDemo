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
    class NieuwsListViewAdapter : BaseAdapter<Nieuws>
        
    {
        public List<Nieuws> mNieuwsItems;
        private Context mContext;
        

        public NieuwsListViewAdapter (Context context, List<Nieuws> items)
        {
            mNieuwsItems = items;
            mContext = context;
        }

        public override int Count
        {
            get { return mNieuwsItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Nieuws this[int position]
        {
            get { return mNieuwsItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listviewRowNieuws, null, false);   
                   
                    }
            TextView txtDatum = row.FindViewById<TextView>(Resource.Id.txtDatum);
            txtDatum.Text = mNieuwsItems[position].Datum;

            TextView txtTitel = row.FindViewById<TextView>(Resource.Id.txtTitel);
            txtTitel.Text = mNieuwsItems[position].Titel;

            TextView txtOndertitel = row.FindViewById<TextView>(Resource.Id.txtOnderTitel);
            txtOndertitel.Text = mNieuwsItems[position].Ondertitel;

            TextView txtNieuwsartikel = row.FindViewById<TextView>(Resource.Id.txtNieuwsArtikel);
            txtNieuwsartikel.Text = mNieuwsItems[position].Tekst;

            return row;
        }


    }
}