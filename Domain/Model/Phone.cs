using System;

namespace Domain.Model
{
    public class Phone
    {
        public Phone()
        {
            CreatedAt = DateTime.Now;
        }

        public string PhoneType { get; set; }

        public string Number { get; set; }

        public string DDD { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
