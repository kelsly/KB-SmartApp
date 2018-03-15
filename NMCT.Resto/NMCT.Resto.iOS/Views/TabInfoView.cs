using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using NMCT.Resto.CoreM.ViewModels;
using NMCT.Resto.iOS.Converters;
using NMCT.Resto.IOS.Converters;
using System;
using UIKit;

namespace NMCT.Resto.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabInfoView : MvxViewController<TabInfoViewModel>
    {
        public TabInfoView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            try
            {

            base.ViewDidLoad();

           

            MvxFluentBindingDescriptionSet<TabInfoView, TabInfoViewModel> set =
                this.CreateBindingSet<TabInfoView, TabInfoViewModel>();

            set.Bind(lblName).To(vm => vm.RestaurantContent.Name);
            set.Bind(lblPriceRange).To(vm => vm.RestaurantContent.PriceRangeString);
            set.Bind(lblCuisines).To(vm => vm.RestaurantContent.Cuisines);
            set.Bind(lblAddress).To(vm => vm.RestaurantContent.Location.Address);
            set.Bind(lblScore).To(vm => vm.RestaurantContent.Score);
            set.Bind(lblScore).For(lbl => lbl.BackgroundColor).To(vm => vm.RestaurantContent.Score).WithConversion<ScoreToColorConverter>();
            set.Bind(imgRestaurant)
            .For(img => img.Image)
            .To(vm => vm.RestaurantContent.ImageUrl)
            .WithConversion<StringToImageConverter>();

            set.Apply();

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}