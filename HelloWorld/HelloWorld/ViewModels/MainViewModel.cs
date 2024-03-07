using FreshMvvm;
using HelloWorld.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        private ObservableCollection<string> items;

        public ObservableCollection<string> Items
        {
            get { return items; }
            set
            {
                items = value;
                RaisePropertyChanged(nameof(Items));

            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }


        public ICommand AddToItemsCommand
        {
            get
            {
                return new Command<string>((string item) =>
                {
                    Items.Add(item);
                });
            }
        }

        public ICommand GoToItemsCommand
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PushPageModel<ItemsViewModel>();
                });
            }
        }

        public ICommand GoToIssueCommand
        {
            get
            {
                return new Command(async () => {
                    // navigeren naar IssuePage
                    // await Application.Current.MainPage.Navigation.PushAsync(new IssuePage(123));
                    await CoreMethods.PushPageModel<IssueViewModel>(125, false, true);
                });
            }
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<string>(new List<string> {
                "Ja", "Nee", "Joske Vermeulen", "Tramesante Lei"
            });
        }

    }
}
