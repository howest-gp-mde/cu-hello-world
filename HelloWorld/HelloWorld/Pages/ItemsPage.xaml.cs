using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Domain.Models;
using HelloWorld.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        
        public ItemsPage()
        {
            InitializeComponent();

            // lstItems.ItemsSource = mockItems;
            var viewModel = new ItemsViewModel();
            viewModel.Title = "Een overzicht van alle items";
            this.BindingContext = viewModel;
        }
    }
}