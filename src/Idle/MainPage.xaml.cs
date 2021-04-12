﻿using Idle.DataAccess.Repositories;
using Idle.Logic.ViewModels;
using Idle.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Idle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

		private async void LanguagesButton_Clicked(object sender, EventArgs e)
		{
			try
			{
                await NavigateToLanguagesPageAsync();
			}
			catch (Exception)
			{

				throw;
			}
		}

        private async Task NavigateToLanguagesPageAsync()
		{
            var languagesRepository = new LanguageRepository();
            var languagesPage = new LanguagesPage();
            var languagesViewModel = new LanguagesViewModel(languagesRepository);

            await languagesViewModel.LoadAsync();
            languagesPage.BindingContext = languagesViewModel;

            await Application.Current.MainPage.Navigation.PushAsync(languagesPage);

        }
	}
}
