using MvvmCross.Core.ViewModels;
using NMCT.Resto.CoreM.Model;
using NMCT.Resto.CoreM.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMCT.Resto.CoreM.ViewModels
{
    public class RestosTableViewModel : MvxViewModel
    {
        private readonly IRestoDataService _restoDataService;

        public RestosTableViewModel(IRestoDataService restoDataService)
        {
            _restoDataService = restoDataService;

            loadData();
        }

        private async void loadData()
        {
            RestosList = await _restoDataService.GetRestaurants();
        }

        private List<Restaurant> _restoslist;

        public List<Restaurant> RestosList
        {
            get { return _restoslist; }
            set { _restoslist = value; RaisePropertyChanged(() => RestosList); }
        }

    }
}
