using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Models
{
    public class Message
    {
        public string DateTime { get; set; } = $"{System.DateTime.Now.DayOfWeek.ToString()} {System.DateTime.Now.ToString()}";
        public string Text { get; set; }
        public bool IsMy { get; set; }
    }
}
