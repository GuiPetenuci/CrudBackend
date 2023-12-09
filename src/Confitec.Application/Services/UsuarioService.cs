using AutoMapper;
using Confitec.Application.Interfaces.Services;
using Confitec.Application.ViewModels;
using Confitec.Domain;
using Confitec.Domain.Entities;

namespace Confitec.Application;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task Add(UsuarioViewModel viewModel)
    {
        await _usuarioRepository.Add(_mapper.Map<Usuario>(viewModel));
    }

    public async Task Update(UsuarioViewModel viewModel)
    {
        await _usuarioRepository.Update(_mapper.Map<Usuario>(viewModel));
    }

    public async Task<IList<UsuarioViewModel>> GetAll()
    {
        return _mapper.Map<IList<UsuarioViewModel>>(await _usuarioRepository.GetAll());
    }

    public async Task<UsuarioViewModel?> GetById(Guid id)
    {
        return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.GetById(id));
    }

    public async Task Remove(Guid id)
    {
        await _usuarioRepository.Remove(id);
    }
}