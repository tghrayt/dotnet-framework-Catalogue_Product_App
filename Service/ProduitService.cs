using Catalogue_Produit_App.DAO;
using Catalogue_Produit_App.DTO;
using Catalogue_Produit_App.Helper;
using Catalogue_Produit_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalogue_Produit_App.Service
{
    public class ProduitService : IProduitService
    {


        ProduitHelper _produitHelper = new ProduitHelper();
        CategorieHelper _categorieHelper = new CategorieHelper();
        ProduitService()
        {

        }

        private readonly IProduitRepository _produitRepository;
       public ProduitService(IProduitRepository produitRepository)
        {
            _produitRepository = produitRepository;

        }





        public bool AddNewProduit(ProduitDto produit)
        {
            CAT_PRODUIT produit_transfered = new CAT_PRODUIT();
            if (produit != null)
            {
                produit_transfered = _produitHelper.ConvertFromDto(produit);
                _produitRepository.AddNewProduit(produit_transfered);
                return true;
            }
            return false;
        }

        public void DeleteProduit(int codeProduit)
        {
            throw new NotImplementedException();
        }

        public List<ProduitDto> GetAllProduits()
        {
            List<ProduitDto> listeProduitDto = new List<ProduitDto>();
            List<CAT_PRODUIT> listeProduit = new List<CAT_PRODUIT>();
            listeProduit = _produitRepository.GetAllProduits();
            if (_produitHelper.IsEmpty(listeProduit)){

                throw new Exception("il n'y a pas de produits sur la base de données !");
            }

            foreach(CAT_PRODUIT item in listeProduit)
            {
                ProduitDto produitDTO = new ProduitDto();
                produitDTO.codeProduit = item.CODE_PRODUIT;
                produitDTO.codeCategorie = (int)item.CODE_CATEGORIE;
                produitDTO.DateSaisie = (DateTime)item.DATE_SAISIE;
                produitDTO.descriptionProduit = item.DESCRIPTION_PRODUIT;
                produitDTO.imageProduit = item.IMAGE_PRODUIT;
                produitDTO.libelleProduit = item.LIBELLE_PRODUIT;
                produitDTO.urlImageProduit = item.URL_IMAGE_PRODUIT;
                produitDTO.categorieDto = _categorieHelper.ConvertToDTO(item.CAT_CATEGORIE);
                listeProduitDto.Add(produitDTO);
            }

            return listeProduitDto;

        }

        public ProduitDto GetProduitById(int codeProduit)
        {
            throw new NotImplementedException();
        }

        public ProduitDto UpdateProduit(ProduitDto produit)
        {
            throw new NotImplementedException();
        }
    }
}