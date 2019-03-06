using System;
using System.Collections.Generic;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public enum ActionMessage
    {
        Failed = 0,
        Success = 1
    }

    public static class AddressDb
    {
        public static List<AddressBookEntry> Addresses { get; set; } = new List<AddressBookEntry>();
    }

    public class AddressBookEntry
    {
        private AddressBookEntry(string line1, string city, string state, string postalCode)
        {
            Id = Guid.NewGuid();
            Line1 = line1;
            Line2 = Line2;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        private AddressBookEntry(string line1, string line2, string city, string state, string postalCode)
            : this(line1, city, state, postalCode) =>
            Line2 = line2;

        public Guid Id { get; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public static AddressBookEntry Create(string line1, string city, string state, string postalCode)
            => new AddressBookEntry(line1, city, state, postalCode);

        public static AddressBookEntry Create(string line1, string line2, string city, string state, string postalCode)
            => new AddressBookEntry(line1, line2, city, state, postalCode);
    }
}