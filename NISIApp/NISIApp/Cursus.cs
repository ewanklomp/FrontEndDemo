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
    public class Cursus
    {

        public string Naam {get; set;}
        public string Beschrijving { get; set; }
        public string Programma { get; set; }
        public string Kosten { get; set; }
        public string Locatie { get; set; }
        public string Link { get; set; }


        public Cursus(string naam, string beschrijving, string programma, string kosten, string locatie ,string link)
        {
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Programma = programma;
            this.Kosten = kosten;
            this.Locatie = locatie;
            this.Link = link;
            
        }

        public Cursus()
        {

        }
            
    }
}