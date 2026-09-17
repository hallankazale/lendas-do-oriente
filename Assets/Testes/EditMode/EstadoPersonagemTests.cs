using LendasDoOriente.Core;
using NUnit.Framework;

namespace LendasDoOriente.Testes
{
    public sealed class EstadoPersonagemTests
    {
        [Test]
        public void ReceberDano_NaoPermiteVidaNegativa()
        {
            var personagem = new EstadoPersonagem();

            personagem.ReceberDano(9999);

            Assert.AreEqual(0, personagem.VidaAtual);
            Assert.IsFalse(personagem.EstaVivo);
        }

        [Test]
        public void RecuperarVida_NaoUltrapassaVidaMaxima()
        {
            var personagem = new EstadoPersonagem();
            personagem.ReceberDano(100);

            personagem.RecuperarVida(9999);

            Assert.AreEqual(personagem.VidaMaxima, personagem.VidaAtual);
        }

        [Test]
        public void TentarConsumirMana_SemManaSuficiente_NaoAlteraEstado()
        {
            var personagem = new EstadoPersonagem();

            bool resultado = personagem.TentarConsumirMana(9999);

            Assert.IsFalse(resultado);
            Assert.AreEqual(personagem.ManaMaxima, personagem.ManaAtual);
        }
    }
}