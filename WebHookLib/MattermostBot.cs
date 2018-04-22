using WebHookLib.Package.Mattermost.DataTemplete;

namespace WebHookLib
{
    public class MattermostBot
    {
        private IDataPostTemplete ObjTemp { get; set; }

        public string WebHookId { get; private set; }
        

        public MattermostBot(string botName, string webHookId)
        {
            ObjTemp = new PostMessageDefault(botName);
            this.WebHookId = webHookId;
        }

        public MattermostBot(string botName, string webHookId, string iconUrl)
        {
            ObjTemp = new PostMessageAddIcon(botName, iconUrl);
            this.WebHookId = webHookId;
        }

        public object GetTest(string message)
        {
            return ObjTemp.GetJsonObject(message);
        }
    }
}
