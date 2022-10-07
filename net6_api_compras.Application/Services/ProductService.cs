using AutoMapper;
using net6_api_compras.Application.DTOs;
using net6_api_compras.Application.DTOs.Validations;
using net6_api_compras.Application.Services.Interfaces;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;

namespace net6_api_compras.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null) return ResultService.Fail<ProductDTO>("Objeto deve ser informado!");

            var result = new ProductDTOValidator().Validate(productDTO);

            if (!result.IsValid) return ResultService.RequestError<ProductDTO>("Problemas na validação", result);

            var product = _mapper.Map<Product>(productDTO);

            var data = await _productRepository.CreateAsync(product);

            return ResultService.Ok(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService> RemoveAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null) return ResultService.Fail("Produto não encontrado.");

            await _productRepository.RemoveAsync(product);

            return ResultService.Ok($"Produto de id [{id}] foi removido com sucesso!");
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null) return ResultService.Fail("Objeto deve ser informado!");

            var validation = new ProductDTOValidator().Validate(productDTO);

            if (!validation.IsValid) return ResultService.RequestError("Problemas com a validação dos campos", validation);

            var product = await _productRepository.GetAsync(productDTO.Id);

            if (product == null) return ResultService.Fail("Produto não encontrado.");

            // Para editar o map é diferente da inserção
            product = _mapper.Map(productDTO, product);

            await _productRepository.UpdateAsync(product);

            return ResultService.Ok("Produto editado.");
        }
        public async Task<ResultService<ICollection<ProductDTO>>> GetAllAsync()
        {
            var product = await _productRepository.GetAllAsync();

            return ResultService.Ok(_mapper.Map<ICollection<ProductDTO>>(product));
        }

        public async Task<ResultService<ProductDTO>> GetAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null) return ResultService.Fail<ProductDTO>("Produto não encontrado");

            return ResultService.Ok(_mapper.Map<ProductDTO>(product));
        }
    }
}
