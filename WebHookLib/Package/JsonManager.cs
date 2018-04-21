using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WebHookLib.Package
{
    internal class JsonManager
    {
        private static JsonManager _SingletonInstance { get; set; }

        public static JsonManager GetInstance
        {
            get
            {
                return _SingletonInstance != null ?
                     _SingletonInstance : new JsonManager();
            }
        }

        private object _LockObj { get; set; }

        private JsonManager()
        {
            _LockObj = new object();
        }

        public string Serialize(object obj)
        {
            var MemStream = new MemoryStream();
            
            lock (_LockObj)
            {
                try
                {
                    var Serializer = new DataContractJsonSerializer(obj.GetType());
                    Serializer.WriteObject(MemStream, obj);

                    return Encoding.UTF8.GetString(MemStream.ToArray());
                }
                catch
                {
                    return string.Empty;
                }
                finally
                {
                    MemStream?.Close();
                    MemStream?.Dispose();
                }
            }
        }
    }
}
