namespace MailSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MailManager mm = new MailManager();
            Fax fax = new Fax(mm);
            Printer prn = new Printer(mm);

            mm.SimulateArrivingMail("Topolino", "Minni", "Cena", "Usciamo stasera");
            mm.SimulateArrivingMail("Minni", "Topolino", "Cena", "No, esco con Pippo");
        }
    }
}
