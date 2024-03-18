using FreshMvvm;
using HelloWorld.Domain.Models;
using HelloWorld.Domain.Services;
using HelloWorld.Domain.Services.Mock;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        private Item selectedItem;

        public Item SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;

                // RaisePropertyChanged(nameof(SelectedItem));
                GoToDetailPage.Execute(null);
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

        public ICommand GoToDetailPage
        {
            get
            {
                return new Command(async () =>
                {
                    if(SelectedItem != null)
                        await CoreMethods.PushPageModel<ItemDetailsViewModel>(SelectedItem.Id, false, true);
                });
            }
        }
      
    }
}
