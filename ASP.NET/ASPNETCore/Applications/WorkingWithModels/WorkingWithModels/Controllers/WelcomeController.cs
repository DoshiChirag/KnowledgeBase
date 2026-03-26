using Microsoft.AspNetCore.Mvc;
using WorkingWithModels.Controllers;
using WorkingWithModels.Models;

namespace WorkingWithModels.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            MockData myData = new MockData();
            string name = myData.GetName();
            int num = myData.GetNumTimes();

            ViewData.Model = myData;

            return View(myData);
        }
    }
}
