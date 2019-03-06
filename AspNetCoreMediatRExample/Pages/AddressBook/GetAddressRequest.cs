using System;
using MediatR;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class GetAddressRequest : IRequest<UpdateAddressRequest>
    {
        public string Id { get; set; }

        public string Line1 { get; set; }
                
        public string Line2 { get; set; }
        
        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}
