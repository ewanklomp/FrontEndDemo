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
    public class Cursus
    {

        public string Naam {get; set;}
        public string Samenvatting { get; set; }
        public string Beschrijving { get; set; }
        public string Programma { get; set; }
        public string Kosten { get; set; }
        public string Locatie { get; set; }
        public string Link { get; set; }
        public Bitmap Foto { get; set; }


        public Cursus(string naam, string samenvatting, string beschrijving, string programma, string kosten, string locatie ,string link, Bitmap foto)
        {

            this.Naam = naam;
            this.Samenvatting = samenvatting;
            this.Beschrijving = beschrijving;
            this.Programma = programma;
            this.Kosten = kosten;
            this.Locatie = locatie;
            this.Link = link;
            this.Foto = foto;
            
        }

        public Cursus()
        {

        }
            
    }
}