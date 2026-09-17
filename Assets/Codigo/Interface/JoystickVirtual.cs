using UnityEngine;
using UnityEngine.EventSystems;

namespace LendasDoOriente.Interface
{
    public sealed class JoystickVirtual : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform baseJoystick;
        [SerializeField] private RectTransform controle;
        [SerializeField, Min(1f)] private float raio = 90f;

        public Vector2 Direcao { get; private set; }

        public void OnPointerDown(PointerEventData evento) => Atualizar(evento);
        public void OnDrag(PointerEventData evento) => Atualizar(evento);

        public void OnPointerUp(PointerEventData evento)
        {
            Direcao = Vector2.zero;
            controle.anchoredPosition = Vector2.zero;
        }

        private void Atualizar(PointerEventData evento)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(baseJoystick, evento.position, evento.pressEventCamera, out Vector2 ponto))
                return;

            Direcao = Vector2.ClampMagnitude(ponto / raio, 1f);
            controle.anchoredPosition = Direcao * raio;
        }
    }
}