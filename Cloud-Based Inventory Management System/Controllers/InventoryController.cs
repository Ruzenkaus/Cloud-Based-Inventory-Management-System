using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cloud_Based_Inventory_Management_System.Contexts;
using Cloud_Based_Inventory_Management_System.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Cloud_Based_Inventory_Management_System.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryContext _context;
        private readonly UserContext _userContext;
        public InventoryController(InventoryContext context, UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        // GET: Inventor
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var ownerName = User.Identity.Name;
            var userInventories = await _context.Inventories.Where(i=>i.Owner == ownerName).ToListAsync();
            return View(userInventories);
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryModel = await _context.Inventories
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventoryModel == null)
            {
                return NotFound();
            }

            return View(inventoryModel);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryId,ProductId,Quantity")] InventoryModel inventoryModel)
        {
            var ownerName = User.Identity.Name;
            var newInventory = new InventoryModel { Owner = ownerName, ProductId = inventoryModel.ProductId, Quantity = inventoryModel.Quantity };

          
            _context.Add(newInventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }


        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryModel = await _context.Inventories.FindAsync(id);
            if (inventoryModel == null)
            {
                return NotFound();
            }
            return View(inventoryModel);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryId,Owner,ProductId,Quantity,LastUpdated")] InventoryModel inventoryModel)
        {
            if (id != inventoryModel.InventoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryModelExists(inventoryModel.InventoryId))
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
            return View(inventoryModel);
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryModel = await _context.Inventories
                .FirstOrDefaultAsync(m => m.InventoryId == id);
            if (inventoryModel == null)
            {
                return NotFound();
            }

            return View(inventoryModel);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventoryModel = await _context.Inventories.FindAsync(id);
            if (inventoryModel != null)
            {
                _context.Inventories.Remove(inventoryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryModelExists(int id)
        {
            return _context.Inventories.Any(e => e.InventoryId == id);
        }
    }
}
