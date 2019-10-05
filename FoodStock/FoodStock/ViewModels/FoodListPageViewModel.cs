using FoodStock.Models;
using FoodStock.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FoodStock.ViewModels
{
    public class FoodListPageViewModel : ViewModelBase
    {
        protected IRepository<FoodItem, long> _repository;
        protected ObservableCollection<FoodItem> _items;

        public ObservableCollection<FoodItem> SampleItems { get => _items; set => SetProperty(ref _items, value); }

        public FoodItem SelectedItem { get; set; }

        public FoodListPageViewModel(INavigationService navigationService, IRepository<FoodItem, long> repository)
            : base(navigationService)
        {
            Title = "Liste";
            _repository = repository;
            _items = new ObservableCollection<FoodItem>(_repository.GetItems());
        }
    }
}
