﻿using FreshMvvm;
using HelloWorld.Domain.Models;
using HelloWorld.Domain.Services;
using HelloWorld.Domain.Services.Mock;
using HelloWorld.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class ItemDetailsViewModel : FreshBasePageModel
    {
        IItemService _itemsService;
        IArticleService _articleService;

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; RaisePropertyChanged(nameof(IsBusy)); }
        }

        private string errorText;

        public string ErrorText
        {
            get { return errorText; }
            set { errorText = value; RaisePropertyChanged(nameof(ErrorText)); }
        }


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
        private string serialNumber;

        public string SerialNumber
        {
            get => serialNumber;
            set
            {
                serialNumber = value; 
                RaisePropertyChanged(nameof(SerialNumber));
                // Validate(new Item { SerialNumber = value, Article = new Article(), IsAvailable=true });
            }
        }

        private string serialNumberError;
        public string SerialNumberError
        {
            get => serialNumberError;
            set
            {
                serialNumberError = value;
                RaisePropertyChanged(nameof(SerialNumberError));
            }
        }

        private Location selectedLocation;

        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set { selectedLocation = value; RaisePropertyChanged(nameof(SelectedLocation)); }
        }


        private Article selectedArticle;
        public Article SelectedArticle { get => selectedArticle; set { selectedArticle = value; RaisePropertyChanged(nameof(SelectedArticle)); } }

        private bool isAvailable;
        public bool IsAvailable { get => isAvailable; set { isAvailable = value; RaisePropertyChanged(nameof(IsAvailable)); } }

        private ObservableCollection<Article> articles;

        public ObservableCollection<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value; RaisePropertyChanged(nameof(Articles));
            }
        }

        private ObservableCollection<Location> locations;
        private ILocationService _locationService;

        public ObservableCollection<Location> Locations
        {
            get { return locations; }
            set { locations = value; RaisePropertyChanged(nameof(Locations)); }
        }



        public ItemDetailsViewModel(
            IItemService itemService, 
            IArticleService articleService,
            ILocationService locationService)
        {
            _itemsService = itemService;
            _articleService = articleService;
            _locationService = locationService;
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            Id = (int)initData;

            LoadData.Execute(null);
        }

        public ICommand LoadData
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    Locations = new ObservableCollection<Location>(await _locationService.GetLocations());
                    Articles = new ObservableCollection<Article>(
                        await _articleService.GetArticlesAsync()
                        );
                    var item = await _itemsService.GetItemAsync(Id);
                    SelectedArticle = item.Article;
                    SelectedLocation = item.Location;
                    SerialNumber = item.SerialNumber;
                    IsAvailable = item.IsAvailable;
                    IsBusy = false;

                });
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Item item = new Item();
                    item.Id = Id;
                    item.SerialNumber = SerialNumber;
                    item.Article = SelectedArticle;
                    item.IsAvailable = IsAvailable;
                    item.Location = SelectedLocation;

                    if (Validate(item))
                    {
                        await _itemsService.SaveItemAsync(item);
                        await CoreMethods.PopPageModel(new { });
                    }
                    //else
                    //{
                    //    ErrorText = "Er is iets fout";
                    //}
                });
            }
        }



        private bool Validate(Item item)
        {

            ItemsValidator validator = new ItemsValidator();

            var result = validator.Validate(item);

            ErrorText = "";
            foreach(var error in  result.Errors)
            {
                ErrorText += error.ErrorMessage + "\n";

                if(error.PropertyName == nameof(SerialNumber))
                {
                    SerialNumberError = error.ErrorMessage;
                }
            }
            return result.IsValid;
            //if (item.SerialNumber.Length < 3)
            //{
            //    SerialNumberError = "De lengte van de serienummer is niet lang genoeg.";
            //    return false;
            //}
            //else
            //{
            //    SerialNumberError = "";
            //}

            //if (item.Article is null)
            //{
            //    return false;
            //}
            //return true;
        }
    }
}
