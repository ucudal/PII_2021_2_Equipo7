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
            ChatDialogHandlerBase handler0 = new CDH_BadCommand();
            ChatDialogHandlerBase handler1 = new CDH_Home(handler0);
            ChatDialogHandlerBase handler2 = new CDH_NextPage(handler1);
            ChatDialogHandlerBase handler3 = new CDH_PrevPage(handler2);
            ChatDialogHandlerBase handler4 = new CDH_Return(handler3);
            ChatDialogHandlerBase handler5 = new CDH_SessionExpired(handler4);
            ChatDialogHandlerBase handler6 = new CDH_WelcomeCompany(handler5);
            ChatDialogHandlerBase handler7 = new CDH_WelcomeEntrepreneur(handler6);
            ChatDialogHandlerBase handler8 = new CDH_WelcomeSysAdmin(handler7);
            ChatDialogHandlerBase handler9 = new CDH_WelcomeUnregistered(handler8);
            ChatDialogHandlerBase handler10 = new CDH_AdminInviteMenu(handler9);
            ChatDialogHandlerBase handler11 = new CDH_AdminMaterialMenu(handler10);
            ChatDialogHandlerBase handler12 = new CDH_AdminQualificationsMenu(handler11);
            ChatDialogHandlerBase handler13 = new CDH_InviteAdminConfirmation(handler12);
            ChatDialogHandlerBase handler14 = new CDH_InviteAdminCreate(handler13);
            ChatDialogHandlerBase handler15 = new CDH_InviteComapnyExistConfirmation(handler14);
            ChatDialogHandlerBase handler16 = new CDH_InviteCompanyConfirmation(handler15);
            ChatDialogHandlerBase handler17 = new CDH_InviteCompanyCreate(handler16);
            ChatDialogHandlerBase handler18 = new CDH_InviteCompanyExistCreate(handler17);
            ChatDialogHandlerBase handler19 = new CDH_InviteCompanyExistList(handler18);
            ChatDialogHandlerBase handler20 = new CDH_InviteEntrepreneurConfirmation(handler19);
            ChatDialogHandlerBase handler21 = new CDH_InviteEntrepreneurCreate(handler20);
            ChatDialogHandlerBase handler22 = new CDH_MateralCategoryFinal(handler21);
            ChatDialogHandlerBase handler23 = new CDH_MaterialCategoryAddName(handler22);
            ChatDialogHandlerBase handler24 = new CDH_MaterialCategoryConfirm(handler23);
            ChatDialogHandlerBase handler25 = new CDH_MaterialCategoryList(handler24);
            ChatDialogHandlerBase handler26 = new CDH_MaterialCategoryRemoveFinal(handler25);
            ChatDialogHandlerBase handler27 = new CDH_MaterialCategoryRemoveFromList(handler26);
            ChatDialogHandlerBase handler28 = new CDH_QualificationAddConfirmation(handler27);
            ChatDialogHandlerBase handler29 = new CDH_QualificationAddCreate(handler28);
            ChatDialogHandlerBase handler30 = new CDH_QualificationRemoveList(handler29);
            ChatDialogHandlerBase handler31 = new CDH_QualificationsAddNameMenu(handler30);
            ChatDialogHandlerBase handler32 = new CDH_RemoveQualificationFinal(handler31);
            ChatDialogHandlerBase handler33 = new CDH_RemoveQualificationRemove(handler32);
            ChatDialogHandlerBase handler34 = new CDH_Company_Tracing_Menu(handler33);
            ChatDialogHandlerBase handler35 = new CDH_VentasLista(handler34);
            ChatDialogHandlerBase handler36 = new CDH_CompanyActionsMaterialMenu(handler35);
            ChatDialogHandlerBase handler37 = new CDH_CompanyAddMenu(handler36);
            ChatDialogHandlerBase handler38 = new CDH_CompanyConfirmationEraseMaterialMenu(handler37);
            ChatDialogHandlerBase handler39 = new CDH_CompanyEraseDataMaterialMenu(handler38);
            ChatDialogHandlerBase handler40 = new CDH_CompanyListMaterialsMenu(handler39);
            ChatDialogHandlerBase handler41 = new CDH_CompanyMaterialAddConfirmationMenu(handler40);
            ChatDialogHandlerBase handler42 = new CDH_CompanyMaterialAddDataMenu(handler41);
            ChatDialogHandlerBase handler43 = new CDH_CompanyMaterialAddNameMenu(handler42);
            ChatDialogHandlerBase handler44 = new CDH_CompanyMaterialMenu(handler43);
            ChatDialogHandlerBase handler45 = new CDH_CompanyMaterialModifiConfirmationMenu(handler44);
            ChatDialogHandlerBase handler46 = new CDH_CompanyMaterialModifiDataMenu(handler45);
            ChatDialogHandlerBase handler47 = new CDH_CompanyMaterialModifiDateBetweenReStockMenu(handler46);
            ChatDialogHandlerBase handler48 = new CDH_CompanyMaterialModifiNameMenu(handler47);
            ChatDialogHandlerBase handler49 = new CDH_CompanyMaterialModifiQuantityMenu(handler48);
            ChatDialogHandlerBase handler50 = new CDH_CompanyMaterialModifiUbicationMenu(handler49);
            ChatDialogHandlerBase handler51 = new CDH_CompanyModifiMenu(handler50);
            ChatDialogHandlerBase handler52 = new CDH_CompanyQualificationAddConfirmationMenu(handler51);
            ChatDialogHandlerBase handler53 = new CDH_CompanyQualificationAddDataMenu(handler52);
            ChatDialogHandlerBase handler54 = new CDH_CompanyQualificationConfirmEraseMenu(handler53);
            ChatDialogHandlerBase handler55 = new CDH_CompanyQualificationEraseDataMenu(handler54);
            ChatDialogHandlerBase handler56 = new CDH_CompanyQualificationListToAddMenu(handler55);
            ChatDialogHandlerBase handler57 = new CDH_CompanyQualificationsListToEraseMenu(handler56);
            ChatDialogHandlerBase handler58 = new CDH_CompanyQualificationsMenu(handler57);
            ChatDialogHandlerBase handler59 = new CDH_CompanyPublicationActionMenu(handler58);
            ChatDialogHandlerBase handler60 = new CDH_CompanyPublicationAddDataMenu(handler59);
            ChatDialogHandlerBase handler61 = new CDH_CompanyPublicationConfirmationAddMenu(handler60);
            ChatDialogHandlerBase handler62 = new CDH_CompanyPublicationConfirmationEraseMenu(handler61);
            ChatDialogHandlerBase handler63 = new CDH_CompanyPublicationEraseDataMenu(handler62);
            ChatDialogHandlerBase handler64 = new CDH_CompanyPublicationListMaterialsToAddMenu(handler63);
            ChatDialogHandlerBase handler65 = new CDH_CompanyPublicationListMenu(handler64);
            ChatDialogHandlerBase handler66 = new CDH_CompanyPublicationMenu(handler65);
            ChatDialogHandlerBase handler67 = new CDH_CompanyPublicationPriceMaterialToAddMenu(handler66);
            ChatDialogHandlerBase handler68 = new CDH_CompanyPublicationQuantityMaterialToAddMenu(handler67);
            ChatDialogHandlerBase handler69 = new CDH_Confirmation_Sale_Category(handler68);
            ChatDialogHandlerBase handler70 = new CDH_Confirmation_Sale_KeyWord(handler69);
            ChatDialogHandlerBase handler71 = new CDH_Confirmation_Sale_Location(handler70);
            ChatDialogHandlerBase handler72 = new CDH_Final_Sale_Category(handler71);
            ChatDialogHandlerBase handler73 = new CDH_Final_Sale_Keyword(handler72);
            ChatDialogHandlerBase handler74 = new CDH_Final_Sale_Location(handler73);
            ChatDialogHandlerBase handler75 = new CDH_History_Sale_Menu(handler74);
            ChatDialogHandlerBase handler76 = new CDH_List_Category_Menu(handler75);
            ChatDialogHandlerBase handler77 = new CDH_List_KeyWords_Menu(handler76);
            ChatDialogHandlerBase handler78 = new CDH_List_Location_Menu(handler77);
            ChatDialogHandlerBase handler79 = new CDH_Material_Regeneration_Menu(handler78);
            ChatDialogHandlerBase handler80 = new CDH_Material_Regeneration_ShowDetail_Menu(handler79);
            ChatDialogHandlerBase handler81 = new CDH_Qualification_Menu(handler80);
            ChatDialogHandlerBase handler82 = new CDH_Qualifications_Add_Confirmation_Menu(handler81);
            ChatDialogHandlerBase handler83 = new CDH_Qualifications_Add_DocumentUrl(handler82);
            ChatDialogHandlerBase handler84 = new CDH_Qualifications_Add_Menu(handler83);
            ChatDialogHandlerBase handler85 = new CDH_Qualifications_Confirmation_Remove(handler84);
            ChatDialogHandlerBase handler86 = new CDH_Qualifications_Final_Add_Menu(handler85);
            ChatDialogHandlerBase handler87 = new CDH_Qualifications_Final_Remove(handler86);
            ChatDialogHandlerBase handler88 = new CDH_Qualifications_List_Menu(handler87);
            ChatDialogHandlerBase handler89 = new CDH_Qualifications_Remove_Menu(handler88);
            ChatDialogHandlerBase handler90 = new CDH_Sale_Publication_Category(handler89);
            ChatDialogHandlerBase handler91 = new CDH_Sale_Publication_KeyWord(handler90);
            ChatDialogHandlerBase handler92 = new CDH_Sale_Publication_Location(handler91);
            ChatDialogHandlerBase handler93 = new CDH_Search_Category_Menu(handler92);
            ChatDialogHandlerBase handler94 = new CDH_Search_KeyWord_Menu(handler93);
            ChatDialogHandlerBase handler95 = new CDH_Search_Location_Menu(handler94);
            ChatDialogHandlerBase handler96 = new CDH_Search_Publication_Menu(handler95);
            ChatDialogHandlerBase handler97 = new CDH_Show_Details_History_Sale_Menu(handler96);
            ChatDialogHandlerBase handler98 = new CDH_SignUpBadCode(handler97);
            ChatDialogHandlerBase handler99 = new CDH_SignUpCancel(handler98);
            ChatDialogHandlerBase handler100 = new CDH_SignUpCode(handler99);
            ChatDialogHandlerBase handler101 = new CDH_SignUpCompanyName(handler100);
            ChatDialogHandlerBase handler102 = new CDH_SignUpCompanyTrade(handler101);
            ChatDialogHandlerBase handler103 = new CDH_SignUpDoneCompanyNew(handler102);
            ChatDialogHandlerBase handler104 = new CDH_SignUpDoneEntrepreneurNew(handler103);
            ChatDialogHandlerBase handler105 = new CDH_SignUpDoneJoinCompany(handler104);
            ChatDialogHandlerBase handler106 = new CDH_SignUpDoneSysAdmin(handler105);
            ChatDialogHandlerBase handler107 = new CDH_SignUpEntrepreneurName(handler106);
            ChatDialogHandlerBase handler108 = new CDH_SignUpEntrepreneurTrade(handler107);
            ChatDialogHandlerBase handler109 = new CDH_SignUpReviewCompanyNew(handler108);
            ChatDialogHandlerBase handler110 = new CDH_SignUpReviewEntrepreneurNew(handler109);
            ChatDialogHandlerBase handler111 = new CDH_SignUpReviewJoinCompany(handler110);
            ChatDialogHandlerBase handler112 = new CDH_SignUpReviewSysAdmin(handler111);
            ChatDialogHandlerBase handler113 = new CDH_SignUpUserFirstName(handler112);
            ChatDialogHandlerBase handler114 = new CDH_SignUpUserLastName(handler113);
            ChatDialogHandlerBase handler115 = new CDH_SignUpVerifyCompanyJoin(handler114);
            ChatDialogHandlerBase handler116 = new CDH_SignUpVerifyCompanyNew(handler115);
            ChatDialogHandlerBase handler117 = new CDH_SignUpVerifyEntrepreneurNew(handler116);
            ChatDialogHandlerBase handler118 = new CDH_SignUpVerifySysAdminNew(handler117);
            ChatDialogHandlerBase handler119 = new CDH_SignUpEntrepreneurAddress(handler118);

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