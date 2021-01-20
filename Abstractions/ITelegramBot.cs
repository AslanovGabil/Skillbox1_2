using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Abstractions
{
    public interface ITelegramBot
    {
        void SendMessage(long id, string text);
    }
}
