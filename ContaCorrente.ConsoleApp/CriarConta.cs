namespace ContaCorrente.ConsoleApp
{
    public class CriarConta
    {
        static int numeroId = 1000;
        public int numeroConta = numeroId++;
        private double saldo = 0;
        public int limiteDebito = 0;
        public string[] extrato = new string[10];
        public int contadorExtrato = 0;

        public Operacoes Operacoes;

        public CriarConta()
        {
            Operacoes = new Operacoes(this);
        }

        public double GetSaldo()
        {
            return saldo;
        }

        public void AdicionarSaldo(double valor)
        {
            saldo += valor;
        }

        public void SubtrairSaldo(double valor)
        {
            saldo -= valor;
        }
    }
}
