using System;

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
                Console.WriteLine("Hello, enter 'log in' to continue in your account\nIf you want to create an account, enter 'sign in'\nOr enter 'exit' to cancel the website");
                string answer = Console.ReadLine().ToLower();
                if (answer == "log in")
                {
                    Console.WriteLine("\n___________________________________\n");
                    Console.WriteLine("Hello, log in, please to continue");
                    ProcessLogIn();
                }
                else if (answer == "sign in")
                {
                    Console.WriteLine("\n___________________________________\n");
                    Console.WriteLine("Hello, sign in, please to continue");
                    ProcessSignIn();
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

        static void ProcessLogIn()
        {
            Console.WriteLine("First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            User user = new User(0, firstName, lastName, password);
            Abstr_PersonalPage page = new LogInChecker();
            page.GetAccessToPersonalPage(user);
        }

        static void ProcessSignIn()
        {
            try
            {
                Console.WriteLine("First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                Console.WriteLine("Flat number: ");
                int flatNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("House number: ");
                int houseNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Quantity of rooms: ");
                int quantityOfRooms = int.Parse(Console.ReadLine());
                User user = new User(0, firstName, lastName, password);
                Flat flat = new Flat(0, flatNumber, houseNumber, quantityOfRooms, 0, "-", "-", "-", "-");
                Abstr_PersonalPage page = new SignInChecker();
                SignInChecker checker = new SignInChecker();
                user = checker.CreateNewAccount(user, flat);
                page.GetAccessToPersonalPage(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nIncorrect value\nEnter numbers in fields:\n'flatNumber', 'houseNumber', 'quantityOfRooms'");
                Console.WriteLine(ex);
            }
        }
    }

    abstract class Abstr_PersonalPage
    {
        public abstract void GetAccessToPersonalPage(User user);
    }

    class PersonalPage : Abstr_PersonalPage
    {
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
    }

    class LogInChecker : Abstr_PersonalPage
    {
        PersonalPage page = new PersonalPage();
        User user = new User();
        UserTable userTable = new UserTable();

        public override void GetAccessToPersonalPage(User userToCheck)
        {
            CheckIfUserExists(userToCheck);
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

        private void CheckIfUserExists(User userToCheck)
        {
            this.user = userTable.GetByNameAndPassword(userToCheck);
            if (user.Id != 0)
            {
                user.isInTheDatabase = true;
            }
        }
    }

    class SignInChecker : Abstr_PersonalPage
    {
        PersonalPage page = new PersonalPage();
        User user = new User();
        UserTable userTable = new UserTable();
        Flat flat = new Flat();
        FlatTable flatTable = new FlatTable();
        UserFlatTable userFlatTable = new UserFlatTable();
        bool dataIsCorrect = false;

        public override void GetAccessToPersonalPage(User createdUser)
        {
            if (this.dataIsCorrect)
            {
                Console.WriteLine("\nSuccess!");
                page.GetAccessToPersonalPage(createdUser);
            }
            else
            {
                Console.WriteLine("\nPage already exists.\nPlease, log in or check out your input and try again.");
                return;
            }
        }

        public User CreateNewAccount(User userToCheck, Flat flatToCheck)
        {
            CheckIfUserExists(userToCheck);
            CheckIfFlatExists(flatToCheck);
            if (!this.user.isInTheDatabase && !this.flat.isInTheDatabase)
            {
                int userId = (int)userTable.Add(userToCheck);
                this.user = userTable.GetById(userId);
                int flatId = (int)flatTable.Add(flatToCheck);
                this.flat = flatTable.GetById(flatId);
                userFlatTable.Add(userId, flatId);
                this.dataIsCorrect = true;
                return user;
            }
            return null;
        }

        private void CheckIfUserExists(User userToCheck)
        {
            this.user = userTable.GetByNameAndPassword(userToCheck);
            if (user.Id != 0)
            {
                user.isInTheDatabase = true;
            }
        }

        private void CheckIfFlatExists(Flat flatToCheck)
        {
            this.flat = flatTable.GetByNumberHouseAndRooms(flatToCheck);
            if (flat.Id != 0)
            {
                flat.isInTheDatabase = true;
            }
        }
    }
}





