using Catalogue_Produit_App.DTO;
using Catalogue_Produit_App.Models;
using System.Collections.Generic;


namespace Catalogue_Produit_App.Helper
{
    public class CategorieHelper
    {

        CatalogueProduitEntities _db = new CatalogueProduitEntities();



        public bool IsEmpty<T>(List<T> list)
        {
            var boolean = false;
            if (list == null)
            {
                boolean = true;
            }

            return boolean;
        }

        public CategorieDto ConvertToDTO(CAT_CATEGORIE categorie)
        {
            CategorieDto categorieDto = new CategorieDto();
            categorieDto.dateSaisie = (System.DateTime)categorie.DATE_SAISIE;
            categorieDto.libelleCategorie = categorie.LIBELLE_CATEGORIE;
            categorieDto.codeCategorie = categorie.CODE_CATEGORIE;


            return categorieDto;
        }

        public CAT_CATEGORIE ConvertFromDto(CategorieDto categorie)
        {
            CAT_CATEGORIE categorieData = new CAT_CATEGORIE();
            categorieData.CODE_CATEGORIE = categorie.codeCategorie;
            categorieData.DATE_SAISIE = categorie.dateSaisie;
            categorieData.LIBELLE_CATEGORIE = categorie.libelleCategorie;
            return categorieData;
        }
    }
}