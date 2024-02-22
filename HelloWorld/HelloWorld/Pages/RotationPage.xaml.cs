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
    public partial class RotationPage : ContentPage
    {
        public RotationPage()
        {
            InitializeComponent();

            //lblText.BindingContext = sldRotation;
            //lblText.SetBinding(Label.RotationProperty, "Value");
        }

        //private void SldRotation_ValueChanged(object sender, ValueChangedEventArgs e)
        //{
            //var degrees = sldRotation.Value;
            //lblText.Rotation = degrees;
        //}
    }
}