using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> hpEmpty;
        [SerializeField] private int hitPoints;
        public bool IsHitPointsExists() => hitPoints > 0;

        public void TakeDamage(int _damage)
        {
            this.hitPoints -= _damage;
            if (this.hitPoints <= 0)
            {
                this.hpEmpty?.Invoke(this.gameObject);
            }
        }
    }
}