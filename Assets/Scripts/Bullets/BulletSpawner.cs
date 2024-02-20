using UnityEngine;

namespace ShootEmUp
{
    public class BulletSpawner 
    {
         private Transform worldTransform;
         private BulletPool bulletPool;
        
        public BulletSpawner(Transform _worldTransform, BulletPool _bulletPool)
        {
            this.worldTransform = _worldTransform;
            this.bulletPool = _bulletPool;

        }
        
        public Bullet SpawnBullet()
        {
            Bullet bullet = bulletPool.GetBullet();
            bullet.transform.SetParent(this.worldTransform);
            return bullet;
        } 
    }
}

