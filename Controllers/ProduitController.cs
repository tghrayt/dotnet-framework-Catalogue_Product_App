using Catalogue_Produit_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catalogue_Produit_App.Helper;
using Catalogue_Produit_App.DTO;
using Catalogue_Produit_App.Service;

namespace Catalogue_Produit_App.Controllers
{
    public class ProduitController : Controller
    {

        ProduitController()
        {

        }

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));  //Declaring Log4Net 


        private readonly IProduitService _produitService;
        private readonly ICategorieService _categorieService;
        public ProduitController(IProduitService produitService , ICategorieService categorieService) {

            _produitService = produitService;
            _categorieService = categorieService;
        }
        CatalogueProduitEntities db = new CatalogueProduitEntities();
        ProduitHelper _produitHelper = new ProduitHelper();






        // GET: Produit
        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult Index()
        {

            try
            {
                LogHelper.Info("Products Page started...");
                return View();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return View("Error");
            }

        }

        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult AjoutProduit()
        {
            try
            {
                LogHelper.Info("Products Page started...");
                ViewBag.listeProduit = _produitService.GetAllProduits();
                ViewBag.listeCategorie = _categorieService.GetAllCategories();
                return View();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return View("Error");
            }
        }


        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [HttpPost]
        public ActionResult AjoutProduit(CAT_PRODUIT produit)
        {

            bool varAdd = false;
            ProduitDto produitDTO = new ProduitDto();
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0]; //le nom de note fichier
                        if (file != null && file.ContentLength > 0)   //si notre fichier est different de null et que sa taille > 0 octet
                        {
                            var fileName = Path.GetFileName(file.FileName); //recuperer le nom du fichier
                            var path = Path.Combine(Server.MapPath("~/Fichier"), fileName); //recupererle chemin d'acces ou sera mis notre fichier
                            file.SaveAs(path);//enregistrer le tout sur le serveur

                            produit.IMAGE_PRODUIT = fileName;
                            produit.URL_IMAGE_PRODUIT = "/Fichier";
                        }
                    }
                    produit.DATE_SAISIE = DateTime.Now;
                    produitDTO = _produitHelper.ConvertToDTO(produit);
                    varAdd = _produitService.AddNewProduit(produitDTO);
                    LogHelper.Info("$Insertion de produit ..." + produit.LIBELLE_PRODUIT + " est encours ...! ");
                    ViewBag.SuccessMessage = "Insertion de produit ..." + produit.LIBELLE_PRODUIT + " avec succès ...! ";
                }
                LogHelper.Info("$Insertion de produit ..." + produit.LIBELLE_PRODUIT + " avec succès ...! ");
                if (varAdd == true)
                {
                    return RedirectToAction("AjoutProduit");
                }
                else
                {
                    ViewBag.ErrorMessage = "Impossible d'ajouter ce produit ..!";
                    throw new Exception("Impossible d'ajouter ce produit ..!");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return View("Error");
            }
        }

        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult SupprimerProduit(int id)
        {
            try
            {
                ProduitDto produitDto = _produitService.GetProduitById(id);
                if (produitDto != null)
                {
                    LogHelper.Info("$Suppression de produit ..." + produitDto.libelleProduit + " est encours ...! ");
                    _produitService.DeleteProduit(id);
                    ViewBag.SuccessMessage = "Suppresion de produit ..." + produitDto.libelleProduit + " avec succès ...! ";
                }
                LogHelper.Info("$Suppression de produit ..." + produitDto.libelleProduit + "  avec succès ...! ");
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Impossible de supprimer ce produit ..!";
                logger.Error(ex.ToString());
                return View("Error");
            }
        }


        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult ModifierProduit(int id)
        {
            try
            {
                ViewBag.listeCategorie = _categorieService.GetAllCategories(); ;
                ViewBag.listeProduit = _produitService.GetAllProduits();

                CAT_PRODUIT produit = new CAT_PRODUIT();
                ProduitDto produitDto = _produitService.GetProduitById(id);
                produit = _produitHelper.ConvertFromDto(produitDto);
                if (produit != null)
                {
                    LogHelper.Info("$Modification de produit ..." + produit.LIBELLE_PRODUIT + " est encours ...! ");
                    ViewBag.SuccessMessage = "$Modification de produit ..." + produit.LIBELLE_PRODUIT + " avec succès ...! ";
                    return View("AjoutProduit", produit);
                }
                LogHelper.Info("$Modification de la categorie ..." + produit.LIBELLE_PRODUIT + " avec succès ...! ");
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Impossible de modifier ce produit ..!";
                logger.Error(ex.ToString());
                return View("Error");
            }
        }


        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [HttpPost]
        public ActionResult ModifierProduit(CAT_PRODUIT produit)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    LogHelper.Info("$Modification de produit ..." + produit.LIBELLE_PRODUIT + " est encours ...! ");
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0]; //le nom de note fichier
                        if (file != null && file.ContentLength > 0)   //si notre fichier est different de null et que sa taille > 0 octet
                        {
                            var fileName = Path.GetFileName(file.FileName); //recuperer le nom du fichier
                            var path = Path.Combine(Server.MapPath("~/Fichier"), fileName); //recupererle chemin d'acces ou sera mis notre fichier
                            file.SaveAs(path);//enregistrer le tout sur le serveur

                            produit.IMAGE_PRODUIT = fileName;
                            produit.URL_IMAGE_PRODUIT = "/Fichier";
                        }
                    }
                    ProduitDto produitDto = new ProduitDto();
                    produitDto = _produitHelper.ConvertToDTO(produit);
                    _produitService.UpdateProduit(produitDto);
                    ViewBag.SuccessMessage = "$Modification de produit ..." + produit.LIBELLE_PRODUIT + " avec succès ...! ";

                }
                LogHelper.Info("$Modification de produit ..." + produit.LIBELLE_PRODUIT + " avec succès ...! ");
                return RedirectToAction("AjoutProduit");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Impossible de modifier ce produit ..!";
                logger.Error(ex.ToString());
                return View("Error");
            }
        }   
    }
}