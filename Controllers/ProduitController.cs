using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalogue_Produit_App.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Produit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutProduit()
        {
            try
            {
                return View();
            }catch(Exception e)
            {
                return HttpNotFound();
            }
        }
    }
}