using UnityEngine;

namespace LendasDoOriente.Jogador
{
    /// <summary>
    /// Controla apenas locomoção e rotação do personagem.
    /// Entrada mobile/teclado é fornecida externamente para manter o componente desacoplado.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public sealed class ControladorMovimentoJogador : MonoBehaviour
    {
        [SerializeField, Min(0.1f)] private float velocidadeCaminhada = 3.5f;
        [SerializeField, Min(0.1f)] private float velocidadeCorrida = 6f;
        [SerializeField, Min(1f)] private float velocidadeRotacao = 12f;
        [SerializeField] private float gravidade = -20f;

        private CharacterController controlador;
        private Vector2 entradaMovimento;
        private bool correndo;
        private float velocidadeVertical;

        private void Awake()
        {
            controlador = GetComponent<CharacterController>();
        }

        public void DefinirEntrada(Vector2 entrada)
        {
            entradaMovimento = Vector2.ClampMagnitude(entrada, 1f);
        }

        public void DefinirCorrida(bool ativa)
        {
            correndo = ativa;
        }

        private void Update()
        {
            Vector3 direcao = new Vector3(entradaMovimento.x, 0f, entradaMovimento.y);

            if (direcao.sqrMagnitude > 0.001f)
            {
                Quaternion alvo = Quaternion.LookRotation(direcao, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, alvo, velocidadeRotacao * Time.deltaTime);
            }

            float velocidade = correndo ? velocidadeCorrida : velocidadeCaminhada;

            if (controlador.isGrounded && velocidadeVertical < 0f)
                velocidadeVertical = -2f;

            velocidadeVertical += gravidade * Time.deltaTime;
            Vector3 deslocamento = direcao * velocidade;
            deslocamento.y = velocidadeVertical;

            controlador.Move(deslocamento * Time.deltaTime);
        }
    }
}