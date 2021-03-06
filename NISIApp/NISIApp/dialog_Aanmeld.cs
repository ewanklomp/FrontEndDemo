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
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Net.Mail;

namespace NISIApp
{

    public class OnAanmeldEventArgs : EventArgs //EventArgs with the right kind of input so that it can be used in the mainactivity.
    {
        private string mNaam;
        private string mEmail;
        private string mNummer;
        private string mBedrijf;
        private string mFunctie;


        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }

        public string Naam
        {
            get { return mNaam; }
            set { mNaam = value; }
        }

        public string Nummer
        {
            get { return mNummer; }
            set { mNummer = value; }
        }

        public string Bedrijf
        {
            get { return mBedrijf; }
            set { mBedrijf = value; }
        }

        public string Functie
        {
            get { return mFunctie; }
            set { mFunctie = value; }
        }

        public OnAanmeldEventArgs(string email, string naam, string tlnnmr, string bedrijf, string functie) : base()
        {
            Email = email;
            Naam = naam;
            Nummer = tlnnmr;
            Bedrijf = bedrijf;
            Functie = functie;

        }

    }

    public class dialog_Aanmeld : DialogFragment
    {

        private EditText mTxtNaam, mTxtEmail, mTxtNummer, mTxtBedrijf, mTxtFunctie;
        private TextView mTxtWarning, mTitel;
        private ImageView mVerstuur;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            GAService.GetGASInstance().Track_App_Page("Aanmeld Pagina");
            GAService.GetGASInstance().Track_App_Event(GAEventCategory.AanmeldOpen, "Aanmeld pagina is open");

            var view = inflater.Inflate(Resource.Layout.dialog_Aanmeld, container, false);
            mTitel = view.FindViewById<TextView>(Resource.Id.txtTitel);
            mTxtNaam = view.FindViewById<EditText>(Resource.Id.txtNaam);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtNummer = view.FindViewById<EditText>(Resource.Id.txtNummer);
            mTxtBedrijf = view.FindViewById<EditText>(Resource.Id.txtBedrijf);
            mTxtFunctie = view.FindViewById<EditText>(Resource.Id.txtFunctie);
            mTxtWarning = view.FindViewById<TextView>(Resource.Id.txtWarning);
            mVerstuur = view.FindViewById<ImageView>(Resource.Id.verstuurbtn);

            mVerstuur.Click += MVerstuur_Click;

            if (MainActivity.AanmeldInt == 2)
            {
                mTitel.Text = "Contact Opnemen";
            }

            return view;
        }

        private void MVerstuur_Click(object sender, EventArgs ea)
        {
            if (mTxtNaam.Text != "" && mTxtEmail.Text != "" && mTxtNummer.Text != "" && mTxtBedrijf.Text != "" && mTxtFunctie.Text != "")
            {
                this.Dismiss();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("NISI App", "teamkoob@gmail.com"));
                message.To.Add(new MailboxAddress("Ewan Klomp", "e.klomp@nisi.nl"));
                message.Subject = MainActivity.AanmeldArray[MainActivity.AanmeldInt];

                message.Body = new TextPart("plain")
                {
                    Text = @"Er is contact opgenomen over het onderwerp in de titel.

Naam: " + mTxtNaam.Text +
"\r\nEmail: " + mTxtEmail.Text +
"\r\nNummer: " + mTxtNummer.Text +
"\r\nBedrijf: " + mTxtBedrijf.Text +
"\r\nFunctie: " + mTxtFunctie.Text
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    try
                    {// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.Connect("smtp.gmail.com", 587);

                        // Note: since we don't have an OAuth2 token, disable
                        // the XOAUTH2 authentication mechanism.
                        client.AuthenticationMechanisms.Remove("XOAUTH2");

                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate("teamkoob@gmail.com", "ResacaBoys");

                        client.Send(message);
                        client.Disconnect(true);

                        Toast.MakeText(this.Activity, "Succes! We zullen zo snel mogelijk contact met u opnemen!", Android.Widget.ToastLength.Short).Show();
                        GAService.GetGASInstance().Track_App_Event(GAEventCategory.AanmeldVerstuur, "Aanmelding is verstuurd");
                    }

                    catch (System.Net.Sockets.SocketException e)
                    {
                        Toast.MakeText(this.Activity, "Geen verbinding kunnen maken, probeer het later nog een keer!", Android.Widget.ToastLength.Short).Show();
                    }

                    /*try
                    {
                        MailMessage mail = new MailMessage();
                        System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("teamkoob@gmail.com");
                        mail.To.Add("e.klomp@nisi.nl");
                        mail.Subject = "Thank you for signing up for our newsletter!";
                        mail.Body = "You'll soon receive the first edition of Koob News!";
                        SmtpServer.Port = 465;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("teamkoob@gmail.com", "ResacaBoys");
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                    }
                    catch (System.Net.Mail.SmtpException e)
                    {
                        Toast.MakeText(this.Activity, e.Message, Android.Widget.ToastLength.Short).Show();
                        
                    }
                    */

                }




            }

            else
            {
                mTxtWarning.Text = "Vul alstublieft alle velden in!";
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)//Erases title of screen
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
        }


    }

    public class dialog_Feedback : DialogFragment
    {

        private EditText mTxtNaam, mTxtEmail, mOpmerking;
        private ImageView mVerstuur;


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            GAService.GetGASInstance().Track_App_Page("Feedback");
            GAService.GetGASInstance().Track_App_Event(GAEventCategory.FeedbackOpen, "Feedback pagina is open");

            var view = inflater.Inflate(Resource.Layout.dialog_Feedback, container, false);

            mTxtNaam = view.FindViewById<EditText>(Resource.Id.txtNaamFeedback);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmailFeedback);
            mOpmerking = view.FindViewById<EditText>(Resource.Id.txtOpmerking);
            mVerstuur = view.FindViewById<ImageView>(Resource.Id.verstuurbtnFeedback);

            mVerstuur.Click += MVerstuur_Click;


            return view;
        }

        private void MVerstuur_Click(object sender, EventArgs ea)
        {

            this.Dismiss();
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("NISI App", "teamkoob@gmail.com"));
            message.To.Add(new MailboxAddress("Ewan Klomp", "e.klomp@nisi.nl"));
            message.Subject = "Feedback";

            message.Body = new TextPart("plain")
            {
                Text = @"Dit is feedback ingestuurd door:

Naam: " + mTxtNaam.Text +
"\r\nEmail: " + mTxtEmail.Text +
"\r\nOpmerking: " + mOpmerking.Text
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.gmail.com", 25, false);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("teamkoob@gmail.com", "ResacaBoys");

                    client.Send(message);
                    client.Disconnect(true);
                    Toast.MakeText(this.Activity, "Succes! We zullen zo snel mogelijk contact met u opnemen!", Android.Widget.ToastLength.Short).Show();
                    GAService.GetGASInstance().Track_App_Event(GAEventCategory.FeedbackVerstuur, "Feedback is verstuurd");

                }
                catch (System.Net.Sockets.SocketException e)
                {
                    Toast.MakeText(this.Activity, "Geen verbinding kunnen maken, probeer het later nog een keer!", Android.Widget.ToastLength.Short).Show();
                }
            }


        }

        public override void OnActivityCreated(Bundle savedInstanceState)//Erases title of screen
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
        }


    }

    public class dialog_CDDemo : DialogFragment
    {
        private EditText mNaamWeb;
        private ProgressBar mProgressWeb;
        private TextView mTxtCountWeb;
        private Button mButtonWeb;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            GAService.GetGASInstance().Track_App_Page("CD3.0 Demo");
           

            var view = inflater.Inflate(Resource.Layout.dialog_CDDemo, container, false);
            mNaamWeb = view.FindViewById<EditText>(Resource.Id.txtWebNaam);

            mProgressWeb = view.FindViewById<ProgressBar>(Resource.Id.WebProgress);
            mProgressWeb.Visibility = ViewStates.Invisible;

            mTxtCountWeb = view.FindViewById<TextView>(Resource.Id.WebKnopCountTxt);

            mTxtCountWeb.Text = MainActivity.CurrentID;
            if (MainActivity.CurrentID == "Server is op dit moment niet bereikbaar")
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("NISI App", "teamkoob@gmail.com"));
                message.To.Add(new MailboxAddress("Ewan Klomp", "e.klomp@nisi.nl"));
                message.Subject = "Server is Down";

                message.Body = new TextPart("plain")
                {
                    Text = @"Er is op " + DateTime.Now + " UTC geprobeerd een connectie te maken met de server, maar dit is niet gelukt. Check of hij nog werkt graag."

                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    try
                    {
                        // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                        client.Connect("smtp.gmail.com", 25, false);

                        // Note: since we don't have an OAuth2 token, disable
                        // the XOAUTH2 authentication mechanism.
                        client.AuthenticationMechanisms.Remove("XOAUTH2");

                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate("teamkoob@gmail.com", "ResacaBoys");

                        client.Send(message);
                        client.Disconnect(true);
                        GAService.GetGASInstance().Track_App_Event(GAEventCategory.FeedbackVerstuur, "Server issue mail is verstuurd");

                    }
                    catch (System.Net.Sockets.SocketException e)
                    {
                        
                    }
                }
            }

            mButtonWeb = view.FindViewById<Button>(Resource.Id.BtnWebRequest);
            mButtonWeb.Click += MButtonWeb_Click;

            return view;
        }

        private void MButtonWeb_Click(object sender, EventArgs e)
        {
            mProgressWeb.Visibility = ViewStates.Visible;                                
            MainActivity.VulWebInitialWebrequest(mNaamWeb.Text);
            Toast.MakeText(this.Activity, MainActivity.CurrentContent, Android.Widget.ToastLength.Short).Show();
                   
                      
            mTxtCountWeb.Text = MainActivity.CurrentID;
            


            mProgressWeb.Visibility = ViewStates.Invisible;

        }

        

        public override void OnActivityCreated(Bundle savedInstanceState)//Erases title of screen
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
        }
    }
}