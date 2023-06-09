﻿using DomainLib.Models;
using JobSearch.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private UserService _service;

        public Login()
        {
            InitializeComponent();

            _service = new UserService();
        }

        private void Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void GoStart(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;

            User user = await _service.GetUser(email, password);
            if(user == null)
            {
               await DisplayAlert("Erro", "Nenhum usuário encontrado!", "OK");
            }
            else
            {      
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(user));
                await App.Current.SavePropertiesAsync();
                App.Current.MainPage = new NavigationPage(new Start());
            }          
        }
    }
}