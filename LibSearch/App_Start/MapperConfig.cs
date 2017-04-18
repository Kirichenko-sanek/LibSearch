using AutoMapper;
using LibSearch.Core.Model;
using LibSearch.Core.ViewModel;

namespace LibSearch.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>().AfterMap((p, m) =>
                {
                    m.IdBook = p.Id;
                    m.Name = p.Name;
                    m.Category = p.Category;
                    m.Author = p.Author;
                    m.Summary = p.Summary;
                    m.PageUrl = p.PageUrl;
                    m.IdPhoto = p.IdPhoto;
                    m.Photo = p.Photo.Url;
                });
            });
        }
    }
}