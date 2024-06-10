using AutoMapper;

namespace BookInfo.API.Profiles
{
    public class TitleAuthorProfile : Profile
    {
        public TitleAuthorProfile()
        {
            CreateMap<Entities.Titleauthor, Models.TitleauthorDto>();
        }
    }
}
