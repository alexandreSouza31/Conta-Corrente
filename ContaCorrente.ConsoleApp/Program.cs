using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CriarConta conta1 = new CriarConta();
            CriarConta conta2=new CriarConta();
 
            Operacoes.Depositar(conta1, -300);
            Operacoes.Depositar(conta1, 100);
            Operacoes.ConsultarSaldo(conta1);
            Operacoes.Transferir(conta1, conta2, 50);
            Operacoes.Sacar(conta1, 20);
            Operacoes.EmitirExtrato(conta1);

            Operacoes.Depositar(conta2, 500);
            Operacoes.Sacar(conta2, 1000);
            Operacoes.ConsultarSaldo(conta2);
            Operacoes.EmitirExtrato(conta2);
            Console.ReadLine();
        }
    }
    public class CriarConta()
    {
        static int numeroId = 1000;
        public int numeroConta =numeroId++;
        public double saldo = 0;
        public int limiteDebito = 0;
        public string[] extrato = new string[10];
        public int contadorExtrato = 0;
    }

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
            conta.saldo += valor;
            mensagem = $"Depósito de R${valor} realizado!";
            Console.WriteLine(mensagem);
            conta.extrato[conta.contadorExtrato] += Convert.ToString(mensagem);
            conta.contadorExtrato++;
            return mensagem;

        }
        public static string Sacar(CriarConta conta, double valor)
        {
            string mensagem;
            if (valor > conta.limiteDebito)
            {
                mensagem = $"Saldo insufuciente para saque![R${valor}]";
                Console.WriteLine(mensagem);
                conta.extrato[conta.contadorExtrato] += Convert.ToString(mensagem);
                conta.contadorExtrato++;
                return mensagem;
            }
            conta.saldo -= valor;
            mensagem = $"Saque de R$ {valor} realizado!";
            Console.WriteLine(mensagem);
            conta.extrato[conta.contadorExtrato] += Convert.ToString(mensagem);
            conta.contadorExtrato++;
            return mensagem;
        }

        public static void ConsultarSaldo(CriarConta conta)
        {
            Console.WriteLine("\n--------------- Saldo da conta ---------------".ToUpper());
            Console.WriteLine($"Conta Corrente: {conta.numeroConta}\tSaldo: {conta.saldo}\tLimite de Débito: {conta.limiteDebito}");
            Console.WriteLine("--------------- Fim do Saldo da conta ---------------\n".ToUpper());
        }

        public static void EmitirExtrato(CriarConta conta)
        {
            Console.WriteLine("\n--------------- Extrato da conta ---------------".ToUpper());
            Console.WriteLine($"Conta Corrente: {conta.numeroConta}\t Saldo: {conta.saldo}");

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

        public static void Transferir(CriarConta contaDebitada,CriarConta contaCreditada, int valor)
        {
            string mensagemTransferenciaRealizada;
            string mensagemTransferenciaRecebida;
            if(contaDebitada.saldo <= 0 || contaDebitada.saldo < valor)
            {
                Console.WriteLine($"Sem fundos suficientes para transferência![R${valor}]");
                return;
            }

            if (contaDebitada.numeroConta == contaCreditada.numeroConta)
            {
                Console.WriteLine("Transferência para a própria conta não é permitida!");
                return;
            }

            contaDebitada.saldo -= valor;
            contaCreditada.saldo += valor;
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