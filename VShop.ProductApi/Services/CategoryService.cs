using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesProduct = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesProduct);
        }
        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(categoryEntity);
            categoryDTO.CategoryId = categoryEntity.CategoryId;
        }
        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(categoryEntity);
        }
        public async Task RemoveCategory(int id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }
    }
}
