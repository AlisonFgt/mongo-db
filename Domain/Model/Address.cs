using System;

namespace Domain.Model
{
    public class Address
    {
        public Address()
        {
            CreatedAt = DateTime.Now;
        }

        public string AddressLine { get; set; }

        public string AddressComplement { get; set; }

        public long Number { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
