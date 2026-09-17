using System;

namespace LendasDoOriente.Core
{
    /// <summary>
    /// Mantém os atributos essenciais do personagem sem depender da interface ou da cena.
    /// Essa separação permite reutilizar a regra em combate, HUD, salvamento e testes.
    /// </summary>
    [Serializable]
    public sealed class EstadoPersonagem
    {
        public int Nivel { get; private set; } = 1;
        public int VidaMaxima { get; private set; } = 320;
        public int VidaAtual { get; private set; } = 320;
        public int ManaMaxima { get; private set; } = 120;
        public int ManaAtual { get; private set; } = 120;
        public int Experiencia { get; private set; }

        public bool EstaVivo => VidaAtual > 0;

        public void ReceberDano(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentOutOfRangeException(nameof(quantidade));

            VidaAtual = Math.Max(0, VidaAtual - quantidade);
        }

        public void RecuperarVida(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentOutOfRangeException(nameof(quantidade));

            VidaAtual = Math.Min(VidaMaxima, VidaAtual + quantidade);
        }

        public bool TentarConsumirMana(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentOutOfRangeException(nameof(quantidade));

            if (ManaAtual < quantidade)
                return false;

            ManaAtual -= quantidade;
            return true;
        }

        public void AdicionarExperiencia(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentOutOfRangeException(nameof(quantidade));

            Experiencia += quantidade;
        }
    }
}