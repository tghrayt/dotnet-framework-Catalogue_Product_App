using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue_Produit_App.DTO
{
    public class ProduitDto
    {

        public int codeProduit { get; set; }
        public CategorieDto categorieDto { get; set; }
        public string libelleProduit { get; set; }
        public string descriptionProduit { get; set; }
        public string imageProduit { get; set; }
        public string urlImageProduit { get; set; }
        public DateTime DateSaisie { get; set; }

    }
}