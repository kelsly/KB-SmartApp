using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using NMCT.Resto.CoreM.Model;
using NMCT.Resto.CoreM.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMCT.Resto.CoreM.ViewModels
{
    public class RestoTabsViewModel : MvxViewModel
    {
        private readonly IRestoDataService _restoDataService;
        private readonly Lazy<TabInfoViewModel> _tabInfoViewModel;
        private readonly Lazy<TabReviewViewModel> _tabReviewModel;

        public TabInfoViewModel TabInfoVM => _tabInfoViewModel.Value;
        public TabReviewViewModel TabReviewVM => _tabReviewModel.Value;

        public RestoTabsViewModel(IRestoDataService restoDataService)
        {
            this._restoDataService = restoDataService;

            _tabInfoViewModel = new Lazy<TabInfoViewModel>(Mvx.IocConstruct<TabInfoViewModel>);
            _tabReviewModel = new Lazy<TabReviewViewModel>(Mvx.IocConstruct<TabReviewViewModel>);

            TabReviewVM.ParentViewModel = this;

            GetRestaurantData();
        }

        private Restaurant _restaurantContent;
        public Restaurant RestaurantContent
        {
            get { return _restaurantContent; }
            set
            {
                _restaurantContent = value;
                RaisePropertyChanged(() => RestaurantContent);
            }
        }

        public async void GetRestaurantData()
        {
            var restolist = await _restoDataService.GetRestaurants();
            RestaurantContent = restolist[13];
            RestaurantContent.Reviews = await _restoDataService.GetReviews(RestaurantContent.Id);
            RaisePropertyChanged(() => RestaurantContent);

            TabInfoVM.RestaurantContent = this.RestaurantContent;
        }

       
    }
}
