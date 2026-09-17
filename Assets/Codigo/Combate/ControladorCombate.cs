using System;
using UnityEngine;

namespace LendasDoOriente.Combate
{
    public sealed class ControladorCombate : MonoBehaviour
    {
        [SerializeField, Min(0)] private int danoBase = 35;
        [SerializeField, Min(0.1f)] private float intervaloAtaque = 0.8f;
        private float proximoAtaque;

        public event Action<int> AtaqueExecutado;

        public bool TentarAtacar()
        {
            if (Time.time < proximoAtaque) return false;

            proximoAtaque = Time.time + intervaloAtaque;
            AtaqueExecutado?.Invoke(danoBase);
            return true;
        }
    }
}