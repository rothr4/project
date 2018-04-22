namespace WebHookLib.Package.Mattermost.DataTemplete
{
    interface IDataPostTemplete
    {
        object GetJsonObject(string message);
    }
}
