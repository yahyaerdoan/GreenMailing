using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GreenMailing.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public string? Sender { get; set; }
        public string? Recever { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Status { get; set; }
        public bool IsRead { get; set; }
        public bool IsTrash { get; set; }
        public bool IsImportant { get; set; }
        public bool IsStarred { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
