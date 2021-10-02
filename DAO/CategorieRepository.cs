using Catalogue_Produit_App.Helper;
using Catalogue_Produit_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue_Produit_App.DAO
{
    public class CategorieRepository : ICategorieRepository
    {
        //Injecter le repository par défaut entity framework (dbContext)
        CatalogueProduitEntities _db = new CatalogueProduitEntities();
        CategorieHelper categorieHelper = new CategorieHelper();
        

        public bool AddNewCategorie(CAT_CATEGORIE categorie)
        {
            if(categorie != null)
            {
                _db.CAT_CATEGORIE.Add(categorie);
                _db.SaveChanges();
                return true;
            }
            return false;
            
        }

        public void DeleteCategorie(int codeCategorie)
        {
            throw new NotImplementedException();
        }

        public List<CAT_CATEGORIE> GetAllCategories()
        {
            List<CAT_CATEGORIE> listCategories = new List<CAT_CATEGORIE>();                  
                listCategories = _db.CAT_CATEGORIE.ToList();               
                return listCategories;            
        }

        public CAT_CATEGORIE GetGategorieById(int codeCategorie)
        {
            throw new NotImplementedException();
        }

        public CAT_CATEGORIE UpdateCategorie(int codeCategorie, CAT_CATEGORIE categorie)
        {
            throw new NotImplementedException();
        }
    }
}