using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField]
        private Transform[] spawnPositions;

        [SerializeField]
        private Transform[] attackPositions;

        public Transform RandomSpawnPosition()
        {
            return this.RandomTransform(this.spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return this.RandomTransform(this.attackPositions);
        }

        private Transform RandomTransform(Transform[] _transforms)
        {
            var index = Random.Range(0, _transforms.Length);
            return _transforms[index];
        }
    }
}