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
    class CursusListViewAdapter : BaseAdapter<CursusRij>
        
    {
        public List<CursusRij> mCursusItems;
        private Context mContext;
        

        public CursusListViewAdapter (Context context, List<CursusRij> items)
        {
            mCursusItems = items;
            mContext = context;
        }

        public override int Count
        {
            get { return mCursusItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override CursusRij this[int position]
        {
            get { return mCursusItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listviewRowCursus, null, false);   
                   
                    }
            ImageView txtFoto = row.FindViewById<ImageView>(Resource.Id.fotoCursus);
            txtFoto.SetImageBitmap(mCursusItems[position].Foto);

            TextView txtOnderwerp = row.FindViewById<TextView>(Resource.Id.onderwerpCursus);
            txtOnderwerp.Text = mCursusItems[position].Onderwerp;

            TextView txtSpreker = row.FindViewById<TextView>(Resource.Id.sprekersCursus);
            txtSpreker.Text = mCursusItems[position].Beschrijving;

            return row;
        }


    }
}