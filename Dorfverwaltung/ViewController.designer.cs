// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Dorfverwaltung
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSArrayController DwarfsArrayController { get; set; }

		[Outlet]
		AppKit.NSTableView DwarfsTableView { get; set; }

		[Outlet]
		AppKit.NSArrayController ItemsArrayController { get; set; }

		[Outlet]
		AppKit.NSTableView ItemsTableView { get; set; }

		[Outlet]
		AppKit.NSArrayController TribesArrayController { get; set; }

		[Outlet]
		AppKit.NSTableView TribesTableView { get; set; }

		[Action ("DwarfsTableViewAction:")]
		partial void DwarfsTableViewAction (Foundation.NSObject sender);

		[Action ("ItemsTableViewAction:")]
		partial void ItemsTableViewAction (Foundation.NSObject sender);

		[Action ("TribesTableViewAction:")]
		partial void TribesTableViewAction (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (DwarfsArrayController != null) {
				DwarfsArrayController.Dispose ();
				DwarfsArrayController = null;
			}

			if (DwarfsTableView != null) {
				DwarfsTableView.Dispose ();
				DwarfsTableView = null;
			}

			if (ItemsArrayController != null) {
				ItemsArrayController.Dispose ();
				ItemsArrayController = null;
			}

			if (ItemsTableView != null) {
				ItemsTableView.Dispose ();
				ItemsTableView = null;
			}

			if (TribesArrayController != null) {
				TribesArrayController.Dispose ();
				TribesArrayController = null;
			}

			if (TribesTableView != null) {
				TribesTableView.Dispose ();
				TribesTableView = null;
			}

		}
	}
}
