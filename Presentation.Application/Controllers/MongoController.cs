using Domain.Model;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Presentation.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MongoController : ControllerBase
    {
        private readonly IMongoRepository<User> _userMongoRepository;

        public MongoController(IMongoRepository<User> userMongoRepository)
        {
            _userMongoRepository = userMongoRepository;
        }

        [HttpGet("GetUserData")]
        public IEnumerable<string> GetUserData()
        {
            var user = _userMongoRepository.FilterBy(
                filter => filter.FirstName != "teste",
                projection => projection.FirstName
            );

            return user;
        }

        [HttpGet("InsertData")]
        public void InsertData()
        {
            User user = CreateUser();

            _userMongoRepository.InsertOne(user);
        }

        private User CreateUser()
        {
            var phones = new List<Phone>();
            phones.Add(new Phone
            {
                Number = "999999999",
                DDD = "51",
                PhoneType = "Mobile"
            });
            phones.Add(new Phone
            {
                Number = "30554812",
                DDD = "51",
                PhoneType = "Residential"
            });

            var address = new List<Address>();
            address.Add(new Address
            {
                AddressLine = "Rua Canaos",
                AddressComplement = "Apartamento 401",
                City = "Canoas",
                Country = "Brasil",
                Number = 99
            });

            var cards = new List<Card>();
            cards.Add(new Card
            {
                Number = 545151515,
                CVC = 111,
                Digit = 5,
                Active = true,
                VirtualCard = false
            });

            cards.Add(new Card
            {
                Number = 333333333,
                CVC = 222,
                Digit = 8,
                Active = true,
                VirtualCard = true
            });

            var digitalAccounts = new List<DigitalAccount>();
            digitalAccounts.Add(new DigitalAccount
            {
                AccountName = "DBServer Account",
                Description = "Workshop",
                Active = true,
                Cards = cards
            });

            return new User
            {
                FirstName = "Alison",
                LastName = "Alves",
                Phones = phones,
                BirthDate = new DateTime(1989, 10, 10),
                Addresses = address,
                DigitalAccounts = digitalAccounts
            };
        }
    }
}
