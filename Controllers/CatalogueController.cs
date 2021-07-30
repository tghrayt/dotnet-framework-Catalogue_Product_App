﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalogue_Produit_App.Models;

namespace Catalogue_Produit_App.Controllers
{
    public class CatalogueController : Controller
       
    {
        CatalogueProduitEntities db = new CatalogueProduitEntities();
        // GET: Catalogue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutCatalogue()
        {
            try
            {
                ViewBag.listeCategorie = db.CAT_CATEGORIE.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AjoutCatalogue(CAT_CATEGORIE categorie)//enregistrement
        {
            try
            {

                if (ModelState.IsValid)
                {
                    categorie.DATE_SAISIE = DateTime.Now;
                    db.CAT_CATEGORIE.Add(categorie);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutCatalogue");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerCatalogue(int id)
        {
            try
            {
                CAT_CATEGORIE categorie = db.CAT_CATEGORIE.Find(id); //recherchede la categorie
                if (categorie != null)
                {
                    db.CAT_CATEGORIE.Remove(categorie); //supprimer la categorie
                    db.SaveChanges();//enregistrer le resultat
                }
                return RedirectToAction("AjoutCatalogue");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult ModifierCatalogue(int id)
        {
            try
            {
                ViewBag.listeCategorie = db.CAT_CATEGORIE.ToList();
                CAT_CATEGORIE categorie = db.CAT_CATEGORIE.Find(id);
                if (categorie != null)
                {
                    return View("AjoutCatalogue", categorie);
                }
                return RedirectToAction("AjoutCatalogue");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ModifierCatalogue(CAT_CATEGORIE categorie)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    
                    db.Entry(categorie).State = EntityState.Modified; // modification de notre categorie
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutCatalogue");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }


    }
}