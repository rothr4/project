using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace WebHookLib.Package.Mattermost.DataTemplete
{
    [DataContract]
    internal class SendBotMessage
    {
        [DataMember]
        public string username { get; private set; }

        [DataMember]
        public string text { get; private set; }

        [DataMember]
        public string icon_url { get; private set; }

        public SendBotMessage GetObject(string botName, string contents)
        {
            this.username = botName;
            this.text = contents;
            this.icon_url = "";

            return this;
        }

        public SendBotMessage GetObject(string botName, string contents, string iconUrl)
        {
            this.username = botName;
            this.text = contents;
            this.icon_url = iconUrl;

            return this;
        }
    }
}
