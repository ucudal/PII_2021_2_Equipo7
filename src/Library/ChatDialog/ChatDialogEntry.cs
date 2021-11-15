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
            ChatDialogHandlerBase handler1 = new CDH_SessionExpired(handler0);
            ChatDialogHandlerBase handler2 = new CDH_WelcomeCompany(handler1);
            ChatDialogHandlerBase handler3 = new CDH_WelcomeEntrepreneur(handler2);
            ChatDialogHandlerBase handler4 = new CDH_WelcomeSysAdmin(handler3);
            ChatDialogHandlerBase handler5 = new CDH_WelcomeUnregistered(handler4);
            ChatDialogHandlerBase handler6 = new CDH_AdminInviteMenu(handler5);
            ChatDialogHandlerBase handler7 = new CDH_AdminQualificationsMenu(handler6);
            ChatDialogHandlerBase handler8 = new CDH_QualificationAddConfirmation(handler7);
            ChatDialogHandlerBase handler9 = new CDH_QualificationsAddNameMenu(handler8);
            ChatDialogHandlerBase handler10 = new CDH_Company_Tracing_Menu(handler9);
            ChatDialogHandlerBase handler11 = new CDH_VentasLista(handler10);
            ChatDialogHandlerBase handler12 = new CDH_CompanyActionsMaterialMenu(handler11);
            ChatDialogHandlerBase handler13 = new CDH_CompanyAddMenu(handler12);
            ChatDialogHandlerBase handler14 = new CDH_CompanyConfirmationEraseMaterialMenu(handler13);
            ChatDialogHandlerBase handler15 = new CDH_CompanyEraseDataMaterialMenu(handler14);
            ChatDialogHandlerBase handler16 = new CDH_CompanyListMaterialsMenu(handler15);
            ChatDialogHandlerBase handler17 = new CDH_CompanyMaterialAddConfirmationMenu(handler16);
            ChatDialogHandlerBase handler18 = new CDH_CompanyMaterialAddDataMenu(handler17);
            ChatDialogHandlerBase handler19 = new CDH_CompanyMaterialAddNameMenu(handler18);
            ChatDialogHandlerBase handler20 = new CDH_CompanyMaterialMenu(handler19);
            ChatDialogHandlerBase handler21 = new CDH_CompanyMaterialModifiConfirmationMenu(handler20);
            ChatDialogHandlerBase handler22 = new CDH_CompanyMaterialModifiDataMenu(handler21);
            ChatDialogHandlerBase handler23 = new CDH_CompanyMaterialModifiDateBetweenReStockMenu(handler22);
            ChatDialogHandlerBase handler24 = new CDH_CompanyMaterialModifiNameMenu(handler23);
            ChatDialogHandlerBase handler25 = new CDH_CompanyMaterialModifiQuantityMenu(handler24);
            ChatDialogHandlerBase handler26 = new CDH_CompanyMaterialModifiUbicationMenu(handler25);
            ChatDialogHandlerBase handler27 = new CDH_CompanyModifiMenu(handler26);
            ChatDialogHandlerBase handler28 = new CDH_CompanyQualificationAddConfirmationMenu(handler27);
            ChatDialogHandlerBase handler29 = new CDH_CompanyQualificationAddDataMenu(handler28);
            ChatDialogHandlerBase handler30 = new CDH_CompanyQualificationConfirmEraseMenu(handler29);
            ChatDialogHandlerBase handler31 = new CDH_CompanyQualificationEraseDataMenu(handler30);
            ChatDialogHandlerBase handler32 = new CDH_CompanyQualificationListToAddMenu(handler31);
            ChatDialogHandlerBase handler33 = new CDH_CompanyQualificationsListToEraseMenu(handler32);
            ChatDialogHandlerBase handler34 = new CDH_CompanyQualificationsMenu(handler33);
            ChatDialogHandlerBase handler35 = new CDH_CompanyPublicationActionMenu(handler34);
            ChatDialogHandlerBase handler36 = new CDH_CompanyPublicationAddDataMenu(handler35);
            ChatDialogHandlerBase handler37 = new CDH_CompanyPublicationConfirmationAddMenu(handler36);
            ChatDialogHandlerBase handler38 = new CDH_CompanyPublicationConfirmationEraseMenu(handler37);
            ChatDialogHandlerBase handler39 = new CDH_CompanyPublicationEraseDataMenu(handler38);
            ChatDialogHandlerBase handler40 = new CDH_CompanyPublicationListMaterialsToAddMenu(handler39);
            ChatDialogHandlerBase handler41 = new CDH_CompanyPublicationListMenu(handler40);
            ChatDialogHandlerBase handler42 = new CDH_CompanyPublicationMenu(handler41);
            ChatDialogHandlerBase handler43 = new CDH_CompanyPublicationPriceMaterialToAddMenu(handler42);
            ChatDialogHandlerBase handler44 = new CDH_CompanyPublicationQuantityMaterialToAddMenu(handler43);
            ChatDialogHandlerBase handler45 = new CDH_Confirmation_Sale_Category(handler44);
            ChatDialogHandlerBase handler46 = new CDH_Confirmation_Sale_KeyWord(handler45);
            ChatDialogHandlerBase handler47 = new CDH_Confirmation_Sale_Location(handler46);
            ChatDialogHandlerBase handler48 = new CDH_Final_Sale_Category(handler47);
            ChatDialogHandlerBase handler49 = new CDH_Final_Sale_Keyword(handler48);
            ChatDialogHandlerBase handler50 = new CDH_Final_Sale_Location(handler49);
            ChatDialogHandlerBase handler51 = new CDH_History_Sale_Menu(handler50);
            ChatDialogHandlerBase handler52 = new CDH_List_Category_Menu(handler51);
            ChatDialogHandlerBase handler53 = new CDH_List_KeyWords_Menu(handler52);
            ChatDialogHandlerBase handler54 = new CDH_List_Location_Menu(handler53);
            ChatDialogHandlerBase handler55 = new CDH_Material_Regeneration_Menu(handler54);
            ChatDialogHandlerBase handler56 = new CDH_Qualification_Menu(handler55);
            ChatDialogHandlerBase handler57 = new CDH_Qualifications_Add_Confirmation_Menu(handler56);
            ChatDialogHandlerBase handler58 = new CDH_Qualifications_Add_Menu(handler57);
            ChatDialogHandlerBase handler59 = new CDH_Qualifications_Confirmation_Remove(handler58);
            //ChatDialogHandlerBase handler60 = new CDH_Qualifications_Detail_Menu(handler59);
            ChatDialogHandlerBase handler61 = new CDH_Qualifications_Final_Add_Menu(handler59);
            ChatDialogHandlerBase handler62 = new CDH_Qualifications_Final_Remove(handler61);
            ChatDialogHandlerBase handler63 = new CDH_Qualifications_List_Menu(handler62);
            ChatDialogHandlerBase handler64 = new CDH_Qualifications_Remove_Menu(handler63);
            ChatDialogHandlerBase handler65 = new CDH_Sale_Publication_Category(handler64);
            ChatDialogHandlerBase handler66 = new CDH_Sale_Publication_KeyWord(handler65);
            ChatDialogHandlerBase handler67 = new CDH_Sale_Publication_Location(handler66);
            ChatDialogHandlerBase handler68 = new CDH_Search_Category_Menu(handler67);
            ChatDialogHandlerBase handler69 = new CDH_Search_KeyWord_Menu(handler68);
            ChatDialogHandlerBase handler70 = new CDH_Search_Location_Menu(handler69);
            ChatDialogHandlerBase handler71 = new CDH_Search_Publication_Menu(handler70);
            ChatDialogHandlerBase handler72 = new CDH_SignUpBadCode(handler71);
            ChatDialogHandlerBase handler73 = new CDH_SignUpCancel(handler72);
            ChatDialogHandlerBase handler74 = new CDH_SignUpCode(handler73);
            ChatDialogHandlerBase handler75 = new CDH_SignUpCompanyName(handler74);
            ChatDialogHandlerBase handler76 = new CDH_SignUpCompanyTrade(handler75);
            ChatDialogHandlerBase handler77 = new CDH_SignUpDoneCompanyNew(handler76);
            ChatDialogHandlerBase handler78 = new CDH_SignUpDoneEntrepreneurNew(handler77);
            ChatDialogHandlerBase handler79 = new CDH_SignUpDoneJoinCompany(handler78);
            ChatDialogHandlerBase handler80 = new CDH_SignUpDoneSysAdmin(handler79);
            ChatDialogHandlerBase handler81 = new CDH_SignUpEntrepreneurName(handler80);
            ChatDialogHandlerBase handler82 = new CDH_SignUpEntrepreneurTrade(handler81);
            ChatDialogHandlerBase handler83 = new CDH_SignUpReviewCompanyNew(handler82);
            ChatDialogHandlerBase handler84 = new CDH_SignUpReviewEntrepreneurNew(handler83);
            ChatDialogHandlerBase handler85 = new CDH_SignUpReviewJoinCompany(handler84);
            ChatDialogHandlerBase handler86 = new CDH_SignUpReviewSysAdmin(handler85);
            ChatDialogHandlerBase handler87 = new CDH_SignUpUserFirstName(handler86);
            ChatDialogHandlerBase handler88 = new CDH_SignUpUserLastName(handler87);
            ChatDialogHandlerBase handler89 = new CDH_SignUpVerifyCompanyJoin(handler88);
            ChatDialogHandlerBase handler90 = new CDH_SignUpVerifyCompanyNew(handler89);
            ChatDialogHandlerBase handler91 = new CDH_SignUpVerifyEntrepreneurNew(handler90);
            ChatDialogHandlerBase handler92 = new CDH_SignUpVerifySysAdminNew(handler91);

            this.firstHandler = handler92;
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