using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class DigitalAccount
    {
        public DigitalAccount()
        {
            CreatedAt = DateTime.Now;
        }

        public string AccountName { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Card> Cards { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
