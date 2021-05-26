using System;
using System.Collections.Generic;
using System.Text;

namespace LegacyApp
{
    public class User
    {
        public Client Client { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public bool HasCredtLimit { get; set; }
        public int CreditLimit { get; set; }
    }
}
