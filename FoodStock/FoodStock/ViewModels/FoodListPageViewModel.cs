using FoodStock.Models;
using FoodStock.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodStock.ViewModels
{
    public class FoodListPageViewModel : ViewModelBase
    {
        protected IRepository<FoodItem, long> _repository;
        protected INavigationService _navigationService;
        protected ObservableCollection<FoodItem> _items;

        public ObservableCollection<FoodItem> Items { get => _items; set => SetProperty(ref _items, value); }

        public FoodItem SelectedItem { get; set; }
        public DelegateCommand AddItemCommand { get; }

        public DelegateCommand SelectedItemCommand { get; }


        public FoodListPageViewModel(INavigationService navigationService, IRepository<FoodItem, long> repository)
            : base(navigationService)
        {
            Title = "Liste";
            _repository = repository;
            _navigationService = navigationService;

            AddItemCommand = new DelegateCommand(OnAddItem);
            SelectedItemCommand = new DelegateCommand(OnSelectedItem);

            Items = new ObservableCollection<FoodItem>(_repository.GetItems());

           
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Items = new ObservableCollection<FoodItem>(_repository.GetItems());
            base.OnNavigatedTo(parameters);
        }

        public async void OnAddItem()
        {
            await _navigationService.NavigateAsync("FoodItemPage");

        }

        public async void OnSelectedItem()
        {
            var p = new NavigationParameters();
            p.Add("item", SelectedItem);
            await NavigationService.NavigateAsync("FoodItemPage", p);
        }
    }
}
