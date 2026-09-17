using System;
using System.Collections.Generic;

namespace LendasDoOriente.Inventario
{
    public sealed class InventarioPersonagem
    {
        private readonly Dictionary<string, int> itens = new();
        public int CapacidadeSlots { get; }
        public IReadOnlyDictionary<string, int> Itens => itens;

        public InventarioPersonagem(int capacidadeSlots = 24)
        {
            if (capacidadeSlots < 1) throw new ArgumentOutOfRangeException(nameof(capacidadeSlots));
            CapacidadeSlots = capacidadeSlots;
        }

        public bool TentarAdicionar(Item item, int quantidade = 1)
        {
            if (item == null || quantidade < 1) return false;
            itens.TryGetValue(item.Id, out int atual);
            if (!itens.ContainsKey(item.Id) && itens.Count >= CapacidadeSlots) return false;
            if (atual + quantidade > item.QuantidadeMaxima) return false;
            itens[item.Id] = atual + quantidade;
            return true;
        }

        public bool TentarRemover(string itemId, int quantidade = 1)
        {
            if (string.IsNullOrWhiteSpace(itemId) || quantidade < 1 || !itens.TryGetValue(itemId, out int atual) || atual < quantidade)
                return false;
            int restante = atual - quantidade;
            if (restante == 0) itens.Remove(itemId); else itens[itemId] = restante;
            return true;
        }
    }
}