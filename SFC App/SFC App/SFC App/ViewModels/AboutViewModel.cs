﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SFC_App.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Smart Food Choice";
        }

        
       

        private string appDescription = "This is simply the best app you have got to download pls give us money now.";
        public string AppDescription
        {
            get { return appDescription; }
        }
    }
}