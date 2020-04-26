using System;
using DeltaTre.Domain.Contacts.Events;
using DeltaTre.Domain.Seedwork;
using Newtonsoft.Json;

namespace DeltaTre.Domain.Contacts
{
    public class Contact : Entity
    {
        public string Email { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        [JsonConstructor]
        private Contact()
        {
        }

        public Contact(
            string email, 
            string firstname,
            string lastname) 
        {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;

            Emit(new ContactCreatedEvent(Id));
        }

        public void SetEmail(string email)
        {
            Email = email;
            Emit(new ContactEmailUpdatedEvent(Id, email));
        }

    }
}