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
        public static int CursusInt;
        public static Bitmap JanFoto, SjaakFoto, SlingerFoto, GarmFoto, CdFoto, SpmFoto, BdmpFoto, FBFoto, MdeFoto, AgilePOFoto, OAgileFoto;
        public static Bitmap cdlv, spmlv, bdmplv, fblv, mdelv, agilepolv, oagilelv;

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

        protected override void OnResume()
        {
            base.OnResume();
            OpenMainScreen();
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

            cdlv = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.cdlv, opt);
            spmlv = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.spmlv, opt);
            bdmplv = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.bmplv, opt);
            fblv = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.feedbacklv, opt);
            mdelv = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.mdelv, opt);
            agilepolv = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.agilepolv, opt);
            oagilelv = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.ontwikkellv, opt);



            string Locatie = "Buys Ballotgebouw,\r\n Princetonplein 5,\r\n Utrecht, 3584CC";
            List<ProgrammaRij> CDProgram = new List<ProgrammaRij>();
            CDProgram.Add(new ProgrammaRij("Datum", "Onderwerp", "Spreker"));
            CDProgram.Add(new ProgrammaRij("18-Jan", "Introductie en CD 3.0", "Jan Vlietland"));
            CDProgram.Add(new ProgrammaRij("25-Jan", "Continuous Integration", "Jan Vlietland, Gastspreker"));
            CDProgram.Add(new ProgrammaRij("01-Feb", "Continuous Testing", "Jan Vlietland, Gastspreker"));
            CDProgram.Add(new ProgrammaRij("08-Feb", "Continuous Deployment", "Jan Vlietland, Gastspreker"));
            CDProgram.Add(new ProgrammaRij("15-Feb", "Continuous Tracking", "Jan Vlietland, Google Nederland"));
            CDProgram.Add(new ProgrammaRij("22-Feb", "Continuous Planning", "Jan Vlietland"));
            CDProgram.Add(new ProgrammaRij("01-Mrt", "Cloudoplossingen", "Jan Vlietland, Microsoft Nederland"));
            CDProgram.Add(new ProgrammaRij("08-Mrt", "Continuous Improvement", "Jan Vlietland"));

            List<ProgrammaRij> SPMProgram = new List<ProgrammaRij>();
            SPMProgram.Add(new ProgrammaRij("Datum", "Onderwerp", "Spreker"));
            SPMProgram.Add(new ProgrammaRij("07-Mrt", "Introductie tot SPM", "Sjaak Brinkkemper, Garm Lucassen"));
            SPMProgram.Add(new ProgrammaRij("14-Mrt", "Requirementscollectie", "Sjaak Brinkkemper, Garm Lucassen"));
            SPMProgram.Add(new ProgrammaRij("21-Mrt", "Requirementsidentificatie en-organisatie", "Sjaak Brinkkemper, Garm Lucassen"));
            SPMProgram.Add(new ProgrammaRij("28-Mrt", "Release planning", "Garm Lucassen, Kevin Vlaanderen"));
            SPMProgram.Add(new ProgrammaRij("04-Apr", "Product planning", "Sjaak Brinkkemper, Garm Lucassen"));
            SPMProgram.Add(new ProgrammaRij("11-Apr", "Intellectual Property & Strategic SPM", "Ronald Wanink, Otto de Graaf"));
            SPMProgram.Add(new ProgrammaRij("18-Apr", "Portfolio management", "Ronald Wanink"));
            SPMProgram.Add(new ProgrammaRij("02-Mei", "Sales Channels & Offshoring", "Wim van de Brandt, Gertjo Tigelaar"));
            SPMProgram.Add(new ProgrammaRij("09-Mei", "Marketing & Agile SPM", "Klaas Klunder, David Griffieon"));
            SPMProgram.Add(new ProgrammaRij("16-Mei", "Rol v/d productmanager en afsluiting", "Sjaak Brinkkemper"));

            List<ProgrammaRij> BDMPProgram = new List<ProgrammaRij>();
            BDMPProgram.Add(new ProgrammaRij("Datum", "Onderwerp", "Spreker"));
            BDMPProgram.Add(new ProgrammaRij("12-Jan", "Introductie en Organization Design", "Slinger Jansen"));
            BDMPProgram.Add(new ProgrammaRij("19-Jan", "Ontwerp voor groei, de ideale klant", "Slinger Jansen"));
            BDMPProgram.Add(new ProgrammaRij("26-Jan", "Business models", "Slinger Jansen"));
            BDMPProgram.Add(new ProgrammaRij("02-Feb", "Partnering en Ecosystemen", "Slinger Jansen"));
            BDMPProgram.Add(new ProgrammaRij("09-Feb", "Productinternationalisatie en outsourcing", "Slinger Jansen"));
            BDMPProgram.Add(new ProgrammaRij("16-Feb", "Opzetten van een Internationale Salesorganisatie", "Gastspreker"));
            BDMPProgram.Add(new ProgrammaRij("23-Feb", "Strategische overnames: How to eat or to become eaten", "Slinger Jansen, Gastspreker"));
            BDMPProgram.Add(new ProgrammaRij("09-Mrt", "Funding voor productinnovatie en groei", "Gastspreker"));

            List<ProgrammaRij> FeedbackProgram = new List<ProgrammaRij>();
            FeedbackProgram.Add(new ProgrammaRij("Datum", "Onderwerp", "Spreker"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Introductie en Agile werken", "Jan Vlietland"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Feedback en de Product Manager", "Jan Vlietland"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Minimal Viable Products", "Jan Vlietland"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Feedback platformen", "Jan Vlietland, Gastspreker"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Business analytics", "Jan Vlietland, Gastdocent"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Continuous Planning", "Jan Vlietland"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Marketing & Social Media", "Gastdocent"));
            FeedbackProgram.Add(new ProgrammaRij("TBA", "Uitrollen van feedbackplatformen", "Jan Vlietland"));

            List<ProgrammaRij> MDEProgram = new List<ProgrammaRij>();
            MDEProgram.Add(new ProgrammaRij("Datum", "Onderwerp", "Spreker"));
            MDEProgram.Add(new ProgrammaRij("12-Jan", "Opfrisser: MDD, MDA, MDE", "Slinger Jansen"));
            MDEProgram.Add(new ProgrammaRij("19-Jan", "Ontwerpkeuzes voor MDD technieken", "SF"));
            MDEProgram.Add(new ProgrammaRij("26-Jan", "Interpretatie versus generatie: Architectuur voor MDD", "MO"));
            MDEProgram.Add(new ProgrammaRij("02-Feb", "Interfacing with Model Driven Software", "Slinger Jansen"));
            MDEProgram.Add(new ProgrammaRij("09-Feb", "MDD en Performance Engineering", "Gururaj Maddodi"));
            MDEProgram.Add(new ProgrammaRij("16-Feb", "Generalisatie en Genericiteit", "dr. A. Hommersom"));
            MDEProgram.Add(new ProgrammaRij("23-Feb", "Rule Based MDD", "Slinger Jansen"));
            MDEProgram.Add(new ProgrammaRij("09-Mrt", "Model Transformation", "Slinger Jansen"));
            MDEProgram.Add(new ProgrammaRij("16-Mrt", "Final Technology Demos", "Slinger Jansen"));

            List<ProgrammaRij> AgilePOProgram = new List<ProgrammaRij>();
            AgilePOProgram.Add(new ProgrammaRij("Datum", "Onderwerp", "Spreker"));
            AgilePOProgram.Add(new ProgrammaRij("14-Mrt", "Introductie Product Ownership", "Jan Wognum, gastspreker"));
            AgilePOProgram.Add(new ProgrammaRij("21-Mrt", "Product Management", "Jan Vlietland, gastspreker"));
            AgilePOProgram.Add(new ProgrammaRij("28-Mrt", "Backlog Management", "Jan Vlietland, gastspreker"));
            AgilePOProgram.Add(new ProgrammaRij("04-Apr", "Stakeholder Management", "Jan Vlietland, gastspreker"));
            AgilePOProgram.Add(new ProgrammaRij("11-Apr", "Product Ownership in complexe omgevingen", "Jan Vlietland, gastspreker"));

            List<ProgrammaRij> OntwikkelAgileProgram = new List<ProgrammaRij>();
            OntwikkelAgileProgram.Add(new ProgrammaRij("Datum", "Onderwerp", "Spreker"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("19-Apr", "Organisatiekunde", "Jan Vlietland"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("26-Apr", "Wendbare organisaties", "Jan Vlietland, gastspreker"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("03-Mei", "Scaled Agile raamwerken", "Jan Vlietland, gastspreker"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("10-Mei", "Organisatie-analyse", "Jan Vlietland, gastspreker"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("17-Mei", "Ontwikkelen van de Agile organisatie", "Jan Vlietland, gastspreker"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("24-Mei", "Veranderkunde", "Jan Vlietland"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("31-Mei", "Het veranderplan", "Jan Vlietland, gastspreker"));
            OntwikkelAgileProgram.Add(new ProgrammaRij("07-Jun", "Bespreken en evalueren", "Jan Vlietland"));


            Cursus CD3 = new Cursus("Continuous Delivery 3.0", "Steeds meer softwarebedrijven transformeren zich tot Agile enterprises. Zulke Agile enterprises leveren real time software aan klanten. Hiervoor gebruiken ze Continuous Delivery. Continuous Delivery maakt het mogelijk om software zeer snel te integreren, testen en uit te rollen.", "Met Continuous Delivery rol je software veel sneller uit met veel minder handmatige werkzaamheden. De next step is Continuous Delivery 3.0. Daarmee krijg je ook zicht op hoe je klant de software ervaart en hoe je softwareontwikkeling op een Agile wijze realiseert. De cursus is bedoeld voor een brede groep medewerkers bij softwarebedrijven, zowel managers als technici kunnen deelnemen. De cursus wordt afgesloten met een certificaat van deelname, uitgegeven door de Universiteit Utrecht.", CDProgram, "Kosten", Locatie, "http://nisi.nl/cursussen/continuousdeliverypipelines", CdFoto, cdlv);
            Cursus SPM = new Cursus("Software Product Management", "De productmanager is verantwoordelijk voor het bepalen van de nieuwe functionaliteit die per release geïmplementeerd zal worden. Daarbij is hij de spil tussen de interne stakeholders (zoals sales en development) en externe stakeholders (zoals klanten en partners).", "Veel bedrijven willen hun focus verleggen van maatwerksoftware naar standaard softwareproducten. We zien daarom dat het belang en de relevantie van de functie productmanager groeit. De productmanager is verantwoordelijk voor het bepalen van de nieuwe functionaliteit die per release geïmplementeerd zal worden. Daarbij is hij de spil tussen de interne stakeholders (zoals sales en development) en externe stakeholders (zoals klanten en partners).", SPMProgram, "Kosten", Locatie, "http://nisi.nl/cursussen/software-product-management", SpmFoto, spmlv);
            Cursus BDMP = new Cursus("Business Development voor Managers van Productsoftwarebedrijven", "De ware groei binnen een softwarebedrijf is te behalen via business development. Als een CXO (=CTO, CEO, COO, CTO, etc.) zich weet vrij te spelen door goed management, kan deze zich gaan richten op echte kansen.", "Een goede salesman of -vrouw kan de omzet van een productsoftwarebedrijf slechts  incrementeel verhogen. De ware groei binnen een softwarebedrijf is te behalen via business development. Als een CXO (=CTO, CEO, COO, CTO, etc.) zich weet vrij te spelen door goed management, kan deze zich gaan richten op echte kansen: internationalisatie, overnames, productinnovatie, partnering, etc. In deze cursus adresseren we precies die uitdagingen.", BDMPProgram, "Kosten", Locatie, "http://nisi.nl/cursussen/business-development",BdmpFoto, bdmplv);
            Cursus Feedback = new Cursus("Feedbackplatformen voor software-productmanagers", "In deze cursus leer je de mogelijkheden van een feedbackplatform en hoe je een feedbackplatform concreet opzet, integreert en uitrolt. We addresseren in de cursus alle relevante onderwerpen voor het uitnutten van zo'n feedbackplatform.", "Steeds meer softwarebedrijven leveren kort-cyclisch software aan de markt. Door software kort-cyclisch te leveren kun je snel inspelen op de behoefte van de klant. Maar hoe kom je die behoefte te weten, ofwel hoe krijg je goed inzicht in je gebruikers? \r\n\r\nIn deze cursus leer je de mogelijkheden van zo'n feedbackplatform en hoe je zo’n feedbackplatform concreet opzet, integreert en uitrolt.", FeedbackProgram, "Kosten", Locatie, "http://nisi.nl/cursussen/feedbackplatformen",FBFoto, fblv);
            Cursus MDE = new Cursus("Advanced Model Driven Engineering", "Softwarebedrijven boeken veel winst met het model gedreven ontwikkelen van software. Er is grote productiviteitswinst te boeken met gespecialiseerde tools die vanuit modellen software kunnen genereren. ", "Softwarebedrijven boeken veel winst met het model gedreven ontwikkelen van software. In deze cursus wordt ingegaan op de custom en productgebaseerde raamwerken die door softwarebedrijven worden ingezet. Developers en software architecten worden bekend gemaakt met de theorie achter dit soort raamwerken. Daarnaast worden participanten uitgedaagd om zelf gemaakte of commerciële modelgedreven platformen naar een hoger niveau te brengen.", MDEProgram, "Kosten", Locatie, "http://nisi.nl/cursussen/advanced-model-driven-engineering",MdeFoto, mdelv);
            Cursus AgilePO = new Cursus("Agile Product Ownership and Agile Product Management", "Veel softwaregedreven bedrijven ervaren de voordelen van het Agile werken. De Product Owner rol blijkt hierin een cruciale rol te hebben. Er wordt dan ook veel van de Product Owner verwacht.", "Veel softwaregedreven bedrijven ervaren de voordelen van het Agile werken. De Product Owner rol blijkt hierin een cruciale rol te hebben. Er wordt dan ook veel van de Product Owner verwacht, zoals productmanagement, stakeholdermanagement en backlogmanagement. In deze cursus komen al deze facetten aan bod. Daarnaast leer je ook hoe je je rol kunt handhaven in een grotere, complexere organisatie. ", AgilePOProgram, "Kosten", Locatie, "http://nisi.nl/cursussen/agile-product-ownership-and-product-management", AgilePOFoto, agilepolv);
            Cursus OntwikkelAgile = new Cursus("Ontwikkelen van Agile organisaties in de praktijk", "Veel Agile successen zijn te vinden in kleinschalige organisaties. Bij het toepassen van het Agile werken in grote organisaties lopen de Agile principes tegen allerlei organisatorische en culturele obstakels aan.", "Veel Agile successen zijn te vinden in kleinschalige organisaties. Bij het toepassen van het Agile werken in grote organisaties lopen de Agile principes tegen allerlei organisatorische en culturele obstakels aan. De bestaande scaled Agile raamwerken helpen daar maar beperkt bij. In deze cursus geven we een grondige verdieping in de organisatiekunde en veranderkunde. Met deze kennis ontwikkel je stap voor stap schaalbare Agile inrichtingen voor verschillende soorten organisaties..", OntwikkelAgileProgram, "Kosten", Locatie, "http://nisi.nl/cursussen/ontwikkelen-van-agile-organisaties-in-de-praktijk",OAgileFoto, oagilelv);
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
            string m2 = "Normaal Contact";
            string m3 = "Continuous Delivery 3.0";
            string m4 = "Software Product Management";
            string m5 = "Business Development voor Managers van Productsoftwarebedrijven";
            string m6 = "Feedbackplatformen voor software-productmanagers";
            string m7 = "Advanced Model Driven Engineering";
            string m8 = "Agile Product Ownership and Agile Product Management";
            string m9 = "Ontwikkelen van Agile organisaties in de praktijk";
            AanmeldArray = new string[10] { m0, m1,m2,m3,m4,m5,m6,m7,m8,m9 };

        }

    }
}

