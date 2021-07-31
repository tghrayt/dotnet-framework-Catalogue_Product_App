using Catalogue_Produit_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogue_Produit_App.Controllers
{
    public class HomeController : Controller
    {
        CatalogueProduitEntities db = new CatalogueProduitEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.listeCategorie = db.CAT_CATEGORIE.ToList().OrderBy(r => r.LIBELLE_CATEGORIE); //la liste des categories rangée par ordre alphabetique
            return View();
        }
    }
}
