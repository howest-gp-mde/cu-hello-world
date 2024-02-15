using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Label lblNewLabel = new Label();
            lblNewLabel.Text = "huppeldepup";
            lblNewLabel.BackgroundColor = Color.YellowGreen;
            lblNewLabel.TextColor = Color.Blue;

            stkMain.Children.Add(lblNewLabel);

            var msgService = DependencyService.Get<IMessageService>();
            // lblWelcome.Text = msgService.GetWelcomeMessage();
        }

        private List<string> items = new List<string>();
        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            items.Add(txtName.Text);
            lstAnswers.ItemsSource = null;
            lstAnswers.ItemsSource = items;
        }

        private void BtnYes_Clicked(object sender, EventArgs e)
        {
            items.Add("Yes");
            lstAnswers.ItemsSource = null;
            lstAnswers.ItemsSource = items;
        }

        private void BtnNo_Clicked(object sender, EventArgs e)
        {
            items.Add("No");
            lstAnswers.ItemsSource = null;
            lstAnswers.ItemsSource = items;
        }
    }
}
