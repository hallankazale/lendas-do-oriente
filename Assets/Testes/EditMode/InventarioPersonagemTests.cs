using LendasDoOriente.Inventario;
using NUnit.Framework;

namespace LendasDoOriente.Testes
{
    public sealed class InventarioPersonagemTests
    {
        [Test]
        public void ItemEmpilhavel_RespeitaQuantidadeMaxima()
        {
            var inventario = new InventarioPersonagem();
            var pocao = new Item("pocao_vida_p", "Poção Pequena de Vida", TipoItem.Consumivel, 20);
            Assert.IsTrue(inventario.TentarAdicionar(pocao, 20));
            Assert.IsFalse(inventario.TentarAdicionar(pocao, 1));
        }

        [Test]
        public void InventarioCheio_RecusaNovoTipoDeItem()
        {
            var inventario = new InventarioPersonagem(1);
            var espada = new Item("espada_01", "Lâmina do Aprendiz", TipoItem.Arma);
            var armadura = new Item("armadura_01", "Traje do Novato", TipoItem.Armadura);
            Assert.IsTrue(inventario.TentarAdicionar(espada));
            Assert.IsFalse(inventario.TentarAdicionar(armadura));
        }
    }
}