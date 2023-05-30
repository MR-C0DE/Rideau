#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rideau.Data;
using Rideau.Models;

namespace Rideau.Controllers
{
    public class ClientController : Controller
    {
        private readonly RideauContext _context;
        private RideauDAO _dao;

        public ClientController(RideauContext context)
        {
            _dao = new RideauDAO();
            _dao.Database = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            return View(await _dao.GetClient());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientVO = await _dao.GetClientByID(id);
            if (clientVO == null)
            {
                return NotFound();
            }

            return View(clientVO);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Livre_id,Prenom,Nom,Email,Adresse,Ville,CodePostal")] ClientVO clientVO)
        {
            if (ModelState.IsValid)
            {
                _dao.AddClient(clientVO);
                await _dao.Database.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientVO);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientVO = await _dao.GetClientByID(id);
            if (clientVO == null)
            {
                return NotFound();
            }
            return View(clientVO);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Livre_id,Prenom,Nom,Email,Adresse,Ville,CodePostal")] ClientVO clientVO)
        {
            if (id != clientVO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dao.UpdateClient(clientVO);
                    await _dao.Database.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientVOExists(clientVO.Id))
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
            return View(clientVO);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientVO = await _dao.GetClientByID(id);
            if (clientVO == null)
            {
                return NotFound();
            }

            return View(clientVO);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientVO = await _dao.FindClientById(id);
            _dao.SupprimeClient(clientVO);
            await _dao.Database.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientVOExists(int id)
        {
            return _dao.ClientExiste(id);
        }
    }
}
