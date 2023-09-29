using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_system.Models
{
    public class Customer
    {
        private int id;
        private string name;
        private string email;
        private string address;
        private int contact;
        private string dob;
        private string gender;

        public Customer(int id, string name, string email, string address, int contact, string dob, string gender)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.address = address;
            this.contact = contact;
            this.dob = dob;
            this.gender = gender;
        }

        public Customer(string name, string email, string address, int contact, string dob, string gender)
        {
            this.name = name;
            this.email = email;
            this.address = address;
            this.contact = contact;
            this.dob = dob;
            this.gender = gender;
        }

        public int GetID() { return id; }
        public string GetName() { return name; }
        public string GetEmail() { return email; }
        public string GetAddress() { return address; }
        public int GetContact() { return contact; }
        public string GetDate() { return dob; }
        public string GetGender() { return gender; }
    }

}
