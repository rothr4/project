using WebHookLib.Package.Mattermost.DataTemplete;

namespace WebHookLib
{
    public class MattermostBot
    {
        public string BotName { get; private set; }
        public string WebHookId { get; private set; }
        public string IconUrl { get; private set; }
        private IDataPostTemplete ObjTemp { get; set; }

        public MattermostBot(string name, string webHookId)
        {
            this.BotName = name;
            this.WebHookId = webHookId;
            this.IconUrl = string.Empty;
            ObjTemp = new PostMessageDefault(BotName);
        }

        public MattermostBot(string name, string webHookId, string iconUrl)
        {
            this.BotName = name;
            this.WebHookId = webHookId;
            this.IconUrl = iconUrl;
            ObjTemp = new PostMessageAddIcon(BotName, iconUrl);
        }

        public object GetTest(string message)
        {
            return ObjTemp.GetJsonObject(message);
        }
    }
}
