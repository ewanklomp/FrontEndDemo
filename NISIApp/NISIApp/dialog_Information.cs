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
    public class OnInformationEventArgs : EventArgs //EventArgs with the right kind of input so that it can be used in the mainactivity.
    {

        public OnInformationEventArgs() : base()
        {

        }

    }

    class dialog_InformationJan : DialogFragment
    {


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_InformationJan, container, false);



            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)//Erases title of screen
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
        }


    }

    class dialog_InformationSjaak : DialogFragment
    {


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_InformationSjaak, container, false);



            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)//Erases title of screen
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
        }


    }
    class dialog_InformationSlinger : DialogFragment
    {


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_InformationSlinger, container, false);



            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)//Erases title of screen
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
        }


    }

    class dialog_InformationGarm : DialogFragment
    {


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_InformationGarm, container, false);



            return view;
        }


        public override void OnActivityCreated(Bundle savedInstanceState)//Erases title of screen
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnActivityCreated(savedInstanceState);
        }





    }
}