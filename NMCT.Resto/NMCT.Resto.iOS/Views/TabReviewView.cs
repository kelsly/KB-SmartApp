using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using NMCT.Resto.CoreM.ViewModels;
using System;
using UIKit;

namespace NMCT.Resto.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabReviewView : MvxViewController
    {
        
        public TabReviewView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();

                MvxFluentBindingDescriptionSet<TabReviewView, TabReviewViewModel> set = this.CreateBindingSet<TabReviewView, TabReviewViewModel>();
                set.Bind(txtDateOfVisist).To(vm => vm.NewReview.TimeStampOfVisit);
                set.Bind(txtComment).To(vm => vm.NewReview.Comment);
                set.Bind(txtScore).To(vm => vm.NewReview.Score);
                set.Bind(txtUsername).To(vm => vm.NewReview.UserName);
                set.Bind(btnSave).To(vm => vm.SaveReviewCommand);
                set.Apply();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}