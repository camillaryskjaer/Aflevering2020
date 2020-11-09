using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpJakob
{
    //This class is responsible of sending a message.
    class MessageSender
    {
        //Create object reference to MEssageConverter.
        MessageConverter mc = new MessageConverter();

        //Sends a message to one person
        public void SendMessage(MessageCarrier type, Message m, bool isHTML)
        {
            //herinde sendes der en email ud til modtageren
            if (type.Equals(MessageCarrier.Smtp))
            {
                SendWithSMTP(m, isHTML);
            }
            else if (type.Equals(MessageCarrier.VMessage))
            {
                SendWithVMessage(m, isHTML);
            }
        }

        //Sends a messsage to multiple people
        public void SendMessageToAll(MessageCarrier type, string[] to, Message m, bool isHTML)
        {
            if (type.Equals(MessageCarrier.Smtp))
            {
                SendWithSMTP(m, isHTML);

            }
            else if (type.Equals(MessageCarrier.VMessage))
            {
                SendWithVMessage(m, isHTML);
            }
        }


        //Sends a message with SMTP
        public void SendWithSMTP(Message m, bool isHTML)
        {
            if (isHTML)
                m.Body = mc.ConvertBodyToHTML(m.Body);
            //her implementeres alt koden til at sende via Smtp
        }

        //Sends a message with Vmessage
        public void SendWithVMessage(Message m, bool isHTML)
        {
            if (isHTML)
                m.Body = mc.ConvertBodyToHTML(m.Body);
            //her implementeres alt koden til at sende via VMessage
        }

        
    }
}
