using Catalogue_Produit_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_Produit_App.Service
{
   public interface IProduitService
    {
        List<ProduitDto> GetAllProduits();
        ProduitDto GetProduitById(int codeProduit);
        bool AddNewProduit(ProduitDto produit);
        void DeleteProduit(int codeProduit);
        ProduitDto UpdateProduit(ProduitDto produit);
    }
}
