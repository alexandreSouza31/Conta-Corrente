using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CriarConta conta1 = new CriarConta();
 
            Operacoes.Depositar(conta1, -300);
            Console.WriteLine($"Conta Corrente: {conta1.numeroConta}\nSaldo: {conta1.saldo}\nLimite de Débito: {conta1.limiteDebito}");
            Console.WriteLine("------------------------------------------------------------");

            CriarConta conta2=new CriarConta();
            Operacoes.Depositar(conta2, 500);
            Operacoes.Sacar(conta2, 1000);
            Console.WriteLine($"Conta Corrente: {conta2.numeroConta}\nSaldo: {conta2.saldo}\nLimite de Débito: {conta2.limiteDebito}");
            Console.ReadLine();
        }
    }
    public class CriarConta()
    {
        static int numeroId = 1000;
        public int numeroConta =numeroId++;
        public double saldo = 0;
        public int limiteDebito = 0;
    }

    public static class Operacoes
    {
        public static void Depositar(CriarConta conta, double valor)
        {
            if (valor < conta.limiteDebito)
            {
                Console.WriteLine("Valor insufuciente para depósito!");
                return;
            }
            conta.saldo += valor;
        }
        public static void Sacar(CriarConta conta, double valor)
        {
            if (valor > conta.limiteDebito) 
            {
                Console.WriteLine("Saldo insufuciente para saque!");
                return;
            } 
            conta.saldo -= valor;
        }
    }
}
