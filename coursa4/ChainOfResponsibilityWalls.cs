using System;

namespace coursa4
{
    public class ChooseWalls
    {
        public string Choose()
        {
            WallsOption op1 = new WallsOption1();
            WallsOption op2 = new WallsOption2();
            WallsOption op3 = new WallsOption3();
            WallsOption op4 = new WallsOption4();
            WallsOption op5 = new WallsOption5();
            WallsOption op6 = new WallsOption6();
            WallsOption op7 = new WallsOption7();
            WallsOption op8 = new WallsOption8();
            WallsOption op9 = new WallsOption9();
            WallsOption op10 = new WallsOption10();
            WallsOption op11 = new WallsOption11();
            WallsOption op12 = new WallsOption12();
            WallsOption op13 = new WallsOption13();
            WallsOption op14 = new WallsOption14();
            WallsOption op15 = new WallsOption15();
            WallsOption op16 = new WallsOption16();
            WallsOption op17 = new WallsOption17();
            WallsOption op18 = new WallsOption18();
            WallsOption op19 = new WallsOption19();
            WallsOption op20 = new WallsOption20();

            op1.SetSuccessor(op2);
            op2.SetSuccessor(op3);
            op3.SetSuccessor(op4);
            op4.SetSuccessor(op5);
            op5.SetSuccessor(op6);
            op6.SetSuccessor(op7);
            op7.SetSuccessor(op8);
            op8.SetSuccessor(op9);
            op9.SetSuccessor(op10);
            op10.SetSuccessor(op11);
            op11.SetSuccessor(op12);
            op12.SetSuccessor(op13);
            op13.SetSuccessor(op14);
            op14.SetSuccessor(op15);
            op15.SetSuccessor(op16);
            op16.SetSuccessor(op17);
            op17.SetSuccessor(op18);
            op18.SetSuccessor(op19);
            op19.SetSuccessor(op20);
            op20.SetSuccessor(op1);

            string decision = op1.ChooseOption();
            if (decision == "Incorrect value")
            {
                Console.WriteLine("\n" + decision + "\nYou can enter only 'yes' or 'no'\n");
                return null;
            }
            return decision;
        }
    }

    abstract class WallsOption
    {
        protected WallsOption successor;

        protected string isChosen;

        protected string choice;

        public void SetSuccessor(WallsOption successor)
        {
            this.successor = successor;
        }

        public abstract string ChooseOption();
    }

    class WallsOption1 : WallsOption
    {

        public override string ChooseOption()
        {
            Console.WriteLine("Light yellow wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light yellow wallpapers";
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

    class WallsOption2 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light green wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light green wallpapers";
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

    class WallsOption3 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light blue wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light blue wallpapers";
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

    class WallsOption4 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light lilac wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light lilac wallpapers";
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

    class WallsOption5 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light pink wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light pink wallpapers";
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

    class WallsOption6 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light grey wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light grey wallpapers";
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

    class WallsOption7 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Light flourish wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "light flourish wallpapers";
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

    class WallsOption8 : WallsOption
    {

        public override string ChooseOption()
        {
            Console.WriteLine("Brown wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "brown wallpapers";
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

    class WallsOption9 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark green wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark green wallpapers";
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

    class WallsOption10 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark blue wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark blue wallpapers";
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

    class WallsOption11 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark lilac wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark lilac wallpapers";
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

    class WallsOption12 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark red wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark red wallpapers";
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

    class WallsOption13 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark grey wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark grey wallpapers";
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

    class WallsOption14 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark flourish wallpapers?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark flourish wallpapers";
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

    class WallsOption15 : WallsOption
    {

        public override string ChooseOption()
        {
            Console.WriteLine("Brown paint?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "brown paint";
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

    class WallsOption16 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark green paint?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark green paint";
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

    class WallsOption17 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark blue paint?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark blue paint";
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

    class WallsOption18 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark lilac paint?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark lilac paint";
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

    class WallsOption19 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark red paint?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark red paint";
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

    class WallsOption20 : WallsOption
    {
        public override string ChooseOption()
        {
            Console.WriteLine("Dark grey paint?");
            this.isChosen = Console.ReadLine().ToLower();
            if (this.isChosen == "yes")
            {
                this.choice = "dark grey paint";
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