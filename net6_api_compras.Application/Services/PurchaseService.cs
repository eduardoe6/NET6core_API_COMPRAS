using net6_api_compras.Application.DTOs;
using net6_api_compras.Application.DTOs.Validations;
using net6_api_compras.Application.Services.Interfaces;
using net6_api_compras.Domain.Entities;
using net6_api_compras.Domain.Repositories;

namespace net6_api_compras.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository, IProductRepository productRepository, IPersonRepository personRepository)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _personRepository = personRepository;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null) return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado.");

            var validate = new PurchaseDTOValidator().Validate(purchaseDTO);

            if (!validate.IsValid) return ResultService.RequestError<PurchaseDTO>("Problemas de validação", validate);

            var productId = await _productRepository.GetIdByCodeErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);

            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;

            return ResultService.Ok(purchaseDTO);
        }
    }
}
