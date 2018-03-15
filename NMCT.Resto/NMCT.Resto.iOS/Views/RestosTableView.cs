using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using NMCT.Resto.CoreM.ViewModels;
using NMCT.Resto.iOS.TableViewSources;
using System;
using UIKit;

namespace NMCT.Resto.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class RestosTableView : MvxTableViewController
    {
        public RestosTableView()
        {

        }

        public RestosTableView (IntPtr handle) : base (handle)
        {
        }

        RestosTableViewSource _restosTableViewSource;
        public override void ViewDidLoad()
        {
            _restosTableViewSource = new RestosTableViewSource(this.TableView);
            base.ViewDidLoad();
            this.TableView.Source = _restosTableViewSource;
            this.TableView.ReloadData();
            MvxFluentBindingDescriptionSet<RestosTableView, RestosTableViewModel> set
                = new MvxFluentBindingDescriptionSet<RestosTableView, RestosTableViewModel>(this);
            set.Bind(_restosTableViewSource).To(vm => vm.RestosList);
            set.Apply();

        }
    }
}