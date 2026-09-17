using System;

namespace LendasDoOriente.Progressao
{
    public sealed class SistemaProgressao
    {
        public int Nivel { get; private set; } = 1;
        public int ExperienciaAtual { get; private set; }
        public int ExperienciaParaProximoNivel => CalcularExperienciaNecessaria(Nivel);

        public event Action<int> NivelAumentou;

        public void AdicionarExperiencia(int quantidade)
        {
            if (quantidade < 0) throw new ArgumentOutOfRangeException(nameof(quantidade));
            ExperienciaAtual += quantidade;
            while (ExperienciaAtual >= ExperienciaParaProximoNivel)
            {
                ExperienciaAtual -= ExperienciaParaProximoNivel;
                Nivel++;
                NivelAumentou?.Invoke(Nivel);
            }
        }

        private static int CalcularExperienciaNecessaria(int nivel)
            => 100 + ((nivel - 1) * 50);
    }
}