using System;
using Foundation;

namespace Dorfverwaltung
{
    [Register("ItemModel")]
    public class ItemModel: NSObject
    {
        private string _type;
        private nuint _magicValue;

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

        [Export("MagicValue")]
        public nuint MagicValue
        {
            get => _magicValue;
            set
            {
                WillChangeValue("MagicValue");
                _magicValue = value;
                DidChangeValue("MagicValue");
            }
        }
    }
}