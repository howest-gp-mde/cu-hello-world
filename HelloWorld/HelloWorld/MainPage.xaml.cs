using HelloWorld.Pages;
using HelloWorld.Services;
using HelloWorld.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MainPage : ContentPage
    {
        private const string ISSUE_NUMBER = "issue_number";
        int issueNumber = 0;
        public MainPage()
        {
            InitializeComponent();

            MainViewModel model = new MainViewModel();
            this.BindingContext = model;


            //Label lblNewLabel = new Label();
            //lblNewLabel.Text = "huppeldepup";
            //lblNewLabel.BackgroundColor = Color.YellowGreen;
            //lblNewLabel.TextColor = Color.Blue;

            //stkMain.Children.Add(lblNewLabel);

            var msgService = DependencyService.Get<IMessageService>();
            // lblWelcome.Text = msgService.GetWelcomeMessage();

       
            if (Application.Current.Properties.ContainsKey(ISSUE_NUMBER))
            {

                issueNumber = (int)Application.Current.Properties[ISSUE_NUMBER];
            }
            else
            {
                issueNumber = 1;
                Application.Current.Properties[ISSUE_NUMBER ] = issueNumber;
            }

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey(ISSUE_NUMBER))
            {
                issueNumber = (int)Application.Current.Properties[ISSUE_NUMBER];
                btnGoToIssue.Text = $"Go to issue nr {issueNumber}";
            }
        }

        private List<string> items = new List<string>();
        

        

        

        private async void BtnGoToIssue_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IssuePage(issueNumber));
        }

        private async void BtnGoToRotation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }
    }
}
