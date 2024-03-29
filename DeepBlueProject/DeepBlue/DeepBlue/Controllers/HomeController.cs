using AspNetCoreHero.ToastNotification.Abstractions;
using DeepBlue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DeepBlue.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;

        public HomeController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            string yEmail = Request.Form["yemail"].ToString();
            string msg = Request.Form["msg"].ToString();

            if (!string.IsNullOrEmpty(yEmail))
            {
                bool sent = SendEmailNotification.SendNotification(msg, yEmail, "");
                if (sent)
                {
                    _notyf.Success("Your Email Sent Successfully");
                }
                else
                {
                    _notyf.Error("occur error ,Please Try Again !");
                }
            }
            else
            {
                _notyf.Error("Please Entrt Your Email");
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}