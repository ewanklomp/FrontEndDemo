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
    public class Content
    {
        
        

        public string Kopjes { get; set; }

        public Content (string kopjes)
        {
            
            this.Kopjes = kopjes;
        }

        public Content()
        {

        }

    }
}
