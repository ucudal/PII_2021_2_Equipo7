// -----------------------------------------------------------------------
// <copyright file="ChatDialogEntry.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

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
        /// Initializes a new instance of the <see cref="ChatDialogEntry"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ChatDialogEntry"/>.
        /// Esta instancia ya pre-configura la cadena de responsabilidad entera
        /// para ser inicializada con el metodo <see cref="Start(ChatDialogSelector)"/>.
        /// </summary>
        public ChatDialogEntry()
        {
            ChatDialogHandlerBase handler0 = new CDHBadCommand();
            ChatDialogHandlerBase handler1 = new CDHHome(handler0);
            ChatDialogHandlerBase handler2 = new CDHNextPage(handler1);
            ChatDialogHandlerBase handler3 = new CDHPrevPage(handler2);
            ChatDialogHandlerBase handler4 = new CDHReturn(handler3);
            ChatDialogHandlerBase handler5 = new CDHSessionExpired(handler4);
            ChatDialogHandlerBase handler6 = new CDHWelcomeCompany(handler5);
            ChatDialogHandlerBase handler7 = new CDHWelcomeEntrepreneur(handler6);
            ChatDialogHandlerBase handler8 = new CDHWelcomeSysAdmin(handler7);
            ChatDialogHandlerBase handler9 = new CDHWelcomeUnregistered(handler8);
            ChatDialogHandlerBase handler10 = new CDHAdminInviteMenu(handler9);
            ChatDialogHandlerBase handler11 = new CDHAdminMaterialMenu(handler10);
            ChatDialogHandlerBase handler12 = new CDHAdminQualificationsMenu(handler11);
            ChatDialogHandlerBase handler13 = new CDHInviteAdminConfirmation(handler12);
            ChatDialogHandlerBase handler14 = new CDHInviteAdminCreate(handler13);
            ChatDialogHandlerBase handler15 = new CDHInviteComapnyExistConfirmation(handler14);
            ChatDialogHandlerBase handler16 = new CDHInviteCompanyConfirmation(handler15);
            ChatDialogHandlerBase handler17 = new CDHInviteCompanyCreate(handler16);
            ChatDialogHandlerBase handler18 = new CDHInviteCompanyExistCreate(handler17);
            ChatDialogHandlerBase handler19 = new CDHInviteCompanyExistList(handler18);
            ChatDialogHandlerBase handler20 = new CDHInviteEntrepreneurConfirmation(handler19);
            ChatDialogHandlerBase handler21 = new CDHInviteEntrepreneurCreate(handler20);
            ChatDialogHandlerBase handler22 = new CDHMateralCategoryFinal(handler21);
            ChatDialogHandlerBase handler23 = new CDHMaterialCategoryAddName(handler22);
            ChatDialogHandlerBase handler24 = new CDHMaterialCategoryConfirm(handler23);
            ChatDialogHandlerBase handler25 = new CDHMaterialCategoryList(handler24);
            ChatDialogHandlerBase handler26 = new CDHMaterialCategoryRemoveFinal(handler25);
            ChatDialogHandlerBase handler27 = new CDHMaterialCategoryRemoveFromList(handler26);
            ChatDialogHandlerBase handler28 = new CDHQualificationAddConfirmation(handler27);
            ChatDialogHandlerBase handler29 = new CDHQualificationAddCreate(handler28);
            ChatDialogHandlerBase handler30 = new CDHQualificationRemoveList(handler29);
            ChatDialogHandlerBase handler31 = new CDHQualificationsAddNameMenu(handler30);
            ChatDialogHandlerBase handler32 = new CDHRemoveQualificationFinal(handler31);
            ChatDialogHandlerBase handler33 = new CDHRemoveQualificationRemove(handler32);
            ChatDialogHandlerBase handler34 = new CDHCompanyTracingMenu(handler33);
            ChatDialogHandlerBase handler35 = new CDHVentasLista(handler34);
            ChatDialogHandlerBase handler36 = new CDHCompanyActionsMaterialMenu(handler35);
            ChatDialogHandlerBase handler37 = new CDHCompanyAddMenu(handler36);
            ChatDialogHandlerBase handler38 = new CDHCompanyConfirmationEraseMaterialMenu(handler37);
            ChatDialogHandlerBase handler39 = new CDHCompanyEraseDataMaterialMenu(handler38);
            ChatDialogHandlerBase handler40 = new CDHCompanyListMaterialsMenu(handler39);
            ChatDialogHandlerBase handler41 = new CDHCompanyMaterialAddConfirmationMenu(handler40);
            ChatDialogHandlerBase handler42 = new CDHCompanyMaterialAddDataMenu(handler41);
            ChatDialogHandlerBase handler43 = new CDHCompanyMaterialAddNameMenu(handler42);
            ChatDialogHandlerBase handler44 = new CDHCompanyMaterialMenu(handler43);
            ChatDialogHandlerBase handler45 = new CDHCompanyQualificationAddConfirmationMenu(handler44);
            ChatDialogHandlerBase handler46 = new CDHCompanyQualificationAddDataMenu(handler45);
            ChatDialogHandlerBase handler47 = new CDHCompanyQualificationConfirmEraseMenu(handler46);
            ChatDialogHandlerBase handler48 = new CDHCompanyQualificationEraseDataMenu(handler47);
            ChatDialogHandlerBase handler49 = new CDHCompanyQualificationListToAddMenu(handler48);
            ChatDialogHandlerBase handler50 = new CDHCompanyQualificationsListToEraseMenu(handler49);
            ChatDialogHandlerBase handler51 = new CDHCompanyQualificationsMenu(handler50);
            ChatDialogHandlerBase handler52 = new CDHCompanyPublicationActionMenu(handler51);
            ChatDialogHandlerBase handler53 = new CDHCompanyPublicationAddDataMenu(handler52);
            ChatDialogHandlerBase handler54 = new CDHCompanyPublicationConfirmationAddMenu(handler53);
            ChatDialogHandlerBase handler55 = new CDHCompanyPublicationConfirmationEraseMenu(handler54);
            ChatDialogHandlerBase handler56 = new CDHCompanyPublicationEraseDataMenu(handler55);
            ChatDialogHandlerBase handler57 = new CDHCompanyPublicationListMaterialsToAddMenu(handler56);
            ChatDialogHandlerBase handler58 = new CDHCompanyPublicationListMenu(handler57);
            ChatDialogHandlerBase handler59 = new CDHCompanyPublicationMenu(handler58);
            ChatDialogHandlerBase handler60 = new CDHCompanyPublicationPriceMaterialToAddMenu(handler59);
            ChatDialogHandlerBase handler61 = new CDHCompanyPublicationQuantityMaterialToAddMenu(handler60);
            ChatDialogHandlerBase handler62 = new CDHConfirmationSaleCategory(handler61);
            ChatDialogHandlerBase handler63 = new CDHConfirmationSaleKeyWord(handler62);
            ChatDialogHandlerBase handler64 = new CDHConfirmationSaleLocation(handler63);
            ChatDialogHandlerBase handler65 = new CDHFinalSaleCategory(handler64);
            ChatDialogHandlerBase handler66 = new CDHFinalSaleKeyword(handler65);
            ChatDialogHandlerBase handler67 = new CDHFinalSaleLocation(handler66);
            ChatDialogHandlerBase handler68 = new CDHHistorySaleMenu(handler67);
            ChatDialogHandlerBase handler69 = new CDHListCategoryMenu(handler68);
            ChatDialogHandlerBase handler70 = new CDHListKeyWordsMenu(handler69);
            ChatDialogHandlerBase handler71 = new CDHListLocationMenu(handler70);
            ChatDialogHandlerBase handler72 = new CDHMaterialRegenerationMenu(handler71);
            ChatDialogHandlerBase handler73 = new CDHMaterialRegenerationShowDetailMenu(handler72);
            ChatDialogHandlerBase handler74 = new CDHQualificationMenu(handler73);
            ChatDialogHandlerBase handler75 = new CDHQualificationsAddConfirmationMenu(handler74);
            ChatDialogHandlerBase handler76 = new CDHQualificationsAddDocumentUrl(handler75);
            ChatDialogHandlerBase handler77 = new CDHQualificationsAddMenu(handler76);
            ChatDialogHandlerBase handler78 = new CDHQualificationsConfirmationRemove(handler77);
            ChatDialogHandlerBase handler79 = new CDHQualificationsFinalAddMenu(handler78);
            ChatDialogHandlerBase handler80 = new CDHQualificationsFinalRemove(handler79);
            ChatDialogHandlerBase handler81 = new CDHQualificationsListMenu(handler80);
            ChatDialogHandlerBase handler82 = new CDHQualificationsRemoveMenu(handler81);
            ChatDialogHandlerBase handler83 = new CDHSalePublicationCategory(handler82);
            ChatDialogHandlerBase handler84 = new CDHSalePublicationKeyWord(handler83);
            ChatDialogHandlerBase handler85 = new CDHSalePublicationLocation(handler84);
            ChatDialogHandlerBase handler86 = new CDHSearchCategoryMenu(handler85);
            ChatDialogHandlerBase handler87 = new CDHSearchKeyWordMenu(handler86);
            ChatDialogHandlerBase handler88 = new CDHSearchLocationMenu(handler87);
            ChatDialogHandlerBase handler89 = new CDHSearchPublicationMenu(handler88);
            ChatDialogHandlerBase handler90 = new CDHShowDetailsHistorySaleMenu(handler89);
            ChatDialogHandlerBase handler91 = new CDHSignUpBadCode(handler90);
            ChatDialogHandlerBase handler92 = new CDHSignUpCancel(handler91);
            ChatDialogHandlerBase handler93 = new CDHSignUpCode(handler92);
            ChatDialogHandlerBase handler94 = new CDHSignUpCompanyName(handler93);
            ChatDialogHandlerBase handler95 = new CDHSignUpCompanyTrade(handler94);
            ChatDialogHandlerBase handler96 = new CDHSignUpDoneCompanyNew(handler95);
            ChatDialogHandlerBase handler97 = new CDHSignUpDoneEntrepreneurNew(handler96);
            ChatDialogHandlerBase handler98 = new CDHSignUpDoneJoinCompany(handler97);
            ChatDialogHandlerBase handler99 = new CDHSignUpDoneSysAdmin(handler98);
            ChatDialogHandlerBase handler100 = new CDHSignUpEntrepreneurAddress(handler99);
            ChatDialogHandlerBase handler101 = new CDHSignUpEntrepreneurName(handler100);
            ChatDialogHandlerBase handler102 = new CDHSignUpEntrepreneurTrade(handler101);
            ChatDialogHandlerBase handler103 = new CDHSignUpReviewCompanyNew(handler102);
            ChatDialogHandlerBase handler104 = new CDHSignUpReviewEntrepreneurNew(handler103);
            ChatDialogHandlerBase handler105 = new CDHSignUpReviewJoinCompany(handler104);
            ChatDialogHandlerBase handler106 = new CDHSignUpReviewSysAdmin(handler105);
            ChatDialogHandlerBase handler107 = new CDHSignUpUserFirstName(handler106);
            ChatDialogHandlerBase handler108 = new CDHSignUpUserLastName(handler107);
            ChatDialogHandlerBase handler109 = new CDHSignUpVerifyCompanyJoin(handler108);
            ChatDialogHandlerBase handler110 = new CDHSignUpVerifyCompanyNew(handler109);
            ChatDialogHandlerBase handler111 = new CDHSignUpVerifyEntrepreneurNew(handler110);
            ChatDialogHandlerBase handler112 = new CDHSignUpVerifySysAdminNew(handler111);
            ChatDialogHandlerBase handler113 = new CDHQualificationsAddBadUrl(handler112);

            this.firstHandler = handler113;
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
        /// la cadena.
        /// </returns>
        public string Start(ChatDialogSelector selector)
        {
            if (this.firstHandler is null)
            {
                string msg = "No hay configurado un ChatDialogHandler inicial en el objeto de entrada.";
                Debug.WriteLine($"Excepcion: {msg}");
                /*throw new NullReferenceException(msg);*/
            }

            return this.firstHandler.NextLink(selector);
        }
    }
}