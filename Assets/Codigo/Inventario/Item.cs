using System;

namespace LendasDoOriente.Inventario
{
    public enum TipoItem { Consumivel, Arma, Armadura, Material, Missao }

    [Serializable]
    public sealed class Item
    {
        public string Id { get; }
        public string Nome { get; }
        public TipoItem Tipo { get; }
        public int QuantidadeMaxima { get; }

        public Item(string id, string nome, TipoItem tipo, int quantidadeMaxima = 1)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID obrigatório.", nameof(id));
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome obrigatório.", nameof(nome));
            if (quantidadeMaxima < 1) throw new ArgumentOutOfRangeException(nameof(quantidadeMaxima));
            Id = id;
            Nome = nome;
            Tipo = tipo;
            QuantidadeMaxima = quantidadeMaxima;
        }
    }
}