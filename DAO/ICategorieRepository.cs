using Catalogue_Produit_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_Produit_App.DAO
{
   public interface ICategorieRepository
    {

        List<CAT_CATEGORIE> GetAllCategories();
        CAT_CATEGORIE GetGategorieById(int codeCategorie);
        bool AddNewCategorie(CAT_CATEGORIE categorie);
        void DeleteCategorie(int codeCategorie);
        CAT_CATEGORIE UpdateCategorie(int codeCategorie, CAT_CATEGORIE categorie);

    }
}
