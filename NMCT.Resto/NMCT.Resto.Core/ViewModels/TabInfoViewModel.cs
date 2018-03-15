using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMCT.Resto.Core.ViewModels
{
    public class TabInfoViewModel : MvxViewModel
    {

        private string _name = "nmct";

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {

                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

    }
}
