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

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public ICollection<DigitalAccount> DigitalAccounts { get; set; }

        //public bool Active { get; set; }
    }
}
