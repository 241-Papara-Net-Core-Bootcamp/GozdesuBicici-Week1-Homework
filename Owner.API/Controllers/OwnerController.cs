using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        private List<OwnerModel> owners = new List<OwnerModel>();
        OwnerModel owner1 = new OwnerModel
        {
            ID = 1,
            FirstName = "Gözdesu",
            LastName = "Biçici",
            Date = DateTime.Now,
            Description = "Papara .Net Core Eğitim Öğrencisi",
            Type = "Mezun",
        };

        OwnerModel owner2 = new OwnerModel
        {
            ID = 2,
            FirstName = "Damla",
            LastName = "Çopur",
            Date = DateTime.Now,
            Description = "Tarih",
            Type = "Mezun",
        };

        OwnerModel owner3 = new OwnerModel
        {
            ID = 3,
            FirstName = "Yiğit",
            LastName = "Biçici",
            Date = DateTime.Now,
            Description = "Mühendis",
            Type = "Mezun",
        };



        [Route("Details")]
        [HttpGet]
        public List<OwnerModel> GetOwnerDetails()
        {
            owners.Add(owner1);
            owners.Add(owner2);
            owners.Add(owner3);

            return owners;
        }

        [HttpPost]
        public OwnerModel Post([FromBody] OwnerModel owner)
        {
          
                owners.Add(owner);
                return owner;
            

        }

        [HttpPut]
        public OwnerModel EditOwner([FromBody] OwnerModel owner)
        {
            var editedOwner = owners.FirstOrDefault(x => x.ID == owner.ID);
            editedOwner.FirstName = owner.FirstName;
            editedOwner.LastName = owner.LastName;
            editedOwner.Date = owner.Date;
            editedOwner.Description = owner.Description;
            editedOwner.Type = owner.Type;

            return owner;
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            var deletedOwner = owners.FirstOrDefault(x => x.ID == id);
            owners.Remove(deletedOwner);
        }
    }
}
