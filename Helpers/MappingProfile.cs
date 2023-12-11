using AutoMapper;
using movieApi.Dtos;
using movieApi.Models;

namespace movieApi.Helpers
{
    public class MappingProfile:Profile
    {
        MappingProfile()
        {

        CreateMap<Movie, MovieDetailsDto> ();
        CreateMap<MovieDto, Movie>()
        .ForMember(src => src.Poster, opt=> opt.Ignore());
        }
    }
}
