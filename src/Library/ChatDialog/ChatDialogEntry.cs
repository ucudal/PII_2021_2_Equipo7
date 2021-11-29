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
            ChatDialogHandlerBase handler36 = new CDHCompanyAddLocationMenu(handler35);
            ChatDialogHandlerBase handler37 = new CDHCompanyListLocationMenu(handler36);
            ChatDialogHandlerBase handler38 = new CDHCompanyLocationAddDoneMenu(handler37);
            ChatDialogHandlerBase handler39 = new CDHCompanyLocationConfirmationAddMenu(handler38);
            ChatDialogHandlerBase handler40 = new CDHCompanyLocationMenu(handler39);
            ChatDialogHandlerBase handler41 = new CDHCompanyActionsMaterialMenu(handler40);
            ChatDialogHandlerBase handler42 = new CDHCompanyAddMenu(handler41);
            ChatDialogHandlerBase handler43 = new CDHCompanyConfirmationEraseMaterialMenu(handler42);
            ChatDialogHandlerBase handler44 = new CDHCompanyEraseDataMaterialMenu(handler43);
            ChatDialogHandlerBase handler45 = new CDHCompanyListMaterialsMenu(handler44);
            ChatDialogHandlerBase handler46 = new CDHCompanyMaterialAddConfirmationMenu(handler45);
            ChatDialogHandlerBase handler47 = new CDHCompanyMaterialAddDataMenu(handler46);
            ChatDialogHandlerBase handler48 = new CDHCompanyMaterialAddNameMenu(handler47);
            ChatDialogHandlerBase handler49 = new CDHCompanyMaterialMenu(handler48);
            ChatDialogHandlerBase handler50 = new CDHCompanyQualificationAddConfirmationMenu(handler49);
            ChatDialogHandlerBase handler51 = new CDHCompanyQualificationAddDataMenu(handler50);
            ChatDialogHandlerBase handler52 = new CDHCompanyQualificationConfirmEraseMenu(handler51);
            ChatDialogHandlerBase handler53 = new CDHCompanyQualificationEraseDataMenu(handler52);
            ChatDialogHandlerBase handler54 = new CDHCompanyQualificationListToAddMenu(handler53);
            ChatDialogHandlerBase handler55 = new CDHCompanyQualificationsListToEraseMenu(handler54);
            ChatDialogHandlerBase handler56 = new CDHCompanyQualificationsMenu(handler55);
            ChatDialogHandlerBase handler57 = new CDHCompanyPublicationActionMenu(handler56);
            ChatDialogHandlerBase handler58 = new CDHCompanyPublicationAddDataMenu(handler57);
            ChatDialogHandlerBase handler59 = new CDHCompanyPublicationConfirmationAddMenu(handler58);
            ChatDialogHandlerBase handler60 = new CDHCompanyPublicationConfirmationEraseMenu(handler59);
            ChatDialogHandlerBase handler61 = new CDHCompanyPublicationCurrencyMaterialToAddMenu(handler60);
            ChatDialogHandlerBase handler62 = new CDHCompanyPublicationDescriptionMaterialToAddMenu(handler61);
            ChatDialogHandlerBase handler63 = new CDHCompanyPublicationEraseDataMenu(handler62);
            ChatDialogHandlerBase handler64 = new CDHCompanyPublicationListMaterialsToAddMenu(handler63);
            ChatDialogHandlerBase handler65 = new CDHCompanyPublicationListMenu(handler64);
            ChatDialogHandlerBase handler66 = new CDHCompanyPublicationLocationMaterialToAddMenu(handler65);
            ChatDialogHandlerBase handler67 = new CDHCompanyPublicationMenu(handler66);
            ChatDialogHandlerBase handler68 = new CDHCompanyPublicationPriceMaterialToAddMenu(handler67);
            ChatDialogHandlerBase handler69 = new CDHCompanyPublicationQuantityMaterialToAddMenu(handler68);
            ChatDialogHandlerBase handler70 = new CDHCompanyPublicationTitleMaterialToAddMenu(handler69);
            ChatDialogHandlerBase handler71 = new CDHConfirmationSaleCategory(handler70);
            ChatDialogHandlerBase handler72 = new CDHConfirmationSaleKeyWord(handler71);
            ChatDialogHandlerBase handler73 = new CDHConfirmationSaleLocation(handler72);
            ChatDialogHandlerBase handler74 = new CDHFinalSaleCategory(handler73);
            ChatDialogHandlerBase handler75 = new CDHFinalSaleKeyword(handler74);
            ChatDialogHandlerBase handler76 = new CDHFinalSaleLocation(handler75);
            ChatDialogHandlerBase handler77 = new CDHHistorySaleMenu(handler76);
            ChatDialogHandlerBase handler78 = new CDHListCategoryMenu(handler77);
            ChatDialogHandlerBase handler79 = new CDHListKeyWordsMenu(handler78);
            ChatDialogHandlerBase handler80 = new CDHListLocationMenu(handler79);
            ChatDialogHandlerBase handler81 = new CDHMaterialRegenerationMenu(handler80);
            ChatDialogHandlerBase handler82 = new CDHMaterialRegenerationShowDetailMenu(handler81);
            ChatDialogHandlerBase handler83 = new CDHQualificationMenu(handler82);
            ChatDialogHandlerBase handler84 = new CDHQualificationsAddBadUrl(handler83);
            ChatDialogHandlerBase handler85 = new CDHQualificationsAddConfirmationMenu(handler84);
            ChatDialogHandlerBase handler86 = new CDHQualificationsAddDocumentUrl(handler85);
            ChatDialogHandlerBase handler87 = new CDHQualificationsAddMenu(handler86);
            ChatDialogHandlerBase handler88 = new CDHQualificationsConfirmationRemove(handler87);
            ChatDialogHandlerBase handler89 = new CDHQualificationsFinalAddMenu(handler88);
            ChatDialogHandlerBase handler90 = new CDHQualificationsFinalRemove(handler89);
            ChatDialogHandlerBase handler91 = new CDHQualificationsListMenu(handler90);
            ChatDialogHandlerBase handler92 = new CDHQualificationsRemoveMenu(handler91);
            ChatDialogHandlerBase handler93 = new CDHSalePublicationCategory(handler92);
            ChatDialogHandlerBase handler94 = new CDHSalePublicationKeyWord(handler93);
            ChatDialogHandlerBase handler95 = new CDHSalePublicationLocation(handler94);
            ChatDialogHandlerBase handler96 = new CDHSearchCategoryMenu(handler95);
            ChatDialogHandlerBase handler97 = new CDHSearchKeyWordMenu(handler96);
            ChatDialogHandlerBase handler98 = new CDHSearchLocationMenu(handler97);
            ChatDialogHandlerBase handler99 = new CDHSearchPublicationMenu(handler98);
            ChatDialogHandlerBase handler100 = new CDHShowDetailsHistorySaleMenu(handler99);
            ChatDialogHandlerBase handler101 = new CDHSignUpBadCode(handler100);
            ChatDialogHandlerBase handler102 = new CDHSignUpCancel(handler101);
            ChatDialogHandlerBase handler103 = new CDHSignUpCode(handler102);
            ChatDialogHandlerBase handler104 = new CDHSignUpCompanyName(handler103);
            ChatDialogHandlerBase handler105 = new CDHSignUpCompanyTrade(handler104);
            ChatDialogHandlerBase handler106 = new CDHSignUpDoneCompanyNew(handler105);
            ChatDialogHandlerBase handler107 = new CDHSignUpDoneEntrepreneurNew(handler106);
            ChatDialogHandlerBase handler108 = new CDHSignUpDoneJoinCompany(handler107);
            ChatDialogHandlerBase handler109 = new CDHSignUpDoneSysAdmin(handler108);
            ChatDialogHandlerBase handler110 = new CDHSignUpEntrepreneurAddress(handler109);
            ChatDialogHandlerBase handler111 = new CDHSignUpEntrepreneurName(handler110);
            ChatDialogHandlerBase handler112 = new CDHSignUpEntrepreneurTrade(handler111);
            ChatDialogHandlerBase handler113 = new CDHSignUpReviewCompanyNew(handler112);
            ChatDialogHandlerBase handler114 = new CDHSignUpReviewEntrepreneurNew(handler113);
            ChatDialogHandlerBase handler115 = new CDHSignUpReviewJoinCompany(handler114);
            ChatDialogHandlerBase handler116 = new CDHSignUpReviewSysAdmin(handler115);
            ChatDialogHandlerBase handler117 = new CDHSignUpUserFirstName(handler116);
            ChatDialogHandlerBase handler118 = new CDHSignUpUserLastName(handler117);
            ChatDialogHandlerBase handler119 = new CDHSignUpVerifyCompanyJoin(handler118);
            ChatDialogHandlerBase handler120 = new CDHSignUpVerifyCompanyNew(handler119);
            ChatDialogHandlerBase handler121 = new CDHSignUpVerifyEntrepreneurNew(handler120);
            ChatDialogHandlerBase handler122 = new CDHSignUpVerifySysAdminNew(handler121);

            this.firstHandler = handler122;
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