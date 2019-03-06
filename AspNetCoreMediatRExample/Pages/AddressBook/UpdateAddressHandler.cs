using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequest, ActionMessage>
    {
        public async Task<ActionMessage> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            int entryToUpdateIndex = -1; //holds the index of the entry to update
            Guid requestId; //holds the converted id string
            ActionMessage retVal;

            //convert id to guid then search list
            if (request != null && Guid.TryParse(request.Id, out requestId))
                entryToUpdateIndex = AddressDb.Addresses.FindIndex(x => x.Id == requestId);

            //update item
            if (entryToUpdateIndex > -1)
            {
                AddressDb.Addresses[entryToUpdateIndex].City = request.City;
                AddressDb.Addresses[entryToUpdateIndex].Line1 = request.Line1;
                AddressDb.Addresses[entryToUpdateIndex].Line2 = request.Line2;
                AddressDb.Addresses[entryToUpdateIndex].PostalCode = request.PostalCode;
                AddressDb.Addresses[entryToUpdateIndex].State = request.State;

                retVal = ActionMessage.Success;
            }
            else
                retVal = ActionMessage.Failed;

            return await Task.FromResult(retVal);
        }
    }
}
