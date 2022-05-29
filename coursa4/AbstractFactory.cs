using System;

namespace coursa4
{
    public class FurnitureFactory
    {
        public string ChooseFurniture()
        {
            Console.WriteLine("Here is a list of furniture:");
            Console.WriteLine("\nFrom Italian manufacturer:");
            ManufacturerFactory factory = new Manufacturer1();
            Items items1 = new Items(factory);
            Console.WriteLine("\nFrom Polish manufacturer:");
            factory = new Manufacturer2();
            Items items2 = new Items(factory);
            Console.WriteLine("\nFrom Ukrainian manufacturer:");
            factory = new Manufacturer3();
            Items items3 = new Items(factory);

            Console.WriteLine("\nAre you ready to choose a manufacturer?\nEnter its name ('italian'/'polish'/'ukrainian')\nOr enter 'no' to come back to your flat page");
            string choice = Console.ReadLine().ToLower();
            if (choice == "italian" || choice == "polish" || choice == "ukrainian")
            {
                return choice;
            }
            else if (choice == "no")
            {
                return null;
            }
            Console.WriteLine("\nIncorrect value\nYou can enter only 'italian'/'polish'/'ukrainian' or 'no'");
            return null;
        }
    }
    abstract class ManufacturerFactory
    {
        public abstract Sofa CreateSofas();
        public abstract Bed CreateBeds();
        public abstract Table CreateTables();
        public abstract Chair CreateChairs();
    }

    class Manufacturer1 : ManufacturerFactory
    {
        public override Sofa CreateSofas()
        {
            return new Manufacturer1Sofa(" - Italy, 1000$");
        }

        public override Bed CreateBeds()
        {
            return new Manufacturer1Bed(" - Italy, 900$");
        }

        public override Table CreateTables()
        {
            return new Manufacturer1Table(" - Italy, 500$");
        }

        public override Chair CreateChairs()
        {
            return new Manufacturer1Chair(" - Italy, 200$");
        }
    }

    class Manufacturer2 : ManufacturerFactory
    {
        public override Sofa CreateSofas()
        {
            return new Manufacturer2Sofa(" - Poland, 700$");
        }

        public override Bed CreateBeds()
        {
            return new Manufacturer2Bed(" - Poland, 740$");
        }

        public override Table CreateTables()
        {
            return new Manufacturer2Table(" - Poland, 250$");
        }

        public override Chair CreateChairs()
        {
            return new Manufacturer2Chair(" - Poland, 130$");
        }
    }

    class Manufacturer3 : ManufacturerFactory
    {
        public override Sofa CreateSofas()
        {
            return new Manufacturer3Sofa(" - Ukraine, 500$");
        }

        public override Bed CreateBeds()
        {
            return new Manufacturer3Bed(" - Ukraine, 670$");
        }

        public override Table CreateTables()
        {
            return new Manufacturer3Table(" - Ukraine, 210$");
        }

        public override Chair CreateChairs()
        {
            return new Manufacturer3Chair(" - Ukraine, 50$");
        }
    }

    abstract class Sofa
    {
        public Sofa(string description)
        {
            Console.WriteLine("A sofa" + description);
        }
    }

    abstract class Bed
    {
        public Bed(string description)
        {
            Console.WriteLine("A bed" + description);
        }
    }

    abstract class Table
    {
        public Table(string description)
        {
            Console.WriteLine("A table" + description);
        }
    }

    abstract class Chair
    {
        public Chair(string description)
        {
            Console.WriteLine("A chair" + description);
        }
    }

    class Manufacturer1Sofa : Sofa
    {
        public Manufacturer1Sofa(string description) : base(description)
        {
        }
    }

    class Manufacturer2Sofa : Sofa
    {
        public Manufacturer2Sofa(string description) : base(description)
        {
        }
    }

    class Manufacturer3Sofa : Sofa
    {
        public Manufacturer3Sofa(string description) : base(description)
        {
        }
    }

    class Manufacturer1Bed : Bed
    {
        public Manufacturer1Bed(string description) : base(description)
        {
        }
    }

    class Manufacturer2Bed : Bed
    {
        public Manufacturer2Bed(string description) : base(description)
        {
        }
    }

    class Manufacturer3Bed : Bed
    {
        public Manufacturer3Bed(string description) : base(description)
        {
        }
    }

    class Manufacturer1Table : Table
    {
        public Manufacturer1Table(string description) : base(description)
        {
        }
    }

    class Manufacturer2Table : Table
    {
        public Manufacturer2Table(string description) : base(description)
        {
        }
}

    class Manufacturer3Table : Table
    {
        public Manufacturer3Table(string description) : base(description)
        {
        }
    }

    class Manufacturer1Chair : Chair
    {
        public Manufacturer1Chair(string description) : base(description)
        {
        }
    }

    class Manufacturer2Chair : Chair
    {
        public Manufacturer2Chair(string description) : base(description)
        {
        }
    }

    class Manufacturer3Chair : Chair
    {
        public Manufacturer3Chair(string description) : base(description)
        {
        }
    }

    class Items
    {
        private Sofa _sofa;
        private Bed _bed;
        private Table _table;
        private Chair _chair;

        public Items(ManufacturerFactory factory)
        {
            _sofa = factory.CreateSofas();
            _bed = factory.CreateBeds();
            _table = factory.CreateTables();
            _chair = factory.CreateChairs();
        }
    }
}