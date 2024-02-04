using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;
using Warehouse.Service;

namespace Warehouse.Controllers
{
    public class ItemsController : Controller
    {
      
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
              return _itemService.GetAll() != null ? 
                          View(_itemService.GetAll()) :
                          Problem("Entity set 'DatabaseContext.Items'  is null.");
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _itemService.GetAll() == null)
            {
                return NotFound();
            }

            var item = _itemService.Get((int)id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            var model = new ItemForCreationDto();
            //model.ItemTypes = _context.ItemTypes.ToList();
            return View(model);
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemForCreationDto dto)
        {
            var item = new Item();
            item.Name = dto.Name;
            item.Description = dto.Description;
            item.ItemTypeId = dto.ItemTypeId;
            _itemService.Add(item);
            return RedirectToAction("Index");
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _itemService.GetAll() == null)
            {
                return NotFound();
            }

            var item =  _itemService.Get((int)id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _itemService.Update(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _itemService.GetAll() == null)
            {
                return NotFound();
            }

            var item =  _itemService.Get((int)id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_itemService.GetAll() == null)
            {
                return Problem("Entity set 'DatabaseContext.Items'  is null.");
            }
            var item = _itemService.Get((int)id);
            if (item != null)
            {
                _itemService.Delete(item);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          
          return (_itemService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
