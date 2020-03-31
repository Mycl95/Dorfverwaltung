using System;
using System.Linq;
using Foundation;

namespace Dorfverwaltung
{
    [Register("DwarfModel")]
    public class DwarfModel: NSObject
    {

        private string _name;
        private nuint _age;
        private readonly NSMutableArray<ItemModel> _items 
            = new NSMutableArray<ItemModel>();
        private TribeModel _tribe;

        [Export("Name")]
        public string Name
        {
            get => _name;
            set
            {
                WillChangeValue("Name");
                _name = value;
                DidChangeValue("Name");
            }
        }

        [Export("Age")]
        public nuint Age
        {
            get => _age;
            set
            {
                WillChangeValue("Age");
                _age = value;
                DidChangeValue("Age");
            }
        }

        [Export("IsLeader")]
        public bool IsLeader => _tribe?.Leader == this;

        [Export("Items")]
        public NSMutableArray Items => _items;
        
        [Export("Power")]
        public nuint Power => 
            _items.Aggregate((nuint)0, (a, item) => a + item.MagicValue);

        [Export("Tribe")]
        public TribeModel Tribe
        {
            get => _tribe;
            set
            {
                WillChangeValue("Tribe");
                _tribe = value;
                DidChangeValue("Tribe");
            }
        }

        [Export("addItem:")]
        public void AddItem(ItemModel item)
        {
            if (_items.Contains(item)) return;
            
            WillChangeValue("Items");
            WillChangeValue("Power");
            Tribe?.WillChangePower();
            _items.Add(item);
            item.Owner?.RemoveItem(item);
            item.Owner = this;
            Tribe?.DidChangePower();
            DidChangeValue("Items");
            DidChangeValue("Power");
            
        }
        
        [Export("addItems:")]
        public void AddItems(NSArray<ItemModel> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }
        
        [Export("removeItem:")]
        public void RemoveItem(ItemModel item)
        {
            if (!_items.Contains(item)) return;
            
            WillChangeValue("Items");
            WillChangeValue("Power");
            Tribe?.WillChangePower();
            _items.RemoveObject((nint)_items.IndexOf(item));
            item.Owner = null;
            Tribe?.DidChangePower();
            DidChangeValue("Items");
            DidChangeValue("Power");
            
        }
        
        public DwarfModel()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}