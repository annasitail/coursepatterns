using System;

namespace coursa4
{
    class FlatPage
    {
        public void GoToFlatPage(int id)
        {
            UserFlatTable userFlatTable = new UserFlatTable();
            Flat flat = new Flat();
            flat = userFlatTable.GetFlatByUserId(id);
            bool stayOnPageStatus = true;
            Context c = new Context(new ChooseInteriorState(flat));
            while(stayOnPageStatus)
            {
                stayOnPageStatus = c.Request();
            }
        }
    }
    
    abstract class ReadinessState
    {
        Flat flat = new Flat();
        public abstract bool Handle(Context context);

        public void GetFlatPageView(Flat flat)
        {
            this.flat = flat;
            Console.WriteLine("\n___________________________________\n");
            Console.WriteLine("Welcome to your flat page");
            Console.WriteLine(this.flat.ToString());
        }
    }
    
    class ChooseInteriorState : ReadinessState
    {
        Flat flat = new Flat();
        public ChooseInteriorState(Flat flat)
        {
            this.flat = flat;
        }

        public override bool Handle(Context context)
        {
            int percentage = this.flat.readinessPercentage;
            if (percentage >=0 && percentage < 25)
            {
                bool statusInteriorChoice = true;
                while (statusInteriorChoice)
                {
                    GetFlatPageView(this.flat);
                    Console.WriteLine("\nChoose interior design\nEnter 'yes' to continue\nOr 'no' to come back to your profile page");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.WriteLine("\n___________________________________\n");
                        ChooseInterior chooseInterior = new ChooseInterior();
                        string result = chooseInterior.ChooseInteriorDesign();
                        if (!string.IsNullOrEmpty(result))
                        {
                            Console.WriteLine("\nYour choice:");
                            Console.WriteLine("Interior type: " + result + "\n");
                            FlatTable flatTable = new FlatTable();
                            this.flat.interiorType = result;
                            this.flat.readinessPercentage += 25;
                            flatTable.Update(this.flat);
                            statusInteriorChoice = false;
                        }
                    }
                    else if (answer == "no")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect value, try again");
                    }
                }
            }
            context.State = new ChooseWallsState(this.flat);
            return true;
        }
    }

    class ChooseWallsState : ReadinessState
    {
        Flat flat = new Flat();
        public ChooseWallsState(Flat flat)
        {
            this.flat = flat;
        }
        
        public override bool Handle(Context context)
        {
            int percentage = this.flat.readinessPercentage;
            if (percentage >= 25 && percentage < 50)
            {
                bool statusWallsChoice = true;
                while (statusWallsChoice)
                {
                    GetFlatPageView(this.flat);
                    Console.WriteLine("\nChoose walls design\nEnter 'yes' to continue\nOr 'no' to come back to your profile page");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.WriteLine("\n___________________________________\n");
                        ChooseWalls chooseWalls = new ChooseWalls();
                        string result = chooseWalls.Choose();
                        if (!string.IsNullOrEmpty(result))
                        {
                            Console.WriteLine("\nYour choice:");
                            Console.WriteLine("Walls design: " + result + "\n");
                            FlatTable flatTable = new FlatTable();
                            this.flat.wallsDesign = result;
                            this.flat.readinessPercentage += 25;
                            flatTable.Update(this.flat);
                            statusWallsChoice = false;
                        }
                    }
                    else if (answer == "no")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect value, try again");
                    }
                }
            }
            context.State = new ChooseFloorState(this.flat);
            return true;
        }
    }

    class ChooseFloorState : ReadinessState
    {
        Flat flat = new Flat();
        public ChooseFloorState(Flat flat)
        {
            this.flat = flat;
        }
        
        public override bool Handle(Context context)
        {
            int percentage = this.flat.readinessPercentage;
            if (percentage >= 50 && percentage < 75)
            {
                bool statusFloorChoice = true;
                while (statusFloorChoice)
                {
                    GetFlatPageView(this.flat);
                    Console.WriteLine("\nChoose floor design\nEnter 'yes' to continue\nOr 'no' to come back to your profile page");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.WriteLine("\n___________________________________\n");
                        ChooseFloor chooseFloor = new ChooseFloor();
                        string result = chooseFloor.Choose();
                        if (!string.IsNullOrEmpty(result))
                        {
                            Console.WriteLine("\nYour choice:");
                            Console.WriteLine("Floor design: " + result + "\n");
                            FlatTable flatTable = new FlatTable();
                            this.flat.floorDesign = result;
                            this.flat.readinessPercentage += 25;
                            flatTable.Update(this.flat);
                            statusFloorChoice = false;
                        }
                    }
                    else if (answer == "no")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect value, try again");
                    }
                }
            }
            context.State = new ChooseFurnitureState(this.flat);
            return true;
        }
    }

    class ChooseFurnitureState : ReadinessState
    {
        Flat flat = new Flat();
        public ChooseFurnitureState(Flat flat)
        {
            this.flat = flat;
        }
        
        public override bool Handle(Context context)
        {
            int percentage = this.flat.readinessPercentage;
            if (percentage >= 75 && percentage < 100)
            {
                bool statusFloorChoice = true;
                while (statusFloorChoice)
                {
                    GetFlatPageView(this.flat);
                    Console.WriteLine("\nChoose furniture\nEnter 'yes' to continue\nOr 'no' to come back to your profile page");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.WriteLine("\n___________________________________\n");

                        FurnitureFactory chooseFurniture = new FurnitureFactory();
                        string result = chooseFurniture.ChooseFurniture();
                        if (!string.IsNullOrEmpty(result))
                        {
                            Console.WriteLine("\nYour choice:");
                            Console.WriteLine("Manufacturer: " + result + "\n");
                            FlatTable flatTable = new FlatTable();
                            this.flat.furniture = result;
                            this.flat.readinessPercentage += 25;
                            flatTable.Update(this.flat);
                            statusFloorChoice = false;
                        }
                    }
                    else if (answer == "no")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect value, try again");
                    }
                }
            }
            context.State = new FlatIsReadyState(this.flat);
            return true;
        }
    }

    class FlatIsReadyState : ReadinessState
    {
        Flat flat = new Flat();
        public FlatIsReadyState(Flat flat)
        {
            this.flat = flat;
        }
        
        public override bool Handle(Context context)
        {
            int percentage = this.flat.readinessPercentage;
            if (percentage == 100)
            {
                GetFlatPageView(this.flat);
                Console.WriteLine("\nYour flat is ready\nCongradulations!");
                Console.WriteLine("\nEnter 'exit' to come back to your profile page");
                string answer = Console.ReadLine().ToLower();
                if (answer != "exit")
                {
                    Console.WriteLine("\nIncorrect value, try again");
                    return true;
                }
            }
            return false;
        }
    }
    
    class Context
    {
        private ReadinessState _state;
        
        public Context(ReadinessState state)
        {
            this.State = state;
        }
        
        public ReadinessState State
        {
            get { return _state; }
            set
            {
                _state = value;
            }
        }
    
        public bool Request()
        {
            return _state.Handle(this);
        }
    }
}
