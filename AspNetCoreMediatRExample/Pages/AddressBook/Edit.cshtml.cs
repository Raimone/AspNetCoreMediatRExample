using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreMediatRExample.Pages.AddressBook
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;
        private GetAddressRequest AddressRequest; 

        /// <summary>
        /// Instantiate our edit model
        /// </summary>
        /// <param name="mediator"></param>
        /// <history>
        ///     Raimone Brown   03/05/2019  created.
        /// </history>
        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

        /// <summary>
        /// get our address request to update
        /// </summary>
        /// <param name="id"></param>
        /// <history>
        ///     Raimone Brown   03/05/2019  added the call to get the address request
        /// </history>
        public async Task<ActionResult> OnGet(string id)
        {
            //create a address request with the passed in id
            AddressRequest = new GetAddressRequest { Id = id };
                        
            UpdateAddressRequest = await _mediator.Send(AddressRequest);

            return Page();
        }

        /// <summary>
        /// send the updated address
        /// </summary>
        /// <returns></returns>
        /// <history>
        ///     Raimone Brown   03/05/2019  added call to send the updated address request
        /// </history>
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _ = await _mediator.Send(UpdateAddressRequest);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}