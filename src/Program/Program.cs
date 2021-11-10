using System;
using ClassLibrary;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string userInput;
            MessageHandler msgHandler = new MessageHandler();
            MessageWrapper msg;
            while (true)
            {
                Console.Write("\nIngrese un commando: ");
                userInput = Console.ReadLine();
                msg = new MessageWrapper(userInput, MessagingService.Console, "1597534826");
                msgHandler.HandleMessage(msg);
            }*/

            DataManager dataManager = new DataManager();
            SessionsContainer sessions = Singleton<SessionsContainer>.Instance;

            Invitation inv = dataManager.Invitation.New();
            inv.Used = false;
            inv.ValidAfter = DateTime.Now.AddMonths(-2);
            inv.ValidBefore = DateTime.Now.AddMonths(2);
            inv.Type = RegistrationType.CopmanyNew;
            int invId = dataManager.Invitation.Insert(inv);

            dataManager.Invitation.GenerateNewInviteCode(invId);
            inv = dataManager.Invitation.GetById(invId);

            TelegramAPI telegramAPI = new TelegramAPI();

            Console.WriteLine($"Oprima una tecla para terminar de ejecutar el bot.\n{inv.Code}");
            Console.ReadLine();

            telegramAPI.Stop();
        }
    }
}
