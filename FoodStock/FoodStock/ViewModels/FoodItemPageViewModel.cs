using FoodStock.Models;
using FoodStock.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodStock.ViewModels
{
    public class FoodItemPageViewModel : ViewModelBase
    {
        protected IRepository<FoodItem, long> _repository;
        protected INavigationService _navigationService;
        private FoodItem _item;
        private bool _isModify = false;

        public FoodItem Item { get => _item; set => SetProperty(ref _item, value); }

        public FoodItemPageViewModel(INavigationService navigationService, IRepository<FoodItem, long> repository)
            : base(navigationService)
        {
            Title = "Item";
            _repository = repository;
            _navigationService = navigationService;
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _isModify = parameters.ContainsKey("item");
            if (_isModify)
            {
                Title = "Modify Item";
                Item = parameters.GetValue<FoodItem>("item");                
            }
            else
            {
                Title = "New Item";
                Item = new FoodItem { Id = _repository.NewId };
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            if (_isModify==false)
            {
                _repository.AddItem(Item);
            }
            else
            {
                _repository.UpdateItem(_item.Id, Item);
            }
        }
    }
}
