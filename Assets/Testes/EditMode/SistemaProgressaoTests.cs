using LendasDoOriente.Progressao;
using NUnit.Framework;

namespace LendasDoOriente.Testes
{
    public sealed class SistemaProgressaoTests
    {
        [Test]
        public void ExperienciaSuficiente_AumentaNivelECarregaExcedente()
        {
            var progressao = new SistemaProgressao();
            progressao.AdicionarExperiencia(120);
            Assert.AreEqual(2, progressao.Nivel);
            Assert.AreEqual(20, progressao.ExperienciaAtual);
        }

        [Test]
        public void GrandeQuantidade_PodeSubirVariosNiveis()
        {
            var progressao = new SistemaProgressao();
            progressao.AdicionarExperiencia(260);
            Assert.AreEqual(3, progressao.Nivel);
            Assert.AreEqual(10, progressao.ExperienciaAtual);
        }
    }
}