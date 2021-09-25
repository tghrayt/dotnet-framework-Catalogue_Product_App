using Catalogue_Produit_App.Models;
using System.Collections.Generic;


namespace Catalogue_Produit_App.Helper
{
    public class CategorieHelper
    {

        CatalogueProduitEntities _db = new CatalogueProduitEntities();


        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public bool IsEmpty<T>(List<T> list)
        {
            var boolean = false;
            if (list == null)
            {
                boolean = true;
            }

            return boolean;
        }
    }
}