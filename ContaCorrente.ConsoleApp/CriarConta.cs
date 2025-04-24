namespace ContaCorrente.ConsoleApp
{
    public class CriarConta()
    {
        static int numeroId = 1000;
        public int numeroConta = numeroId++;
        public double saldo = 0;
        public int limiteDebito = 0;
        public string[] extrato = new string[10];
        public int contadorExtrato = 0;
    }
}
