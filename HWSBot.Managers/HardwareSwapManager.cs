﻿using HWSBot.Interfaces;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;
using System.Collections.Generic;
using System.Linq;

namespace HWSBot.Managers
{
    public class HardwareSwapManager : IHardwareSwapManager
    {
        private readonly IHardwareSwapRepository _hardwareSwapRepository;

        public HardwareSwapManager(IHardwareSwapRepository hardwareSwapRepoisory)
        {
            _hardwareSwapRepository = hardwareSwapRepoisory;
        }

        public List<Product> GetUsersProductList(int userId)
        {
            List<Product> productList;

            productList = _hardwareSwapRepository.SearchUserProductList(userId);

            return productList;
        }
        
        public List<ProductPost> GetProductPostList(int productId)
        {
            List<ProductPost> productPostList;
            Product product;
            
            product = GetProduct(productId);
            productPostList = _hardwareSwapRepository.GetProductPostList(product);
            PopulateProductPostList(productPostList);

            return productPostList;
        }
        private void PopulateProductPostList(List<ProductPost> productPostList)
        {
            Dictionary<int, Post> postByIdDictionary;

            postByIdDictionary = _hardwareSwapRepository.GetBatchPostList(productPostList.Select(pp => pp.Post.PostId).ToList());

            foreach (ProductPost productPost in productPostList)
            {
                productPost.Post = postByIdDictionary[productPost.Post.PostId];
            }
        }

        public Product GetProduct(int productId)
        {
            Product product;

            product = _hardwareSwapRepository.GetProduct(productId);

            if (product == null)
            {
                throw new System.Exception("Product not found");
            }

            product.ProductCriteriaList = _hardwareSwapRepository.GetProductCriteriaList(product.ProductId);
            product.StoreList = _hardwareSwapRepository.GetProductStoreList(product.ProductId);
            return product;
        }
        
        public List<Post> GetNewPostList(int? lastPostId)
        {
            return _hardwareSwapRepository.GetNewPostList(lastPostId);
        }

        public void Save(List<ProductPost> productPostList)
        {
            _hardwareSwapRepository.Save(productPostList);
        }

        public void Save(Product product)
        {
            _hardwareSwapRepository.Save(product);
            _hardwareSwapRepository.Save(product.ProductCriteriaList);
            _hardwareSwapRepository.Save(product.StoreList);
        }
    }
}
