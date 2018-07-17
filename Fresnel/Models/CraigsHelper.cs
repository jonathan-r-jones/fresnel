﻿using CodeHollow.FeedReader;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Fresnel.Models
{
    public class CraigsHelper
    {
        public static async Task<List<BikeItem>> SearchAsync(string query)
        {

            try
            {
                var sourceUrl = $"https://washingtondc.craigslist.org/search/sss?format=rss&hasPic=1&max_price=100&query={query}&sort=date";
                // This is the line it crashes on.
                var rss = await FeedReader.ReadAsync(sourceUrl);
                var items = rss.Items.Select(s => new BikeItem()
                {
                    Id = s.Id,
                    Text = HtmlEntity.DeEntitize(s.Title),
                    Description = HtmlEntity.DeEntitize(s.Description),
                    Image = s.SpecificItem.Element.Descendants().FirstOrDefault(x => x.Name.LocalName == "enclosure")?.Attribute("resource")?.Value,
                    Price = 10,
                    Link = s.Link,
                }).ToList();
                foreach (var item in items)
                {
                    var match = Regex.Match(item.Text, "\\$(\\d+)");
                    if (match.Success)
                    {
                        item.Price = Convert.ToDouble(match.Groups[1].Value);
                    }
                }
                return items;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
