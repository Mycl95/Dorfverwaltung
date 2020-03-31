using System;
using System.Collections.Generic;
using Foundation;

namespace Dorfverwaltung
{
    public class Model: NSObject
    {
        private readonly NSMutableArray<TribeModel> _tribes = new NSMutableArray<TribeModel>();
        private nfloat _taxes;

        [Export("Tribes")]
        public NSArray Tribes => _tribes;

        [Export("Taxes")]
        public nfloat Taxes
        {
            get => _taxes;
            set
            {
                WillChangeValue("Taxes");
                _taxes = value;
                foreach(var tribe in _tribes)
                {
                    tribe.Taxes = value;
                }
                DidChangeValue("Taxes");
            }
        }

        public void InitWithExampleData()
        {
            DwarfModel gimli = new DwarfModel()
            {
                Name = "Gimli",
                Age = 140,
            };

            gimli.AddItems(NSArray<ItemModel>.FromNSObjects(
                new ItemModel()
                {
                    Type = "Axt",
                    IconName = "Axe",
                    MagicValue = 12
                },
                new ItemModel()
                {
                    Type = "Schwert",
                    IconName = "Sword",
                    MagicValue = 15
                }
            ));

            DwarfModel gumli = new DwarfModel()
            {
                Name = "Gumli",
                Age = 163,
            };
            
            gumli.AddItem(
                new ItemModel()
                {
                    Type = "Axt",
                    IconName = "Axe",
                    MagicValue = 17
                }
            );

            DwarfModel zwingli = new DwarfModel()
            {
                Name = "Zwingli",
                Age = 70,
            };
            
            zwingli.AddItems(NSArray<ItemModel>.FromNSObjects(
                new ItemModel()
                {
                    Type = "Zauberstab",
                    IconName = "Wand",
                    MagicValue = 45
                },
                new ItemModel()
                {
                    Type = "Streithammer",
                    IconName = "Warhammer",
                    MagicValue = 15
                }
            ));


            TribeModel altobarden = new TribeModel()
            {
                Name = "Altobarden",
                Founding = 1247,
            };
            altobarden.AddDwarfs(NSArray<DwarfModel>.FromNSObjects(gimli, zwingli));
            altobarden.Leader = gimli;
            altobarden.LeaderSince = 25;

            TribeModel elbknechte = new TribeModel()
            {
                Name = "Elbknechte",
                Founding = 1023,
            };
            elbknechte.AddDwarf(gumli);

            AddTribes(altobarden, elbknechte);

            Taxes = 2.125f;
        }

        public TribeModel CreateTribe(string name = "New Tribe", nint founding = default)
        {
            var tribe = new TribeModel()
            {
                Name = name,
                Founding = founding
            };

            AddTribe(tribe);
            return tribe;
        }

        public TribeModel CreateTribe(DwarfModel leader, string name = "New Tribe", nint founding = default, nuint leaderSince = default)
        {
            var tribe = new TribeModel()
            {
                Name = name,
                Founding = founding,
                Leader = leader,
                LeaderSince = leaderSince
            };

            AddTribe(tribe);
            return tribe;
        }

        public void AddTribe(TribeModel tribe)
        {
            if (_tribes.Contains(tribe)) return;

            WillChangeValue("Tribes");
            _tribes.Add(tribe);
            DidChangeValue("Tribes");
        }

        public void RemoveTribe(TribeModel tribe)
        {
            if (!_tribes.Contains(tribe)) return;

            WillChangeValue("Tribes");
            _tribes.RemoveObject((nint)_tribes.IndexOf(tribe));
            DidChangeValue("Tribes");
        }

        public void AddTribes(params TribeModel[] tribes) 
        {
            foreach(var tribe in tribes)
            {
                AddTribe(tribe);
            }
        }

        public DwarfModel CreateDwarf(TribeModel tribe, string name = "New Dwarf", nuint age = default)
        {
            var dwarf = new DwarfModel()
            {
                Name = name,
                Age = age
            };

            tribe.AddDwarf(dwarf);
            return dwarf;
        }

        public ItemModel CreateItem(DwarfModel dwarf, string type = "New Item", nuint magicValue = default)
        {
            var item = new ItemModel()
            {
                Type = type,
                MagicValue = magicValue
            };

            dwarf.AddItem(item);
            return item;
        }
    }
}