using System;

using AppKit;
using Foundation;

namespace Dorfverwaltung
{
    public partial class ViewController : NSViewController
    {
        private readonly Model _model = new Model();
        [Export("tribeModelArray")]
        public NSArray Tribes => _model.Tribes;


        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            WillChangeValue("tribeModelArray");
            _model.InitWithExampleData();
            DidChangeValue("tribeModelArray");
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
    }
}
