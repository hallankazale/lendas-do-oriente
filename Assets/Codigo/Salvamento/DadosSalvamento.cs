using System;
using System.Collections.Generic;

namespace LendasDoOriente.Salvamento
{
    [Serializable]
    public sealed class DadosSalvamento
    {
        public int Versao = 1;
        public string IdPersonagem = string.Empty;
        public int Nivel = 1;
        public int Experiencia;
        public int VidaAtual = 320;
        public int ManaAtual = 120;
        public long MoedasImperiais;
        public string CenaAtual = "VilaDasCerejeiras";
        public float PosicaoX;
        public float PosicaoY;
        public float PosicaoZ;
        public List<string> MissoesConcluidas = new();
    }
}