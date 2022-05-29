using System;

namespace coursa4
{
    public class ChooseFloor
    {
        public string Choose()
        {
            FloorOption op1 = new FloorOption1();
            FloorOption op2 = new FloorOption2();
            FloorOption op3 = new FloorOption3();
            FloorOption op4 = new FloorOption4();
            FloorOption op5 = new FloorOption5();
            FloorOption op6 = new FloorOption6();

            op1.SetSuccessor(op2);
            op2.SetSuccessor(op3);
            op3.SetSuccessor(op4);
            op4.SetSuccessor(op5);
            op5.SetSuccessor(op6);
            op6.SetSuccessor(op1);

            string decision = op1.ChooseOption();
            if (decision == "Incorrect value")
            {
                Console.WriteLine("\n" + decision + "\nYou can enter only 'yes' or 'no'\n");
                return null;
            }
            return decision;
        }
    }

    abstract class FloorOption
    {
        protected FloorOption successor;

        protected string isChosen;

        protected string choice;

        public void SetSuccessor(FloorOption successor)
        {
            this.successor = successor;
        }

        public abstract string ChooseOption();
    }

    class FloorOption1 : FloorOption
    {

        public override string ChooseOption()
        {
            Console.WriteLine("Light wood?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light wood";
            }
            else if (successor != null && this.isChosen == "no")
            {
                this.choice = successor.ChooseOption();
            }
            else if (this.isChosen == "exit")
            {
                this.choice = null;
            }
            else
            {
                this.choice =  "Incorrect value";
            }
            return this.choice;
        }
    }

    class FloorOption2 : FloorOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark wood?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark wood";
            }
            else if (successor != null && this.isChosen == "no")
            {
                this.choice = successor.ChooseOption();
            }
            else if (this.isChosen == "exit")
            {
                this.choice = null;
            }
            else
            {
                this.choice =  "Incorrect value";
            }
            return this.choice;
        }
    }

    class FloorOption3 : FloorOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light carpet?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light carpet";
            }
            else if (successor != null && this.isChosen == "no")
            {
                this.choice = successor.ChooseOption();
            }
            else if (this.isChosen == "exit")
            {
                this.choice = null;
            }
            else
            {
                this.choice =  "Incorrect value";
            }
            return this.choice;
        }
    }

    class FloorOption4 : FloorOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark carpet?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark carpet";
            }
            else if (successor != null && this.isChosen == "no")
            {
                this.choice = successor.ChooseOption();
            }
            else if (this.isChosen == "exit")
            {
                this.choice = null;
            }
            else
            {
                this.choice =  "Incorrect value";
            }
            return this.choice;
        }
    }

    class FloorOption5 : FloorOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light tile?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light tile";
            }
            else if (successor != null && this.isChosen == "no")
            {
                this.choice = successor.ChooseOption();
            }
            else if (this.isChosen == "exit")
            {
                this.choice = null;
            }
            else
            {
                this.choice =  "Incorrect value";
            }
            return this.choice;
        }
    }

    class FloorOption6 : FloorOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark tile?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark wood";
            }
            else if (successor != null && this.isChosen == "no")
            {
                this.choice = successor.ChooseOption();
            }
            else if (this.isChosen == "exit")
            {
                this.choice = null;
            }
            else
            {
                this.choice = "Incorrect value";
            }
            return this.choice;
        }
    }
}