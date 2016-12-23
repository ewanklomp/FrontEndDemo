using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;
using System.Collections.Generic;
using Android.Graphics;

namespace NISIApp
{
    [Activity(Label = "NISI", MainLauncher = true, Icon = "@drawable/nisilogo",Theme ="@style/MyTheme")]
    public class MainActivity : Activity
    {
        public static Content[] KopjesArray;
        public static Cursus[] CursusArray;
        public static TeamLid[] TeamLidArray;
        public static string[] AanmeldArray;
        public static int AanmeldInt;
        public static Bitmap JanFoto, SjaakFoto, SlingerFoto, GarmFoto, CdFoto, SpmFoto, BdmpFoto, FBFoto, MdeFoto, AgilePOFoto, OAgileFoto;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Thread thread = new Thread(OpenMainScreen);
            thread.Start();
            VulKopjes();
            VulCursussen();
            VulTeamleden();
            VulAanmeldingen();

        }

        private void OpenMainScreen()
        {
            Thread.Sleep(5000);
            RunOnUiThread(() => {
                Intent i = new Intent(this, typeof(MainScreen));
                this.StartActivity(i);
            });
        }

        public void VulKopjes()
        {
            Content Home = new Content("🏠                Home");
            Content Nieuws = new Content("📰              Nieuws");
            Content WieZijnWij = new Content("👪           Wie zijn wij");
            Content Cursussen = new Content("📕            Cursussen");
            Content Consultancy = new Content("👨          Consultancy");
            Content Werkgroepen = new Content("✎           Werkgroepen");
            Content Contact = new Content("📞               Contact");
            KopjesArray = new Content[7] { Home, Nieuws, WieZijnWij, Cursussen, Consultancy, Werkgroepen, Contact };
                        
        }

