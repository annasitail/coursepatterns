using System;
using System.Collections.Generic;

namespace coursa4
{
    public class CheckUser
    {
        public void Authentication()
        {
            bool status = true;
            while(status)
            {
                Console.WriteLine("\n___________________________________\n");
                Console.WriteLine("Hello, enter 'log in' to continue\nOr enter 'exit' to cancel the website");
                string answer = Console.ReadLine().ToLower();
                if (answer == "log in")
                {
                    Console.WriteLine("\n___________________________________\n");
                    Console.WriteLine("Hello, log in, please to continue");
                    Console.WriteLine("First Name: ");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Last Name: ");
                    string lastName = Console.ReadLine();
                    User user = new User(0, firstName, lastName);
                    Abstr_PersonalPage page = new Checker();
                    page.GetAccessToPersonalPage(user);
                }
                else if (answer == "exit")
                {
                    Console.WriteLine("\n___________________________________\n");
                    Console.WriteLine("Thank you for visiting us!\nGood luck");
                    status = false;
                }
                else 
                {
                    Console.WriteLine("\nIncorrect value\nYou can enter only 'log in' or 'exit'\n");
                }
            }
        }
    }

    abstract class Abstr_PersonalPage
    {
        public abstract void GetAccessToPersonalPage(User user);
    }

    class PersonalPage : Abstr_PersonalPage
    {
        List<UserFlat> userFlats = new List<UserFlat>();
        UserFlatTable userFlatTable = new UserFlatTable();
        List<Flat> flats = new List<Flat>();
        FlatTable flatTable = new FlatTable();

        public override void GetAccessToPersonalPage(User user)
        {
            bool status = true;
            while(status)
            {
                Console.WriteLine("\n___________________________________\n");
                Console.WriteLine("Welcome to your profile page");
                Console.WriteLine("Enter 'flat' to visit your flat page\nOr 'exit' to log out");
                string choice = Console.ReadLine().ToLower();
                if (choice == "flat")
                {
                    FlatPage flatPage = new FlatPage();
                    flatPage.MainFlatPage(user.Id);
                }
                else if (choice == "exit")
                {
                    status = false;
                }
                else
                {
                    Console.WriteLine("\nIncorrect value\nYou can enter only 'flat' or 'exit'\n");
                }
            }
            return;
        }

        // private void ChooseFlatPage(User user)
        // {
        //     // UserFlat userFlat = new UserFlat();
        //     Flat flat = new Flat();
        //     this.userFlats = userFlatTable.GetByUserId(user.Id);
        //     int flatsInTotal = userFlats.Count;
        //     Console.WriteLine("Your flat(s):");

        //     foreach(UserFlat uf in userFlats)
        //     {
        //         Console.WriteLine(flatTable.GetById(uf.flatId).ShortInfo());
        //     }
        //     if (flatsInTotal == 1)
        //     {
        //         Console.WriteLine("Enter 'more' for details");
        //         if (Console.ReadLine() == "more")
        //         {
        //             Console.WriteLine(flatTable.GetById(userFlats.ToArray()[0].flatId));
        //             Console.WriteLine("Choose team");
        //             // State state = new State();
        //             // state.StateMethod(user);
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine($"Enter '(1-{flatsInTotal}) more' for details");
        //         if (Console.ReadLine().Split(' ')[1] == "more" &&  int.Parse(Console.ReadLine().Split(' ')[0]) <= flatsInTotal && int.Parse(Console.ReadLine().Split(' ')[0]) > 0)
        //         {
        //             Console.WriteLine(flatTable.GetById(userFlats.ToArray()[flatsInTotal - 1].flatId));
        //             Console.WriteLine("Want to choose team?");
        //         }
        //     }
        // }
    }

    class Checker : Abstr_PersonalPage
    {
        PersonalPage page = new PersonalPage();
        User user = new User();
        UserTable userTable = new UserTable();

        public override void GetAccessToPersonalPage(User userToCheck)
        {
            CheckIfUserIsCorrect(userToCheck);
            if (this.user.isInTheDatabase)
            {
                page.GetAccessToPersonalPage(user);
            }
            else
            {
                Console.WriteLine("\nPage is not found.\nPlease, check out your input and try again.");
                return;
            }
        }

        private void CheckIfUserIsCorrect(User userToCheck)
        {
            string firstName = userToCheck.firstName;
            string lastName = userToCheck.lastName;
            this.user = userTable.GetByName(firstName, lastName);
            if (user.Id != 0)
            {
                user.isInTheDatabase = true;
            }
        }
    }
}





