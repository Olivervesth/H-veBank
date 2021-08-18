using System;
using System.Collections.Generic;
using System.Text;

namespace HæveBank
{
    class Menu
    {
        Bank bank = new Bank();
        public void Start()//Starts the system
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("Would you like to make a new account y/Yes\n Type no to login");
                    string result = Console.ReadLine();
                    if (result.ToLower() == "y" || result.ToLower() == "yes")
                    {
                        bool usercreated = false;
                        while (usercreated == false)
                        {
                            usercreated = NewUser();
                        }
                    }
                    else
                    {

                        User loggedin = LoginMenu();
                        if (loggedin.name != null)
                        {
                            ShowAccountOptions(loggedin);
                        }
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }
            }
        }

        public bool NewUser()//Lets the user make a new account
        {
            Console.Write("Make new account\nName:");
            string name = Console.ReadLine();
            Console.Clear();
            Console.Write("Set pin: ");
            bool pinvalid = false;
            int pin = 0;
            int confirmpin = 0;
            while (pinvalid == false)
            {

                try
                {
                    pin = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Confirm pin: ");
                    confirmpin = int.Parse(Console.ReadLine());
                    pinvalid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Pin must only contain numbers");
                    Console.Write("pin: ");
                }
            }
            Console.Clear();
            if (pin.Equals(confirmpin))
            {
                Console.WriteLine(bank.CreateNewAccount(name, pin));
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong pin!");
                return false;
            }

        }
        public User LoginMenu()//Shows a login menu
        {

            Console.Clear();
            Console.WriteLine("Login");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("pin: ");
            int pin = int.Parse(Console.ReadLine());
            return bank.Login(name, pin);
        }

        public void ShowAccountOptions(User user)//Give the user options for there account
        {
            Console.WriteLine(user.name + "'s account");
            Console.WriteLine("Balance: " + user.account.balance);
            bool loggedin = true;
            while (loggedin)
            {
                try
                {
                    Console.WriteLine("1. withdraw\n3. balance\n4. LogOut");
                    int answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.Write("Withdraw amount: ");
                            int draw = int.Parse(Console.ReadLine());
                            bank.Withdraw(draw, user);
                            break;
                        case 3:
                            Console.WriteLine(user.account.balance);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

            }
        }
    }
}
