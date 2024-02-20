using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class EnemySpawner
    {
        private GameObject character;

        [Header("Spawn")]
        private EnemyPositions enemyPositions;
        private Transform worldTransform;
        private EnemyPool enemyPool;

        [Inject]
        public void Construct(GameObject _character, EnemyPositions _enemyPositions, Transform _worldTransform,
            EnemyPool _enemyPool)
        {
            character = _character;
            enemyPositions = _enemyPositions;
            worldTransform = _worldTransform;
            enemyPool = _enemyPool;
        }
        
        public GameObject SpawnEnemy()
        {
            var _enemy = enemyPool.GetEnemy();
            _enemy.transform.SetParent(this.worldTransform);

            var _spawnPosition = this.enemyPositions.RandomSpawnPosition();
            _enemy.transform.position = _spawnPosition.position;

            var _attackPosition = this.enemyPositions.RandomAttackPosition();
            _enemy.GetComponent<EnemyMoveAgent>().SetDestination(_attackPosition.position);

            _enemy.GetComponent<EnemyAttackAgent>().SetTarget(this.character);
            return _enemy;
        }
    }
}

