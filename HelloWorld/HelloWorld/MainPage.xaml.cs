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
            lblWelcome.Text = msgService.GetWelcomeMessage();
        }
    }
}
