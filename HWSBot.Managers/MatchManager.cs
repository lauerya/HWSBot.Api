using HWSBot.Interfaces;
using HWSBot.ServiceModel;
using HWSBot.ServiceModel.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HWSBot.Managers
{
    public class MatchManager
    {
        private readonly IHardwareSwapRepository _hardwareSwapRepository;

        public MatchManager(IHardwareSwapRepository hardwareSwapRepository)
        {
            _hardwareSwapRepository = hardwareSwapRepository;
        }

        public List<ProductPost> GetProductPostList(Product product)
        {
            List<ProductPost> productPostList;
            List<Post> postList;
            ProductPost productPost;
            string[] stringSplit;
            int rank;

            productPostList = _hardwareSwapRepository.GetProductPostList(product);
            PopulateProductPostList(productPostList);

            postList = _hardwareSwapRepository.GetNewPostList(product.LastPostId);
            
            if (postList == null || postList.Count == 0)
            {
                return null;
            }

            foreach (Post post in postList)
            {
                if (!ShouldProductSearchPost(product, post))
                {
                    continue;
                }
                rank = 0;

                foreach (ProductCriteria productCriteria in product.ProductCriteriaList)
                {
                    stringSplit = post.Text.Split(new[] { productCriteria.Value }, StringSplitOptions.None);

                    if (stringSplit.Length < 2)
                    {
                        continue;
                    }

                    for (int i = 1; i <= stringSplit.Length - 1; i++)
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
            }
            product.LastPostId = postList.Last().PostId;

            return productPostList;
        }

        private void PopulateProductPostList(List<ProductPost> productPostList)
        {
            _hardwareSwapRepository.GetBatchPostList(productPostList.Select(pp => pp.Post.PostId).ToList());

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
