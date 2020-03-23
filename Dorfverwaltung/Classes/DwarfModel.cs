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
        private bool _isLeader;

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
        public bool IsLeader
        {
            get => _isLeader;
            set
            {
                WillChangeValue("IsLeader");
                _isLeader = value;
                DidChangeValue("IsLeader");
            }
        }

        [Export("Items")]
        public NSMutableArray Items => _items;
        
        [Export("Power")]
        public nuint Power => 
            _items.Aggregate((nuint)0, (a, item) => a + item.MagicValue);

        [Export("addItem:")]
        public void AddItem(ItemModel item)
        {
            WillChangeValue("Items");
            WillChangeValue("Power");
            if (!_items.Contains(item))
                _items.Add(item);
            DidChangeValue("Items");
            DidChangeValue("Power");
        }
        
        [Export("addItems:")]
        public void AddItems(NSArray<ItemModel> items)
        {
            WillChangeValue("Items");
            WillChangeValue("Power");
            foreach (var item in items)
                _items.Add(item);
            DidChangeValue("Items");
            DidChangeValue("Power");
        }
        
        [Export("removeItem:")]
        public void RemoveItem(ItemModel item)
        {
            WillChangeValue("Items");
            WillChangeValue("Power");
            if (_items.Contains(item))
            {
            }
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