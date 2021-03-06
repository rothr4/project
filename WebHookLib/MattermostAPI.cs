﻿using WebHookLib.Package;
using WebHookLib.Package.Mattermost.DataTemplete;

namespace WebHookLib
{
    public class MattermostAPI
    {
        private static MattermostAPI _SingletonInstance;
        // シングルトン
        public static MattermostAPI GetInstance(string serverUrl)
        {
            return _SingletonInstance != null ?
                _SingletonInstance
                : new MattermostAPI(serverUrl);
        }

        // コンストラクタは非公開に
        private MattermostAPI(string serverUrl)
        {
            this.ServerURL = serverUrl;
            _SingletonInstance = this;
        }


        public string ServerURL { get; private set; }

        public void PostMessage(string botName, string contents, string webHookId)
        {
            var PostObj = new PostMessageDefault(botName);
            string PostData = JsonManager.GetInstance.Serialize(PostObj.GetJsonObject(contents));
            string RoomURL = string.Format("{0}hooks/{1}", ServerURL, webHookId);

            HttpManager.GetInstance.HttpPostRequest(PostData, RoomURL);
        }

        public void PostMessage(string botName, string contents, string webHookId, string iconUrl)
        {
            var PostObj = new PostMessageAddIcon(botName, iconUrl);
            string PostData = JsonManager.GetInstance.Serialize(PostObj.GetJsonObject(contents));
            string RoomURL = string.Format("{0}hooks/{1}", ServerURL, webHookId);

            HttpManager.GetInstance.HttpPostRequest(PostData, RoomURL);
        }

        public void PostMessage(MattermostBot bot, string contents)
        {
            string PostData = JsonManager.GetInstance.Serialize(bot.GetTest(contents));
            string RoomURL = string.Format("{0}hooks/{1}", ServerURL, bot.WebHookId);

            HttpManager.GetInstance.HttpPostRequest(PostData, RoomURL);
        }
    }
}
