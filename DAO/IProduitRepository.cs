using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogue_Produit_App.Models;

namespace Catalogue_Produit_App.DAO
{
   public interface IProduitRepository
    {
        List<CAT_PRODUIT> GetAllProduits();
        CAT_PRODUIT GetProduitById(int codeProduit);
        bool AddNewProduit(CAT_PRODUIT produit);
        void DeleteProduit(int codeProduit);
        CAT_PRODUIT UpdateProduit(CAT_PRODUIT produit);
    }
}
