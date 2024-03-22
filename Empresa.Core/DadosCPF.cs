namespace Empresa.Core
{
    public class DadosCPF
    {
        public DateTime DataHora { get; set; }
        public bool Valido { get; set; }
        public string? CPF { get; set; }
        public string? Origem { get; set; }
        public string? Mensagem { get; set; }

        public static DadosCPF VerificarCPF(string CPF)
        {
            DadosCPF Obj = new()
            {
                DataHora = DateTime.Now,
                Valido = false,
                CPF = null,
                Origem = null,
                Mensagem = ""
            };

            RespostaVerificacao DadosEntrada = VerificarDadosEntrada(CPF);
            if (DadosEntrada.Valido == false)
            {
                Obj.Mensagem = DadosEntrada.Mensagem;
                Obj.Valido = DadosEntrada.Valido;
                return Obj;
            }

            RespostaVerificacao CPFnumerico = VerificarCPFnumerico(CPF);
            if (CPFnumerico.Valido == false)
            {
                Obj.Mensagem = CPFnumerico.Mensagem;
                Obj.Valido = CPFnumerico.Valido;
                return Obj;
            }

            string CPFNum;
            if (CPFnumerico.Mensagem == null) CPFNum = "";
            else CPFNum = CPFnumerico.Mensagem;


            RespostaVerificacao FalsoPositivo = VerificarFalsoPositivo(CPFNum);
            if (FalsoPositivo.Valido == false)
            {
                Obj.Mensagem = FalsoPositivo.Mensagem;
                Obj.Valido = FalsoPositivo.Valido;
                return Obj;
            }

            RespostaVerificacao CPFVerificado = ConfereVerificador(CPFNum);
            if (CPFVerificado.Valido == false)
            {
                Obj.Mensagem = CPFVerificado.Mensagem;
                Obj.Valido = CPFVerificado.Valido;
                return Obj;
            }

            string CPFFormatado = FormataCPF(CPFNum);
            string EstadoOrigem = BuscarEstadoOrigem(CPFNum);
            Obj.CPF = CPFFormatado;
            Obj.Origem = EstadoOrigem;
            Obj.Valido = true;
            Obj.Mensagem = "O CPF inserido foi verificado e ele é válido";
            return Obj;
        }
        private static RespostaVerificacao VerificarDadosEntrada(string CPF)
        {
            if (CPF == null)
            {
                return new RespostaVerificacao
                {
                    Valido = false,
                    Mensagem = "O campo de entrada dos dados está em branco"
                };
            }
            if (CPF.Length > 14)
            {
                return new RespostaVerificacao
                {
                    Valido = false,
                    Mensagem = "O valor de entrada possui muitos caracteres"
                };
            }
            if (CPF.Length < 11)
            {
                return new RespostaVerificacao
                {
                    Valido = false,
                    Mensagem = "O valor de entrada possui poucos caracteres"
                };
            }
            return new RespostaVerificacao
            {
                Valido = true,
                Mensagem = "Ok"
            };
        }
        private static RespostaVerificacao VerificarCPFnumerico(string CPF)
        {
            string CPFnumerico = "";
            int pos = 1;

            foreach (char caractere in CPF)
            {
                if (char.IsDigit(caractere))
                {
                    CPFnumerico += caractere;
                }
                else
                {
                    if ((caractere == '.' || caractere == '-') && CPF.Length == 14)
                    {
                        if (caractere == '.' && (pos != 4 && pos != 8))
                        {
                            return new RespostaVerificacao
                            {
                                Valido = false,
                                Mensagem = "Formato incorreto - Verifique os pontos '.' e o traço '-'"
                            };
                        }
                        if (caractere == '-' && pos != 12)
                        {
                            return new RespostaVerificacao
                            {
                                Valido = false,
                                Mensagem = "Formato incorreto - Verifique os pontos '.' e o traço '-'"
                            };
                        }
                    }

                    else
                    {
                        return new RespostaVerificacao
                        {
                            Valido = false,
                            Mensagem = "Caracteres incorretos - Coloque apenas os números e/ou os pontos e o traço"
                        };
                    }
                }
                pos++;
            }

            if (CPFnumerico.Length != 11)
            {
                return new RespostaVerificacao
                {
                    Valido = false,
                    Mensagem = "O valor inserido não possui 11 caracteres numéricos"
                };
            }

            return new RespostaVerificacao
            {
                Valido = true,
                Mensagem = CPFnumerico
            };
        }
        private static RespostaVerificacao VerificarFalsoPositivo(string CPF)
        {
            int n = CPF.Length;
            for (int i = 1; i < n; i++)
            {
                if (CPF[i] != CPF[0])
                {
                    return new RespostaVerificacao
                    {
                        Valido = true,
                        Mensagem = "Ok"
                    };
                }
            }

            return new RespostaVerificacao
            {
                Valido = false,
                Mensagem = "Este CPF é invalido - Trata-se de um Falso positivo"
            };
        }

        private static RespostaVerificacao ConfereVerificador(string CPF)
        {
            int VerificadorUm = CalcularVerificador(CPF, 1);
            int VerificadorDois = CalcularVerificador(CPF, 2);

            int VerificadorUmEntrada = Convert.ToInt32(CPF.Substring(9, 1));
            int VerificadorDoisEntrada = Convert.ToInt32(CPF.Substring(10, 1));

            if (VerificadorUm != VerificadorUmEntrada || VerificadorDois != VerificadorDoisEntrada)
            {
                return new RespostaVerificacao
                {
                    Valido = false,
                    Mensagem = "O cálculo realizado indica que o CPF é invalido"
                };
            }
            return new RespostaVerificacao
            {
                Valido = true,
                Mensagem = "Ok"
            };
        }
        private static int CalcularVerificador(string CPF, int PosicaoVerficador)
        {
            int Peso = 0;
            int PosicaoCPF = 0;
            if (PosicaoVerficador == 1) Peso = 1;

            int somaPesos = 0;

            while (Peso < 10)
            {
                somaPesos += Peso * Convert.ToInt32(CPF.Substring(PosicaoCPF, 1));
                Peso++;
                PosicaoCPF++;
            }

            int DigVerificador = somaPesos % 11;
            return DigVerificador;
        }
        private static string FormataCPF(string CPF)
        {
            string CPFFormatado = "";

            CPFFormatado += CPF.Substring(0, 3);
            CPFFormatado += ".";
            CPFFormatado += CPF.Substring(3, 3);
            CPFFormatado += ".";
            CPFFormatado += CPF.Substring(6, 3);
            CPFFormatado += "-";
            CPFFormatado += CPF.Substring(9, 2);

            return CPFFormatado;
        }
        private static string BuscarEstadoOrigem(string CPF)
        {
            int verificador = Convert.ToInt32(CPF.Substring(8, 1));
            List<string> Estados = new() {
                "Rio Grande do Sul",
                "Distrito Federal, Goiás, Mato Grosso, Mato Grosso do Sul ou Tocantins",
                "Amazonas, Pará, Roraima, Amapá, Acre ou Rondônia",
                "Ceará, Maranhão ou Piauí",
                "Paraíba, Pernambuco, Alagoas ou Rio Grande do Norte",
                "Bahia ou Sergipe",
                "Minas Gerais",
                "Rio de Janeiro ou Espírito Santo",
                "São Paulo",
                "Paraná ou Santa Catarina"
            };
            return Estados[verificador];
        }
    }

    internal class RespostaVerificacao
    {
        public bool Valido { get; set; }
        public string Mensagem { get; set; }
    }
}
