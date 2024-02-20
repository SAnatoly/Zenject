using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Zenject.ReflectionBaking.Mono.CompilerServices.SymbolWriter;

namespace ShootEmUp
{
    public class BulletPool
    {

        
        private int initialCount = 50;

        private Transform container;
        public Bullet prefab;
        public GameManager gameManager;
        public LevelBounds levelBounds;

        private readonly Queue<Bullet> bulletPool = new();
        private DiContainer diContainer;

        private BulletPool(Bullet _bullet, Transform _container, GameManager _gameManager, LevelBounds _levelBounds, DiContainer _diContainer)
        {

            prefab = _bullet;
            container = _container;
            gameManager = _gameManager;
            levelBounds = _levelBounds;
            diContainer = _diContainer;
            
            for (var i = 0; i < this.initialCount; i++)
            {
               SpawnBullet();
            }
        }

      

        private Bullet SpawnBullet()
        {
            var _bullet =   diContainer.InstantiatePrefab(this.prefab, this.container);
            Bullet bullet = _bullet.GetComponent<Bullet>();
            this.bulletPool.Enqueue(bullet);
            gameManager.AddListener(bullet);
            return bullet;
        }
        
        public Bullet GetBullet()
        {
            if (bulletPool.TryDequeue(out Bullet bullet))
                return bullet;
            
            return SpawnBullet();
        }
        
        public void RemoveBullet(Bullet _bullet)
        {
            _bullet.transform.SetParent(this.container);
            this.bulletPool.Enqueue(_bullet);
            gameManager.RemoveListener(_bullet);
        }
    }
}

