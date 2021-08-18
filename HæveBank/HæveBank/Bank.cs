using System;
using System.Collections.Generic;
using System.Text;

namespace HæveBank
{
    public class Bank
    {
        List<User> bankusers = new List<User>();
        public string CreateNewAccount(string username, int pin)//Create new account
        {
            Account acc = new Account() { pin = pin };
            User newuser = new User() { name = username, account = acc };
            newuser.account.balance = 100;
            bankusers.Add(newuser);
            return "New user created";
        }
        public User Login(string username, int pin)//Login to existing account
        {
            for (int i = 0; i < bankusers.Count; i++)
            {
                if (bankusers[i].name == username)
                {
                    if (bankusers[i].account.pin == pin)
                    {
                        return bankusers[i];
                    }
                }
            }
            return null;
        }
        public bool Withdraw(int amount, User user)//Withdraw money from bank
        {
            for (int i = 0; i < bankusers.Count; i++)
            {
                if (bankusers[i].name == user.name)
                {
                    if (bankusers[i].account.pin == user.account.pin)
                    {
                        if (0 >= bankusers[i].account.balance - amount)
                        {
                            return false;
                        }
                        else
                        {
                            bankusers[i].account.balance -= amount;
                            return true;
                        }

                    }
                }
            }
            return false;
        }
        

    }
}
