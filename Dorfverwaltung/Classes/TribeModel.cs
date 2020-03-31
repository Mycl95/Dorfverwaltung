using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;

namespace Dorfverwaltung
{
    [Register("TribeModel")]
    public class TribeModel: NSObject
    {
        private string _name;
        private nint _founding;
        private DwarfModel _leader;
        private nuint _leaderSince;
        private readonly NSMutableArray<DwarfModel> _dwarfs 
            = new NSMutableArray<DwarfModel>();
        private nfloat _taxes;
        
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
        
        [Export("Founding")]
        public nint Founding
        {
            get => _founding;
            set
            {
                WillChangeValue("Founding");
                _founding = value;
                DidChangeValue("Founding");
            }
        }
        
        [Export("Leader")]
        public DwarfModel Leader
        {
            get => _leader;
            set
            {
                if (value == null || Dwarfs.Contains(value))
                {
                    WillChangeValue("Leader");
                    Leader?.WillChangeValue("IsLeader");
                    value?.WillChangeValue("IsLeader");
                    _leader = value;
                    DidChangeValue("Leader");
                    Leader?.DidChangeValue("IsLeader");
                    value?.DidChangeValue("IsLeader");
                }
            }
        }

        [Export("LeaderSince")]
        public nuint LeaderSince
        {
            get => _leaderSince;
            set
            {
                WillChangeValue("LeaderSince");
                _leaderSince = value;
                DidChangeValue("LeaderSince");
            }
        }
        
        [Export("Dwarfs")]
        public NSArray Dwarfs => _dwarfs;
        
        [Export("Power")]
        public nuint Power => 
            _dwarfs.Aggregate((nuint)0, (a, dwarf) => a + dwarf.Power);

        [Export("Taxes")]
        public nfloat Taxes
        {
            get => Power * _taxes;
            set
            {
                WillChangeValue("Taxes");
                _taxes = value;
                DidChangeValue("Taxes");
            }
        }
        
        [Export("addDwarf:")]
        public void AddDwarf(DwarfModel dwarf)
        {
            if (_dwarfs.Contains(dwarf)) return;
            
            WillChangeValue("Dwarfs");
            WillChangePowerAndTaxes();
            _dwarfs.Add(dwarf);
            dwarf.Tribe?.RemoveDwarf(dwarf);
            dwarf.Tribe = this;
            DidChangeValue("Dwarfs");
            DidChangePowerAndTaxes();
            
        }

        [Export("addDwarfs:")]
        public void AddDwarfs(NSArray<DwarfModel> dwarfs)
        {
            foreach (var dwarf in dwarfs)
            {
                AddDwarf(dwarf);
            }
        }
        
        [Export("removeDwarf:")]
        public void RemoveDwarf(DwarfModel dwarf)
        {
            if (!_dwarfs.Contains(dwarf)) return;
            
            WillChangeValue("Dwarfs");
            WillChangePowerAndTaxes();
            _dwarfs.RemoveObject((nint)_dwarfs.IndexOf(dwarf));
            dwarf.Tribe = null;
            DidChangeValue("Dwarfs");
            DidChangePowerAndTaxes();
            
        }

        public void WillChangePowerAndTaxes()
        {
            WillChangeValue("Power");
            WillChangeValue("Taxes");
        }

        public void DidChangePowerAndTaxes()
        {
            DidChangeValue("Power");
            DidChangeValue("Taxes");
        }
    }
}