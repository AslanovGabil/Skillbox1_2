using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Models
{
    public class Contact
    { 
        public User User { get; set; }
        public int CountNewMessage { get; set; }
        public DateTime TimeNewMessage { get; set; }
    }
}
