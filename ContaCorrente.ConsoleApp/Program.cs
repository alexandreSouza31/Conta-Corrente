using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conta1 = new CriarConta();
            var conta2 = new CriarConta();

            conta1.Operacoes.Depositar(-300);
            conta1.Operacoes.Depositar(100);
            conta1.Operacoes.ConsultarSaldo();
            conta1.Operacoes.Transferir(conta2, 50);
            conta1.Operacoes.Sacar(200);
            conta1.Operacoes.EmitirExtrato();

            conta2.Operacoes.Depositar(500);
            conta2.Operacoes.Sacar(1000);
            conta2.Operacoes.ConsultarSaldo();
            conta2.Operacoes.EmitirExtrato();
            Console.ReadLine();
        }
    }
}