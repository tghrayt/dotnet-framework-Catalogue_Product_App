using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue_Produit_App.DTO
{
    public class CategorieDto
    {

        public int codeCategorie { get; set; }
        public string libelleCategorie { get; set; }
        public DateTime dateSaisie { get; set; }

        public  ICollection<ProduitDto> produits { get; set; }
    }
}