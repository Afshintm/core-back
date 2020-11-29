using System;

namespace WebapiMed.Models
{
    public class GoodmentsConfig
    {
        public string Username { get; set; } = "";
        public Guid PayerId { get; set; }
        public Guid RecipientId { get; set; }
    }
}