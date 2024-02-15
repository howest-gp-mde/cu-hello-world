using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(HelloWorld.UWP.Services.MessageServiceUwp))]
namespace HelloWorld.UWP.Services
{
    public class MessageServiceUwp : IMessageService
    {
        public string GetWelcomeMessage()
        {
            return "Welkom op onze XBOX - Mitch neemt hem nog mee";
        }
    }
}
