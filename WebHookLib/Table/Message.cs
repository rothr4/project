using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHookLib.Table
{
    public enum MessageLevel
    {
        INFO,
        WARING,
        ERROR
    }

    internal abstract class Message
    {
        public abstract int Id { get; }

        public abstract string Text { get; }

        public abstract MessageLevel Level { get; }
    }
}
