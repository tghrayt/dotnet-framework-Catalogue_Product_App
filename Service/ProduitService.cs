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
            throw new NotImplementedException();
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