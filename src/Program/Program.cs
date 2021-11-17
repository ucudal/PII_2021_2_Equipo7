// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using ClassLibrary;

namespace Program
{
    /// <summary>
    /// Programa Principal.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            DataManager dataManager = new DataManager();

            Invitation inv = dataManager.Invitation.New();
            inv.Used = false;
            inv.ValidAfter = DateTime.Now.AddMonths(-2);
            inv.ValidBefore = DateTime.Now.AddMonths(2);
            inv.Type = RegistrationType.CopmanyNew;
            int invId = dataManager.Invitation.Insert(inv);

            dataManager.Invitation.GenerateNewInviteCode(invId);
            inv = dataManager.Invitation.GetById(invId);

            using TelegramAPI telegramAPI = new TelegramAPI();
            Console.WriteLine($"Oprima una tecla para terminar de ejecutar el bot.\n{inv.Code}");
            Console.ReadLine();

            telegramAPI.Stop();
        }
    }
}
