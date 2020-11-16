using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Web.ApiServices;
using src.Web.DTOs;
using src.Web.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace src.Web.Controllers
{

    public class CategoriesController : Controller
    {

        private readonly IMapper _mapper;
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(IMapper mapper, CategoryApiService categoryApiService)
        {
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        public async Task<IActionResult> Index()
        {

            var categories = await _categoryApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {

            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("index");
        }


        public async Task<IActionResult> Update(int id)
        {

            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);
            return RedirectToAction("index");
        }

        //[CategoryNotFoundFilter] bu şekilde kullanmamızın sebebi.
        //Contructer istediği için servicefilter olarak kullanıyoruz.
        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryApiService.Remove(id);

            return RedirectToAction("index");
        }
    }
}
