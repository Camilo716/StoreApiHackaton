using AutoMapper;
using HackatonApi.DTOs;
using HackatonApi.Models;

namespace HackatonApi.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ProductCreationDTO, Product>();
    }
}