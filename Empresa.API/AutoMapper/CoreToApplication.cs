using AutoMapper;
using Empresa.Core;
using Empresa.WebAPI.Models;

namespace Empresa.WebAPI.AutoMapper
{
    public class CoreToApplication : Profile
    {

        public CoreToApplication()
        {
            CreateMap<Funcionario, FuncionarioDto>();
        }
    }
}
