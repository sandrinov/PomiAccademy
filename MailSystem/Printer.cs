using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class Printer
    {
        private MailManager _mailManager;
        public Printer(MailManager mailManager)
        {
            _mailManager = mailManager;
            _mailManager.MailArrived += _mailManager_MailArrived;
        }

        private void _mailManager_MailArrived(MailManager senderManager, MailEventArgs e)
        {
            Console.WriteLine("Printing mail arrived: ");
            Console.WriteLine("From " + e.From);
            Console.WriteLine("To " + e.To);
            Console.WriteLine("Object " + e.Obj);
            Console.WriteLine("Body " + e.Body);
        }
    }
}
