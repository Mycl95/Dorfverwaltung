using System;

using AppKit;
using Foundation;

namespace Dorfverwaltung
{
    public partial class ViewController : NSViewController
    {
        private readonly Model _model = new Model();
        private string _currentScope;

        [Export("Model")]
        public Model Model => _model;

        public string CurrentScope
        {
            get => _currentScope;
            private set => _currentScope = value;
        }

        public TribeModel SelectedTribe
        {
            get => TribesArrayController.SelectedObjects.Length > 0
                ? TribesArrayController.SelectedObjects[0] as TribeModel
                : null;
            set => TribesArrayController.SelectedObjects = new[] { value };
        }

        public DwarfModel SelectedDwarf {
            get => DwarfsArrayController.SelectedObjects.Length > 0
                ? DwarfsArrayController.SelectedObjects [0] as DwarfModel
                : null;
            set => DwarfsArrayController.SelectedObjects = new[] { value };
        }
        public ItemModel SelectedItem {
            get => ItemsArrayController.SelectedObjects.Length > 0
                ? ItemsArrayController.SelectedObjects [0] as ItemModel
                : null;
            set => ItemsArrayController.SelectedObjects = new[] { value };
        }

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _model.InitWithExampleData();
            CurrentScope = "Tribes";
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }


        partial void TribesTableViewAction(NSObject sender)
        {
            CurrentScope = "Tribes";
        }

        partial void DwarfsTableViewAction(NSObject sender)
        {
            if (SelectedTribe != null)
            {
                CurrentScope = "Dwarfs";
            }
        }

        partial void ItemsTableViewAction(NSObject sender)
        {
            if (SelectedDwarf != null)
            { 
                CurrentScope = "Items";
            }
        }
    }
}
