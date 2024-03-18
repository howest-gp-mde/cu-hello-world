using FreshMvvm;
using HelloWorld.Domain.Models;
using HelloWorld.Domain.Services;
using HelloWorld.Domain.Services.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class ItemDetailsViewModel : FreshBasePageModel
    {
        IItemsService _itemsService;
        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }


        public string SerialNumber { get; set; }
        public Article SelectedArticle { get; set; }
        public bool IsAvailable { get; set; }

        public ItemState State { get; set; }

        public ItemDetailsViewModel()
        {
            _itemsService = new MockItemsService();
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            Id = (int)initData;

            FetchItem.Execute(null);
        }

        public ICommand FetchItem
        {
            get
            {
                return new Command(async () =>
                {
                    var item =await _itemsService.GetItemAsync(Id);
                });
            }
        }
    }
}
