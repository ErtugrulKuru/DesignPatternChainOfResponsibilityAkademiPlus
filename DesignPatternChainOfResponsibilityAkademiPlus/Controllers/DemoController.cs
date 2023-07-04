using Microsoft.AspNetCore.Mvc;

namespace DesignPatternChainOfResponsibilityAkademiPlus.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
