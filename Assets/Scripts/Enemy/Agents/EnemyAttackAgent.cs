using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour,
        IGameFixedUpdateListener
    {
       

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [Inject] private BulletSystem bulletSystem;
        
        [SerializeField] private BulletConfig config;
        
        [SerializeField] private float countdown;

        private GameObject target;
        private float currentTime;

        
        
        public void SetTarget(GameObject _target)
        {
            this.target = _target;
        }

        public void Reset()
        {
            this.currentTime = this.countdown;
        }

        private void Fire()
        {
            var startPosition = this.weaponComponent.position;
            var vector = (Vector2) this.target.transform.position - startPosition;
            var direction = vector.normalized;
            
            
            bulletSystem.SpawnBullet(new BulletArgs
            {
                isPlayer = false,
                physicsLayer = (int) config.physicsLayer,
                color = config.color,
                damage = config.damage,
                position = startPosition,
                velocity = direction * config.speed
            });
        }

        public void OnFixedUpdate(float _deltaTime)
        {
            if (!this.moveAgent.IsReached)
            {
                return;
            }

            if (!this.target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                this.Fire();
                this.currentTime += this.countdown;
            }
        }

        public void GetBulletSystem(BulletSystem _bulletSystem) => bulletSystem = _bulletSystem;
    }
}