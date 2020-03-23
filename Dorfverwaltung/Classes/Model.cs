using System.Collections.Generic;
using Foundation;

namespace Dorfverwaltung
{
    public class Model
    {
        public readonly NSMutableArray<TribeModel> Tribes = new NSMutableArray<TribeModel>();

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
                    MagicValue = 12
                },
                new ItemModel()
                {
                    Type = "Schwert",
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
                    MagicValue = 45
                },
                new ItemModel()
                {
                    Type = "Streithammer",
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

            Tribes.AddObjects(altobarden, elbknechte);
        }
    }
}