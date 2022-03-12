using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    //Rehber proporty'leri
    public class Contact
    {
        private string firstName;
        private string lastName;
        private string phoneNo;

        public string FirstName { get => firstName; set => firstName = value; }

        public string LastName { get => lastName; set => lastName = value; }

        public string PhoneNo { get => phoneNo; set => phoneNo = value; }


        public Contact(string firstName, string lastName, string phoneNo)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNo = phoneNo;
        }

        public Contact() { }
    }
}
