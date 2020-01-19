using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaymentClient.Models;
using Newtonsoft.Json;
using System.Text;

namespace PaymentClient
{
    public class MakePaymentsModel : PageModel
    {
        public void OnGet()
        {

        }


        [BindProperty]

        public PaymentInformation paymentInformation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            HttpClient httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(paymentInformation), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:44382/api/payment", content);
           
            return RedirectToPage("../Index");
        }

    }
}