using System;

namespace LendasDoOriente.Combate
{
    public sealed class Habilidade
    {
        public string Id { get; }
        public string Nome { get; }
        public int CustoMana { get; }
        public int Poder { get; }
        public float RecargaSegundos { get; }

        public Habilidade(string id, string nome, int custoMana, int poder, float recargaSegundos)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID obrigatório.", nameof(id));
            if (custoMana < 0 || poder < 0 || recargaSegundos < 0) throw new ArgumentOutOfRangeException();
            Id = id; Nome = nome ?? string.Empty; CustoMana = custoMana; Poder = poder; RecargaSegundos = recargaSegundos;
        }
    }
}