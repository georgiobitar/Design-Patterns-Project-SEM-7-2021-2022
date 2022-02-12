using AdminWeb.Models;
using Infrastructure.Model.DataContracts.Requests;
using Infrastructure.Model.DataContracts.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flurl.Http;
using Infrastructure.Model.Requests;
using Infrastructure.Model.Responses;

namespace AdminWeb.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AdminViewModel adminViewModel)
        {
            if(ModelState.IsValid)
            {
                SignUpRequestDTO signUpRequest = new SignUpRequestDTO()
                {
                    UserName = adminViewModel.UserName,
                    FirstName = adminViewModel.FirstName,
                    LastName = adminViewModel.LastName,
                    Email = adminViewModel.Email,
                    PhoneNumber = adminViewModel.PhoneNumber,
                    Country = adminViewModel.Country,
                    Password = adminViewModel.Password
                };
                SignUpResponseDTO response = await (ServiceEndpoints.Endpoint + "/Authentication/SignUpAdmin").PostJsonAsync(signUpRequest).ReceiveJson<SignUpResponseDTO>();
                ModelState.AddModelError(string.Empty, response.Message);
                return View();
            }

            return View();
        }
    }
}
