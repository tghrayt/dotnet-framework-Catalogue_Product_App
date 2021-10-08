using Catalogue_Produit_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue_Produit_App.Service
{
    public interface ICategorieService
    {
        List<CategorieDto> GetAllCategories();
        CategorieDto GetGategorieById(int codeCategorie);
        bool AddNewCategorie(CategorieDto categorie);
        void DeleteCategorie(int codeCategorie);
        CategorieDto UpdateCategorie(CategorieDto categorie);
    }
}
