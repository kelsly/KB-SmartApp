using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using NMCT.Resto.CoreM.Model;
using NMCT.Resto.iOS.Converters;
using System;
using UIKit;

namespace NMCT.Resto.iOS
{
    public partial class RestosTableCell : MvxTableViewCell
    {
        internal static readonly NSString Identifier = new NSString("RestosCell");

        public RestosTableCell (IntPtr handle) : base (handle)
        {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            MvxFluentBindingDescriptionSet<RestosTableCell, Restaurant> set
                = new MvxFluentBindingDescriptionSet<RestosTableCell, Restaurant>(this);
            set.Bind(TextLabel).To(res => res.Name);
            set.Bind(DetailTextLabel).To(res => res.Location.Locality);
            set.Bind(ImageView)
                .For(img => img.Image)
                .To(res => res.ThumbUrl)
                .WithConversion<StringToImageConverter>();
            set.Apply();
        }

    }
}