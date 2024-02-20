using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyPool 
    {
        private int countEnemy = 7;
        private Transform container;
        private GameObject prefab;
        public readonly Queue<GameObject> enemyPool = new();
        private DiContainer diContainer;
        
        public EnemyPool(Transform _container, GameObject _prefab, DiContainer _diContainer)
        {
            container = _container;
            prefab = _prefab;
            diContainer = _diContainer;
            
            for (var i = 0; i < countEnemy; i++)
            {
                SpawnAndAddEnemyPool();
            }
        }

        
        public GameObject SpawnAndAddEnemyPool()
        {
            var _enemy = diContainer.InstantiatePrefab(this.prefab, this.container);
            this.enemyPool.Enqueue(_enemy);
            return _enemy;
        }

        public GameObject GetEnemy()
        {
            if (enemyPool.TryDequeue(out GameObject enemy))
                return enemy;
            
            return SpawnAndAddEnemyPool();
        }
        public void RemoveEnemy(GameObject _enemy)
        {
            _enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(_enemy);
        }
    }
}