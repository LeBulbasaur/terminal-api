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
        var pinned = htmlDoc.DocumentNode.SelectNodes("//div[@class='pinned-item-list-item-content']");
        
        //var links = htmlDoc.DocumentNode.SelectNodes("//a[@class='Link mr-1 text-bold wb-break-word']");
        for(int i = 0; i < pinned.Count; i++)
        {
            // get span text with repo class
            string name = pinned[i].SelectNodes("//span[@class='repo']")[i]
                .InnerText;
            // get href value
            string link = pinned[i].SelectNodes("//a[@class='Link mr-1 text-bold wb-break-word']")[i].Attributes["href"].Value;
            // get span text with description class
            string description = pinned[i].SelectNodes("//p[@class='pinned-item-desc color-fg-muted text-small mt-2 mb-0']")[i].InnerText;


            // remove new lines and spaces from the start of the string
            description = description.Replace("\n", "");
            description = description.TrimStart();

            if (description == "")
            {
                description = "No description provided";
            }

            RepositoryModel repositoryModel = new RepositoryModel(name, "https://github.com" + link, description);
            repos.Add(repositoryModel);
        }
        return Task.FromResult(repos);
    }
}