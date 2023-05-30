using Rideau.Data;
using Rideau.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rideau.Controllers
{
    public class LibrairieController : Controller
    {
        private RideauDAO _dao;

        public LibrairieController(RideauContext context)
        {
            _dao = new RideauDAO();
            _dao.Database = context;
        }
        // GET: Livre
        public async Task<IActionResult> Index()
        {
            return View(await _dao.GetLivre());
        }
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

            ViewData["image"] = id + ".png";

            return View(livreVO);
        }

        public async Task<IActionResult> Confirmation([Bind("Id,Livre_id,Prenom,Nom,Email,Adresse,Ville,CodePostal")] ClientVO clientVO)
        {
            
            if (ModelState.IsValid)
            {
                var livreVO = await _dao.GetLivreByID(clientVO.Livre_id);
                ViewData["livre_titre"] = livreVO.Titre;
                ViewData["livre_auteur"] = livreVO.Auteur;
                ViewData["livre_description"] = livreVO.Description;
                ViewData["livre_edition"] = livreVO.Edition;
                ViewData["livre_date"] = livreVO.DatePuplication;
                ViewData["num"] = ((_dao.CountClient()) + 1);

                _dao.AddClient(clientVO);
                await _dao.Database.SaveChangesAsync();
                return View(clientVO);
            }
            return NotFound();
        }

        // GET: Client/Create
        public IActionResult Formulaire(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  _dao.GetClientByID(id);

            if (client == null)
            {
                return NotFound();
            }

            ViewData["id_client_achat"] = id;
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Formulaire([Bind("Id,Livre_id,Prenom,Nom,Email,Adresse,Ville,CodePostal")] ClientVO clientVO)
        {
            if (ModelState.IsValid)
            {
                _dao.AddClient(clientVO);
                //await _dao.Database.SaveChangesAsync();
                return RedirectToAction(nameof(Confirmation));
            }
            return View(clientVO);
        }

    }
}
