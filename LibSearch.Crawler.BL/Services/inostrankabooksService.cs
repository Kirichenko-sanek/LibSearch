﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using LibSearch.Core.Model;
using LibSearch.Core.Model.Crawler;
using LibSearch.Crawler.BL.Interfaces.Service;

namespace LibSearch.Crawler.BL.Services
{
    public class InostrankabooksService : IInostrankabooksService
    {
        public int ProgresMax { get; set; }
        public int ProgresNow { get; set; }

        public InostrankabooksService()
        {
            ProgresMax = 0;
            ProgresNow = 0;
        }

        public List<string> GetListSeries(string url)
        {
            var seriesList = new List<string>();
            var wClientSeries = new WebClient();
            var htmlSeries = new HtmlDocument();
            try
            {
                htmlSeries.LoadHtml(wClientSeries.DownloadString(url + "/ru/series/"));
            }
            catch (Exception)
            {
                return seriesList;
            }

            var elements = htmlSeries.DocumentNode.SelectNodes("//div[@class='seria_books']/div[@class='all']/a");

            if (elements == null)
            {
                return seriesList;
            }
            foreach (var item in elements)
            {
                seriesList.Add(url + item.GetAttributeValue("href", ""));
            }
            return seriesList;
        }

        public List<string> GetListPages(string url, string mainUrl)
        {
            ProgresMax = 0;
            ProgresNow = 0;
            var pagesList = new List<string>();
            var cout = 1;
            var wClientStart = new WebClient();
            var htmlStart = new HtmlDocument();

            try
            {
                htmlStart.LoadHtml(wClientStart.DownloadString(url));
            }
            catch (Exception)
            {
                return pagesList;
            }
            
            var pagesCout = htmlStart.DocumentNode.SelectNodes("//tr[@valign='top']/td[@align='center']/span/a[@class='hl']");
            if (pagesCout == null)
            {
                return pagesList;
            }
            if (pagesCout.Count > 1)
            {
                cout = pagesCout.Count + 1;
            }
            pagesList.Clear();
            //Parallel.For(1, cout, i =>
            //{
            //    using (var wClient = new WebClient())
            //    {
            //        var html = new HtmlDocument();
            //        try
            //        {
            //            html.LoadHtml(wClient.DownloadString(url + i + "/"));
            //        }
            //        catch (Exception)
            //        {
            //            return;
            //        }

            //        var elements = html.DocumentNode.SelectNodes("//tr[@valign='top']/td[@width='185']/a");
            //        if (elements == null)
            //        {
            //            return;
            //        }
            //        foreach (var item in elements)
            //        {
            //            pagesList.Add(mainUrl + item.GetAttributeValue("href", ""));
            //        }
            //    }
            //});
            pagesList.Add("http://inostrankabooks.ru/ru/book/24433/");
            return pagesList;
        }


        public List<BookOfInostrankabooks> GetInfoBooks(List<string> urlList, string mainUrl)
        {
            var listBooks = new List<BookOfInostrankabooks>();

            Parallel.ForEach(urlList, item =>
            {
                using (var wClient = new WebClient())
                {
                    var htmlInfo = new HtmlDocument();
                    var info = new BookOfInostrankabooks();
                    try
                    {
                        htmlInfo.LoadHtml(wClient.DownloadString(item));
                    }
                    catch (Exception)
                    {
                        return;
                    }

                    info.Name =
                        Encoding.UTF8.GetString(
                            Encoding.Default.GetBytes(
                                htmlInfo.DocumentNode.SelectSingleNode("//tr[@valign='top']/td/h1")?.InnerText));

                    info.Photo =
                        htmlInfo.DocumentNode.SelectSingleNode("//tr[@valign='top']/td/img")?
                            .GetAttributeValue("src", "");

                    info.Category =
                        Encoding.UTF8.GetString(
                            Encoding.Default.GetBytes(
                                htmlInfo.DocumentNode.SelectSingleNode("//tr[@valign='top']/td/a[@class='seria_sm']")?
                                    .InnerText));

                    info.Author =
                        Encoding.UTF8.GetString(
                            Encoding.Default.GetBytes(
                                htmlInfo.DocumentNode.SelectSingleNode("//tr[@valign='top']/td/a[@class='author']")?
                                    .InnerText));

                    var elements = htmlInfo.DocumentNode.SelectSingleNode("//table[4]/tr/td");

                
                    info.Summary =
                        Encoding.UTF8.GetString(
                            Encoding.Default.GetBytes(
                                htmlInfo.DocumentNode.SelectSingleNode("//table[4]/tr/td")?.InnerText));

                    info.PageUrl = item;



                    var a = 0;



                    



                }

            });





            return listBooks;
        }




    }
}