        public void VulCursussen()
        {

            BitmapFactory.Options opt = new BitmapFactory.Options();
            opt.InScaled = false;
            CdFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.cd, opt);
            SpmFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.spm, opt);
            BdmpFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.bdmp, opt);
            FBFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.feedback2, opt);
            MdeFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.mde, opt);
            AgilePOFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.agile, opt);
            OAgileFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.oagile, opt);

            Cursus CD3 = new Cursus("Continuous Delivery 3.0", "Steeds meer softwarebedrijven transformeren zich tot Agile enterprises. Zulke Agile enterprises leveren real time software aan klanten. Hiervoor gebruiken ze Continuous Delivery. Continuous Delivery maakt het mogelijk om software zeer snel te integreren, testen en uit te rollen.", "Met Continuous Delivery rol je software veel sneller uit met veel minder handmatige werkzaamheden. De next step is Continuous Delivery 3.0. Daarmee krijg je ook zicht op hoe je klant de software ervaart en hoe je softwareontwikkeling op een Agile wijze realiseert. De cursus is bedoeld voor een brede groep medewerkers bij softwarebedrijven, zowel managers als technici kunnen deelnemen. De cursus wordt afgesloten met een certificaat van deelname, uitgegeven door de Universiteit Utrecht.", "Hier komt nog een programma", "De kosten van de cursus bedragen € 2.800,- per persoon excl. btw (€ 2.600,- voor leden van Nederland~ICT)", "Locatie", "http://nisi.nl/cursussen/continuousdeliverypipelines", CdFoto);
            Cursus SPM = new Cursus("Software Product Management", "De productmanager is verantwoordelijk voor het bepalen van de nieuwe functionaliteit die per release geïmplementeerd zal worden. Daarbij is hij de spil tussen de interne stakeholders (zoals sales en development) en externe stakeholders (zoals klanten en partners).", "Veel bedrijven willen hun focus verleggen van maatwerksoftware naar standaard softwareproducten. We zien daarom dat het belang en de relevantie van de functie productmanager groeit. De productmanager is verantwoordelijk voor het bepalen van de nieuwe functionaliteit die per release geïmplementeerd zal worden. Daarbij is hij de spil tussen de interne stakeholders (zoals sales en development) en externe stakeholders (zoals klanten en partners).", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/software-product-management", SpmFoto);
            Cursus BDMP = new Cursus("Business Development voor Managers van Productsoftwarebedrijven", "De ware groei binnen een softwarebedrijf is te behalen via business development. Als een CXO (=CTO, CEO, COO, CTO, etc.) zich weet vrij te spelen door goed management, kan deze zich gaan richten op echte kansen.", "Een goede salesman of -vrouw kan de omzet van een productsoftwarebedrijf slechts  incrementeel verhogen. De ware groei binnen een softwarebedrijf is te behalen via business development. Als een CXO (=CTO, CEO, COO, CTO, etc.) zich weet vrij te spelen door goed management, kan deze zich gaan richten op echte kansen: internationalisatie, overnames, productinnovatie, partnering, etc. In deze cursus adresseren we precies die uitdagingen.", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/business-development",BdmpFoto);
            Cursus Feedback = new Cursus("Feedbackplatformen voor software-productmanagers", "In deze cursus leer je de mogelijkheden van een feedbackplatform en hoe je een feedbackplatform concreet opzet, integreert en uitrolt. We addresseren in de cursus alle relevante onderwerpen voor het uitnutten van zo'n feedbackplatform.", "Steeds meer softwarebedrijven leveren kort-cyclisch software aan de markt. Door software kort-cyclisch te leveren kun je snel inspelen op de behoefte van de klant. Maar hoe kom je die behoefte te weten, ofwel hoe krijg je goed inzicht in je gebruikers? \r\n\r\nIn deze cursus leer je de mogelijkheden van zo'n feedbackplatform en hoe je zo’n feedbackplatform concreet opzet, integreert en uitrolt.", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/feedbackplatformen",FBFoto);
            Cursus MDE = new Cursus("Advanced Model Driven Engineering", "Softwarebedrijven boeken veel winst met het model gedreven ontwikkelen van software. Er is grote productiviteitswinst te boeken met gespecialiseerde tools die vanuit modellen software kunnen genereren. ", "Softwarebedrijven boeken veel winst met het model gedreven ontwikkelen van software. In deze cursus wordt ingegaan op de custom en productgebaseerde raamwerken die door softwarebedrijven worden ingezet. Developers en software architecten worden bekend gemaakt met de theorie achter dit soort raamwerken. Daarnaast worden participanten uitgedaagd om zelf gemaakte of commerciële modelgedreven platformen naar een hoger niveau te brengen.", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/advanced-model-driven-engineering",MdeFoto);
            Cursus AgilePO = new Cursus("Agile Product Ownership and Agile Product Management", "Veel softwaregedreven bedrijven ervaren de voordelen van het Agile werken. De Product Owner rol blijkt hierin een cruciale rol te hebben. Er wordt dan ook veel van de Product Owner verwacht.", "Veel softwaregedreven bedrijven ervaren de voordelen van het Agile werken. De Product Owner rol blijkt hierin een cruciale rol te hebben. Er wordt dan ook veel van de Product Owner verwacht, zoals productmanagement, stakeholdermanagement en backlogmanagement. In deze cursus komen al deze facetten aan bod. Daarnaast leer je ook hoe je je rol kunt handhaven in een grotere, complexere organisatie. ", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/agile-product-ownership-and-product-management", AgilePOFoto);
            Cursus OntwikkelAgile = new Cursus("Ontwikkelen van Agile organisaties in de praktijk", "Veel Agile successen zijn te vinden in kleinschalige organisaties. Bij het toepassen van het Agile werken in grote organisaties lopen de Agile principes tegen allerlei organisatorische en culturele obstakels aan.", "Veel Agile successen zijn te vinden in kleinschalige organisaties. Bij het toepassen van het Agile werken in grote organisaties lopen de Agile principes tegen allerlei organisatorische en culturele obstakels aan. De bestaande scaled Agile raamwerken helpen daar maar beperkt bij. In deze cursus geven we een grondige verdieping in de organisatiekunde en veranderkunde. Met deze kennis ontwikkel je stap voor stap schaalbare Agile inrichtingen voor verschillende soorten organisaties..", "Programma", "Kosten", "Locatie", "http://nisi.nl/cursussen/ontwikkelen-van-agile-organisaties-in-de-praktijk",OAgileFoto);
            CursusArray = new Cursus[7] { CD3, SPM, BDMP, Feedback, MDE, AgilePO, OntwikkelAgile };
        }

        private void VulTeamleden()
        {

            BitmapFactory.Options opt = new BitmapFactory.Options();
            opt.InScaled = false;
            JanFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.jan, opt);
            SjaakFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.sjaak, opt);
            SlingerFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.slinger, opt);
            GarmFoto = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.garm, opt);

            TeamLid Jan = new TeamLid("Jan Vlietland", "Beschrijving", JanFoto);
            TeamLid Sjaak = new TeamLid("Sjaak Brinkkemper", "Beschrijving", SjaakFoto);
            TeamLid Slinger = new TeamLid("Slinger Jansen", "Beschrijving", SlingerFoto);
            TeamLid Garm = new TeamLid("Garm Lucassen", "Beschrijving", GarmFoto);
            TeamLidArray = new TeamLid[4] { Jan, Sjaak, Slinger, Garm };

        }

        private void VulAanmeldingen()
        {

            string m0 = "Consultancy";
            string m1 = "Werkgroepen";
            string m2 = "Normaal Contanct";

            AanmeldArray = new string[3] { m0, m1,m2 };

        }

    }
}

