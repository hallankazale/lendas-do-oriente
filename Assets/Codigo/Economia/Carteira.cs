using System;

namespace LendasDoOriente.Economia
{
    public sealed class Carteira
    {
        public long MoedasImperiais { get; private set; }

        public void Creditar(long quantidade)
        {
            if (quantidade < 0) throw new ArgumentOutOfRangeException(nameof(quantidade));
            checked { MoedasImperiais += quantidade; }
        }

        public bool TentarDebitar(long quantidade)
        {
            if (quantidade < 0) return false;
            if (quantidade > MoedasImperiais) return false;
            MoedasImperiais -= quantidade;
            return true;
        }
    }
}