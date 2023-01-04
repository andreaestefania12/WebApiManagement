﻿namespace WebApiManagement.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }    
        public string PhoneNumber { get; set; }
        public string RegistrationDate { get; set; }
        public string Status { get; set; }
    }
}
