namespace ContaCorrente.ConsoleApp
{
    public class CriarConta
    {
        Movimentacao movimentacao;
        static int numeroId = 1000;
        public int numeroConta = numeroId++;
        private double saldo = 0;
        public int limiteDebito = 0;
        public Movimentacao[] movimentacoes = new Movimentacao[10];
        public int contadorMovimentacoes = 0;

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

        public void RegistrarMovimentacao(string tipo, double valor)
        {
            if (contadorMovimentacoes < movimentacoes.Length)
            {
                movimentacoes[contadorMovimentacoes] = new Movimentacao
                {
                    tipo = tipo,
                    valor = (decimal)valor
                };
                contadorMovimentacoes++;
            }
        }
    }
}
