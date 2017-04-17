using System.Collections.Generic;
using LibSearch.Core.Model.Crawler;

namespace LibSearch.Crawler.BL.Interfaces.Service
{
    public interface IInostrankabooksService
    {
        int ProgresMax { get; set; }
        int ProgresNow { get; set; }

        List<string> GetListSeries(string url);
        List<string> GetListPages(string url, string mainUrl);

        List<BookOfInostrankabooks> GetInfoBooks(List<string> urlList, string mainUrl);

    }
}
