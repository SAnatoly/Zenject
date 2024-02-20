using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour, 
        IGameStartListener,
        IGamePauseListener, 
        IGamePlayingListener, 
        IGameFinishListener, 
        IGameFixedUpdateListener
    {
      
        public bool IsReached
        {
            get { return this.isReached; }
        }

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 destination;

        private bool isReached;

        public void SetDestination(Vector2 _endPoint)
        {
            this.destination = _endPoint;
            this.isReached = false;
            Debug.Log("Destination");
        }

        public void OnStart()
        {
           // enabled = true;
        }
    
        public void OnPause()
        {
            //enabled = false;
        }

        public void OnPlaying()
        {
           // enabled = true;
        }

        public void OnFinish()
        {
           // enabled = false;
        }

        public void OnFixedUpdate(float _deltaTime)
        {
            
            if (this.isReached)
            {
                return;
            }

           
            var vector = this.destination - (Vector2)this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this.isReached = true;
                return;
            }
           
            var direction = vector.normalized * Time.fixedDeltaTime;
            this.moveComponent.Move(direction);
        }
    }
}