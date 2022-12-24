using BillGenerator.Data;
using BillGenerator.Models;
using BillGenerator.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BillGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context = null)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public IActionResult Create()
        {
           
            var vm = new BillViewModel();
            vm.ItemList = _context.Items.ToList().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()                
            }).ToList();


            return View(vm);
        }



        public IActionResult Allitems()
        {
            var items = _context.Items.ToList();
            return new JsonResult(items);
        }


        //[HttpGet]
        //ItemsV
        public JsonResult getUnitPrice(int id)
        {
            var data = _context.Items.Where(x => x.Id == id).Select(x=>new Item()
            {
                Id=x.Id,
                Name=x.Name,
                Price=x.Price

            }).SingleOrDefault();
                return Json(data.Price);
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //    public IActionResult Error()
        //    {
        //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
    }
}