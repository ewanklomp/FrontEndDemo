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
    public class CursusRij
    {
        public Bitmap Foto { get; set; }
        public string Onderwerp { get; set; }
        public string Beschrijving { get; set; }

        public CursusRij(Bitmap foto, string onderwerp, string beschrijving)
        {
            this.Foto = foto;
            this.Onderwerp = onderwerp;
            this.Beschrijving = beschrijving;
        }

        public CursusRij()
        {

        }

    }
}