using UnityEngine;

namespace LendasDoOriente.Camera
{
    public sealed class CameraTerceiraPessoa : MonoBehaviour
    {
        [SerializeField] private Transform alvo;
        [SerializeField] private Vector3 deslocamento = new Vector3(0f, 2.2f, -4.5f);
        [SerializeField, Min(0.1f)] private float suavidade = 10f;
        [SerializeField, Min(0.1f)] private float sensibilidade = 120f;
        [SerializeField] private float anguloMinimo = -20f;
        [SerializeField] private float anguloMaximo = 65f;

        private Vector2 entradaCamera;
        private float rotacaoHorizontal;
        private float rotacaoVertical = 15f;

        public void DefinirAlvo(Transform novoAlvo) => alvo = novoAlvo;
        public void DefinirEntrada(Vector2 entrada) => entradaCamera = entrada;

        private void LateUpdate()
        {
            if (alvo == null) return;

            rotacaoHorizontal += entradaCamera.x * sensibilidade * Time.deltaTime;
            rotacaoVertical -= entradaCamera.y * sensibilidade * Time.deltaTime;
            rotacaoVertical = Mathf.Clamp(rotacaoVertical, anguloMinimo, anguloMaximo);

            Quaternion rotacao = Quaternion.Euler(rotacaoVertical, rotacaoHorizontal, 0f);
            Vector3 posicaoDesejada = alvo.position + rotacao * deslocamento;
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, suavidade * Time.deltaTime);
            transform.LookAt(alvo.position + Vector3.up * 1.4f);
        }
    }
}