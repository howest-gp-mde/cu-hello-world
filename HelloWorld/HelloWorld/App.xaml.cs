using FreshMvvm;
using HelloWorld.Domain.Services;
using HelloWorld.Domain.Services.Api;
using HelloWorld.Domain.Services.Mock;
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

            // Set main page
            var page = FreshPageModelResolver.ResolvePageModel<MainViewModel>();
            this.MainPage = new FreshNavigationContainer(page);

            // Set dependencies
            FreshIOC.Container
                .Register<IItemService, MockItemService>()
                .AsMultiInstance();
            FreshIOC.Container.Register<IArticleService, MockArticleService>();
            FreshIOC.Container.Register<ILocationService, ApiLocationService>();
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
