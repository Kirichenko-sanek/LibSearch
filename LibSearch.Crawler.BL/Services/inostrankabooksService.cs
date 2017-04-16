using System.Collections.Generic;
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




            return seriesList;
        }

    }
}
