using RedditSharp.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWSBot.Managers;
using HWSBot.ServiceModel;
using System.Data.SqlClient;

namespace HWSBot.Managers
{
    public class DataManager
    {
        ItemDetail itemDetail;

        public List<string> GetPrice(Post post)
        {
            itemDetail = new ItemDetail();
            itemDetail.Date = post.Created;

            var postText = post.SelfText;
            var charSearch = '$';
            int j = 0;

            for (int i = 0; i < postText.Length; i++)
            {
                string totalPrice = "";

                if (postText[i] == charSearch)
                {

                    i++;
                    while (Char.IsDigit(postText[i]))
                    {
                        totalPrice += postText[i];
                        i++;
                    }
                    itemDetail.Price.Add(totalPrice);
                    j++;
                }
            }
            if (itemDetail.Price.Count < 0)
            { itemDetail.Price = new List<string>(); }

            return itemDetail.Price;
        }

        public string ParseTitle(string title)
        {
            if (title.Contains("[H]") || title.Contains("[h]"))
            {
                return title.Split(']')[1].Split('[')[0].Replace(" ", "");
            }
            return "0";
    
        }
    }
}
