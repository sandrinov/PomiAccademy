using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class Fax
    {
        private MailManager _mailManager;
        public Fax(MailManager mailManager)
        {
            _mailManager = mailManager;
            MailEventHandler eh = new MailEventHandler(this.MailArrived_EventHandler);
            _mailManager.MailArrived += eh;
        }

        public void MailArrived_EventHandler (MailManager senderManager, MailEventArgs e)
        {
            Console.WriteLine("Fax mail arrived: ");
            Console.WriteLine("From "+ e.From);
            Console.WriteLine("To " + e.To);
            Console.WriteLine("Object " + e.Obj);
            Console.WriteLine("Body " + e.Body);
        }
    }
}
