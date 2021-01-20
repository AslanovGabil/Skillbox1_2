using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Models
{
    public class Chat
    {
        public User User { get; set; } = new User();
        public int CountNewMessage { get; set; } = 0;
        public DateTime TimeNewMessage { get; set; }
        public string Path { get; set; }
        // public List<Message> Messages { get; set; }
    }
}
