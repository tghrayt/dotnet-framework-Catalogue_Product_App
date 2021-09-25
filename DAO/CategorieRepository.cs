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

        CategorieHelper _categorieHelper = new CategorieHelper();

        public bool AddNewCategorie(CAT_CATEGORIE categorie)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategorie(int codeCategorie)
        {
            throw new NotImplementedException();
        }

        public List<CAT_CATEGORIE> GetAllCategories()
        {
            List<CAT_CATEGORIE> listCategories = new List<CAT_CATEGORIE>();

            try
            {            
                listCategories = _db.CAT_CATEGORIE.ToList();
                if (_categorieHelper.IsEmpty(listCategories))
                {
                    throw new Exception("il n'y a pas de catalogue sur la base de données !");
                }
                return listCategories;

            }
            catch (Exception e)
            {   
                throw new Exception(e.Message);
               
            }

            
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