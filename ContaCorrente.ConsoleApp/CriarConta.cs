namespace ContaCorrente.ConsoleApp
{
    public class CriarConta
    {
        static int numeroId = 1000;
        public int numeroConta = numeroId++;
        private double saldo = 0;
        private int limite;
        private Movimentacao[] movimentacoes;
        public int contadorMovimentacoes = 0;

        public Operacoes Operacoes;

        public CriarConta()
        {
            Operacoes = new Operacoes(this);
            movimentacoes = new Movimentacao[10];
            limite = 200;
        }

        public Movimentacao[] GetMovimentacoes()
        {
            return movimentacoes;
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

        public int GetLimite()
        {
            return limite;
        }
    }
}
