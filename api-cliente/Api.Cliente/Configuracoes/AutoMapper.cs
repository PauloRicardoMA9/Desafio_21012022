using Api.Cliente.Domain.Objetos;
using Api.Cliente.ViewModels;
using AutoMapper;

namespace Api.Cliente.Configuracoes
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Domain.Objetos.Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Telefone, TelefoneViewModel>();
        }
    }
}
