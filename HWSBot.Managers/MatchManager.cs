﻿using HWSBot.Interfaces;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;
using System;
using System.Collections.Generic;

namespace HWSBot.Managers
{
    public class MatchManager : IMatchManager
    {
        private readonly IHardwareSwapManager _hardwareSwapManager;

        public MatchManager(IHardwareSwapManager hardwareSwapManager)
        {
            _hardwareSwapManager = hardwareSwapManager;
        }

        public void MatchProductPost(int productId)
        {
            List<ProductPost> productPostList;
            List<Post> postList;
            ProductPost productPost;
            Product product;
            string[] stringSplit;
            int rank;
            int saveCounter = 0;
            product = _hardwareSwapManager.GetProduct(productId);
            postList = _hardwareSwapManager.GetNewPostList(product.LastPostId);

            if (postList == null || postList.Count == 0)
            {
                return;
            }
            productPostList = new List<ProductPost>();

            foreach (Post post in postList)
            {
                if (!ShouldProductSearchPost(product, post))
                {
                    continue;
                }
                saveCounter++;
                rank = 0;

                foreach (ProductCriteria productCriteria in product.ProductCriteriaList)
                {
                    stringSplit = post.Text.Split(new[] { productCriteria.Value }, StringSplitOptions.None);

                    if (stringSplit.Length < 2)
                    {
                        continue;
                    }

                    for (int i = 1; i <= stringSplit.Length - 1 && i < 5; i++)
                    {
                        rank += productCriteria.Rank / i;
                    }
                }

                if (rank < product.RankThreshold)
                {
                    continue;
                }
                productPost = new ProductPost();
                productPost.Post = post;
                productPost.Product = product;
                productPost.TotalRank = rank;

                productPostList.Add(productPost);
                product.LastPostId = post.PostId;

                if (saveCounter > 100)
                {
                    _hardwareSwapManager.Save(productPostList);
                    _hardwareSwapManager.Save(product);

                    productPostList = new List<ProductPost>();
                    saveCounter = 0;
                }
            }

            _hardwareSwapManager.Save(productPostList);
            _hardwareSwapManager.Save(product);
        }

        private bool ShouldProductSearchPost(Product product, Post post)
        {
            if (product.LastPostId.HasValue && product.LastPostId.Value >= post.PostId)
            {
                return false;
            }

            //TODO check the store
            return true;
        }
    }
}
