using System.Runtime.Serialization;

namespace WebHookLib.Package.Mattermost.DataTemplete
{
    [DataContract]
    internal class PostMessageDefault : IDataPostTemplete
    {
        [DataMember]
        public string username { get; private set; }

        [DataMember]
        public string text { get; private set; }


        public PostMessageDefault(string botName)
        {
            this.username = botName;
        }

        public object GetJsonObject(string message)
        {
            this.text = message;
            return this;
        }
    }
}
