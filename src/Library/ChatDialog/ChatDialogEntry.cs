using System;
using System.Diagnostics;

namespace ClassLibrary
{
    /// <summary>
    /// Punto de entrada a la cadena de responsabilidad asociada
    /// a la navegacion del chat con el bot por el usuario.
    /// </summary>
    public class ChatDialogEntry
    {
        private ChatDialogHandlerBase firstHandler;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ChatDialogEntry"/>.
        /// Esta instancia ya pre-configura la cadena de responsabilidad entera
        /// para ser inicializada con el metodo <see cref="Start(ChatDialogSelector)"/>
        /// </summary>
        public ChatDialogEntry()
        {
            ChatDialogHandlerBase handler0 = new CDH_BadCommand();
            ChatDialogHandlerBase handler1 = new CDH_SignUpBadCode(handler0);
            ChatDialogHandlerBase handler2 = new CDH_SignUpCode(handler1);
            ChatDialogHandlerBase handler3 = new CDH_WelcomeUnregistered(handler2);
            ChatDialogHandlerBase handler4 = new CDH_SignUpVerifyEntrepreneurNew(handler3);
            ChatDialogHandlerBase handler5 = new CDH_SignUpVerifyCompanyJoin(handler4);
            ChatDialogHandlerBase handler6 = new CDH_SignUpVerifyCompanyNew(handler5);
            ChatDialogHandlerBase handler7 = new CDH_SignUpCancel(handler6);
            ChatDialogHandlerBase handler8 = new CDH_SignUpUserFirstName(handler7);
            ChatDialogHandlerBase handler9 = new CDH_SignUpUserLastName(handler8);
            ChatDialogHandlerBase handler10 = new CDH_SignUpCompanyName(handler9);
            ChatDialogHandlerBase handler11 = new CDH_SignUpCompanyTrade(handler10);
            ChatDialogHandlerBase handler12 = new CDH_SignUpReviewCompanyNew(handler11);
            ChatDialogHandlerBase handler13 = new CDH_SignUpDoneCompanyNew(handler12);
            ChatDialogHandlerBase handler14 = new CDH_WelcomeCompany(handler13);
            ChatDialogHandlerBase handler15 = new CDH_WelcomeEntrepreneur(handler14);
            ChatDialogHandlerBase handler16 = new CDH_WelcomeSysAdmin(handler15);
            ChatDialogHandlerBase handler17 = new CDH_SignUpReviewSysAdmin(handler16);
            ChatDialogHandlerBase handler18 = new CDH_SignUpDoneSysAdmin(handler17);
            ChatDialogHandlerBase handler19 = new CDH_SignUpVerifySysAdminNew(handler18);
            ChatDialogHandlerBase handler20 = new CDH_SignUpDoneEntrepreneurNew(handler19);
            ChatDialogHandlerBase handler21 = new CDH_SignUpReviewJoinCompany(handler20);
            ChatDialogHandlerBase handler22 = new CDH_SignUpEntrepreneurName(handler21);
            ChatDialogHandlerBase handler23 = new CDH_SignUpEntrepreneurTrade(handler22);
            ChatDialogHandlerBase handler24 = new CDH_SignUpDoneJoinCompany(handler23);
            ChatDialogHandlerBase handler25 = new CDH_SignUpReviewEntrepreneurNew(handler24);
            ChatDialogHandlerBase handler26 = new CDH_SessionExpired(handler25);

            this.firstHandler = handler26;
        }

        /// <summary>
        /// Inicia el proceso de la cadena de responsabilidad
        /// de acuerdo a un selector recibido.
        /// </summary>
        /// <param name="selector">
        /// Contenedor de los datos precisos por la cadena
        /// de responsabilidad.
        /// </param>
        /// <returns>
        /// string con el resultado de ejecutar
        /// la cadena
        /// </returns>
        public string Start(ChatDialogSelector selector)
        { 
            if (this.firstHandler is null)
            {
                string msg = "No hay configurado un ChatDialogHandler inicial en el objeto de entrada.";
                Debug.WriteLine($"Excepcion: {msg}");
                //throw new NullReferenceException(msg);
            }

            return this.firstHandler.Next(selector);
        }
    }
}