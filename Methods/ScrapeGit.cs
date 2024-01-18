using System.Reflection.Metadata;
using HtmlAgilityPack;
using Terminal.Models;

namespace Terminal.Methods;

public static class ScrapeGit
{
    public static Task<List<RepositoryModel>> Scrape()
    {
        // create new list of strings
        List<RepositoryModel> repos = new List<RepositoryModel>();
        string html = @"https://github.com/LeBulbasaur";
        HtmlWeb web = new HtmlWeb();
        HtmlDocument htmlDoc = web.Load(html);
        var links = htmlDoc.DocumentNode.SelectNodes("//a[@class='Link mr-1 text-bold wb-break-word']");
        for(int i = 0; i < links.Count; i++)
        {
            // get href attribute
            string hrefValue = links[i].GetAttributeValue("href", string.Empty);
            // get span text with repo class
            string name = links[i].SelectNodes("//span[@class='repo']")[i]
                .InnerText;
            
            RepositoryModel repositoryModel = new RepositoryModel(name, "https://github.com" + hrefValue);
            repos.Add(repositoryModel);
        }
        return Task.FromResult(repos);
    }
}