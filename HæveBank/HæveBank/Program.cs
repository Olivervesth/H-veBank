using System;

namespace HæveBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();//Starts the program process 
            Console.ReadKey();
        }
    }
}
