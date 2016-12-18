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
using Android.Graphics;

namespace NISIApp
{
    public class TeamLid
    {

        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public Bitmap Foto { get; set; }

        public TeamLid (string naam, string beschrijving, Bitmap foto)
        {
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Foto = foto;
        }

        public TeamLid()
        {

        }

    }
}