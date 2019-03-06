using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class GetAddressRequestHandler : IRequestHandler<GetAddressRequest, UpdateAddressRequest>
    {
        /// <summary>
        /// look up an address book entry based on request id.
        /// if we don't find one we will just create a new one to update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <history>
        ///     Raimone Brown   03/05/2019  created.
        /// </history>
        public async Task<UpdateAddressRequest> Handle(GetAddressRequest request, CancellationToken cancellationToken)
        {
            AddressBookEntry addressBookEntry = null; //holds the found address book entry
            UpdateAddressRequest retVal; //holds the address request to be returned
            Guid requestId; //holds the converted id string
                        
            //check to see if we have an id and items to search
            if (request != null && !string.IsNullOrEmpty(request.Id) && AddressDb.Addresses != null && AddressDb.Addresses.Count > 0)
            {
                //convert passed in id to guid then search list
                if (Guid.TryParse(request.Id, out requestId))
                    addressBookEntry = AddressDb.Addresses.Find(x => x.Id == requestId);
            }
                        
            if (addressBookEntry == null)
                addressBookEntry = AddressBookEntry.Create("", "", "", "");

            //populate our address book entry
            retVal = new UpdateAddressRequest
            {
                City = addressBookEntry.City,
                Id = request.Id.ToString(),
                Line1 = addressBookEntry.Line1,
                Line2 = addressBookEntry.Line2,
                PostalCode = addressBookEntry.PostalCode,
                State = addressBookEntry.State
            };

            return await Task.FromResult(retVal);
        }
    }
}
