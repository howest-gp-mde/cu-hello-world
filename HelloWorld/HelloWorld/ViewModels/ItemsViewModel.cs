using FreshMvvm;
using HelloWorld.Domain.Models;
using HelloWorld.Domain.Services;
using HelloWorld.Domain.Services.Mock;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class ItemsViewModel: FreshBasePageModel
    {

        private IItemsService _itemService;

        public string Title { get; set; }

        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get => items;
            set
            {
                items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public ItemsViewModel() {
            _itemService = new MockItemsService();

            

            Title = "Een overzicht van alle items";
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            RefreshData.Execute(null);
        }

        public ICommand RefreshData
        {
            get
            {
                return new Command(async () =>
                {
                    List<Item> fetchedItems = await _itemService.GetItemsAsync();
                    Items = new ObservableCollection<Item>(fetchedItems);
                });
            }
        }
    }
}
