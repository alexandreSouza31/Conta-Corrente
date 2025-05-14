namespace ContaCorrente.ConsoleApp
{
    public class Operacoes
    {
        private CriarConta conta;

        public Operacoes(CriarConta conta)
        {
            this.conta = conta;
        }

        public string Depositar( double valor)
        {
            string mensagem;
            if (valor < conta.limiteDebito)
            {
                mensagem = $"Depósito inválido!";
                conta.RegistrarMovimentacao($"{mensagem}", valor);
                conta.contadorMovimentacoes++;
                mensagem += $"[{valor}]";
                Console.WriteLine(mensagem);
                return mensagem;
            }
            conta.AdicionarSaldo(valor);
            mensagem = $"Depósito realizado!";
            conta.RegistrarMovimentacao($"{mensagem}", valor);
            mensagem += $"[{valor}]";
            Console.WriteLine(mensagem);
            return mensagem;
        }
        public string Sacar(double valor)
        {
            string mensagem;
            if (valor > conta.GetSaldo() || valor < conta.limiteDebito)
            {
                mensagem = $"Saque inválido!";
                conta.RegistrarMovimentacao($"{mensagem}", valor);
                mensagem += $"[{valor}]";
                Console.WriteLine(mensagem);
                conta.contadorMovimentacoes++;
                return mensagem;
            }
            conta.SubtrairSaldo(valor);
            mensagem = $"Saque realizado!";
            conta.RegistrarMovimentacao($"{mensagem}", valor);
            mensagem += $"[{valor}]";
            Console.WriteLine(mensagem);
            conta.contadorMovimentacoes++;
            return mensagem;
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine("\n--------------- Saldo da conta ---------------".ToUpper());
            Console.WriteLine($"Conta Corrente: {conta.numeroConta}\tSaldo: {conta.GetSaldo()}\tLimite de Débito: {conta.limiteDebito}");
            Console.WriteLine("--------------- Fim do Saldo da conta ---------------\n".ToUpper());
        }

        public void EmitirExtrato()
        {
            Console.WriteLine("\n--------------- Extrato da conta ---------------".ToUpper());
            Console.WriteLine($"Conta Corrente: {conta.numeroConta}\t Saldo: {conta.GetSaldo()}");

            if (conta.contadorMovimentacoes == 0)
            {
                Console.WriteLine("Sem movimentações na conta ainda!");
                return;
            }

            for (int i = 0; i < conta.contadorMovimentacoes; i++)
            {
                if (conta.movimentacoes[i] != null)
                {
                    Console.WriteLine($" - {conta.movimentacoes[i].LerMovimentacao()}");
                }
            }
            Console.WriteLine("--------------- Fim do Extrato da conta ---------------\n".ToUpper());
        }

        public string Transferir(CriarConta contaDestino, double valor)
        {
            var contaDebitada = conta;
            var contaCreditada = contaDestino;

            if (contaDebitada.GetSaldo() <= 0 || contaDebitada.GetSaldo() < valor || valor <= 0)
            {
                string mensagem = $"Transferência inválida!";
                conta.RegistrarMovimentacao(mensagem, valor);
                mensagem += $"[{valor}]";
                Console.WriteLine(mensagem);
                return mensagem;
            }

            if (contaDebitada.numeroConta == contaCreditada.numeroConta)
            {
                return "Transferência para a própria conta não é permitida!";
            }

            contaDebitada.SubtrairSaldo(valor);
            contaCreditada.AdicionarSaldo(valor);

            string mensagemTransferenciaRealizada = $"Transferência realizada para a conta {contaCreditada.numeroConta}!";
            string mensagemTransferenciaRecebida = $"Transferência recebida da conta {contaDebitada.numeroConta}!";

            contaDebitada.RegistrarMovimentacao(mensagemTransferenciaRealizada, valor);
            contaCreditada.RegistrarMovimentacao(mensagemTransferenciaRecebida, valor);

            mensagemTransferenciaRealizada += $"[{valor}]";
            Console.WriteLine(mensagemTransferenciaRealizada);
            return mensagemTransferenciaRealizada;
        }

    }
}
