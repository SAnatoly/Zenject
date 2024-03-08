using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterMoveAgent : IGameUpdateListener
    {
        public float horizontalDirection { get;  set; }
        private MoveComponent moveComponent;

        public CharacterMoveAgent(MoveComponent _moveComponent)
        {
            moveComponent = _moveComponent;
        }
        
        public void OnUpdate(float _deltaTime)
        {
            moveComponent.Move(new Vector2(this.horizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}

