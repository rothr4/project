using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebHookLib.Table.CodeResultMessage
{
    internal abstract class CodeResultInfo : Message
    {
        public override MessageLevel Level => MessageLevel.INFO;
    }
}
