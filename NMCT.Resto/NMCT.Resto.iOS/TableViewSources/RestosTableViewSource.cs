using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace NMCT.Resto.iOS.TableViewSources
{
    public class RestosTableViewSource : MvxTableViewSource
    {
        public RestosTableViewSource(UITableView tableView) : base(tableView)
        {

        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (RestosTableCell)tableView.DequeueReusableCell(RestosTableCell.Identifier, indexPath);
            return cell;
        }
    }
}