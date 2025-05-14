namespace ContaCorrente.ConsoleApp
{
    public static class Operacoes
    {
        public static string Depositar(CriarConta conta, double valor)
        {
            string mensagem;
            if (valor < conta.limiteDebito)
            {
                mensagem = $"Valor insufuciente para depósito![R${valor}]";
                Console.WriteLine(mensagem);
                conta.extrato[conta.contadorExtrato] += Convert.ToString(mensagem);
                conta.contadorExtrato++;
                return mensagem;
            }
            conta.AdicionarSaldo(valor);
            mensagem = $"Depósito de R${valor} realizado!";
            Console.WriteLine(mensagem);
            conta.extrato[conta.contadorExtrato] += Convert.ToString(mensagem);
            conta.contadorExtrato++;
            return mensagem;

        }
        public static string Sacar(CriarConta conta, double valor)
        {
            string mensagem;
            if (valor > conta.GetSaldo() || valor < conta.limiteDebito)
            {
                mensagem = $"Saldo insufuciente para saque![R${valor}]";
                Console.WriteLine(mensagem);
                conta.extrato[conta.contadorExtrato] += Convert.ToString(mensagem);
                conta.contadorExtrato++;
                return mensagem;
            }
            conta.SubtrairSaldo(valor);
            mensagem = $"Saque de R$ {valor} realizado!";
            Console.WriteLine(mensagem);
            conta.extrato[conta.contadorExtrato] += Convert.ToString(mensagem);
            conta.contadorExtrato++;
            return mensagem;
        }

        public static void ConsultarSaldo(CriarConta conta)
        {
            Console.WriteLine("\n--------------- Saldo da conta ---------------".ToUpper());
            Console.WriteLine($"Conta Corrente: {conta.numeroConta}\tSaldo: {conta.GetSaldo()}\tLimite de Débito: {conta.limiteDebito}");
            Console.WriteLine("--------------- Fim do Saldo da conta ---------------\n".ToUpper());
        }

        public static void EmitirExtrato(CriarConta conta)
        {
            Console.WriteLine("\n--------------- Extrato da conta ---------------".ToUpper());
            Console.WriteLine($"Conta Corrente: {conta.numeroConta}\t Saldo: {conta.GetSaldo()}");

            if (conta.contadorExtrato == 0)
            {
                Console.WriteLine("Sem movimentações na conta ainda!");
                return;
            }

            for (int i = 0; i < conta.contadorExtrato; i++)
            {
                if (!string.IsNullOrEmpty(conta.extrato[i]))
                {
                    Console.WriteLine($" - {conta.extrato[i]}");
                }
            }
            Console.WriteLine("--------------- Fim do Extrato da conta ---------------\n".ToUpper());
        }

        public static void Transferir(CriarConta contaDebitada, CriarConta contaCreditada, int valor)
        {
            string mensagemTransferenciaRealizada;
            string mensagemTransferenciaRecebida;
            if (contaDebitada.GetSaldo() <= 0 || contaDebitada.GetSaldo() < valor || valor <= 0)
            {
                Console.WriteLine($"Sem fundos suficientes para transferência![R${valor}]");
                return;
            }

            if (contaDebitada.numeroConta == contaCreditada.numeroConta)
            {
                Console.WriteLine("Transferência para a própria conta não é permitida!");
                return;
            }

            contaDebitada.SubtrairSaldo(valor);
            contaCreditada.AdicionarSaldo(valor);
            mensagemTransferenciaRealizada = $"Transferência realizada para a conta {contaCreditada.numeroConta}! R${valor}";
            mensagemTransferenciaRecebida = $"Transferência recebida da conta {contaDebitada.numeroConta}! R${valor}";

            contaDebitada.extrato[contaDebitada.contadorExtrato] += Convert.ToString(mensagemTransferenciaRealizada);
            contaDebitada.contadorExtrato++;

            contaCreditada.extrato[contaCreditada.contadorExtrato] += Convert.ToString(mensagemTransferenciaRecebida);
            contaCreditada.contadorExtrato++;
            Console.WriteLine(mensagemTransferenciaRealizada);
        }
    }
}
