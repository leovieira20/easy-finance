using BankAccountModule.Domain;
using CreditCardModule.Domain;
using Db.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace BankAccountModule.Api.Infrastructure.Db;

public class MigrationHelper
{
    public static void Migrate(IServiceProvider services)
    {
        using var context = services
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<EasyFinanceDbContext>();

        context.Database.EnsureDeleted();
        context.Database.Migrate();
        
        RegisterBankAccountAndTransactions(context);
        RegisterCreditCardAndTransactions(context);
    }

    private static void RegisterBankAccountAndTransactions(EasyFinanceDbContext context)
    {
        var id = new BankAccountId(Guid.Parse("5395CE24-2C9A-4DDD-8838-52D02890CEC1"));
        var name = "Test bank account";

        var bankAccount = BankAccount.Create(id, name);

        context.BankAccounts.Add(bankAccount);
        context.SaveChanges();

        RegisterBankAccountCredits(bankAccount);
        RegisterBankAccountDebits(bankAccount);

        context.BankAccounts.Update(bankAccount);
        context.SaveChanges();
    }

    private static void RegisterBankAccountCredits(BankAccount bankAccount)
    {
        // Jan 2021
        bankAccount.RegisterCredit(new DateTime(2021, 01, 01), 10330.89m, "Initial balance");
        bankAccount.RegisterCredit(new DateTime(2021, 01, 04), 850m, "RENT IE21010409562236");
        bankAccount.RegisterCredit(new DateTime(2021, 01, 26), 33914.49m, "DELL PRODUCTS IE21012628238312");
        bankAccount.RegisterCredit(new DateTime(2021, 01, 27), 4068.28m, "1327D0F1BE6541C197 IE21012225982313");
        
        // Feb 2021
        bankAccount.RegisterCredit(new DateTime(2021, 02, 05), 850m, "RENT IE21020538935297");
        bankAccount.RegisterCredit(new DateTime(2021, 02, 22), 150m, "*ATMLDG D'DRUM TCA Card ending: 0354");
        bankAccount.RegisterCredit(new DateTime(2021, 02, 22), 1350.00m, "*ATMLDG D'DRUM TCA Card ending: 0354");
        bankAccount.RegisterCredit(new DateTime(2021, 02, 26), 4325.73m, "C9A6569F89A1442581 IE21022453818544");
        
        // March 2021
        bankAccount.RegisterCredit(new DateTime(2021, 03, 02), 400m, "*ATMLDG D'DRUM TCA Card ending: 0354");
        bankAccount.RegisterCredit(new DateTime(2021, 03, 02), 850m, "RENT IE21030259497638");
        bankAccount.RegisterCredit(new DateTime(2021, 03, 23), 1173.43m, "MINTOS MARKETPLACE IE21032376966944");
        bankAccount.RegisterCredit(new DateTime(2021, 03, 26), 4325.75m, "09B07ACBACC342AD84 IE21031974287472");
        bankAccount.RegisterCredit(new DateTime(2021, 03, 31), 850m, "DYLAN IE21033184137623");
        
        // April 2021
        bankAccount.RegisterCredit(new DateTime(2021, 04, 27), 4325.73m, "4A91F11B8A3B460AA6 IE21042303809586");
        
        // May 2021
        bankAccount.RegisterCredit(new DateTime(2021, 05, 07), 850m, "RENT IE21050716566277");
        bankAccount.RegisterCredit(new DateTime(2021, 05, 12), 52.34m, "REVCOM051879919JA2 IE21051219727417");
        bankAccount.RegisterCredit(new DateTime(2021, 05, 24), 50m, "PRI 1 DE 4 ");
        bankAccount.RegisterCredit(new DateTime(2021, 05, 27), 4325.74m, "ABCB1D3195BC421AA8 IE21052429618277");
        bankAccount.RegisterCredit(new DateTime(2021, 05, 31), 150m, "JANYNNE ABREU IE21053135796074");
        
        // Jun 2021
        bankAccount.RegisterCredit(new DateTime(2021, 06, 01), 432.41m, "VDP-PAYPAL *AIRBNB ");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 01), 40m, "JANYNNE ABREU IE21060138191760");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 08), 0.94m, "VDP-AMZ*Amazon.co. 0.81 GBP@ 0.86170");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 11), 1m, "VDP-AMZ*Amazon.co. 0.86 GBP@ 0.8");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 11), 1.13m, "VDP-AMZ*Amazon.co. 0.98 GBP@ 0.86725");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 18), 2.3m, "VDP-CHRISDERMO* SU ");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 23), 10.02m, "VDP-PAYPAL *THOMAN ");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 25), 90.61m, "VDP-gotinder.com/h ");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 25), 4325.74m, "062115CDDEF04C1285 IE21062355931693");
        bankAccount.RegisterCredit(new DateTime(2021, 06, 28), 97.35m, "VDP-PAYPAL *APPLE. ");
        
        // Jul 2021
        bankAccount.RegisterCredit(new DateTime(2021, 07, 27), 4325.74m, "7AC0E114DE194DCD8B IE21072383813321");
        bankAccount.RegisterCredit(new DateTime(2021, 07, 30), 250m, "NETO SWITCH ");
        
        // Aug 2021
        bankAccount.RegisterCredit(new DateTime(2021, 08, 27), 4325.74m, "CBF8FF7CBE9E4AED94 IE21082510950515");
        bankAccount.RegisterCredit(new DateTime(2021, 09, 03), 185.32m, "843314189397 IE21090219535937");
        
        // Sep 2021
        bankAccount.RegisterCredit(new DateTime(2021, 09, 14), 82.06m, "VIRGINMEDIAREFUND IE21090925416014");
        bankAccount.RegisterCredit(new DateTime(2021, 09, 24), 1817.36m, "RENT REFUND IE21092437856304");
        bankAccount.RegisterCredit(new DateTime(2021, 09, 27), 4325.74m, "692E2FCA3E214F8F9F IE21092337314203");
        
        // Oct 2021
        bankAccount.RegisterCredit(new DateTime(2021, 10, 05), 170m, "JANYNNE ABREU IE21100549113903");
        bankAccount.RegisterCredit(new DateTime(2021, 10, 18), 52.18m, "VDP-AMZ*Amazon.co. 44.28 GBP@ 0.848");
        bankAccount.RegisterCredit(new DateTime(2021, 10, 27), 4325.74m, "601C560CED3942BB84 IE21102264288671");
        
        // Nov 2021
        bankAccount.RegisterCredit(new DateTime(2021, 11, 12), 799.3m, "VDP-Wise ");
        bankAccount.RegisterCredit(new DateTime(2021, 11, 26), 4565.74m, "0A41B405FE1B41FC8F IE21112392181039");
        
        // Dez 2021
        bankAccount.RegisterCredit(new DateTime(2021, 12, 06), 57.81m, "VDP-AMZ*Amazon.co. 49.45 GBP@ 0.85538");
        bankAccount.RegisterCredit(new DateTime(2021, 12, 17), 4325.73m, "A785072BA5114D8FAE IE21121614526590");
        
        // Jan 2022
        bankAccount.RegisterCredit(new DateTime(2022, 01, 27), 4157.27m, "E3AFA472A14347F2A0 IE22012548017327");
        
        // Feb 2022
        bankAccount.RegisterCredit(new DateTime(2022, 02, 03), 1000.00m, "PAI DE TODOS ");
        bankAccount.RegisterCredit(new DateTime(2022, 02, 03), 371.11m, "MINTOS MARKETPLACE IE22020358459173");
        bankAccount.RegisterCredit(new DateTime(2022, 02, 04), 474.31m, "LINKED FINANCE ");
        bankAccount.RegisterCredit(new DateTime(2022, 02, 09), 371m, "PAI DE TODOS ");
        bankAccount.RegisterCredit(new DateTime(2022, 02, 14), 575m, "*ATMLDG D'DRUM TCA Card ending: 0354");
        bankAccount.RegisterCredit(new DateTime(2022, 02, 14), 900m, "*ATMLDG D'DRUM TCA Card ending: 0354");
        bankAccount.RegisterCredit(new DateTime(2022, 02, 25), 1703.16m, "AB2533D841E042B5BD IE22022476769883");
        bankAccount.RegisterCredit(new DateTime(2022, 02, 25), 2935.39m, "PRIVAPATH DIAGNOST IE22022476759140");
        
        // Mar 2022
        bankAccount.RegisterCredit(new DateTime(2022, 03, 24), 3600.00m, "PRIVAPATH DIAGNOST IE22032301081133");
    }

    private static void RegisterBankAccountDebits(BankAccount bankAccount)
    {
        // Jan 2021
        bankAccount.RegisterDebit(new DateTime(2021, 01, 04), 300m, "VDP-REVO*LeonardoV ");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 04), 9.83m, "VDP-Spotify P12E0D ");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 04), 250m, "VDP-REVO*LeonardoV ");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 08), 29m, "D/D HARLANDS DDMS IE21010713966087");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 11), 239.48m, "D/D PAYPAL (EUROPE IE21010815217052");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 21), 1000m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 26), 1000m, "VDP-Revolut* - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 26), 0.24m, "STAMP DUTY 0354 ");
        bankAccount.RegisterDebit(new DateTime(2021, 01, 28), 69.99m, "D/D VIRGIN MEDIA I IE21012527309540");
        
        // Feb 2021
        bankAccount.RegisterDebit(new DateTime(2021, 02, 01), 1840.81m, "RENT ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 04), 9.83m, "VDP-Spotify P134B7 ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 08), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 18), 300m, "VDP-Transferwise L ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 22), 503.49m, "VDP-GAMESTOP UK IR ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 22), 40.98m, "VDP-PAYPAL *DOMINO ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 22), 80.55m, "VDP-TESCO STORES 3 ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 22), 51.2m, "VDP-THE HEALTH STO ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 22), 10000.00m, "*INET FASTINV FEB ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 22), 1500.00m, "*INET BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 02, 25), 300m, "VDP-Revolut  - 700 ");
        
        // Mar 2021
        bankAccount.RegisterDebit(new DateTime(2021, 03, 01), 1840.81m, "RENT ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 01), 69.99m, "D/D VIRGIN MEDIA I IE21022453815235");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 03), 5.5m, "VDP-ONLYFANS.COM 6.05 USD@ 1.19801");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 04), 9.99m, "VDP-Spotify P13B83 ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 08), 40.37m, "VDP-ONLYFANS.COM 47.19 USD@ 1.18926");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 08), 29.99m, "VDP-PAYPAL *MLSOUN ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 08), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 15), 13.41m, "VDP-TESCO STORES ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 18), 97.3m, "VDP-TESCO STORES 3 ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 19), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 19), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 22), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 22), 127.7m, "VDP-STARTINFINITY. 149.00 USD@ 1.18715");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 22), 1000.00m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 23), 500m, "VDP-Wise ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 24), 3.52m, "VDP-OnlyFans 3.63 USD@ 1.1824");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 24), 29.1m, "VDP-OnlyFans 33.86 USD@ 1.18391");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 29), 14m, "FEE-QTR TO 26FEB21 933392-30388001");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 30), 5000.00m, "*INET FI APR ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 30), 1840.81m, "RENT ");
        bankAccount.RegisterDebit(new DateTime(2021, 03, 31), 100m,
            "VDA-SPAR GARDINER DUBLIN 1 T 00 44291.793055555");
        
        // Apr 2021
        bankAccount.RegisterDebit(new DateTime(2021, 04, 06), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 06), 9.99m, "VDP-Spotify P1432F ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 06), 91.27m, "VDP-TESCO STORES 3 ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 06), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 12), 95.46m, "VDP-BOOTS RETAIL(I ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 12), 65m, "VDP-DOCTOR CIARAN ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 12), 75.45m, "VDP-Just Eat Irela ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 12), 48.7m, "VDP-TESCO STORES 3 ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 13), 28.93m, "VDP-Haven Pharmacy ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 20), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 20), 13.07m, "D/D PAYPAL (EUROPE IE21041999089046");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 21), 62.6m, "VDP-PAYPAL *THOMAN ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 21), 1500.00m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 26), 9.52m, "VDP-OnlyFans 10.89 USD@ 1.20066");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 28), 70m, "D/D VIRGIN MEDIA I IE21042304032279");
        bankAccount.RegisterDebit(new DateTime(2021, 04, 30), 1840.81m, "RENT ");
        
        // May 2021
        bankAccount.RegisterDebit(new DateTime(2021, 05, 04), 277.5m, "VDP-PAYPAL *GEAR4M ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 04), 128.96m, "VDP-PAYPAL *SOUNDB ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 04), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 05), 44m, "VDP-PAYPAL *THOMAN ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 05), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 05), 9.99m, "VDP-Spotify P14A8C ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 06), 143.82m, "VDP-AMZNMktplace 121.91 GBP@ 0.86246");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 10), 100m, "VDP-Transferwise E ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 10), 400m, "VDP-Transferwise E ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 11), 432.41m, "VDP-PAYPAL *AIRBNB ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 17), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 21), 200m, "VDP-DR EDDIE MOLON ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 21), 38.47m, "VDP-PAYPAL *2CHECK ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 24), 9.41m, "VDP-OF 10.89 USD@ 1.21540");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 24), 72.5m, "VDP-TESCO STORE 35 ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 25), 8177.53m, "*INET 614 CUBES 3 ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 26), 52.89m, "D/D PAYPAL (EUROPE IE21052530327687");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 27), 40.93m, "VDP-AXOSOFT GITKRA 49.00 USD@ 1.21799");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 27), 95m, "VDP-PAYPAL *THOMAN ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 27), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 28), 70m, "D/D VIRGIN MEDIA I IE21052530573855");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 31), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 31), 1840.81m, "RENT ");
        bankAccount.RegisterDebit(new DateTime(2021, 05, 31), 4470.30m, "*MOBI BE ");
        
        // Jun 2021
        bankAccount.RegisterDebit(new DateTime(2021, 06, 01), 200m, "VDP-Transferwise E ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 01), 400m, "VDP-Transferwise E ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 08), 12.4m, "VDP-FREENOW*509QBZ ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 08), 15.12m, "VDP-ONLYFANS 17.78 USD@ 1.21199");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 08), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 10), 2279.70m, "VDP-PAYPAL *THOMAN ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 11), 29.2m, "VDP-FREENOW*50ONP0 ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 15), 2.3m, "VDP-CHRISDERMO* SU ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 18), 36.99m, "VDP-ARGOS DUNDRUM ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 21), 90.61m, "VDP-gotinder.com/h ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 21), 199m, "VDP-PAYPAL *NATIVE ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 21), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 21), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 22), 119m, "VDP-GOOGLE *Google ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 22), 39.95m, "D/D PAYPAL (EUROPE IE21062153466264");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 23), 49.74m, "VDP-SUSHIDA D6 ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 23), 20m, "*MOBI PRI BDAY ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 24), 9.59m, "VDP-OnlyFans 10.89 USD@ 1.19146");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 25), 98.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 28), 43.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 28), 129.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 28), 30.99m, "VDP-PIZZA HUT DELI ");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 28), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 28), 17.8m, "FEE-QTR TO 28MAY21 933392-30388001");
        bankAccount.RegisterDebit(new DateTime(2021, 06, 28), 70m, "D/D VIRGIN MEDIA I IE21062355707037");
        
        // Jul 2021
        bankAccount.RegisterDebit(new DateTime(2021, 07, 02), 300m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 05), 18.2m, "VDP-FREENOW*5442B9 ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 05), 10.7m, "VDP-OnlyFans 12.10 USD@ 1.18048");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 07), 0.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 07), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 08), 99m, "VDP-COMPU B DUNDRU ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 08), 356.28m, "*MOBI 43DV2019 ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 08), 29m, "D/D HARLANDS DDMS IE21070769385333");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 09), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 19), 69.99m, "VDP-PlaystationNet ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 21), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 22), 1000.00m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 26), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 07, 27), 550m, "VDP-Transferwise E ");
        
        // Aug 2021
        bankAccount.RegisterDebit(new DateTime(2021, 08, 03), 63.11m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 03), 15.4m, "VDP-FREENOW*58BG3B ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 03), 31.64m, "VDP-PAYPAL *COCOAT ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 03), 500m, "VDP-Revolut  - 700 ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 03), 1m, "D/D PAYPAL (EUROPE IE21080594995315");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 06), 54.4m, "D/D PAYPAL (EUROPE IE21080594995319");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 09), 0.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 09), 29m, "D/D HARLANDS DDMS IE21080696418381");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 16), 97m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 16), 26.05m, "VDP-SUSHIDA D6 ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 17), 39.36m, "D/D PAYPAL (EUROPE IE21081603056912");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 18), 31.35m, "VDP-HS-EMPORIOBLUE 189.60 BRL@ 6.15184");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 18), 500m, "VDP-Revolut  3706 ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 23), 111m, "VDP-BROWN THOMAS ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 23), 139m, "VDP-MARKS & SPENCE ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 23), 1500.00m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 30), 0.5m, "VDP-MY.FLIPDIS* BR ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 30), 0.5m, "VDP-MY.FLIPDIS* BR ");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 30), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 08, 30), 144.19m, "D/D VIRGIN MEDIA I IE21082511005440");
        
        // Sep 2021
        bankAccount.RegisterDebit(new DateTime(2021, 09, 02), 42.35m, "D/D PAYPAL (EUROPE IE21090117937609");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 03), 41.75m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 06), 155m, "VDP-PAYPAL *TOONTR ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 06), 23.5m, "VDP-SUSHIDA SANDYF ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 07), 0.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 07), 397.9m, "VDP-PAYPAL *THOMAN ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 08), 76.64m, "VDP-AMZN Mktp UK*W ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 08), 122.4m, "VDP-AMZNMktplace ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 08), 29m, "D/D HARLANDS DDMS IE21090723230301");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 08), 26.2m, "VDC-OLLIES BAR AND ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 08), 173.7m, "VDP-PAYPAL *GEAR4M ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 08), 2000.00m, "VDP-Revolut  - 370 ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 14), 129.13m, "VDP-PAYPAL *SSL ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 16), 4771.86m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 20), 82.2m, "VDP-AMZNMktplace 68.90 GBP@ 0.85282");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 20), 2.75m, "VDC-AMT COFFEE DUB ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 20), 17.34m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 20), 29m, "VDC-ELEPHANT & CAS ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 21), 500m, "VDP-Wise ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 22), 272.64m, "VDP-Amazon.co.uk*X 228.37 GBP@ 0.85225");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 24), 40.83m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 27), 30.95m, "VDP-PIZZA HUT DELI ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 27), 46.55m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 27), 6m, "VDC-F.X. BUCKLEY ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 27), 9.9m, "VDC-MCDONALDS 7006 ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 27), 19.65m, "VDC-POLONEZ DUNDRU ");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 28), 16.5m, "FEE-QTR TO 27AUG21 933392-30388001");
        bankAccount.RegisterDebit(new DateTime(2021, 09, 30), 25m, "*MOBI  TOP-UP 834503765");
        
        // Oct 2021
        bankAccount.RegisterDebit(new DateTime(2021, 10, 01), 399m, "VDP-COMPU B DUNDRU ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 01), 104.98m, "VDP-GAMESTOP DUNDR ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 04), 103.49m, "VDP-Superdry ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 04), 34.05m, "VDC-BEWLEYS CAFE G ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 04), 40.48m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 04), 30m, "VDC-MUSIC MINDS ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 04), 50m, "VDC-SPICE OF LIFE ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 05), 64.37m, "VDP-PAYPAL *AIRBNB ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 07), 0.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 08), 25m, "D/D HARLANDS DDMS IE21100750791095");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 11), 257.44m, "VDP-PAYPAL *AIRBNB ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 20), 99.99m, "VDP-PAYPAL *CLEVER ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 20), 59m, "VDP-PAYPAL *CROSSO ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 21), 5.99m, "VDP-PAYPAL *APPLE. ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 26), 3000.00m, "VDP-Revolut  - 370 ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 26), 3000.00m, "VDP-Revolut  - 370 ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 26), 1000.00m, "*MOBI LEO TO DYLAN ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 26), 300m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 28), 17.3m, "VDP-AMZN Digital*I 14.16 GBP@ 0.84035");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 28), 4.5m, "VDP-AMZN Digital*U 3.40 GBP@ 0.83950");
        bankAccount.RegisterDebit(new DateTime(2021, 10, 28), 7.59m, "VDP-AMZN Digital*4 6.00 GBP@ 0.84033");
        
        // Nov 2021
        bankAccount.RegisterDebit(new DateTime(2021, 11, 03), 319.05m, "VDP-Amazon.co.uk*4 264.44 GBP@ 0.8433");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 03), 1100.00m, "VDP-Revolut  - 370 ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 03), 500m, "VDP-Wise ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 04), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 04), 9.27m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 08), 55.1m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 08), 79.5m, "VDP-Wasabi Bar & G ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 08), 799.3m, "VDP-Wise ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 08), 25m, "D/D HARLANDS DDMS IE21110577575874");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 08), 16m, "VDC-DUNNES NORTH E ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 08), 15m, "VDC-O BRIENS WINES ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 09), 77.51m, "VDP-AZUL AIR    BD ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 09), 69.9m, "VDP-GOL LINHAS A*Q 438.96 BRL@ 6.38951");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 09), 59m, "VDP-RANDOX TEORANT ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 09), 791m, "VDP-Wise ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 10), 7.47m, "VDP-AMZN Digital*K 5.99 GBP@ 0.85327");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 10), 14.88m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 10), 12m, "VDC-O BRIENS WINES ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 11), 143m, "VDP-BAH33deg The A ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 11), 5.85m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 15), 241.48m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 15), 5.08m, "VDC-BOOTS RETAIL 1 ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 15), 16.38m, "VDC-DUTY FREE NEW 18.40 USD@ 1.14285");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 15), 17.7m, "VDC-FIRST CLASS CA ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 15), 8.15m, "VDC-SPECIALLY AERO ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 15), 50m, "VDC-THE LOOP T1 ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 16), 39.36m, "D/D PAYPAL (EUROPE IE21111685101032");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 18), 44.32m, "VDP-PAYPAL *FASTSP ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 18), 26.71m, "VDP-PAYPAL *TRUEFI ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 18), 500m, "VDP-Revolut  - 370 ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 19), 99m, "VDP-PAYPAL *FASTSP ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 22), 1.63m, "VDP-AMZN Digital*E 0.99 GBP@ 0.83898");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 22), 4.27m, "VDP-AMZN Digital*9 3.20 GBP@ 0.83769");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 22), 200m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 24), 39m, "VDP-PAYPAL *PADDLE ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 24), 500m, "VDP-Revolut  - 370 ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 25), 137.76m, "VDP-PAYPAL *OREILL ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 25), 0.84m, "D/D PAYPAL (EUROPE IE21112492634091");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 25), 1.28m, "D/D PAYPAL (EUROPE IE21112492635454");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 25), 3.26m, "D/D PAYPAL (EUROPE IE21112492633895");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 25), 3.64m, "D/D PAYPAL (EUROPE IE21112492634020");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 26), 54.01m, "VDP-PAYPAL *ADSRLI ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 26), 71.71m, "VDP-PAYPAL *ALGOEX ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 26), 22.34m, "VDP-PAYPAL *EDDIEL ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 26), 18.62m, "VDP-PAYPAL *PUREMI ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 26), 1.63m, "D/D PAYPAL (EUROPE IE21112594098311");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 26), 3.94m, "D/D PAYPAL (EUROPE IE21112594099497");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 29), 73.35m, "VDP-PAYPAL *ADSRLI ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 29), 34.32m, "VDP-PAYPAL *SSL ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 30), 178.2m, "VDP-PAYPAL *SOFTUB ");
        bankAccount.RegisterDebit(new DateTime(2021, 11, 30), 1.76m, "D/D PAYPAL (EUROPE IE21113098526150");
        
        // Dez 2021
        bankAccount.RegisterDebit(new DateTime(2021, 12, 03), 1624.42m, "VDP-Revolut* - 370 ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 03), 13.48m, "VDC-GAMESTOP DUNDR ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 07), 2.13m, "D/D PAYPAL (EUROPE IE21120604702750");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 15), 7.48m, "VDP-AMZN Digital*R 5.98 GBP@ 0.8506");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 15), 1612.50m, "VDP-PAYPAL *GEAR4M ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 15), 700m, "VDP-Wise ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 17), 300m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 20), 26.78m, "VDP-PAYPAL *TRUEFI ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 21), 183.27m, "VDP-NEURAL DSP ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 21), 300m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 21), 0.82m, "D/D PAYPAL (EUROPE IE21122017384139");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 21), 8.56m, "D/D PAYPAL (EUROPE IE21122017382514");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 22), 55.25m, "VDP-MP*CAVALERA 346.99 BRL@ 6.39023");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 22), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 24), 60.12m, "VDP-PAYPAL *GOODHE ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 24), 9.14m, "D/D PAYPAL (EUROPE IE21122322207065");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 30), 18.45m, "VDP-PAYPAL *PUREMI ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 30), 1208.00m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 30), 20.3m, "FEE-QTR TO 26NOV21 933392-30388001");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 30), 1.39m, "D/D PAYPAL (EUROPE IE21122825306725");
        bankAccount.RegisterDebit(new DateTime(2021, 12, 30), 2.44m, "D/D PAYPAL (EUROPE IE21122825305622");
        
        // Jan 2022
        bankAccount.RegisterDebit(new DateTime(2022, 01, 04), 1.02m, "D/D PAYPAL (EUROPE IE22010329607206");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 04), 1.45m, "D/D PAYPAL (EUROPE IE22010329608955");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 04), 2.25m, "D/D PAYPAL (EUROPE IE22010329612656");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 04), 2.5m, "D/D PAYPAL (EUROPE IE22010329606574");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 04), 2.5m, "D/D PAYPAL (EUROPE IE22010329608814");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 04), 7.48m, "D/D PAYPAL (EUROPE IE22010329612834");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 05), 200m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 06), 7.47m, "D/D PAYPAL (EUROPE IE22010531207384");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 06), 9.52m, "D/D PAYPAL (EUROPE IE22010531260426");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 07), 200m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 10), 1196.68m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 10), 1.62m, "D/D PAYPAL (EUROPE IE22010733818157");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 12), 42.16m, "VDP-MLCLUS ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 12), 32.31m, "VDP-PAYPAL *VEDPRA ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 18), 26.5m, "VDP-PAYPAL *TRUEFI ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 18), 500m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 20), 5.94m, "VDP-AMZN Digital*Y 4.57 GBP@ 0.83242");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 20), 6.44m, "VDP-AMZN Digital*1 4.99 GBP@ 0.83305");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 20), 37.47m, "VDP-AMZN Mktp US*V ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 25), 18.43m, "VDP-PAYPAL *PUREMI ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 26), 0.12m, "STAMP DUTY 0354 ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 28), 116.99m, "VDP-AMZNMktplace ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 28), 45.3m, "VDP-NEW CORPORE VP 269.70 BRL@ 6.05659");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 31), 60m, "VDP-PAYPAL *TOONTR ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 31), 100m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2022, 01, 31), 25m, "*MOBI  TOP-UP 834503765");
        
        // Feb 2022
        bankAccount.RegisterDebit(new DateTime(2022, 02, 02), 2.09m, "D/D PAYPAL (EUROPE IE22013154250667");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 02), 95.93m, "VDP-PAYPAL *IKMULT ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 02), 289.04m, "VDP-PAYPAL *IKMULT ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 03), 65.03m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 03), 700m, "VDP-WISE*LeonardoC ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 53.49m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 22.32m, "VDP-QTEKA.COM 24.95 USD@ 1.14083");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 200m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 200m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 1100.00m, "VDP-Revolut**3706* ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 1.33m, "VDP-WUPIS.COM 1.00 USD@ 1.13636");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 29.18m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 07), 42.19m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 08), 212.88m, "D/D PAYPAL (EUROPE IE22020760942918");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 09), 17.96m, "VDP-WUPIS.COM 19.95 USD@ 1.13934");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 11), 12.76m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 14), 3000.00m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 14), 11.48m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 14), 20.32m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 14), 5m, "VDC-GAMESTOP DUNDR ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 14), 29.71m, "VDC-TESCO STORES 3 ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 18), 26.63m, "VDP-PAYPAL *TRUEFI ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 21), 50.15m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 21), 74.99m, "VDP-GAMESTOP DUNDR ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 25), 137.76m, "VDP-PAYPAL *OREILL ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 25), 18.43m, "VDP-PAYPAL *PUREMI ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 28), 65.76m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 02, 28), 15.5m, "VDC-O BRIENS WINES ");
        
        // Mar 2022
        bankAccount.RegisterDebit(new DateTime(2022, 03, 02), 25m, "*MOBI  TOP-UP 834503765");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 07), 78.5m, "VDP-TESCO STORE 35 ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 07), 4.05m, "VDC-THE FORTY FOOT ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 07), 8.1m, "VDC-THE FORTY FOOT ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 07), 35.3m, "VDC-THE FORTY FOOT ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 08), 23.54m, "VDP-QTEKA.COM 24.95 USD@ 1.08055");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 10), 500m, "*MOBI BE ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 11), 3000m, "VDP-Revolut* - 993 ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 11), 18.63m, "VDP-WUPIS.COM 19.95 USD@ 1.09735");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 11), 39.56m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 14), 500m, "D/D PAYPAL (EUROPE IE22031191835221");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 14), 14.97m, "VDC-BOOTS RETAIL 1 ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 14), 15.15m, "VDC-28302541 DUB T ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 15), 120m, "VDA-BANCO BPM VENEZIA 44633.6562");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 15), 70m, "VDP-AL CORNER ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 15), 24m, "VDC-ATVO SPA MOBIL ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 21), 300m, "VDA-CASH WITHDRAWA ATM 44638.633333333");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 21), 71.86m, "VDP-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 21), 27.59m, "VDP-PAYPAL *TRUEFI ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 21), 8.5m, "VDC-FARMACIA TORRE ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 25), 18.99m, "VDP-PAYPAL *PUREMI ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 19.6m, "FEE-QTR TO 25FEB22 933392-30388001");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 6.4m, "VDC-BLACKBIRD RATH ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 2.59m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 38.38m, "VDC-DUNNES BEACON ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 12.9m, "VDC-FIBBER MAGEES ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 13m, "VDC-FIBBER MAGEES ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 10m, "VDC-MCDONALDS 7005 ");
        bankAccount.RegisterDebit(new DateTime(2022, 03, 28), 9.1m, "VDC-RATHMINES OMNI ");
    }

    private static void RegisterCreditCardAndTransactions(EasyFinanceDbContext context)
    {
        var id = new CreditCardId(Guid.Parse("5395CE24-2C9A-4DDD-8838-52D02890CEC1"));
        var name = "Test credit card";

        var creditCard = CreditCard.Create(id, name);
        
        creditCard.SetLimit(7000m);
        creditCard.SetThreshold(3600 * 0.30m);
        creditCard.SetDefaultPaymentAmount(500m);

        context.CreditCards.Add(creditCard);
        context.SaveChanges();

        RegisterCreditCardPayments(context, creditCard);
        RegisterCreditCardExpenses(context, creditCard);

        context.SaveChanges();
    }

    private static void RegisterCreditCardPayments(EasyFinanceDbContext context, CreditCard creditCard)
    {
        context.CreditCardTransactions.AddRange(
            CreditCardTransaction.CreatePayment(new DateTime(2020, 04, 20), 1000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 05, 01), 3500.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 05, 25), 300m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 06, 22), 500m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 07, 22), 500m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 08, 17), 1000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 09, 21), 1000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 10, 21), 1500.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 11, 04), 963.05m, "COMPU B", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 11, 23), 1500.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2020, 12, 24), 1000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 01, 21), 1000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 01, 27), 361.79m, "PAYPAL *AUTONOMOUS", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 02, 22), 1500.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 03, 22), 1000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 04, 21), 1500.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 05, 31), 4470.30m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 06, 29), 130m, "PAYPAL *IKEA IE", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 07, 22), 1000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 08, 23), 1500.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 09, 14), 29.22m, "Amazon.co.uk", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 09, 16), 4771.86m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 09, 24), 278m, "PAYPAL *NUZZIE LLC", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 10, 18), 51.62m, "AMZ*Amazon.co.uk", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 10, 26), 300m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 11, 08), 1399.00m, "COMPU B", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 11, 22), 200m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2021, 12, 17), 300m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2022, 01, 18), 500m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2022, 02, 14), 3000.00m, "PAYMENT THANK YOU", creditCard.Id),
            CreditCardTransaction.CreatePayment(new DateTime(2022, 03, 10), 500m, "PAYMENT THANK YOU", creditCard.Id)
        );
    }

    private static void RegisterCreditCardExpenses(EasyFinanceDbContext context, CreditCard creditCard)
    {
        context.CreditCardTransactions.AddRange(
            // Apr 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 04, 08), 359m, "Toontrack Music", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 04, 09), 284.13m, "BLS*PRESONUS122521", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 04, 21), 386.91m, "PAYPAL *GEAR4MUSIC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 04, 23), 14.29m, "PP*GOOGLE FILMIC I", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 04, 27), 29.86m, "PURCHASE *FINANCE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 04, 29), 1033.86m, "Amazon.co.uk*VP53Z", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 04, 29), 7m, "OVERLIMIT FEE", creditCard.Id),
            
            // May 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 05, 01), 788m, "PAYPAL *THOMANN", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 05, 21), 155m, "PAYPAL *TOONTRACKM", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 05, 22), 406.5m, "PAYPAL *GEAR4MUSIC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 05, 25), 18m, "PAYPAL *GEAR4MUSIC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 05, 27), 10.85m, "PURCHASE *FINANCE", creditCard.Id),
            
            // Jun 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 06, 08), 169.84m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 06, 08), 56.61m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 06, 12), 45.12m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 06, 26), 33.05m, "PURCHASE *FINANCE", creditCard.Id),
            
            // Jul 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 01), 30m, "GOVERNMENT STAMP D", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 02), 283.22m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 08), 232.52m, "AMZNMktplace", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 13), 78.87m, "PAYPAL *LINE 6 INC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 13), 197.73m, "AMZNMktplace", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 16), 124.51m, "INDIEGOGO* HUAMI", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 21), 81.43m, "AMZNMktplace", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 07, 27), 18.53m, "PURCHASE *FINANCE", creditCard.Id),
            
            // Aug 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 08, 10), 219.78m, "AMZNMktplace", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 08, 13), 126m, "PAYPAL *FASTSPRING", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 08, 13), 159m, "PAYPAL *DIGITALRIV", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 08, 27), 347.45m, "INDIEGOGO* SPEED C", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 08, 27), 24.73m, "PURCHASE *FINANCE", creditCard.Id),
            
            // Sep 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 09, 22), 99m, "PAYPAL *DIGITALRIV", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 09, 24), 662.75m, "Amazon.co.uk*K54VE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 09, 25), 22.18m, "PURCHASE *FINANCE", creditCard.Id),
            
            // Oct 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 10, 02), 331.06m, "DELL PRODUCTS", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 10, 07), 255.98m, "AMZNMktplace", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 10, 27), 17.64m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 10, 29), 524.9m, "PAYPAL *MUSIC STOR", creditCard.Id),
            
            // Nov 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 11, 02), 963.05m, "COMPU B", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 11, 02), 510.21m, "AMZNMktplace", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 11, 09), 369.17m, "CKO*www.autonomous", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 11, 09), 1000.15m, "AMZNMKTPLACE AMAZO", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 11, 17), 470.36m, "Amazon.co.uk*M70LL", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 11, 27), 11.6m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Dez 2020
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 07), 102.67m, "PLUGIN ALLIANCE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 07), 146.11m, "SHOP.LINE6.COM", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 08), 57.2m, "WWW.GEAR4MUSIC.COM", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 14), 119m, "HARVEY NORMAN", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 17), 213.61m, "PAYPAL *ZWILLINGJH", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 17), 153.16m, "PP*GOOGLE MASTERCL", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 18), 321.38m, "DELL PRODUCTS", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 21), 323.24m, "PAYPAL *APPLE STOR", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 21), 361.79m, "PAYPAL *AUTONOMOUS", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 22), 7m, "LATE PAYMENT FEE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2020, 12, 24), 40.61m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Jan 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 01, 18), 259.57m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 01, 27), 33.53m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Feb 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 02, 18), 57.8m, "PAYPAL *SSL", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 02, 22), 503.49m, "PAYPAL *GAMESTOPLT", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 02, 26), 20.56m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Mar 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 03, 03), 82.28m, "CKO*www.autonomous", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 03, 03), 325.61m, "CKO*www.autonomous", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 03, 04), 180m, "CKO*www.autonomous", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 03, 19), 1m, "PAYPAL *PPGFIRE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 03, 22), 2854.20m, "PAYPAL *THOMANN", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 03, 26), 12.99m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Apr 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 04, 06), 30m, "GOVERNMENT STAMP D", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 04, 27), 39.38m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 04, 30), 1093.00m, "APPLE.COM/IE", creditCard.Id),
            
            // May 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 05, 05), 26.66m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 05, 10), 337.03m, "PAYPAL *APPLE STOR", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 05, 24), 7m, "LATE PAYMENT FEE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 05, 27), 22.46m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Jun 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 06, 14), 1118.00m, "PAYPAL *IKEA IE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 06, 16), 158.91m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 06, 17), 1886.50m, "PAYPAL *GEAR4MUSIC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 06, 25), 2.21m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 06, 28), 85.95m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            
            // Jul 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 07, 27), 30.77m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 07, 28), 1m, "PAYPAL *PPGFIRE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 07, 29), 622m, "PAYPAL *THOMANN", creditCard.Id),
            
            // Aug 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 08, 18), 996.49m, "TAP AIRLINE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 08, 25), 26.29m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 08, 27), 15.42m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Sep 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 01), 294.7m, "PAYPAL *NUZZIE LLC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 06), 379m, "PAYPAL *TOONTRACKM", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 06), 318m, "PAYPAL *TOONTRACKM", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 06), 322.87m, "PAYPAL *SYNTHOGY", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 14), 779.37m, "PAYPAL *GEAR4MUSIC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 14), 393.6m, "Amazon.co.uk*UN8NL", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 27), 2738.00m, "COMPU B", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 09, 27), 3.1m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Oct 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 10, 04), 298.09m, "PAYPAL *POSITIVEGD", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 10, 06), 359m, "PAYPAL *TOONTRACKM", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 10, 08), 631.58m, "PAYPAL *IRIJULE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 10, 12), 245.99m, "PAYPAL *IKMULTIMED", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 10, 18), 306.66m, "PAYPAL *PLUGINBOUT", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 10, 22), 7m, "LATE PAYMENT FEE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 10, 27), 22.96m, "INTEREST ON PURCHA", creditCard.Id),
            
            // Nov 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 11, 18), 273.58m, "PAYPAL *HSC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 11, 26), 31.14m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 11, 30), 189.36m, "PAYPAL *PLUGINBOUT", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 11, 30), 288.26m, "PAYPAL *PLUGINBOUT", creditCard.Id),
            
            // Dez 2021
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 06), 113.43m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 06), 90.74m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 06), 90.98m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 10), 1740.85m, "AMZN Mktp UK*UT3I6", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 10), 7m, "OVERLIMIT FEE", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 17), 166.6m, "PP*GOOGLE MASTERCL", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 24), 19.91m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2021, 12, 29), 7m, "OVERLIMIT FEE", creditCard.Id),
            
            // Jan 2021
            CreditCardTransaction.CreateExpense(new DateTime(2022, 01, 17), 275.55m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 01, 20), 33.74m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 01, 27), 346.39m, "STUDIODESK", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 01, 27), 51.35m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 01, 28), 350m, "PAYPAL *STUDIODESK", creditCard.Id),
            
            // Feb 2021
            CreditCardTransaction.CreateExpense(new DateTime(2022, 02, 01), 622m, "PAYPAL *YOGIBO", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 02, 16), 297.95m, "PAYPAL *UNICORNWAV", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 02, 21), 342.87m, "AMZNMktplace", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 02, 21), 149m, "PAYPAL *CLEVERBRID", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 02, 22), 28.3m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 02, 25), 31.48m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 02, 28), 346.39m, "STUDIODESK", creditCard.Id),
            
            // Mar 2021
            CreditCardTransaction.CreateExpense(new DateTime(2022, 03, 10), 34.25m, "PAYPAL *PLUGNALLNC", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 03, 22), 893.43m, "PAYPAL *ENDOR AG", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 03, 25), 35.25m, "INTEREST ON PURCHA", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 03, 28), 639.97m, "PAYPAL *GAMESTOPLT", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 03, 28), 346.39m, "STUDIODESK", creditCard.Id),
            CreditCardTransaction.CreateExpense(new DateTime(2022, 03, 29), 81.64m, "PAYPAL *MICROSOFT", creditCard.Id)
        );
    }
}