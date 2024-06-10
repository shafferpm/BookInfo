using AutoMapper;
using BookInfo.API.Entities;
using BookInfo.API.Models;

namespace BookInfo.API.Profiles
{
    // This class derives from Profile, which is a class from the AutoMapper library.
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            // CreateMap is a method from the Profile class that creates a map between the source and destination types.
            // The source type is Author, and the destination type is AuthorDto.
            CreateMap<Entities.Author, Models.AuthorDto>();
            CreateMap<Entities.Author, Models.AuthorWithoutTitleDto>();
            CreateMap<Models.AuthorForCreationDto, Entities.Author>();
            CreateMap<Models.AuthorForUpdateDto, Entities.Author>();
            CreateMap<Entities.Author, Models.AuthorForUpdateDto>();
        }
    }
}
