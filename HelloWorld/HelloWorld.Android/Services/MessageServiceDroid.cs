using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(HelloWorld.Droid.Services.MessageServiceDroid))]
namespace HelloWorld.Droid.Services
{
    public class MessageServiceDroid : IMessageService
    {
        public string GetWelcomeMessage()
        {
            return "Welkom bij onze Pixel 5 ! Deze draait op Android...";
        }
    }
}