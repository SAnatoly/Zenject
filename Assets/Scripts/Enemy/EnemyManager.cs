using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{

    public sealed class EnemyManager
    {
        private EnemySpawner enemySpawner;
        private EnemyPool enemyPool;
        private EnemyMoveController enemyMoveController;
        private EnemyAtackController enemyAtackController;
        private BulletSystem bulletSystem;
        private readonly HashSet<GameObject> activeEnemies = new();

        [Inject]
        public void Construct(EnemySpawner _enemySpawner, EnemyPool _enemyPool, BulletSystem _bulletSystem,
            EnemyMoveController _enemyMoveController, EnemyAtackController _enemyAtackController)
        {
            enemySpawner = _enemySpawner;
            enemyPool = _enemyPool;
            enemyMoveController = _enemyMoveController;
            enemyAtackController = _enemyAtackController;
            bulletSystem = _bulletSystem;
        }
        
        public void SpawnEnemy()
        {
            var _enemy = enemySpawner.SpawnEnemy();
            
            if (this.activeEnemies.Add(_enemy)) 
            { 
                _enemy.GetComponent<HitPointsComponent>().hpEmpty += this.Destroyed;
                enemyMoveController.AddAgents(_enemy.GetComponent<EnemyMoveAgent>());
                enemyAtackController.AddAgents(_enemy.GetComponent<EnemyAttackAgent>());
                _enemy.GetComponent<EnemyAttackAgent>().GetBulletSystem(bulletSystem);
            }
            
        }
        private void Destroyed(GameObject _enemy)
        {
            if (activeEnemies.Remove(_enemy))
            {
                _enemy.GetComponent<HitPointsComponent>().hpEmpty -= this.Destroyed;

                enemyPool.RemoveEnemy(_enemy);
                enemyMoveController.RemoveAgents(_enemy.GetComponent<EnemyMoveAgent>());
                enemyAtackController.RemoveAgents(_enemy.GetComponent<EnemyAttackAgent>());
            }
        }

    }
}