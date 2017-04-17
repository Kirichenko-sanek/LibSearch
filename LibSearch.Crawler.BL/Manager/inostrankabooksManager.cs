using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSearch.Crawler.BL.Interfaces.Manager;
using LibSearch.Crawler.BL.Interfaces.Repository;
using LibSearch.Crawler.BL.Interfaces.Service;

namespace LibSearch.Crawler.BL.Manager
{
    public class InostrankabooksManager : IInostrankabooksManager
    {
        private readonly IInostrankabooksService _inostrankabooksService;
        private readonly IRepository _repository;

        public InostrankabooksManager(IInostrankabooksService inostrankabooksService, IRepository repository)
        {
            _inostrankabooksService = inostrankabooksService;
            _repository = repository;
        }

        public int GetProgressMax()
        {
            return _inostrankabooksService.ProgresMax;
        }

        public int GetProgressNow()
        {
            return _inostrankabooksService.ProgresNow;
        }

        public void GetInfo(string folder)
        {
            var mainUrl = "http://inostrankabooks.ru";
            _inostrankabooksService.ProgresMax = 0;
            _inostrankabooksService.ProgresNow = 0;

            var series = _inostrankabooksService.GetListSeries(mainUrl);

            var pages = new List<string>();
            Parallel.ForEach(series, i =>
            {
                var result = _inostrankabooksService.GetListPages(i, mainUrl);
                if (result.Count > 0)
                {
                    foreach (var cout in result)
                    {
                        pages.Add(cout);
                    }
                }
            });

            var info = _inostrankabooksService.GetInfoBooks(pages, mainUrl);
            var infoStr = _inostrankabooksService.ConvertInfoToString(info);
            _repository.WriteToFile(infoStr, "inostrankabooks", folder);
        }
    }
}
