using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.implementation.Models
{
    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }



        //[JsonConstructor]
        //public Customer(int id, string name, string email, string address, int contact, string dob, string gender)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Email = email;
        //    this.Address = address;
        //    this.Contact = contact;
        //    this.Dob = dob;
        //    this.Gender = gender;
        //}

        //public Customer(string name, string email, string address, int contact, string dob, string gender)
        //{
        //    this.Name = name;
        //    this.Email = email;
        //    this.Address = address;
        //    this.Contact = contact;
        //    this.Dob = dob;
        //    this.Gender = gender;
        //}


    }
}
