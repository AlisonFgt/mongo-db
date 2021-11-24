using Domain.Model;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MongoController : ControllerBase
    {
        private readonly IMongoRepository<Car> _carMongoRepository;
        private readonly IMongoRepository<User> _userMongoRepository;

        public MongoController(IMongoRepository<User> userMongoRepository, IMongoRepository<Car> carMongoRepository)
        {
            _userMongoRepository = userMongoRepository;
            _carMongoRepository = carMongoRepository;
        }

        [HttpGet("GetUser/{id}")]
        public User GetUser(int id)
        {
            var user = _userMongoRepository.FilterBy(filter => filter.Uuid.Equals(id.ToString())).FirstOrDefault();
            return user;
        }

        [HttpPost("InsertDefaultUser")]
        public void InsertDefaultUser()
        {
            User user = CreateUser(0);
            _userMongoRepository.InsertOne(user);
        }

        [HttpPost("InsertDefaultCar/{cor}")]
        public void InsertDefaultCar(string cor)
        {
            Car car = new Car { Cor = cor , Portas = 4 };
            _carMongoRepository.InsertOne(car);
        }

        [HttpPost("InsertData/{id}")]
        public void InsertDataId(int id)
        {
            User user = CreateUser(id);
            _userMongoRepository.InsertOne(user);
        }

        [HttpPost("InsertManyUsers/{qtd}")]
        public object InsertManyValues(int qtd)
        {
            var listUsers = new List<User>();

            if (qtd == 0)
                qtd = 1;

            for (int i = 1; i < qtd; i++)
            {
                listUsers.Add(CreateUser(i));
            }

            _userMongoRepository.InsertMany(listUsers);

            return Ok("DONE");
        }

        [HttpGet("GetDocuments/{collection}")]
        public object GetCollection(string collection)
        {
            if (collection.ToLower().Equals("user"))
            {
                return _userMongoRepository.FilterBy(filter => filter.FirstName != null).ToList();
            }                
            else if (collection.ToLower().Equals("car"))
            {
                return _carMongoRepository.FilterBy(filter => filter.Cor != null).ToList();
            }                

            return BadRequest("COLLECTION_NOT_FOUND");
        }

        private User CreateUser(int id)
        {
            List<Phone> phones = CreatePhones();

            var address = new List<Address>();
            address.Add(new Address
            {
                AddressLine = "Rua Canaos",
                AddressComplement = "Apartamento 401",
                City = "Canoas",
                Country = "Brasil",
                Number = 99
            });

            List<Card> cards = CreateCards();

            var digitalAccounts = new List<DigitalAccount>();
            digitalAccounts.Add(new DigitalAccount
            {
                AccountName = "DBServer Account",
                Description = "Workshop",
                Active = true,
                Cards = cards
            });

            string nome = "Alison";

            if (id > 0)
                nome = nome + " - " + id.ToString();

            return new User
            {
                FirstName = nome,
                Uuid = id.ToString(),
                LastName = "Alves",
                Phones = phones,
                BirthDate = new DateTime(1989, 10, 10),
                Addresses = address,
                DigitalAccounts = digitalAccounts
            };
        }

        private static List<Card> CreateCards()
        {
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

            return cards;
        }

        private static List<Phone> CreatePhones()
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

            return phones;
        }
    }
}
