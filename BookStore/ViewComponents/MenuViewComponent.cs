using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private ILanguageService languageService;
        private IBrandService brandService;

        public MenuViewComponent(ILanguageService languageService, IBrandService brandService)
        {
            this.languageService = languageService;
            this.brandService = brandService;
        }
        public IViewComponentResult Invoke()
        {
            var brand = brandService.GetBrands();
            var language = languageService.GetLanguages();
            return View(language);

            //ViewBag.Brand = brandService.GetBrands();
            //ViewBag.Language = languageService.GetLanguages();
            //return View();

        }

        
        private List<SelectListItem> getLanguagesForSelect()
        {
            var languages = languageService.GetLanguages();
            List<SelectListItem> selectListLanguages = new List<SelectListItem>();
            languages.ToList().ForEach(language => selectListLanguages.Add(new SelectListItem { Text = language.Name, Value = language.LanguageId.ToString() }));
            return selectListLanguages;
        }

        private List<SelectListItem> getBrandsForSelect()
        {
            var brands = brandService.GetBrands();


            List<SelectListItem> selectListBrands = new List<SelectListItem>();
            brands.ToList().ForEach(brand => selectListBrands.Add(new SelectListItem { Text = brand.Name, Value = brand.BrandId.ToString() }));
            return selectListBrands;
        }
    }
}
