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

        public FoodItem Item { get => _item; set => SetProperty(ref _item, value); }
        public DelegateCommand RemoveItemCommand { get => new DelegateCommand(OnRemoveItem); }
        public DelegateCommand AddNewItemCommand { get => new DelegateCommand(OnAddNewItem); }


        public FoodItemPageViewModel(INavigationService navigationService, IRepository<FoodItem, long> repository)
            : base(navigationService)
        {
            Title = "Item";
            _repository = repository;
            _navigationService = navigationService;
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Item = parameters.GetValue<FoodItem>("item");
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            AddOrUpdateCurrentItem();
        }

        public async void OnRemoveItem()
        {
            _repository.DeleteItem(Item.Id);
            await _navigationService.NavigateAsync("FoodListPage");
        }

        public async void OnAddNewItem()
        {
            AddOrUpdateCurrentItem();
            var p = new NavigationParameters();
            FoodItem item = new FoodItem { Id = 0, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow };
            p.Add("item", item);
            await _navigationService.NavigateAsync("FoodItemPage", p);
        }

        public void AddOrUpdateCurrentItem()
        {
            if (Item.Id == 0)
                _repository.AddItem(Item);
            else
                _repository.UpdateItem(_item.Id, Item);
        }
    }
}
