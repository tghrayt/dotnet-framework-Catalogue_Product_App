using Catalogue_Produit_App.DTO;
using Catalogue_Produit_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue_Produit_App.Helper
{
    public class ProduitHelper
    {

        public bool IsEmpty<T>(List<T> list)
        {
            var boolean = false;
            if (list == null)
            {
                boolean = true;
            }

            return boolean;
        }




        public ProduitDto ConvertToDTO(CAT_PRODUIT produit)
        {
            ProduitDto produitDto = new ProduitDto();
            produitDto.DateSaisie = (DateTime)produit.DATE_SAISIE;
            produitDto.codeProduit = produit.CODE_PRODUIT;
            produitDto.descriptionProduit = produit.DESCRIPTION_PRODUIT;
            produitDto.imageProduit = produit.IMAGE_PRODUIT;
            produitDto.libelleProduit = produit.LIBELLE_PRODUIT;
            produitDto.urlImageProduit = produit.URL_IMAGE_PRODUIT;
            produitDto.codeCategorie = (int)produit.CODE_CATEGORIE;

            return produitDto;
        }

        public CAT_PRODUIT ConvertFromDto(ProduitDto produit)
        {
            CAT_PRODUIT produitData = new CAT_PRODUIT();
            produitData.CODE_PRODUIT = produit.codeProduit;
            produitData.CODE_CATEGORIE = produit.codeCategorie;
            produitData.DATE_SAISIE = produit.DateSaisie;
            produitData.DESCRIPTION_PRODUIT = produit.descriptionProduit;
            produitData.IMAGE_PRODUIT = produit.imageProduit;
            produitData.LIBELLE_PRODUIT = produit.libelleProduit;
            produitData.URL_IMAGE_PRODUIT = produit.urlImageProduit;

            return produitData;
        }
    }
}