﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebHookLib.Package;
using WebHookLib.Package.Mattermost.DataTemplete;

namespace WebHookLib
{
    public class MattermostAPI
    {
        private static MattermostAPI _SingletonInstance;

        public static MattermostAPI GetInstance(string serverUrl)
        {
            return _SingletonInstance != null ?
                _SingletonInstance
                : new MattermostAPI(serverUrl);
        }

        public static MattermostAPI GetInstance(string serverUrl, int serverPort)
        {
            return _SingletonInstance != null ?
                _SingletonInstance
                : new MattermostAPI(serverUrl, serverPort);
        }

        private MattermostAPI(string serverUrl)
        {
            this.ServerURL = serverUrl;
            this.ServerPort = 0;
            _SingletonInstance = this;
        }

        private MattermostAPI(string serverUrl, int serverPort)
        {
            this.ServerURL = serverUrl;
            this.ServerPort = serverPort;
            _SingletonInstance = this;
        }



        public string ServerURL { get; private set; }

        public int ServerPort { get; private set; }
        

        public void IncomingWebHook(string botName, string contents, string webHookId)
        {
            var PostObj = new SendBotMessage();
            string PostData = JsonManager.GetInstance.Serialize(PostObj.GetObject(botName, contents));
            string RoomURL = string.Format("{0}hooks/{1}", GetAppServerURL(), webHookId);

            HttpManager.GetInstance.HttpPostRequest(PostData, RoomURL);
        }

        public void IncomingWebHook(string botName, string contents, string webHookId, string iconUrl)
        {
            var PostObj = new SendBotMessage();
            string PostData = JsonManager.GetInstance.Serialize(PostObj.GetObject(botName, contents, iconUrl));
            string RoomURL = string.Format("{0}hooks/{1}", GetAppServerURL(), webHookId);

            HttpManager.GetInstance.HttpPostRequest(PostData, RoomURL);
        }




        private string GetAppServerURL()
        {
            return this.ServerPort == 0 ?
                this.ServerURL
                : string.Format("{0}:{1}/", this.ServerURL, this.ServerPort.ToString());
        }
    }
}