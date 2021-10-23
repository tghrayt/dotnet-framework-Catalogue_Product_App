using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Catalogue_Produit_App.DTO;
using Catalogue_Produit_App.Helper;
using Catalogue_Produit_App.Models;
using Catalogue_Produit_App.Service;

namespace Catalogue_Produit_App.Controllers
{
    public class CatalogueController : Controller

    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));  //Declaring Log4Net 
        public CatalogueController()
        {

        }
        CatalogueProduitEntities db = new CatalogueProduitEntities();
        private readonly ICategorieService _categorieService;
        public CatalogueController(ICategorieService categorieService) => _categorieService = categorieService;

        private CategorieHelper _categorieHelper = new CategorieHelper();




        // GET: Catalogue
        public ActionResult Index()
        {
            try
            {
                LogHelper.Info("Category Page started...");
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
        public ActionResult AjoutCatalogue()
        {
            try
            {  
                LogHelper.Info("Category Page started...");
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
        public ActionResult AjoutCatalogue(CAT_CATEGORIE categorie)//enregistrement
        {
            bool varAdd = false;
            CategorieDto categorieDto = new CategorieDto();
            try
            {

                if (ModelState.IsValid)
                {
                    categorie.DATE_SAISIE = DateTime.Now;
                    categorieDto = _categorieHelper.ConvertToDTO(categorie);
                    varAdd = _categorieService.AddNewCategorie(categorieDto);
                    LogHelper.Info("$Insertion de la categorie ..."+categorie.LIBELLE_CATEGORIE+" est encours ...! ");
                    ViewBag.SuccessMessage = "Insertion de la categorie ..." + categorie.LIBELLE_CATEGORIE + " avec succès ...! ";
                }
               
                LogHelper.Info("$Insertion de la categorie ..." + categorie.LIBELLE_CATEGORIE + " avec succès ...! ");
                if(varAdd == true)
                {
                    return RedirectToAction("AjoutCatalogue");
                }
                else
                {
                    ViewBag.ErrorMessage = "Impossible d'ajouter cette catégorie ..!";
                    throw new Exception("Impossible d'ajouter cette catégorie ..!");
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
        public ActionResult SupprimerCatalogue(int id)
        {
            try
            {
                CategorieDto categorieDto = _categorieService.GetGategorieById(id);//recherchede la categorie
                if (categorieDto != null)
                {
                    LogHelper.Info("$Suppression de la categorie ..." + categorieDto.libelleCategorie + " est encours ...! ");
                    _categorieService.DeleteCategorie(id);
                    ViewBag.SuccessMessage = "Suppresion de la categorie ..." + categorieDto.libelleCategorie + " avec succès ...! ";
                }
                LogHelper.Info("$Suppresion de la categorie ..."+ categorieDto.libelleCategorie+" avec succès ...! ");
                return RedirectToAction("AjoutCatalogue");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Impossible de supprimer cette catégorie ..!";
                logger.Error(ex.ToString());
                return View("Error");
            }
        }



        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult ModifierCatalogue(int id)
        {
            try
            {
                ViewBag.listeCategorie = _categorieService.GetAllCategories();
                CAT_CATEGORIE categorie = new CAT_CATEGORIE();
                CategorieDto categorieDto = _categorieService.GetGategorieById(id);
                categorie = _categorieHelper.ConvertFromDto(categorieDto);
                if (categorie != null)
                {
                    LogHelper.Info("$Modification de la categorie ..." + categorie.LIBELLE_CATEGORIE + " est encours ...! ");
                    ViewBag.SuccessMessage = "$Modification de la categorie ..." + categorie.LIBELLE_CATEGORIE + " avec succès ...! ";
                    return View("AjoutCatalogue", categorie);
                }
                LogHelper.Info("$Modification de la categorie ..." + categorie.LIBELLE_CATEGORIE + " avec succès ...! ");
                return RedirectToAction("AjoutCatalogue");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Impossible de modifier cette catégorie ..!";
                logger.Error(ex.ToString());
                return View("Error");
            }
        }


        [HandleError]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        [HttpPost]
        public ActionResult ModifierCatalogue(CAT_CATEGORIE categorie)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    LogHelper.Info("$Modification de la categorie ..." + categorie.LIBELLE_CATEGORIE + " est encours ...! ");
                    //db.Entry(categorie).State = EntityState.Modified; // modification de notre categorie
                    //db.SaveChanges();
                    CategorieDto categorieDto = new CategorieDto();
                    categorieDto = _categorieHelper.ConvertToDTO(categorie);
                    _categorieService.UpdateCategorie(categorieDto);
                    ViewBag.SuccessMessage = "$Modification de la categorie ..." + categorie.LIBELLE_CATEGORIE + " avec succès ...! ";
                }
                LogHelper.Info("$Modification de la categorie ..." + categorie.LIBELLE_CATEGORIE + " avec succès ...! ");
                return RedirectToAction("AjoutCatalogue");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Impossible de modifier cette catégorie ..!";
                logger.Error(ex.ToString());
                return View("Error");
            }
        }


    }
}