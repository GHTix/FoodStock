using FoodStock.Models;
using FoodStock.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        public DelegateCommand AddItemCommand { get => new DelegateCommand(OnAddItem); }
        public DelegateCommand SelectedItemCommand { get => new DelegateCommand(OnSelectedItem); }


        public FoodListPageViewModel(INavigationService navigationService, IRepository<FoodItem, long> repository)
            : base(navigationService)
        {
            Title = "Liste";
            _repository = repository;
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Items = new ObservableCollection<FoodItem>(_repository.GetItems().OrderBy(x => x.UseByDate));
        }

        public async void OnAddItem()
        {
            await NavigateEditAsync(true);
        }

        public async void OnSelectedItem()
        {
            await NavigateEditAsync(false);
        }

        public async Task NavigateEditAsync(bool isNew)
        {
            var p = new NavigationParameters();
            FoodItem item = (isNew == true) ?
                                    new FoodItem { Id = 0, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow } :
                                    SelectedItem;
            p.Add("item", item);
            await _navigationService.NavigateAsync("FoodItemPage", p);
        }
    }
}
