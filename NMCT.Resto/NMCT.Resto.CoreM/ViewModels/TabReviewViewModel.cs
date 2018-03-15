using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using NMCT.Resto.CoreM.Model;
using NMCT.Resto.CoreM.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMCT.Resto.CoreM.ViewModels
{

    public class TabReviewViewModel : MvxViewModel
    {

        protected readonly IRestoDataService _restoDataService;
        private readonly Lazy<TabInfoViewModel> _tabInfoViewModel;

        public TabInfoViewModel TabInfoVM => _tabInfoViewModel.Value;

        public TabReviewViewModel(IRestoDataService restoDataService)
        {
            this._restoDataService = restoDataService;

            NewReview = new Review();

            _tabInfoViewModel = new Lazy<TabInfoViewModel>(Mvx.IocConstruct<TabInfoViewModel>);
        }

        
        private RestoTabsViewModel  _parentViewModel;
        public RestoTabsViewModel ParentViewModel
        {
            get { return _parentViewModel; }
            set
            {
                _parentViewModel = value;
                RaisePropertyChanged(() => ParentViewModel);
            }
        }

        private Review _newReview;
        public Review NewReview
        {
            get { return _newReview; }
            set
            {
                _newReview = value;
                RaisePropertyChanged(() => NewReview);
            }
        }

        public MvxCommand SaveReviewCommand
        {
            get
            {
                return new MvxCommand(() => SaveReview());
            }
        }

        private async void SaveReview()
        {

            try
            {
                bool succes = await _restoDataService.AddReview(ParentViewModel.RestaurantContent.Id, NewReview);
                if (succes) NewReview = new Review();
                ParentViewModel.GetRestaurantData();
            } catch (Exception e) { throw e; }
        }
    }
}
