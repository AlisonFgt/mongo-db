using Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class User : Document
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public IEnumerable<Address> Addresses { get; set; }

        public IEnumerable<Phone> Phones { get; set; }

        public IEnumerable<DigitalAccount> DigitalAccounts { get; set; }
    }
}
