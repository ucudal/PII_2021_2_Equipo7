using System;
using ClassLibrary;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            MessageHandler msgHandler = new MessageHandler();
            MessageWrapper msg;
            while (true)
            {
                Console.Write("\nIngrese un commando: ");
                userInput = Console.ReadLine();
                msg = new MessageWrapper(userInput, MessagingService.Console, "1597534826");
                msgHandler.HandleMessage(msg);
            }
        }
    }
}
