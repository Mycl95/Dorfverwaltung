// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace Dorfverwaltung
{
	public partial class WindowController : NSWindowController
	{
        private Model _model;

        [Export("Model")]
        public Model Model {
            get => _model;
            set
            {
                WillChangeValue("Model");
                _model = value;
                DidChangeValue("Model");
            }
        }

		public WindowController (IntPtr handle) : base (handle)
		{
		}

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            var controller = ContentViewController as ViewController;
            Model = controller.Model;
        }

        partial void AddRemoveElement(NSObject sender)
        {
            var controller = ContentViewController as ViewController;
            var model = controller.Model;
            var segmentedControl = sender as NSSegmentedControl;
            var selectedSegment = segmentedControl.SelectedSegment;
            switch(selectedSegment)
            {
                case 0:
                    switch(controller.CurrentScope)
                    {
                        case "Tribes":
                            var tribe = model.CreateTribe();
                            controller.SelectedTribe = tribe;
                            break;
                        case "Dwarfs":
                            var dwarf = model.CreateDwarf(controller.SelectedTribe);
                            controller.SelectedDwarf = dwarf;
                            break;
                        case "Items":
                            var item = model.CreateItem(controller.SelectedDwarf);
                            controller.SelectedItem = item;
                            break;
                    }
                    break;
                case 1:
                    switch (controller.CurrentScope)
                    {
                        case "Tribes":
                            if(controller.SelectedTribe != null)
                            {
                                Model.RemoveTribe(controller.SelectedTribe);
                            }
                            break;
                        case "Dwarfs":
                            if(controller.SelectedDwarf != null)
                            {
                                controller.SelectedTribe.RemoveDwarf(controller.SelectedDwarf);
                            }
                            break;
                        case "Items":
                            if(controller.SelectedItem != null)
                            {
                                controller.SelectedDwarf.RemoveItem(controller.SelectedItem);
                            }
                            break;
                    }
                    break;
            }
        }

        partial void SetUnsetLeader(NSObject sender)
        {
            var controller = ContentViewController as ViewController;
            var segmentedControl = sender as NSSegmentedControl;
            var selectedSegment = segmentedControl.SelectedSegment;
            switch (selectedSegment)
            {
                case 0:
                    if(controller.SelectedDwarf != null)
                    {
                        controller.SelectedTribe.Leader = controller.SelectedDwarf;
                    }
                    break;
                case 1:
                    if(controller.SelectedTribe != null)
                    {
                        controller.SelectedTribe.Leader = null;
                    }
                    break;
            }
        }

        partial void ChangeTaxesAction(NSObject sender)
        {
           

        }
    }
}
