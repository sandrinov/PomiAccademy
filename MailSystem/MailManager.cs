using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailEventArgs
    {
        public String From { get; set; }
        public String To { get; set; }
        public String Obj { get; set; }
        public String Body { get; set; }
    }

    public delegate void MailEventHandler(MailManager senderManager, MailEventArgs e);
    
    public class MailManager
    {
        public event MailEventHandler MailArrived;

        public void SimulateArrivingMail(String from, String to, String obj, String body)
        {
            MailEventArgs args = new MailEventArgs()
                { Body = body, From=from, Obj=obj, To=to };
            if (MailArrived != null )
            {
                MailArrived(this, args);
            }
        }
    }
}
