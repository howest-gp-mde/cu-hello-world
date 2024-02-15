using Foundation;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(HelloWorld.iOS.Services.MessageServiceIOS))]
namespace HelloWorld.iOS.Services
{
    public class MessageServiceIOS : IMessageService
    {
        public string GetWelcomeMessage()
        {
            return "Welkom op IOS!";
        }
    }
}