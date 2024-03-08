using UnityEngine;

namespace ShootEmUp
{
    public class CharacterAttackAgent 
    {
        private WeaponComponent weapon;
        [Space]
        private BulletSystem bulletSystem;
        private BulletConfig bulletConfig;

        public CharacterAttackAgent(WeaponComponent _weaponComponent, BulletSystem _bulletSystem,
            BulletConfig _bulletConfig)
        {
            weapon = _weaponComponent;
            this.bulletSystem = _bulletSystem;
            this.bulletConfig = _bulletConfig;
        }
        
        public void Shoot()
        {
            bulletSystem.SpawnBullet(new BulletArgs
            {
                isPlayer = true,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = weapon.position,
                velocity = weapon.rotation * Vector3.up * bulletConfig.speed
            });
        }
    }
}

