using System.IO;
using System.Net;
using System.Text;

namespace WebHookLib.Package
{
    internal class HttpManager
    {
        private static HttpManager _SingletonInstance;

        public static HttpManager GetInstance
        {
            get
            {
                return _SingletonInstance != null ?
                    _SingletonInstance : new HttpManager();
            }
        }

        private HttpManager()
        {
            _SingletonInstance = this;
        }


        public void HttpPostRequest(string postData, string url)
        {
            WebRequest WebReq = null;
            byte[] PostDataBytes = Encoding.UTF8.GetBytes(postData);
            SetPostParameter(out WebReq, PostDataBytes, url);
            PostRequest(ref WebReq, PostDataBytes);
        }
        
        private void SetPostParameter(out WebRequest webReq, byte[] postDataBytes, string url)
        {
            webReq = null;

            try
            {
                webReq = WebRequest.Create(url);
                webReq.Method = "POST";
                webReq.ContentType = "application/json";
                webReq.ContentLength = postDataBytes.Length;

                return;
            }
            catch
            {

            }
        }

        private void PostRequest(ref WebRequest webReq, byte[] postDataBytes)
        {
            Stream resStream = Stream.Null;

            try
            {
                resStream = webReq.GetRequestStream();
                resStream.Write(postDataBytes, 0, postDataBytes.Length);

                return;
            }
            catch
            {

            }
            finally
            {
                resStream?.Close();
                resStream?.Dispose();
            }
        }
    }
}
