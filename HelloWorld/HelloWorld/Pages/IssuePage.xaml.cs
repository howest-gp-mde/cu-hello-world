using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IssuePage : ContentPage
    {
        public IssuePage()
        {
            InitializeComponent();
        }

        private async void BtnFix_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Issue fixed", "Congratulations, the " +
                "network is up again", "Maak het weer kapot (Annuleer)");
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnState_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet(
                "Actionsheet: In welke staat is het product?",
                "Annuleren",
                null,
                "Nieuwe", "Gebruikt", "Zo goed als kapot", "kapot"
                );

            if(action == "Nieuwe")
            {
                await DisplayAlert("state", "laat het product staan", "annuleer");
            }
            else
            {
                await DisplayAlert("state", "Vervang het product, we lapper" +
                    "ze er wel een nieuw product aan hun been", "annuleer");
            }
        }
    }
}