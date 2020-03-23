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
        
        [Export("FoundingString")]
        public string FoundingString
            => $"{Founding} {(Founding >= 0 ? "ndK" : "vdK")}";
        
        [Export("Leader")]
        public DwarfModel Leader
        {
            get => _leader;
            set
            {
                if (Dwarfs.Contains(value))
                {
                    WillChangeValue("Leader");
                    if(_leader != null)
                        _leader.IsLeader = false;
                    _leader = value;
                    _leader.IsLeader = true;
                    DidChangeValue("Leader");
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
        
        [Export("addDwarf:")]
        public void AddDwarf(DwarfModel dwarf)
        {
            WillChangeValue("Dwarfs");
            WillChangeValue("Power");
            if (!_dwarfs.Contains(dwarf))
                _dwarfs.Add(dwarf);
            DidChangeValue("Dwarfs");
            DidChangeValue("Power");
        }

        [Export("addDwarfs:")]
        public void AddDwarfs(NSArray<DwarfModel> dwarfs)
        {
            WillChangeValue("Dwarfs");
            WillChangeValue("Power");
            foreach (var dwarf in dwarfs)
                _dwarfs.Add(dwarf);
            DidChangeValue("Dwarfs");
            DidChangeValue("Power");
        }
        
        [Export("removeDwarf:")]
        public void RemoveDwarf(DwarfModel dwarf)
        {
            WillChangeValue("Dwarfs");
            WillChangeValue("Power");
            if (_dwarfs.Contains(dwarf))
            {
            }
            DidChangeValue("Dwarfs");
            DidChangeValue("Power");
        }

        public TribeModel()
        {
        }
    }
}