using System.Collections.Generic;

namespace LibSearch.Crawler.BL.Interfaces.Service
{
    public interface IInostrankabooksService
    {
        int ProgresMax { get; set; }
        int ProgresNow { get; set; }

        List<string> GetListSeries(string url);


    }
}
