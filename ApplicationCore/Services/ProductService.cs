﻿using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;
using ApplicationCore.Resources;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services
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

        public async Task<int> CreateProductAsync(AddProductResource product, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Product>(product);
            return await _productRepository.CreateAsync(entity, cancellationToken);
        }

        public async Task<int> DeleteProductAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _productRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<GetProductResource>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {

            var products = await _productRepository.GetAllAsync(cancellationToken);
            var productResources = _mapper.Map<List<GetProductResource>>(products);

            return productResources;

        }

        public async Task<GetProductResource> GetProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            var productResource = _mapper.Map<GetProductResource>(product);
           
            return productResource;
        }

        public async Task<int> UpdateProductAsync(int id, AddProductResource product, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Product>(product);
            entity.ProductId = id;
           return  await _productRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}
