using System;
using AppKit;
using Foundation;

namespace Dorfverwaltung
{
    [Register("ItemModel")]
    public class ItemModel: NSObject
    {
        private string _type;
        private string _iconName = "Sword";
        private nuint _magicValue;
        private DwarfModel _owner;

        [Export("Type")]
        public string Type
        {
            get => _type;
            set
            {
                WillChangeValue("Type");
                _type = value;
                DidChangeValue("Type");
            }
        }

        [Export("IconName")]
        public string IconName
        {
            get => _iconName;
            set
            {
                WillChangeValue("IconName");
                WillChangeValue("Icon");
                _iconName = value;
                DidChangeValue("IconName");
                DidChangeValue("Icon");
            }
        }

        [Export("Icon")]
        public NSImage Icon => NSImage.ImageNamed(_iconName);

        [Export("MagicValue")]
        public nuint MagicValue
        {
            get => _magicValue;
            set
            {
                WillChangeValue("MagicValue");
                _owner?.WillChangeValue("Power");
                _owner?.Tribe?.WillChangePower();
                _magicValue = value;
                DidChangeValue("MagicValue");
                _owner?.DidChangeValue("Power");
                _owner?.Tribe?.DidChangePower();
            }
        }

        [Export("Owner")]
        public DwarfModel Owner
        {
            get => _owner;
            set
            {
                WillChangeValue("Owner");
                _owner = value;
                DidChangeValue("Owner");
            }
        }
    }
}