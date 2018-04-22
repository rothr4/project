using System.Runtime.Serialization;

namespace WebHookLib.Package.Mattermost.DataTemplete
{
    [DataContract]
    internal class PostMessageAddIcon : IDataPostTemplete
    {
        [DataMember]
        public string username { get; private set; }

        [DataMember]
        public string text { get; private set; }

        [DataMember]
        public string icon_url { get; private set; }


        public PostMessageAddIcon(string botName, string iconUrl)
        {
            this.username = botName;
            this.icon_url = iconUrl;
        }

        public object GetJsonObject(string message)
        {
            this.text = message;
            return this;
        }
    }
}
