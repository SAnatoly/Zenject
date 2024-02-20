using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{

    public sealed class EnemyManager
    {
        
        private EnemySpawner enemySpawner;
        private EnemyPool enemyPool;
        private GameManager manager;
        private BulletSystem bulletSystem;
        
        private readonly HashSet<GameObject> activeEnemies = new();

        [Inject]
        public void Construct(EnemySpawner _enemySpawner, EnemyPool _enemyPool, GameManager _gameManager,
            BulletSystem _bulletSystem)
        {
            enemySpawner = _enemySpawner;
            enemyPool = _enemyPool;
            manager = _gameManager;
            bulletSystem = _bulletSystem;
        }
        
        public void SpawnEnemy()
        {
            var _enemy = enemySpawner.SpawnEnemy();
            
            if (this.activeEnemies.Add(_enemy)) 
            { 
                _enemy.GetComponent<HitPointsComponent>().hpEmpty += this.Destroyed;
                manager.AddListener(_enemy.GetComponent<EnemyMoveAgent>());
                manager.AddListener(_enemy.GetComponent<EnemyAttackAgent>());
                _enemy.GetComponent<EnemyAttackAgent>().GetBulletSystem(bulletSystem);
            }
            
        }
        private void Destroyed(GameObject _enemy)
        {
            if (activeEnemies.Remove(_enemy))
            {
                _enemy.GetComponent<HitPointsComponent>().hpEmpty -= this.Destroyed;

                enemyPool.RemoveEnemy(_enemy);
                manager.RemoveListener(_enemy.GetComponent<EnemyMoveAgent>());
                manager.RemoveListener(_enemy.GetComponent<EnemyAttackAgent>());
            }
        }

    }
}