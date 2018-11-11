using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationTemplateManager.Models
{
    public class NotificationTemplate
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsInactive { get; set; }
    }
}
