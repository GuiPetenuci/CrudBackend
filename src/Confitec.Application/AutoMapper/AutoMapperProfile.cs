using AutoMapper;
using Confitec.Application.ViewModels;
using Confitec.Domain.Entities;

namespace Confitec.Application.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
    }
}
