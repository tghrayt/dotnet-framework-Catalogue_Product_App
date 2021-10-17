using Catalogue_Produit_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue_Produit_App.DAO
{
    public class ProduitRepository : IProduitRepository
    {
        //Injecter le repository par défaut entity framework (dbContext)
        CatalogueProduitEntities _db = new CatalogueProduitEntities();


        public bool AddNewProduit(CAT_PRODUIT produit)
        {
            if (produit != null)
            {
                _db.CAT_PRODUIT.Add(produit);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteProduit(int codeProduit)
        {
            throw new NotImplementedException();
        }

        public List<CAT_PRODUIT> GetAllProduits()
        {
            return _db.CAT_PRODUIT.ToList();
        }

        public CAT_PRODUIT GetProduitById(int codeProduit)
        {
            throw new NotImplementedException();
        }

        public CAT_PRODUIT UpdateProduit(CAT_PRODUIT produit)
        {
            throw new NotImplementedException();
        }
    }
}