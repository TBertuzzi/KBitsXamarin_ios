using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace KBitsXamarin_ios
{
    public partial class HistoricoController : UITableViewController
    {
        public List<string> NumerosTelefone { get; set; }

        static NSString historicoCellId = new NSString("HistoricoCell");

        public HistoricoController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), historicoCellId);
            TableView.Source = new HistoricoDataSource(this);
            NumerosTelefone = new List<string>();
        }

        class HistoricoDataSource : UITableViewSource
        {
            HistoricoController controller;

            public HistoricoDataSource(HistoricoController controller)
            {
                this.controller = controller;
            }

            public override nint RowsInSection(UITableView tableView, nint section)
            {
                return controller.NumerosTelefone.Count;
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(HistoricoController.historicoCellId);

                int row = indexPath.Row;
                cell.TextLabel.Text = controller.NumerosTelefone[row];
                return cell;
            }
        }
    }
}