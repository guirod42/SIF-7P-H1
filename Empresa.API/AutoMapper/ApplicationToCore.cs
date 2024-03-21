using AutoMapper;
using Empresa.Core;
using Empresa.WebAPI.Models;

namespace Empresa.WebAPI.AutoMapper
{
    public class ApplicationToCore : Profile
    {
        public ApplicationToCore()
        {
            CreateMap<FuncionarioDto, Funcionario>()
           .ConstructUsing(f => new Funcionario(f.Nome, f.Salario, f.CPF, f.Habilidades));

        }
    }
}
