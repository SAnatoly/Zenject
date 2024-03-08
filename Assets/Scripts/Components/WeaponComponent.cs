using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public Vector2 position => this.firePoint.position;
        public Quaternion rotation => this.firePoint.rotation;
        [SerializeField]
        private Transform firePoint;
    }
}