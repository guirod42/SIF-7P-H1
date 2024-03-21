using Empresa.Core;
using System.Net;

namespace Empresa.Tests
{
    public class FuncionarioTests
    {
        public class TestesExercicio
        {
            readonly string NomeOk = "Guilherme Silva Rodrigues";
            readonly double SalarioOk = 2024.42f;
            readonly string CPFOk = "11634098633";
            readonly List<string> HabilidadesOk = ["Habilidade1", "Habilidade2", "Habilidade3"];

            [Theory]
            [InlineData("", "Nome em branco")]
            public void TestarFuncionarioSemNome(string nomeTeste, string resultado)
            {
                var resultadoExcecao = Assert.Throws<Exception>(()
                    => new Funcionario(nomeTeste, SalarioOk, CPFOk, HabilidadesOk));

                Assert.Equal(resultado, resultadoExcecao.Message);
            }

            [Theory]
            [InlineData(1999.99, NivelProfissional.Junior)]
            [InlineData(2000.00, NivelProfissional.Pleno)]
            [InlineData(7999.99, NivelProfissional.Pleno)]
            [InlineData(8000.00, NivelProfissional.Senior)]
            public void TestarNivelProfissionalPorSalario(double salarioTeste, NivelProfissional resultado)
            {
                Funcionario teste = new(NomeOk, salarioTeste, CPFOk, HabilidadesOk);
                Assert.Equal(resultado, teste.NivelProfissional);
            }

            [Theory]
            [InlineData(0, "Salário zerado ou negativo")]
            [InlineData(-1, "Salário zerado ou negativo")]
            [InlineData(-1000, "Salário zerado ou negativo")]
            public void TestarSalarioZeroOuNegativo(double salarioTeste, string resultado)
            {
                var resultadoExcecao = Assert.Throws<Exception>(()
                    => new Funcionario(NomeOk, salarioTeste, CPFOk, HabilidadesOk));

                Assert.Equal(resultado, resultadoExcecao.Message);
            }

            [Theory]
            [InlineData("Habilidade1", "Habilidade2")]
            [InlineData("HabilidadeA", "HabilidadeB")]
            [InlineData("Preenchida1", "Preenchida2 ", "", "", "", "")]
            public void TestarQuantidadeMinimaHabilidades(params string[] habilidades)
            {
                List<string> listaDeHabilidades = habilidades.ToList();

                var resultadoExcecao = Assert.Throws<Exception>(()
                    => new Funcionario(NomeOk, SalarioOk, CPFOk, listaDeHabilidades));

                Assert.Equal("Precisa de ao menos 3 habilidades", resultadoExcecao.Message);
            }

            [Theory]
            [InlineData("", "CPF inválido")]
            [InlineData("360514040810597", "CPF inválido")]
            [InlineData("513.666.800-820", "CPF inválido")]
            public void TestarCPFInvalido(string cpfTeste, string resultado)
            {
                var resultadoExcecao = Assert.Throws<Exception>(()
                    => new Funcionario(NomeOk, SalarioOk, cpfTeste, HabilidadesOk));

                Assert.Equal(resultado, resultadoExcecao.Message);
            }
        }
    }
}