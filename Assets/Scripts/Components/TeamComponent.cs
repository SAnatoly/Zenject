using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public bool IsPlayer => this.isPlayer;
        [SerializeField]
        private bool isPlayer;
    }
}