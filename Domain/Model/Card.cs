using System;

namespace Domain.Model
{
    public class Card
    {
        public Card()
        {
            CreatedAt = DateTime.Now;
        }

        public long Number { get; set; }

        public int Digit { get; set; }

        public int CVC { get; set; }

        public bool VirtualCard { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
