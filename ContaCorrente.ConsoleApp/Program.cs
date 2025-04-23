using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        //Além disso, a conta mantém um registro de movimentações financeiras, que englobam todas as transações realizadas.
        static void Main(string[] args)
        {
            CriarConta conta1 = new CriarConta();
            //conta1.numeroId += 1;
            conta1.saldo = 1000.0;
            //conta1.limiteDebito = 500;
            Console.WriteLine($"ID: {conta1.numeroConta}\nSaldo: {conta1.saldo}\nLimite de Débito: {conta1.limiteDebito}");
            Console.WriteLine("------------------------------------------------------------");

            CriarConta conta2=new CriarConta();
            Console.WriteLine($"ID: {conta2.numeroConta}\nSaldo: {conta2.saldo}\nLimite de Débito: {conta2.limiteDebito}");
            Console.ReadLine();
        }
    }
    public class CriarConta()
    {
        //número de identificação único,
        static int numeroId = 1000;
        public int numeroConta =numeroId++;
        //um saldo disponível
        public double saldo = 0;
        //e um limite de débito estabelecido.
        public int limiteDebito = 0;
    }
}
