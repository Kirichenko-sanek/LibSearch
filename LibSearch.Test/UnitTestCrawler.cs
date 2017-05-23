using System.Collections.Generic;
using LibSearch.Core.Model.Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibSearch.Crawler.BL.Services;

namespace LibSearch.Test
{
    [TestClass]
    public class UnitTestCrawler
    {
        [TestMethod]
        public void TestGetListSeries()
        {
            var url = "http://inostrankabooks.ru";
            var service = new InostrankabooksService();

            List<string> actual;
            actual = service.GetListSeries(url);

            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void TestGetListPages()
        {
            var mainUrl = "http://inostrankabooks.ru";
            var url = "http://inostrankabooks.ru/ru/seria/839/";
            var service = new InostrankabooksService();

            List<string> actual;
            actual = service.GetListPages(url, mainUrl);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestInfoBooks()
        {
            var mainUrl = "http://inostrankabooks.ru";
            var url = "http://inostrankabooks.ru/ru/book/25468/";
            var service = new InostrankabooksService();
            var list = new List<string>();
            list.Add(url);

            List<BookOfInostrankabooks> actual;
            actual = service.GetInfoBooks(list, mainUrl);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestConvertInfoToString()
        {
            var book = new BookOfInostrankabooks()
            {
                Author = "Ю Несбё",
                Category = "Авторская серия Ю Несбё ",
                Name = "Снеговик",
                PageUrl = "http://inostrankabooks.ru/ru/book/25468/",
                Photo = "http://inostrankabooks.ru/img/book/w240/978-5-389-11463-0.jpg",
                Summary =
                    " Ю Несбё — самый известный норвежский писатель, обладатель более двух десятков наград в номинациях «Книга года», «Лучший детектив года», «Выбор читателей», премии «Стеклянный ключ» за лучший скандинавский триллер. Его романы, переведенные более чем на 40 языков, отличает напряженная, безукоризненно выстроенная интрига, яркие характеры и всегда неожиданная развязка.Уже несколько лет в тот день, когда выпадает первый снег, в Норвегии бесследно исчезают замужние женщины. Невинная детская игра в снеговика оборачивается кошмаром, а для Харри Холе погоня за серийным убийцей становится охотой на тень. Преступник будто дразнит старшего инспектора, обретая все новые и новые обличья..Хронология серии детективов о Харри Холе:1.\tНетопырь2.\tТараканы3.\tКрасношейка4.\tНемезида5.\tПентаграмма6.\tСпаситель7.\tСнеговик8.\tЛеопард 9.\tПризрак 10. Полиция"
            };
            var service = new InostrankabooksService();
            var list = new List<BookOfInostrankabooks>();
            list.Add(book);

            string actual;
            actual = service.ConvertInfoToString(list);

            Assert.IsNotNull(actual);
        }
    }
}
