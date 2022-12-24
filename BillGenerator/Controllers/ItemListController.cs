using BillGenerator.Data;
using BillGenerator.Models;
using BillGenerator.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace BillGenerator.Controllers
{

    public class ItemListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemListController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ItemList()
        {
            IEnumerable<Item> items = _context.Items;

            return View(items);
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        
        public IActionResult Create(Item item)
        {
            if(ModelState.IsValid)
            { 
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("ItemList");
            }
            return View(item);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==0||id==null)
            {
                return NotFound();
            }

            var item = _context.Items.Find(id);
            if(item==null)
            {
                return NotFound();
            }
            return View(item);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                _context.SaveChanges();
                return RedirectToAction("ItemList");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _context.Items.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var CategoryFromDb = _context.Items.Find(id);

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            _context.Items.Remove(CategoryFromDb);
            _context.SaveChanges();
            TempData["Success"] = "Category Deleted";
            return RedirectToAction("ItemList");
        }


    }
}
