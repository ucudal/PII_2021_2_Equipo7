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
            ChatDialogHandlerBase handler45 = new CDHCompanyMaterialModifiConfirmationMenu(handler44);
            ChatDialogHandlerBase handler46 = new CDHCompanyMaterialModifiDataMenu(handler45);
            ChatDialogHandlerBase handler47 = new CDHCompanyMaterialModifiDateBetweenReStockMenu(handler46);
            ChatDialogHandlerBase handler48 = new CDHCompanyMaterialModifiNameMenu(handler47);
            ChatDialogHandlerBase handler49 = new CDHCompanyMaterialModifiQuantityMenu(handler48);
            ChatDialogHandlerBase handler50 = new CDHCompanyMaterialModifiUbicationMenu(handler49);
            ChatDialogHandlerBase handler51 = new CDHCompanyModifiMenu(handler50);
            ChatDialogHandlerBase handler52 = new CDHCompanyQualificationAddConfirmationMenu(handler51);
            ChatDialogHandlerBase handler53 = new CDHCompanyQualificationAddDataMenu(handler52);
            ChatDialogHandlerBase handler54 = new CDHCompanyQualificationConfirmEraseMenu(handler53);
            ChatDialogHandlerBase handler55 = new CDHCompanyQualificationEraseDataMenu(handler54);
            ChatDialogHandlerBase handler56 = new CDHCompanyQualificationListToAddMenu(handler55);
            ChatDialogHandlerBase handler57 = new CDHCompanyQualificationsListToEraseMenu(handler56);
            ChatDialogHandlerBase handler58 = new CDHCompanyQualificationsMenu(handler57);
            ChatDialogHandlerBase handler59 = new CDHCompanyPublicationActionMenu(handler58);
            ChatDialogHandlerBase handler60 = new CDHCompanyPublicationAddDataMenu(handler59);
            ChatDialogHandlerBase handler61 = new CDHCompanyPublicationConfirmationAddMenu(handler60);
            ChatDialogHandlerBase handler62 = new CDHCompanyPublicationConfirmationEraseMenu(handler61);
            ChatDialogHandlerBase handler63 = new CDHCompanyPublicationEraseDataMenu(handler62);
            ChatDialogHandlerBase handler64 = new CDHCompanyPublicationListMaterialsToAddMenu(handler63);
            ChatDialogHandlerBase handler65 = new CDHCompanyPublicationListMenu(handler64);
            ChatDialogHandlerBase handler66 = new CDHCompanyPublicationMenu(handler65);
            ChatDialogHandlerBase handler67 = new CDHCompanyPublicationPriceMaterialToAddMenu(handler66);
            ChatDialogHandlerBase handler68 = new CDHCompanyPublicationQuantityMaterialToAddMenu(handler67);
            ChatDialogHandlerBase handler69 = new CDHConfirmationSaleCategory(handler68);
            ChatDialogHandlerBase handler70 = new CDHConfirmationSaleKeyWord(handler69);
            ChatDialogHandlerBase handler71 = new CDHConfirmationSaleLocation(handler70);
            ChatDialogHandlerBase handler72 = new CDHFinalSaleCategory(handler71);
            ChatDialogHandlerBase handler73 = new CDHFinalSaleKeyword(handler72);
            ChatDialogHandlerBase handler74 = new CDHFinalSaleLocation(handler73);
            ChatDialogHandlerBase handler75 = new CDHHistorySaleMenu(handler74);
            ChatDialogHandlerBase handler76 = new CDHListCategoryMenu(handler75);
            ChatDialogHandlerBase handler77 = new CDHListKeyWordsMenu(handler76);
            ChatDialogHandlerBase handler78 = new CDHListLocationMenu(handler77);
            ChatDialogHandlerBase handler79 = new CDHMaterialRegenerationMenu(handler78);
            ChatDialogHandlerBase handler80 = new CDHMaterialRegenerationShowDetailMenu(handler79);
            ChatDialogHandlerBase handler81 = new CDHQualificationMenu(handler80);
            ChatDialogHandlerBase handler82 = new CDHQualificationsAddConfirmationMenu(handler81);
            ChatDialogHandlerBase handler83 = new CDHQualificationsAddDocumentUrl(handler82);
            ChatDialogHandlerBase handler84 = new CDHQualificationsAddMenu(handler83);
            ChatDialogHandlerBase handler85 = new CDHQualificationsConfirmationRemove(handler84);
            ChatDialogHandlerBase handler86 = new CDHQualificationsFinalAddMenu(handler85);
            ChatDialogHandlerBase handler87 = new CDHQualificationsFinalRemove(handler86);
            ChatDialogHandlerBase handler88 = new CDHQualificationsListMenu(handler87);
            ChatDialogHandlerBase handler89 = new CDHQualificationsRemoveMenu(handler88);
            ChatDialogHandlerBase handler90 = new CDHSalePublicationCategory(handler89);
            ChatDialogHandlerBase handler91 = new CDHSalePublicationKeyWord(handler90);
            ChatDialogHandlerBase handler92 = new CDHSalePublicationLocation(handler91);
            ChatDialogHandlerBase handler93 = new CDHSearchCategoryMenu(handler92);
            ChatDialogHandlerBase handler94 = new CDHSearchKeyWordMenu(handler93);
            ChatDialogHandlerBase handler95 = new CDHSearchLocationMenu(handler94);
            ChatDialogHandlerBase handler96 = new CDHSearchPublicationMenu(handler95);
            ChatDialogHandlerBase handler97 = new CDHShowDetailsHistorySaleMenu(handler96);
            ChatDialogHandlerBase handler98 = new CDHSignUpBadCode(handler97);
            ChatDialogHandlerBase handler99 = new CDHSignUpCancel(handler98);
            ChatDialogHandlerBase handler100 = new CDHSignUpCode(handler99);
            ChatDialogHandlerBase handler101 = new CDHSignUpCompanyName(handler100);
            ChatDialogHandlerBase handler102 = new CDHSignUpCompanyTrade(handler101);
            ChatDialogHandlerBase handler103 = new CDHSignUpDoneCompanyNew(handler102);
            ChatDialogHandlerBase handler104 = new CDHSignUpDoneEntrepreneurNew(handler103);
            ChatDialogHandlerBase handler105 = new CDHSignUpDoneJoinCompany(handler104);
            ChatDialogHandlerBase handler106 = new CDHSignUpDoneSysAdmin(handler105);
            ChatDialogHandlerBase handler107 = new CDHSignUpEntrepreneurAddress(handler106);
            ChatDialogHandlerBase handler108 = new CDHSignUpEntrepreneurName(handler107);
            ChatDialogHandlerBase handler109 = new CDHSignUpEntrepreneurTrade(handler108);
            ChatDialogHandlerBase handler110 = new CDHSignUpReviewCompanyNew(handler109);
            ChatDialogHandlerBase handler111 = new CDHSignUpReviewEntrepreneurNew(handler110);
            ChatDialogHandlerBase handler112 = new CDHSignUpReviewJoinCompany(handler111);
            ChatDialogHandlerBase handler113 = new CDHSignUpReviewSysAdmin(handler112);
            ChatDialogHandlerBase handler114 = new CDHSignUpUserFirstName(handler113);
            ChatDialogHandlerBase handler115 = new CDHSignUpUserLastName(handler114);
            ChatDialogHandlerBase handler116 = new CDHSignUpVerifyCompanyJoin(handler115);
            ChatDialogHandlerBase handler117 = new CDHSignUpVerifyCompanyNew(handler116);
            ChatDialogHandlerBase handler118 = new CDHSignUpVerifyEntrepreneurNew(handler117);
            ChatDialogHandlerBase handler119 = new CDHSignUpVerifySysAdminNew(handler118);

            this.firstHandler = handler119;
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