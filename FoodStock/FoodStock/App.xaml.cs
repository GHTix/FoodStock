﻿using Prism;
using Prism.Ioc;
using FoodStock.ViewModels;
using FoodStock.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodStock.Services;
using FoodStock.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FoodStock
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/FoodListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRepository<FoodItem, long>, FoodItemReader>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<FoodListPage, FoodListPageViewModel>();
            containerRegistry.RegisterForNavigation<FoodItemPage, FoodItemPageViewModel>();
        }
    }
}
