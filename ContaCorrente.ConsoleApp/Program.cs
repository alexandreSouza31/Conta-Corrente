using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CriarConta conta1 = new CriarConta();
 
            Operacoes.Depositar(conta1, -300);
            Operacoes.ConsultarSaldo(conta1);
            Operacoes.EmitirExtrato(conta1);

            CriarConta conta2=new CriarConta();
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
            mensagem = $"Depósito de R${valor} realizado com sucesso!";
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
            mensagem = $"Saque de R$ {valor} realizado com sucesso!";
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
            Console.WriteLine($"Conta Corrente: {conta.numeroConta}");

            if (conta.contadorExtrato == 0) 
            {
                Console.WriteLine("Sem movimentações na conta ainda!"); 
                return;
            }

            for(int i = 0; i < conta.contadorExtrato; i++)
                {
                if (!string.IsNullOrEmpty(conta.extrato[i]))
                    {
                        Console.WriteLine($" - {conta.extrato[i]}");
                    }
                }
            Console.WriteLine("--------------- Fim do Extrato da conta ---------------\n".ToUpper());
        }
    }
}
