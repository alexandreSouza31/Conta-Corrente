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
            Operacoes.Sacar(conta1, 200);
            Operacoes.EmitirExtrato(conta1);

            Operacoes.Depositar(conta2, 500);
            Operacoes.Sacar(conta2, 1000);
            Operacoes.ConsultarSaldo(conta2);
            Operacoes.EmitirExtrato(conta2);
            Console.ReadLine();
        }
    }
}