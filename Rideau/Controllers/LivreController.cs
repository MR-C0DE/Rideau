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
    public class LivreController : Controller
    {
       
        private RideauDAO _dao;

        public LivreController(RideauContext context)
        {
 
            _dao = new RideauDAO();
            _dao.Database = context;
        }

        // GET: Livre
        public async Task<IActionResult> Index()
        {
            return View( await _dao.GetLivre());
        }

        // GET: Livre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livreVO = await _dao.GetLivreByID(id);

            if (livreVO == null)
            {
                return NotFound();
            }

            return View(livreVO);
        }

        // GET: Livre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Auteur,Description,Edition,DatePuplication")] LivreVO livreVO)
        {
            if (ModelState.IsValid)
            {
                _dao.AddLivre(livreVO);
                await _dao.Database.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livreVO);
        }

        // GET: Livre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livreVO = await _dao.GetLivreByID(id);
            if (livreVO == null)
            {
                return NotFound();
            }
            return View(livreVO);
        }

        // POST: Livre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Auteur,Description,Edition,DatePuplication")] LivreVO livreVO)
        {
            if (id != livreVO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dao.UpdateLivre(livreVO);
                    await _dao.Database.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreVOExists(livreVO.Id))
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
            return View(livreVO);
        }

        // GET: Livre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livreVO = await _dao.GetLivreByID(id);
            if (livreVO == null)
            {
                return NotFound();
            }

            return View(livreVO);
        }

        // POST: Livre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livreVO = await _dao.FindLivreById(id);
            _dao.SupprimeLivre(livreVO);
            await _dao.Database.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivreVOExists(int id)
        {
            return _dao.LivreExiste(id);
        }
    }
}
