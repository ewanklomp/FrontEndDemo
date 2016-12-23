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
    public class ProgrammaRij
    {
        public string Datum { get; set; }
        public string Onderwerp { get; set; }
        public string Spreker { get; set; }

        public ProgrammaRij(string datum, string onderwerp, string spreker)
        {
            this.Datum = datum;
            this.Onderwerp = onderwerp;
            this.Spreker = spreker;
        }

        public ProgrammaRij()
        {

        }

    }
}