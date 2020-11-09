using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpJakob
{
    class Controller
    {
        public Controller()
        {

            Main();

        }

        public void Main()
        {
            //Create object reference to MessgeSender in order to access SendMessage method 
            MessageSender ms = new MessageSender();

            //Create object of Message
            Message message1 = new Message("Mads", "Mads", "Hello Mads", "Hej Mads", "Mads.mp3");

            //Call SendMessage object with MessageCarrier type, the MessageObject and a booleon of weather or not it is html
            ms.SendMessage(MessageCarrier.Smtp, message1, true);


        }

        
    }
}
