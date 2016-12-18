using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;
using System.Collections.Generic;

namespace NISIApp
{
    [Activity(Label = "NISI", MainLauncher = true, Icon = "@drawable/nisilogo",Theme ="@style/MyTheme")]
    public class MainActivity : Activity
    {
        public static Content[] KopjesArray;
        public static Cursus[] CursusArray;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Thread thread = new Thread(ActLikeRequest);
            thread.Start();
            VulKopjes();
            VulCursussen();
        }

        private void ActLikeRequest()
        {
            Thread.Sleep(4000);
            RunOnUiThread(() => {
                Intent i = new Intent(this, typeof(MainScreen));
                this.StartActivity(i);
            });
        }

        public void VulKopjes()
        {
            Content Home = new Content("Home");
            Content Nieuws = new Content("Nieuws");
            Content WieZijnWij = new Content("Wie zijn wij");
            Content Cursussen = new Content("Cursussen");
            Content Consultancy = new Content("Consultancy");
            Content Werkgroepen = new Content("Werkgroepen");
            Content Contact = new Content("Contact");
            KopjesArray = new Content[7] { Home, Nieuws, WieZijnWij, Cursussen, Consultancy, Werkgroepen, Contact };
                        
        }

        public void VulCursussen()
        {

            Cursus CD3 = new Cursus("Continuous Delivery 3.0", "Met Continuous Delivery rol je software veel sneller uit met veel minder handmatige werkzaamheden. De next step is Continuous Delivery 3.0. Daarmee krijg je ook zicht op hoe je klant de software ervaart en hoe je softwareontwikkeling op een Agile wijze realiseert.", "Hier komt nog een programma", "De cursus is bedoeld voor een brede groep medewerkers bij softwarebedrijven, zowel managers als technici kunnen deelnemen. De cursus wordt afgesloten met een certificaat van deelname, uitgegeven door de Universiteit Utrecht. De kosten van de cursus bedragen € 2.800,- per persoon excl. btw (€ 2.600,- voor leden van Nederland~ICT)", "Locatie", "http://nisi.nl/cursussen/continuousdeliverypipelines");
            Cursus SPM = new Cursus("Software Product Management", "Beschrijving", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/software-product-management");
            Cursus BDMP = new Cursus("Business Development voor Managers van Productsoftwarebedrijven", "Beschrijving", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/business-development");
            Cursus Feedback = new Cursus("Feedbackplatformen voor software-productmanagers", "Beschrijving", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/feedbackplatformen");
            Cursus MDE = new Cursus("Advanced Model Driven Engineering", "Beschrijving", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/advanced-model-driven-engineering");
            Cursus AgilePO = new Cursus("Agile Product Ownership and Agile Product Management", "Beschrijving", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/agile-product-ownership-and-product-management");
            Cursus OntwikkelAgile = new Cursus("Ontwikkelen van Agile organisaties in de praktijk", "Beschrijving", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/ontwikkelen-van-agile-organisaties-in-de-praktijk");
            CursusArray = new Cursus[7] { CD3, SPM, BDMP, Feedback, MDE, AgilePO, OntwikkelAgile };
        }


    }
}

