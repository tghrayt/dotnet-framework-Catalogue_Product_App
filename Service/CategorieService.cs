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
    public class CategorieService : ICategorieService

    {
        CategorieHelper _categorieHelper = new CategorieHelper();


        public CategorieService()
        {

        }
        private readonly ICategorieRepository _categorieRepository;
        public CategorieService(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }

        public bool AddNewCategorie(CategorieDto categorie)
        {
            CAT_CATEGORIE categorie_transfered = new CAT_CATEGORIE();
            if (categorie != null)
            {
                categorie_transfered = _categorieHelper.ConvertFromDto(categorie);
                _categorieRepository.AddNewCategorie(categorie_transfered);
                return true;
            }
            return false;
        }

        public void DeleteCategorie(int codeCategorie)
        {
            if(codeCategorie!= 0)
            {
                _categorieRepository.DeleteCategorie(codeCategorie);
            }
        }

        public List<CategorieDto> GetAllCategories()
        {
           
                List<CategorieDto> listCategorieDto = new List<CategorieDto>();         
                List<CAT_CATEGORIE> listCategories = new List<CAT_CATEGORIE>();
                listCategories = _categorieRepository.GetAllCategories();
                if (_categorieHelper.IsEmpty(listCategories))
                {
                    throw new Exception("il n'y a pas de catalogue sur la base de données !");
                }

            foreach (CAT_CATEGORIE item in listCategories)
                {
                    CategorieDto categorieDto = new CategorieDto();
                    categorieDto.codeCategorie = item.CODE_CATEGORIE;
                    categorieDto.libelleCategorie = item.LIBELLE_CATEGORIE;
                    categorieDto.dateSaisie = (DateTime)item.DATE_SAISIE;
                    listCategorieDto.Add(categorieDto);
                }

                return listCategorieDto;
          
           
        }

        public CategorieDto GetGategorieById(int codeCategorie)
        {
            CategorieDto categorieDto = new CategorieDto();
            categorieDto = _categorieHelper.ConvertToDTO(_categorieRepository.GetGategorieById(codeCategorie));
            return categorieDto;
        }

        public CategorieDto UpdateCategorie(CategorieDto categorie)
        {
            CategorieDto categorieDto = new CategorieDto();
            CAT_CATEGORIE categorieData = new CAT_CATEGORIE();
            categorieData = _categorieHelper.ConvertFromDto(categorie);
            categorieDto = _categorieHelper.ConvertToDTO(_categorieRepository.UpdateCategorie(categorieData));
            return categorieDto;
        }
    }
}