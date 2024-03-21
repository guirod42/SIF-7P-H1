using Microsoft.AspNetCore.Mvc;
using Empresa.Core;
using Empresa.WebAPI.Models;
using AutoMapper;
namespace Empresa.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private IMapper _mapper;

        public FuncionarioController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("NovoFuncionario")]
        public IActionResult NovoFuncionario(FuncionarioDto funcionarioDto)
        {
            try
            {
                _mapper.Map<Funcionario>(funcionarioDto);

                return Ok(new { status = true, Mensagem = "UsuarioCriado" });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, Mensagem = ex.Message });
            }
        }
    }
}
