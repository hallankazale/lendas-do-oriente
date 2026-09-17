using System;

namespace LendasDoOriente.Missoes
{
    public enum EstadoMissao { NaoIniciada, EmAndamento, Concluida }

    public sealed class Missao
    {
        public string Id { get; }
        public string Titulo { get; }
        public string Descricao { get; }
        public EstadoMissao Estado { get; private set; }

        public Missao(string id, string titulo, string descricao)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID obrigatório.", nameof(id));
            Id = id;
            Titulo = titulo ?? string.Empty;
            Descricao = descricao ?? string.Empty;
        }

        public bool Iniciar()
        {
            if (Estado != EstadoMissao.NaoIniciada) return false;
            Estado = EstadoMissao.EmAndamento;
            return true;
        }

        public bool Concluir()
        {
            if (Estado != EstadoMissao.EmAndamento) return false;
            Estado = EstadoMissao.Concluida;
            return true;
        }
    }
}