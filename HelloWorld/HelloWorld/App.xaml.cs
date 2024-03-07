using FreshMvvm;
using HelloWorld.Pages;
using HelloWorld.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
            this.MainPage = new FreshNavigationContainer(page);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
