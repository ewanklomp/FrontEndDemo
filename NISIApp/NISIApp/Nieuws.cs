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
    public class Nieuws
    {

        public string Datum {get; set;}
        public string Titel { get; set; }
        public string Ondertitel { get; set; }
        public string Tekst { get; set; }
        public string Categorie { get; set; }


        public Nieuws(string datum, string titel, string ondertitel, string tekst, string categorie)
        {
            this.Datum = datum;
            this.Titel = titel;
            this.Ondertitel = ondertitel;
            this.Tekst = tekst;
            this.Categorie = categorie;
            
            
        }

        public Nieuws()
        {

        }
            
    }
}