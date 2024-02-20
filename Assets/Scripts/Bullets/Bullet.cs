using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, 
        IGamePauseListener,
        IGamePlayingListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool isPlayer { get; set; }
        public int damage { get; set; }

        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private SpriteRenderer spriteRenderer;


        private Vector2 oldVelocity;
        private void OnCollisionEnter2D(Collision2D _collision)
        {
            this.OnCollisionEntered?.Invoke(this, _collision);
            
            if (!_collision.transform.TryGetComponent(out TeamComponent _team))
            {
                return;
            }

            if (isPlayer == _team.IsPlayer)
            {
                return;
            }

            if (_collision.transform.TryGetComponent(out HitPointsComponent _hitPoints))
            {
                _hitPoints.TakeDamage(damage);
            }
        }

        public void SetVelocity(Vector2 _velocity)
        {
            this.rigidbody2D.velocity = _velocity;
        }

        public void SetPhysicsLayer(int _physicsLayer)
        {
            this.gameObject.layer = _physicsLayer;
        }

        public void SetPosition(Vector3 _position)
        {
            this.transform.position = _position;
        }

        public void SetColor(Color _color)
        {
            this.spriteRenderer.color = _color;
        }

        public void OnPause()
        {
            oldVelocity = rigidbody2D.velocity;
            SetVelocity(Vector2.zero);
        }

        public void OnPlaying()
        {
            SetVelocity(oldVelocity);
        }
    }
}